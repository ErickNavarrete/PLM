using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class Departamentos
    {
        public int id { get; set; }

        [Required]
    
        public string IdDepartamento { get; set; } 

        [Required]
        
        public string Descripción { get; set; }        

        [Required]
        public double TResp { get; set;}

        public int Dthread { get; set;}
    }
}
