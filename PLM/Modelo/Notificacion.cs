using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo
{
    public class Notificacion
    {
        public int id { get; set; }
        public string UsuarioCreador { get; set; }
        public string NroTarea { get; set; }
        public string DepartamentoResp { get; set;}
        public string Descripcion { get; set; }
        public int EstadoTarea { get; set; } 

    }
}
