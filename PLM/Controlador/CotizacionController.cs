using PLM.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM.Controlador
{
    public class CotizacionController
    {
        private Dynamics dbd = new Dynamics();
        PLMContext db = new PLMContext();

        public void getClientes(DataGridView controlView)
        {
            var datos = dbd.Inventario2().Select(x=> new {x.Cliente, x.Tienda, x.ClienteC}).ToList();
            controlView.Columns.Clear();
            controlView.DataSource = datos;
            controlView.Columns[0].Width = 400;
            controlView.Columns[1].Width = 200;
        }

        public void getArticulosPT(DataGridView controlView)
        {
            var datos = dbd.getArticulosPT();
            controlView.Columns.Clear();
            controlView.DataSource = datos;
            controlView.Columns[2].Visible = false;
            controlView.Columns[3].Visible = false;
            controlView.Columns[4].Visible = false;
            controlView.Columns[5].Visible = false;

            controlView.Columns[0].Width = 200;
            controlView.Columns[1].Width = 300;
        }

        public void getArticulosCOT(DataGridView controlView)
        {
            var datos = dbd.getArticulosCot().Select(x => new { x.Clave, x.Descr, x.Ancho, x.Peso, x.Proveedor, x.UnidadMedida, x.Calibre }).ToList();
            controlView.Columns.Clear();
            controlView.DataSource = datos;
            controlView.Columns[0].Width = 150;
            controlView.Columns[1].Width = 200;
            controlView.Columns[1].Name = "Descripción";
        }

        public Segundas GetSegundas(string cliente)
        {
            Segundas segundas = db.Segundas.Where(x => x.Cliente == cliente).FirstOrDefault();

            return segundas;
        }

        public void GetProceso(DataGridView controlView)
        {
            var datos = db.Procesos.ToList();
            controlView.Columns.Clear();
            controlView.DataSource = datos;
            controlView.Columns[0].Visible = false;
            controlView.Columns[1].HeaderText = "PROCESO";
            controlView.Columns[2].HeaderText = "DESCRIPCIÓN";
            controlView.Columns[2].Width = 500;
        }

        public void GetManoObra(DataGridView controlView)
        {
            var datos = db.ManodeObra.ToList();
            controlView.Columns.Clear();
            controlView.DataSource = datos;
            controlView.Columns[0].Visible = false;
            controlView.Columns[1].HeaderText = "MANO DE OBRA";
            controlView.Columns[2].HeaderText = "DESCRIPCIÓN";
            controlView.Columns[2].Width = 500;
        }

        public Presupuestos GetPresupuestos(string presupuesto)
        {
            Presupuestos presupuestos= db.Presupuestos.Where(x => x.IdPresupuesto == presupuesto).FirstOrDefault();

            return presupuestos;
        }
    }
}
