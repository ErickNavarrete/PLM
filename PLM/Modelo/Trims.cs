using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace PLM.Modelo
{
    public class Trims
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string IdTrim { get; set; }

        [Required]
        [StringLength(25)]
        public string Descripción { get; set; }

        [Required]
        [StringLength(25)]
        public string Departamento { get; set; }

        [Required]
        [StringLength(25)]
        public string Segmento { get; set; } 

        [Required]
        public int Secuencia { get; set; }     
    }
}
