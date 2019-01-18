using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IWidgets
    {
        List<P2PWidget> WidgetsByContainer(int ContainerID);
        List<P2PWidget> AllWidgets();
    }

    public class Widgets : IWidgets
    {
        private SqlConnection conn;

        public Widgets()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<P2PWidget> WidgetsByContainer(int ContainerID)
        {
            conn.Open();
            List<P2PWidget> widgets = new List<P2PWidget>();
            IWidgetRepository widgetRepository;

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

                widgetRepository = new WidgetRepository();
                widget = widgetRepository.AddWidget(WidgetID, ContainerID, Locked, Properties, SortOrder, P2PWidgetTypeID, IsRequired, IsVisible, VisibilityConditionTypeID);
                widgets.Add(widget);
            }

            conn.Close();
            return widgets;
        }

        public List<P2PWidget> AllWidgets()
        {
            conn.Open();
            List<P2PWidget> widgets = new List<P2PWidget>();
            IWidgetRepository widgetRepository;

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

                widgetRepository = new WidgetRepository();
                widget = widgetRepository.AddWidget(WidgetID, ContainerID, Locked, Properties, SortOrder, P2PWidgetTypeID, IsRequired, IsVisible, VisibilityConditionTypeID);
                widgets.Add(widget);
            }

            conn.Close();
            return widgets;
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
