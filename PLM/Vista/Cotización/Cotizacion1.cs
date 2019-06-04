using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM.Modelo;

namespace PLM.Vista.Cotización
{
    public partial class Cotizacion1 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        
        public Cotizacion1()
        {
            InitializeComponent();
        }

        private void tbArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticulo.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvTP.Rows.Add(tbTipo.Text,articulosCot.Ancho, articulosCot.Peso, articulosCot.Descr, articulosCot.Proveedor, tbConsumoP.Text , articulosCot.UnidadMedida,tbCosto.Text, tbCosto.Text);
        }
    }
}
