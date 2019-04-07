using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace PLM.Modelo
{
    public  class DiasFeriados
    {
        public int id { get; set; }
        
        [Required]  
        public string Proveedor { get; set; } 

        [Required]
        public DateTime DiasF { get; set; }
    }
}
