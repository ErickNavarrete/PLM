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
using ArcangelDialogs;

namespace PLM.Vista.Cotización
{
    public partial class Cotizacion1 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        public string nacionalidad;
        public decimal porcentaje_tela = 0, tipo_cambio = 0;
        public bool t_cambio = false, cliente = false;
        
        public Cotizacion1()
        {
            InitializeComponent();
        }

        public void limpia_campos_programado()
        {
            tbTipo.Text = String.Empty;
            tbArticulo.Text = String.Empty;
            tbConsumoP.Text = String.Empty;
            tbCosto.Text = String.Empty;
        }

        public void limpia_campos_hilo()
        {
            tbTipoHilo.Text = String.Empty;
            tbArticuloHilo.Text = String.Empty;
            tbConsumoPHilo.Text = String.Empty;
            tbCostoHilo.Text = String.Empty;
        }

        public void activa_campos(bool tipo)
        {
            tbTipo.Enabled = tipo;
            tbArticulo.Enabled = tipo;
            tbConsumoP.Enabled = tipo;
            tbCosto.Enabled = tipo;
            tbFletes.Enabled = tipo;
            tbSubTelas.Enabled = tipo;
            btnAdd.Enabled = tipo;

            tbTipoHilo.Enabled = tipo;
            tbArticuloHilo.Enabled = tipo;
            tbConsumoPHilo.Enabled = tipo;
            tbCostoHilo.Enabled = tipo;
            tbCostoHilo.Enabled = tipo;
            tbSubHilo.Enabled = tipo;
            btnAddHilo.Enabled = tipo;
        }

        public void limpia_todo()
        {
            limpia_campos_hilo();
            limpia_campos_programado();
            tbSubHilo.Text = "";
            tbSubTelas.Text = "";
            tbFletes.Text = "";
        }

        private void tbArticuloHilo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloHilo.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddHilo_Click(object sender, EventArgs e)
        {
            decimal total = 0, costo, consumo;

            if (!cliente)
            {
                Dialogs.Show("Sin cliente", DialogsType.Warning);
                return;
            }
            if (!t_cambio)
            {
                Dialogs.Show("Sin Tipo de Cambio", DialogsType.Warning);
                return;
            }
            if (tbArticuloHilo.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloHilo.Focus();
                return;
            }
            if (tbConsumoPHilo.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPHilo.Focus();
                return;
            }
            if (tbCostoHilo.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoHilo.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoHilo.Text);
            consumo = Convert.ToDecimal(tbConsumoPHilo.Text);

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvHilos.Rows.Add(articulosCot.Calibre,tbTipoHilo.Text, articulosCot.Descr, articulosCot.Proveedor,consumo, articulosCot.UnidadMedida, tbCosto.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvHilos.Rows.Add(articulosCot.Calibre, tbTipoHilo.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "",tbCosto.Text, total);
            }

            if (tbSubHilo.Text != "")
            {
                tbSubHilo.Text = (Convert.ToDecimal(tbSubHilo.Text) + total).ToString("N2");
            }
            else
            {
                tbSubHilo.Text = total.ToString("N2");
            }

            limpia_campos_hilo();
        }

        private void tbArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticulo.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal total = 0, costo, consumo;

            if (!cliente)
            {
                Dialogs.Show("Sin cliente", DialogsType.Warning);
                return;
            }
            if (!t_cambio)
            {
                Dialogs.Show("Sin Tipo de Cambio", DialogsType.Warning);
                return;
            }
            if (tbArticulo.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticulo.Focus();
                return;
            }
            if (tbConsumoP.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoP.Focus();
                return;
            }
            if (tbCosto.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCosto.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCosto.Text);
            consumo = Convert.ToDecimal(tbConsumoP.Text);

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvTP.Rows.Add(tbTipo.Text, articulosCot.Ancho, articulosCot.Peso, articulosCot.Descr, articulosCot.Proveedor, tbConsumoP.Text, articulosCot.UnidadMedida, tbCosto.Text, "",total);
            }
            else{
                total = costo + (costo * porcentaje_tela * consumo);
                dgvTP.Rows.Add(tbTipo.Text, articulosCot.Ancho, articulosCot.Peso, articulosCot.Descr, articulosCot.Proveedor, tbConsumoP.Text, articulosCot.UnidadMedida, "", tbCosto.Text,total);
            }
            
            if(tbSubTelas.Text != "")
            {
                tbSubTelas.Text = (Convert.ToDecimal(tbSubTelas.Text) + total).ToString("N2");
            }
            else
            {
                tbSubTelas.Text = total.ToString("N2");
            }

            limpia_campos_programado();
        }
    }
}
