using System;
using Proyecto_de_entrenamiento.Servicios;
namespace Proyecto_de_entrenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            IContainer container = new Container();
            IEvents events = new Events();

            container.createContainers();
            events.createEvents();
            Console.ReadLine();
        }
    }
}
