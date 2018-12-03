using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;

namespace Proyecto_de_entrenamiento.Servicios
{
    interface IWidgets
    {
        void createWidgets();
    }

    class Widgets : IWidgets
    {
        public void createWidgets()
        {
            IWidgetRepository widgetRepository = new WidgetRepository();
            Console.WriteLine("");
            Console.WriteLine("**** Widgets ****");
            for (int i = 1; i <= 15; i++)
            {
                P2PWidget widget = widgetRepository.AddWidget(i);

                Console.WriteLine("");
                Console.WriteLine("Widget ID: {0}", widget.WidgetID);
                Console.WriteLine("Widget Properties: {0}", widget.Properties);

                List<P2PWidgetContent> widgetContentList =  widgetRepository.AddWidgetContent(i);

                foreach (P2PWidgetContent widgetContent in widgetContentList)
                {
                    Console.WriteLine("Widget Content ID: {0}", widgetContent.WidgetID);
                    Console.WriteLine("Widget Content LenguageCode: {0}", widgetContent.LenguageCode);
                }
            }
        }
    }
}
