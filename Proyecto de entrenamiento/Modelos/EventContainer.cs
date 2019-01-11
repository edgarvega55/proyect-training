using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_entrenamiento.Modelos
{
    public class EventContainer
    {
        public int EventID { get; set; }
        public string Description { get; set; }
        public P2PContainer Container { get; set; }
    }
}
