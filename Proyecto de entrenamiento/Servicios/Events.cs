using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IEvents
    {
        List<Event> createEvents();
        EventContainer FindEvent(List<Event> events, List<P2PContainer> containers, int eventId);
    }

    public class Events : IEvents
    {
        public List<Event> createEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            List<Event> events = new List<Event>();
            int countToContainerID = 5;

            for (int i = 1; i <= 5; i++)
            {
                Event newEvent = eventRepository.addEvent(i, i+1, countToContainerID);
                countToContainerID--;
                events.Add(newEvent);
            }
            return events;
        }

        public EventContainer FindEvent (List<Event> events, List<P2PContainer> containers, int eventId)
        {
            EventContainer eventContainer;

            foreach (Event entityEvent in events)
            {
                if (entityEvent.EventID == eventId)
                {
                    IContainer servicioContainer = new Container();
                    P2PContainer container = servicioContainer.FindContainer(containers, entityEvent.ContainerID);
                    eventContainer = addEventContainer(entityEvent.EventID, entityEvent.Description, container);
                    return eventContainer;
                }
            }

            return null;
        }

        public EventContainer addEventContainer(int EventID, string Description, P2PContainer Container)
        {
            EventContainer eventContainer = new EventContainer
            {
                EventID = EventID,
                Description = "Event " + EventID,
                Container = Container
            };

            return eventContainer;
        }
    }
}
