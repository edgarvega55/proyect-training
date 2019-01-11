using System;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IEventRepository
    {
        Event addEvent(int EventID, int OrganizationID, int ContainerID);
    }

    class EventRepository : IEventRepository
    {
        public EventRepository()
        {

        }

        public Event addEvent(int EventID, int OrganizationID, int ContainerID)
        {
            Event newEvent = new Event
            {
                EventID = EventID,
                OrganizationID = OrganizationID,
                Description = "Event " + EventID,
                ContainerID = ContainerID
            };

            return newEvent;
        }
    }
}