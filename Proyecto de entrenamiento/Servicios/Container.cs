using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Proyecto_de_entrenamiento.Enums;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IContainer
    {
        List<P2PContainer> ContainersByEvent(int EventID, int PageType);
        List<P2PContainer> AllContainers();
    }

    public class Container : IContainer
    {
        private SqlConnection conn;

        public Container()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<P2PContainer> ContainersByEvent(int EventID, int PageType)
        {
            conn.Open();
            List<P2PContainer> containers = new List<P2PContainer>();
            IContainerRepository containerRepository;

            string sql = "EXECUTE ContainerByEvent;";
            string P2PPageType = AssignAPageType(PageType);
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
                
                containerRepository = new ContainerRepository();
                container = containerRepository.AddContainer(ContainerID, eventId, P2PPageTypeID, Properties, IsHero, IsHeroLocked, SortOrder, ColumnOrder, true);
                containers.Add(container);
            }

            conn.Close();
            return containers;
        }

        public List<P2PContainer> AllContainers()
        {
            conn.Open();
            List<P2PContainer> containers = new List<P2PContainer>();
            IContainerRepository containerRepository;

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

                containerRepository = new ContainerRepository();
                container = containerRepository.AddContainer(ContainerID, EventId, P2PPageTypeID, Properties, IsHero, IsHeroLocked, SortOrder, ColumnOrder, false);
                containers.Add(container);
            }

            return containers;
        }

        private bool ParseBoolean(string option)
        {
            if (option == "y")
                return true;
            else
                return false;
        }

        private string AssignAPageType(int PageType)
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
