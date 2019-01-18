using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto_de_entrenamiento.Modelos;
using Proyecto_de_entrenamiento.Servicios;

namespace WebApi.Controllers
{
    public class EventController : ApiController
    {
        private IEvents events;

        public EventController()
        {
            events = new Events();
        }

        [Route("events")]
        public IHttpActionResult GetAllEvents()
        {
            List<Event> eventsList = events.AllEvents();
            return Ok(eventsList);
        }

        [Route("event/{eventID}/page/{pageType}")]
        public IHttpActionResult getEvents(int eventID, int pageType)
        {
            Event eventFound = events.FindEvent(eventID);
            return Ok(eventFound);
        }

        // GET: api/Event/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
