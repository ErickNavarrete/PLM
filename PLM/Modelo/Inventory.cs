using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM.Modelo
{
    public class Inventory
    {
        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public string Categoria { get; set; }

        public string Lavado { get; set; }

        public string IdEstilos { get; set; }

        public string Espec { get; set; }

        public string Division { get; set;  }

        public string Cliente { get; set;  }
        
        public string ClienteC { get; set;  }
        
        public string IdCliente { get; set; }

        public string Category { get; set; }

        public string Piece { get; set; }

        public string Supplier { get; set; }

        public string IdProvedor { get; set; }

        public string Proveedor { get; set; }
        
        public float Costo { get; set;}

        public string Thread { get; set;}

        public string EstilosThread { get; set; }

        public string HDescripcion { get; set; }
        
        public float Ancho { get; set; }

        public float Peso { get; set; }

        public float Calibre { get; set; }

        public string NroOrdenCompra { get; set; }

        public string IdClienteO { get; set; }

        public string EtapaProceso { get; set; }

        public DateTime PlanInicio { get; set; }

        public string OrdenVenta { get; set; }
       
        public float CantidadFabricar { get; set; }

        public float MaximoEnExistencia { get; set; }

        public float UMCompra { get; set; }

        //public DateTime FechaEntProv { get; set; }
        public float FechaEntProv { get; set; }

    }
}
