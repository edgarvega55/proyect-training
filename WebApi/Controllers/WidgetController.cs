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
    public class WidgetController : ApiController
    {
        private IWidgets widget;

        public WidgetController()
        {
            widget = new Widgets();
        }

        [Route("widgets")]
        public IHttpActionResult GetAllWidgets()
        {
            List<P2PWidget> widgets = widget.AllWidgets();
            return Ok(widgets);
        }

        // GET: api/Widget
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Widget/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Widget
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Widget/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Widget/5
        public void Delete(int id)
        {
        }
    }
}
