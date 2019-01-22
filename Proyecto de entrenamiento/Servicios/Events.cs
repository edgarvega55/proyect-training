using System;
using Proyecto_de_entrenamiento.Repositorios;
using Proyecto_de_entrenamiento.Modelos;
using System.Collections.Generic;


namespace Proyecto_de_entrenamiento.Servicios
{
    public interface IEvents
    {
        List<Event> AllEvents();
        Event FindEvent(int eventId, int PageType);
    }

    public class Events : IEvents
    {
        
        public Events()
        {
            
        }

        public List<Event> AllEvents()
        {
            IEventRepository eventRepository = new EventRepository();
            List<Event> events = eventRepository.AllEvents();
            return events;
        }

        public Event FindEvent (int EventID, int PageType)
        {
            IEventRepository eventRepository = new EventRepository();
            Event newEvent = eventRepository.FindEvent(EventID, PageType);
            return newEvent;
        }

    }
}