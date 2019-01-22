using System;
using Proyecto_de_entrenamiento.Enums;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IContainerRepository
    {
        List<P2PContainer> ContainersByEvent(int EventID, int PageType);
        List<P2PContainer> AllContainers();
    }

    public class ContainerRepository : IContainerRepository
    {
        private SqlConnection conn;

        public ContainerRepository()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<P2PContainer> ContainersByEvent(int EventID, int PageType)
        {
            List<P2PContainer> containers = new List<P2PContainer>();
            
            conn.Open();

            string sql = "EXECUTE ContainerByEvent;";
            string P2PPageType = AssignAPageTypeInt(PageType);
            SqlCommand command = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "ContainerByEvent"
            };
            command.Parameters.Add("@EvenID", SqlDbType.Int);
            command.Parameters["@EvenID"].Value = EventID;
            command.Parameters.Add("@PageType", SqlDbType.VarChar);
            command.Parameters["@PageType"].Value = P2PPageType;

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                P2PContainer container;
                int SortOrder = 0;
                int ColumnOrder = 0;
                int ContainerID = int.Parse(dataReader.GetValue(1).ToString());
                int eventId = int.Parse(dataReader.GetValue(0).ToString());
                string P2PPageTypeID = dataReader.GetValue(2).ToString();
                string Properties = dataReader.GetValue(3).ToString();
                bool IsHero = ParseBoolean(dataReader.GetValue(4).ToString());
                bool IsHeroLocked = ParseBoolean(dataReader.GetValue(5).ToString());

                if (!dataReader.IsDBNull(6))
                    SortOrder = int.Parse(dataReader.GetValue(6).ToString());

                if (!dataReader.IsDBNull(7))
                    ColumnOrder = int.Parse(dataReader.GetValue(7).ToString());
                
                container = AddContainer(ContainerID, 
                                        eventId, 
                                        P2PPageTypeID, 
                                        Properties, 
                                        IsHero, 
                                        IsHeroLocked, 
                                        SortOrder, 
                                        ColumnOrder, 
                                        true);
                containers.Add(container);
            }

            conn.Close();
            return containers;
        }

        public List<P2PContainer> AllContainers()
        {
            conn.Open();
            List<P2PContainer> containers = new List<P2PContainer>();
            
            string sql = "EXECUTE AllContainers;";
            SqlCommand command = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AllContainers"
            };

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                P2PContainer container;
                int SortOrder = 0;
                int ColumnOrder = 0;
                int ContainerID = int.Parse(dataReader.GetValue(0).ToString());
                int EventId = int.Parse(dataReader.GetValue(1).ToString());
                string P2PPageTypeID = dataReader.GetValue(2).ToString();
                string Properties = dataReader.GetValue(3).ToString();
                bool IsHero = ParseBoolean(dataReader.GetValue(4).ToString());
                bool IsHeroLocked = ParseBoolean(dataReader.GetValue(5).ToString());

                if (!dataReader.IsDBNull(6))
                    SortOrder = int.Parse(dataReader.GetValue(6).ToString());

                if (!dataReader.IsDBNull(7))
                    ColumnOrder = int.Parse(dataReader.GetValue(7).ToString());

                container = AddContainer(ContainerID, EventId, P2PPageTypeID, Properties, IsHero, IsHeroLocked, SortOrder, ColumnOrder, false);
                containers.Add(container);
            }

            return containers;
        }

        public P2PContainer AddContainer(int ContainerID, int EventID, string P2PPageTypeID, string Properties, bool IsHero, bool IsHeroLocked, int SortOrder, int ColumnOrder, bool widget)
        {
            P2PContainer container = new P2PContainer
            {
                ContainerID = ContainerID,
                EventID = EventID,
                P2PPageTypeID = P2PPageTypeID,
                Properties = Properties,
                IsHero = IsHero,
                IsHeroLocked = IsHeroLocked,
                SortOrder = SortOrder,
                ColumnOrder = ColumnOrder
            };

            if (widget)
            {
                IWidgets widgets = new Widgets();
                container.widgets = widgets.WidgetsByContainer(ContainerID);
            }

            return container;
        }

        public P2PContainerContent AddContainerContent(int ContainerID)
        {
            P2PContainerContent containerContent = new P2PContainerContent
            {
                ContainerID = ContainerID,
                LenguageCode = "en-CA",
                Content = "{..}"
            };

            return containerContent;
        }

        private string AssignAPageType (int ContainerID)
        {
            string P2PPageTypeID = "";

            if (ContainerID == 1 || ContainerID == 3)
            {
                P2PPageTypeID = pageType.Event.ToString();
            }
            else if (ContainerID == 2 || ContainerID == 4)
            {
                P2PPageTypeID = pageType.Donation.ToString();
            }
            else if (ContainerID == 5)
            {
                P2PPageTypeID = pageType.DonationThankYou.ToString();
            }

            return P2PPageTypeID;
        }

        private bool ParseBoolean(string option)
        {
            if (option == "y")
                return true;
            else
                return false;
        }

        private string AssignAPageTypeInt(int PageType)
        {
            string P2PPageTypeID = "";

            if (PageType == 1)
            {
                P2PPageTypeID = "Event";
            }
            else if (PageType == 2)
            {
                P2PPageTypeID = "Donation";
            }
            else if (PageType == 3)
            {
                P2PPageTypeID = "DonationThankYou";
            }

            return P2PPageTypeID;
        }
    }
}