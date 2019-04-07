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
   public class Boms
    {
        public int Id { get; set; }
        public string NroBom{ get; set; }
        public string Estilo{ get; set; }
        public string CodigoNacional{ get; set; }
        public string usuario { get; set; }
        public DateTime FechaCreacion { get; set;}
        public DateTime FUltimaModificacion { get; set; }
        public int NumeroRevisiones { get; set; }
        public int Estado { get; set; }
        public int Etapa { get; set; }       
        public string PO { get; set; }
        public string SPO { get; set; }
        public string Hilos { get; set; }
        public string Notas { get; set;}
             
    }
}
