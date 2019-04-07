using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class Inseam
    {
        public int id { get; set; }// Campo ID Auto incrementable

        [Required]
        [StringLength(10)]
        public string IdInseam { get; set; } 

        [Required]
        [StringLength(25)]
        public string Descripción { get; set; }
    }
}
