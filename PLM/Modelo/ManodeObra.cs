using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PLM.Modelo
{
    public class ManodeObra
    {
        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string IdManodeObra { get; set; }

        [Required]
        [StringLength(25)]
        public string Descripción { get; set; }
    }
}
