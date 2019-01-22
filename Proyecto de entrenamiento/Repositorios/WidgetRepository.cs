using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_de_entrenamiento.Repositorios
{
    public interface IWidgetRepository
    {
        List<P2PWidget> WidgetsByContainer(int ContainerID);
        List<P2PWidget> AllWidgets();
    }

    public class WidgetRepository : IWidgetRepository
    {
        private SqlConnection conn;

       
        public List<P2PWidget> WidgetsByContainer(int ContainerID)
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);

            List<P2PWidget> widgets = new List<P2PWidget>();
            
            conn.Open();

            string sql = "EXECUTE WidgetByContainer;";
            SqlCommand command = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "WidgetByContainer"
            };
            command.Parameters.Add("@ContainerID", SqlDbType.Int);
            command.Parameters["@ContainerID"].Value = ContainerID;

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                P2PWidget widget;

                int WidgetID = int.Parse(dataReader.GetValue(0).ToString());
                int SortOrder = int.Parse(dataReader.GetValue(3).ToString());
                string Locked = dataReader.GetValue(1).ToString();
                string Properties = dataReader.GetValue(2).ToString();
                string P2PWidgetTypeID = dataReader.GetValue(5).ToString();
                string IsVisible = dataReader.GetValue(7).ToString();
                string VisibilityConditionTypeID = dataReader.GetValue(8).ToString();
                bool IsRequired = ParseBoolean(dataReader.GetValue(6).ToString());
                widget = AddWidget(WidgetID, 
                                    ContainerID, 
                                    Locked, 
                                    Properties, 
                                    SortOrder, 
                                    P2PWidgetTypeID, 
                                    IsRequired, 
                                    IsVisible, 
                                    VisibilityConditionTypeID);
                widgets.Add(widget);
            }

            conn.Close();
            return widgets;
        }

        public List<P2PWidget> AllWidgets()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
            List<P2PWidget> widgets = new List<P2PWidget>();

            conn.Open();

            string sql = "EXECUTE AllWidgets;";
            SqlCommand command = new SqlCommand(sql, conn)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AllWidgets"
            };
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                P2PWidget widget;

                int WidgetID = int.Parse(dataReader.GetValue(0).ToString());
                int ContainerID = int.Parse(dataReader.GetValue(9).ToString());
                int SortOrder = int.Parse(dataReader.GetValue(3).ToString());
                string Locked = dataReader.GetValue(1).ToString();
                string Properties = dataReader.GetValue(2).ToString();
                string P2PWidgetTypeID = dataReader.GetValue(5).ToString();
                string IsVisible = dataReader.GetValue(7).ToString();
                string VisibilityConditionTypeID = dataReader.GetValue(8).ToString();
                bool IsRequired = ParseBoolean(dataReader.GetValue(6).ToString());

                widget = AddWidget(WidgetID, 
                                    ContainerID, 
                                    Locked, 
                                    Properties, 
                                    SortOrder, 
                                    P2PWidgetTypeID, 
                                    IsRequired, 
                                    IsVisible, 
                                    VisibilityConditionTypeID);
                widgets.Add(widget);
            }

            conn.Close();
            return widgets;
        }

        public P2PWidget AddWidget(int WidgetID, int ContainerID, string Locked, string Properties, int SortOrder, string P2PWidgetTypeID, bool IsRequired, string IsVisible, string VisibilityConditionTypeID)
        {
            P2PWidget widget = new P2PWidget
            {
                WidgetID = WidgetID,
                ContainerID = ContainerID,
                Locked = Locked,
                Properties = Properties,
                SortOrder = SortOrder,
                P2PWidgetTypeID = P2PWidgetTypeID,
                IsRequired = IsRequired,
                IsVisible = IsVisible,
                VisibilityConditionTypeID = VisibilityConditionTypeID
            };

            return widget;
        }

        public List<P2PWidgetContent> AddWidgetContent(int WidgetID)
        {
            List<P2PWidgetContent> WidgetContentList = new List<P2PWidgetContent>();

            P2PWidgetContent widgetContentEn = new P2PWidgetContent
            {
                WidgetID = WidgetID,
                LenguageCode = "en-CA",
                Content = "{..}"
            };

            P2PWidgetContent widgetContentFR = new P2PWidgetContent
            {
                WidgetID = WidgetID,
                LenguageCode = "fr-CA",
                Content = "{..}"
            };

            WidgetContentList.Add(widgetContentEn);
            WidgetContentList.Add(widgetContentFR);

            return WidgetContentList;
        }

        private bool ParseBoolean(string option)
        {
            if (option == "y")
                return true;
            else
                return false;
        }
    }
}