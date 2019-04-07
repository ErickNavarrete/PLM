using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo.Reportes
{
   public class DetalleUsuario
    {
        public string usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FUltimaModificacion { get; set; }
        public int NumeroRevisiones { get; set; } 
    }
}
