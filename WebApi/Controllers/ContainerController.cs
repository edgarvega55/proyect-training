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
    public class ContainerController : ApiController
    {
        private IContainer container;
        private IEvents events;
        private List<Event> eventList;
        private List<P2PContainer> containerList;

        public ContainerController()
        {
            events = new Events();
            container = new Container();
            eventList = new List<Event>();
            containerList = new List<P2PContainer>();

            containerList = container.createContainers();
            eventList = events.createEvents();
        }

        [Route("event/{eventID}/page/{pageType}")]
        public IHttpActionResult getEvents(int eventID, int pageType)
        {
            EventContainer eventContainer = events.FindEvent(eventList, containerList, eventID, pageType);
            return Ok(eventContainer);
        }

        // GET: api/Container
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Container/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Container
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Container/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Container/5
        public void Delete(int id)
        {
        }
    }
}
