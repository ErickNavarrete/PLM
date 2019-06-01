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

        public void getClientes(DataGridView controlView)
        {
            var datos = dbd.Inventario2().Select(x=> new {x.Cliente, x.Tienda}).ToList();
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
    }
}
