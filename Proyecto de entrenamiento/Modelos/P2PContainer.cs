using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_entrenamiento.Modelos
{
    class P2PContainer
    {
        public int ContainerID { get; set; }
        public int EventID { get; set; }
        public int P2PPageTypeID { get; set; }
        public string Properties { get; set; }
        public bool IsHero { get; set; }
        public bool IsHeroLocked { get; set; }
        public int SortOrder { get; set; }
        public int ColumnOrder { get; set; }
    }
}