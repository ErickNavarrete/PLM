using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class DiasAnticipacion
    {        
        public int id { get; set; }

        [Required]
        public int DiasA { get; set; }  

        [Required]
        public int DiasdeMargen { get; set; } 
    }
}
