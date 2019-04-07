using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PLM.Modelo
{
    public class EstilosProduccions
    {
        public int id { get; set; }

        [Required]      
        public string IdEstilo { get; set; } 

        [Required]     
        public string Descripcion { get; set; }

        [Required]        
        public string Categoria { get; set; }

        [Required]      
        public string Division { get; set; }

        [Required]
        public string Estacion { get; set; } 
       
        [Required]     
        public string Cliente { get; set; } 

        [Required]      
        public string Marca { get; set; }

        [Required]       
        public string Category2 { get; set; }

        [Required]
        [Column ("Espec", TypeName = "VARCHAR(MAX)")]              
        public string Espec { get; set; }
       
        [Column("EspecType", TypeName = "VARCHAR(MAX)")]
        public string EspecType { get; set; }

        [Required]     
        public string Fit { get; set; } 

        [Required]    
        public string Body { get; set; } 

        [Required]       
        public string Lavado { get; set; } 

        [Required]       
        public string Inseam { get; set; }

        [Required]      
        public string Empaque { get; set; }      
    }
}
