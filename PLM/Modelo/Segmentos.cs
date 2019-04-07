using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class Segmentos
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string IdSegmento { get; set; }

        [Required]
        [StringLength(25)]
        public string Descripción { get; set; }  

        [Required]
        public int SecuenciaSegmento { get; set; }

        [Required]
        public int TiempoDeRespuesta { get; set; }       
    }
}
