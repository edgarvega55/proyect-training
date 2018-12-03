using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Servicios
{
    interface IEvents
    {
        void createEvents();
    }

    class Events : IEvents
    {
        public void createEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            Console.WriteLine("");
            Console.WriteLine("**** Events ****");
            for (int i = 1; i <= 5; i++)
            {
                Event newEvent = eventRepository.addEvent(i, i+1);
                Console.WriteLine("Event ID: {0}", newEvent.EventID);
                Console.WriteLine("Event Organization ID: {0}", newEvent.OrganizationID);
            }
        }
    }
}
