using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_entrenamiento.Modelos
{
    public class Event
    {
        public int EventID { get; set; }
        public int OrganizationID { get; set; }
        public string Description { get; set; }
        public int ContainerID { get; set; }
    }
}