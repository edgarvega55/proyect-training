using System;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IEventRepository
    {
        Event addEvent(int EventID, int OrganizationID, List<P2PContainer> Containers);
    }

    class EventRepository : IEventRepository
    {
        public EventRepository()
        {

        }

        public Event addEvent(int EventID, int OrganizationID, List<P2PContainer> Containers)
        {
            Event newEvent = new Event
            {
                EventID = EventID,
                OrganizationID = OrganizationID,
                Description = "Event " + EventID,
                Containers = Containers
            };

            return newEvent;
        }
    }
}