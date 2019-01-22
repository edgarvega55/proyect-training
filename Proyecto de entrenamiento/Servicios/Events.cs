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
        IEventRepository _eventRepository;

        public Events()
        {
            _eventRepository = new EventRepository();
        }

        public Events(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> AllEvents()
        {
            List<Event> events = _eventRepository.AllEvents();
            return events;
        }

        public Event FindEvent (int EventID, int PageType)
        {
            Event newEvent = _eventRepository.FindEvent(EventID, PageType);
            return newEvent;
        }

    }
}