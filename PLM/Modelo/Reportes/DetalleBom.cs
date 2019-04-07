using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo.Reportes
{
    public class DetalleBom
    {        
        public string Segmento { get; set; }       
        public string Trims { get; set; }
        public string ItemCode { get; set; }
        public string Category { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public double Cantidad { get; set; }
        public double Costo { get; set; }
        public string Piece { get; set; }
        public string Supplier { get; set; }      
    }
}
