using System;
using Proyecto_de_entrenamiento.Modelos;

namespace Proyecto_de_entrenamiento.Repositorios
{
    interface IEventRepository
    {
        Event addEvent(int EventID, int OrganizationID);
    }

    class EventRepository : IEventRepository
    {
        public EventRepository()
        {

        }

        public Event addEvent(int EventID, int OrganizationID)
        {
            Event newEvent = new Event
            {
                EventID = EventID,
                OrganizationID = OrganizationID
            };

            return newEvent;
        }
    }
}