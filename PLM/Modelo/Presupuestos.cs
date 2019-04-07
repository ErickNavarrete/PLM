using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations; 
namespace PLM.Modelo
{
    public class Presupuestos
    {
        public int id { get; set; }

        [Required]
        public string Diario { get; set; }

        [Required]
        public string Mo { get; set; }

        [Required]
        public string Prestaciones { get; set; }

        [Required]
        public string Admon { get; set; }

        [Required]
        public string Prod { get; set; }

        [Required]
        public string Ventas { get; set; }

        [Required]
        public string Varios { get; set; }

        [Required]
        public string IdPresupuesto { get; set; } 
    }
}
