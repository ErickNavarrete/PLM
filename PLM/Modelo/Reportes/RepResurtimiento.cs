using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo.Reportes
{
    public class RepResurtimiento
    {
        public string clave { get; set; }
        public string descripcion { get; set; }
        public string cant_ord { get; set; }
        public string ot { get; set; }
        public string tipo_material { get; set; }
        public string existencia { get; set; }
        public string unidad_compra { get; set; }
        public string orden_venta { get; set; }
        public string po { get; set; }
        public string adicional { get; set; }
        public string cantidad_ordenes_venta { get; set; }
        public string cod_proveedor { get; set; }
        public string desc_proveedor { get; set; }
        public string proveedor { get; set; }
        public string tiempo_entrega { get; set; }
        public string fecha_embarque { get; set; }
        public string cliente_id { get; set; }
        public string cant_fabr { get; set; }
    }
}
