using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;
using Proyecto_de_entrenamiento.Enums;

namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IEvents
    {
        List<Event> createEvents();
        EventContainer FindEvent(List<Event> events, List<P2PContainer> containers, int eventId, int pageType);
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

        public EventContainer FindEvent (List<Event> events, List<P2PContainer> containers, int eventId, int pageType)
        {
            EventContainer eventContainer;

            foreach (Event entityEvent in events)
            {
                if (entityEvent.EventID == eventId)
                {
                    IContainer servicioContainer = new Container();
                    P2PContainer container = servicioContainer.FindContainer(containers, entityEvent.ContainerID);
                    if (container.P2PPageTypeID == AssignAPageType(pageType))
                    {
                        eventContainer = addEventContainer(entityEvent.EventID, entityEvent.Description, container);
                        return eventContainer;
                    } else
                    {
                        return null;
                    }
                    
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

        private string AssignAPageType(int ContainerID)
        {
            string P2PPageTypeID = "";

            if (ContainerID == 1 || ContainerID == 3)
            {
                P2PPageTypeID = pageType.Event.ToString();
            }
            else if (ContainerID == 2 || ContainerID == 4)
            {
                P2PPageTypeID = pageType.Donation.ToString();
            }
            else if (ContainerID == 5)
            {
                P2PPageTypeID = pageType.DonationThankYou.ToString();
            }

            return P2PPageTypeID;
        }
    }
}
