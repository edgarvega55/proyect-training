using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_entrenamiento.Modelos
{
    public class P2PWidget
    {
        public int WidgetID { get; set; }
        public int ContainerID { get; set; }
        public string Locked { get; set; }
        public string Properties { get; set; }
        public int SortOrder { get; set; }
        public int P2PWidgetTypeID { get; set; }
        public bool IsRequired { get; set; }
        public string IsVisible { get; set; }
        public int VisibilityConditionTypeID { get; set; }
    }
}
