using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace PLM.Modelo
{
    public class Hilos
    {
       public int Id { get; set; }
       public string NroBom{ get; set;}
       public string Estilos{ get; set;}
       public string Nacionaliad{ get; set;}
       public string CodigoHilos{ get; set;}
       public int Estado { get; set; }
       
    }
}
