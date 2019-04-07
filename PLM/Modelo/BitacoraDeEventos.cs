using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PLM.Modelo
{
    public class BitacoraDeEventos
    {
        public int id { get; set; }

        public string Usuario { get; set; }

        public string Departamento { get; set; }

        public DateTime Fecha { get; set; }

        public string Evento { get; set; }
    }
}
