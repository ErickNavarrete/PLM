using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations; 
namespace PLM.Modelo
{
    public class Segundas  
    {
        public int id { get; set; }

        [Required]
        [StringLength(3)]
        public string Cliente { get; set; }

        [Required]
        public string Tela { get; set; }

        [Required]
        public string Conf { get; set; } 

        [Required]
        public string Lavado { get; set; } 

        [Required]
        public string proc { get; set; }

        [Required]
        public string avios { get; set; }

        [Required]
        public string faltantes { get; set; }

        [Required]
        public string total { get; set; }               
    }
}
