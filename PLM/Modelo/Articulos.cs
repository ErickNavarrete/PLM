using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo
{
    public class Articulos
    {
        public string Clave { get; set; }
        public string Descr { get; set; }
        public string Material { get; set; }
        public string UnidadMedida { get; set; }
        public string Proveedor { get; set; }
        public string Categoria { get; set; }
        public string Color{ get; set; }
    }

    public class ArticulosPT
    {
        public string Clave { get; set; }
        public string Descr { get; set; }
        public string Categoria { get; set; }
        public string Estilo { get; set; }
        public string Linea { get; set; }
        public string Marca { get; set; }
    }

    public class ArticulosCot
    {
        public string Clave { get; set; }
        public string Descr { get; set; }
        public string UnidadMedida { get; set; }
        public string Proveedor { get; set; }
        public string Color { get; set; }
        public decimal Peso { get; set; }
        public decimal Ancho { get; set; }
        public decimal Calibre { get; set; }
    }
}
