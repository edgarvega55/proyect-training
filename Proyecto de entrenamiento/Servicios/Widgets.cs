using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IWidgets
    {
        void CreateWidgets(P2PContainer ContainerID);
    }

    public class Widgets : IWidgets
    {
        public void CreateWidgets(P2PContainer Container)
        {
            IWidgetRepository widgetRepository = new WidgetRepository();
            List<P2PWidget> widgets = new List<P2PWidget>();

            for (int i = 1; i <= 5; i++)
            {
                P2PWidget widget = widgetRepository.AddWidget(i, Container.ContainerID);
                widgets.Add(widget);
                List<P2PWidgetContent> widgetContentList =  widgetRepository.AddWidgetContent(i);

                foreach (P2PWidgetContent widgetContent in widgetContentList)
                {
                    Console.WriteLine("Widget Content ID: {0}", widgetContent.WidgetID);
                    Console.WriteLine("Widget Content LenguageCode: {0}", widgetContent.LenguageCode);
                }
            }
            Container.widgets = widgets;
        }
    }
}
