using System;
using Proyecto_de_entrenamiento.Servicios;
namespace Proyecto_de_entrenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IWidgets widgets = new Widgets();
            IContainer container = new Container();
            IEvents events = new Events();

            widgets.createWidgets();
            container.createContainers();
            events.createEvents();
            Console.ReadLine();
        }
    }
}
