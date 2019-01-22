using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
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
        IWidgetRepository _widgetRepository;

        public Widgets()
        {
            _widgetRepository = new WidgetRepository();
        }

        public Widgets(IWidgetRepository widgetRepository)
        {
            _widgetRepository = widgetRepository;
        }

        public List<P2PWidget> WidgetsByContainer(int ContainerID)
        {
            List<P2PWidget> widgets = _widgetRepository.WidgetsByContainer(ContainerID);
            return widgets;
        }

        public List<P2PWidget> AllWidgets()
        {
            List<P2PWidget> widgets = _widgetRepository.AllWidgets();
            return widgets;
        }

       
    }
}
