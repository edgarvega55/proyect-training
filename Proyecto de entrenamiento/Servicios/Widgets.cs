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
        IWidgetRepository widgetRepository;

        public Widgets()
        {
            string settings = ConfigurationManager.ConnectionStrings["dbconnectionTraining"].ConnectionString;
            conn = new SqlConnection(settings);
        }

        public List<P2PWidget> WidgetsByContainer(int ContainerID)
        {
            widgetRepository = new WidgetRepository();
            List<P2PWidget> widgets = widgetRepository.WidgetsByContainer(ContainerID);
            return widgets;
        }

        public List<P2PWidget> AllWidgets()
        {
            widgetRepository = new WidgetRepository();
            List<P2PWidget> widgets = widgetRepository.AllWidgets();
            return widgets;
        }

       
    }
}
