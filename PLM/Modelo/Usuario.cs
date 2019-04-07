using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{ 
    // Tabla, Entidad o Modelo Usuario
    public class Usuario
    {
        public int id { get; set; } // Campo ID Auto incrementable

        [Required]
        [StringLength(10)]
        public string Usser { get; set; } // Campo Usuario 

        [Required]
        [StringLength(10)]
        public string Password { get; set; } // Campo Password

        [Required]
        public string Departamento { get; set; } // Campo Departamento

        [Required]
        public int Pantallas { get; set; } // Campo para las pantallas que se observaran

        [Required]
        public string Correo { get; set; } // Campo Correo electrónico 

        [Required]
        public int Agregar { get; set; } // Campo permite agregar

        [Required]
        public int Modificar { get; set; } // Campo permite modificar

        [Required]
        public int Eliminar { get; set; } // Campo permite eliminar
                
        [Required]
        public int Autorizado { get; set; } // Campo permiso autorizado cancelar BOM
        [Required]
        public int Liberar { get; set; } // Campo permiso liberar hojas de cotización 

        [Required]
        public int Reabrir { get; set; } // Campo permiso para reabrir hojas de cotización
    }
}
