using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class Tareas
    {
        public int id { get; set; }
        public string Ref { get; set; }
        public string IdBOM { get; set; }
        public string Nacionalidad { get; set; }
        public string Segmento { get; set; }
        public int TiempoRespuesta { get; set; }
        public string Trim { get; set; }
        public string UsuarioEnvio { get; set; }
        public DateTime FechaTarea { get; set; }
        public string DepartamentoRespuesta { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public int? Dif { get; set; }
        public int Status { get; set; }
    }
}
