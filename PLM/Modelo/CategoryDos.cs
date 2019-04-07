using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace PLM.Modelo
{
    public class Category_2
    {
        public int id { get; set; }

        [Required]     
        public string IdCategory2 { get; set; } 

        [Required]
        [StringLength(25)]
        public string Descripción { get; set; }
    }
}
