using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
     public class HilosDetails
    {
        public int Id { get; set; }
        public string Vista{ get; set; }
        public float MetrajeVista { get; set; }
        public string Interior { get; set; }
        public float MetrajeInteiores{ get; set; }
        public float Total { get; set; }
        public string Notas { get; set; } 
        public string CodigoHilos { get; set; }
        public int Estado { get; set; }
        public int posicion { get; set; }
    }
}
