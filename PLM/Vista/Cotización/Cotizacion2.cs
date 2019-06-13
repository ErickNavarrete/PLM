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
    public partial class Cotizacion2 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        public string nacionalidad;
        public decimal porcentaje_tela = 0, tipo_cambio = 0;
        public bool t_cambio = false, cliente = false;
        public decimal fusing = 0, cierre = 0;

        public Cotizacion2()
        {
            InitializeComponent();
        }

        #region FUNCIONES
        public void limpia_campos_fusing()
        {
            tbTipoF.Text = String.Empty;
            tbArticuloF.Text = String.Empty;
            tbConsumoPF.Text = String.Empty;
            tbCostoF.Text = String.Empty;
        }

        public void limpia_campos_cierre()
        {
            tbTipoC.Text = String.Empty;
            tbArticuloC.Text = String.Empty;
            tbConsumoPC.Text = String.Empty;
            tbCostoC.Text = String.Empty;
        }

        public void activa_campos(bool tipo)
        {
            tbTipoF.Enabled = tipo;
            tbArticuloF.Enabled = tipo;
            tbConsumoPF.Enabled = tipo;
            tbCostoF.Enabled = tipo;
            tbSubF.Enabled = tipo;
            btnAddF.Enabled = tipo;

            tbTipoC.Enabled = tipo;
            tbArticuloC.Enabled = tipo;
            tbConsumoPC.Enabled = tipo;
            tbCostoC.Enabled = tipo;
            tbSubCierre.Enabled = tipo;
            btnAdd2.Enabled = tipo;
        }

        public void limpia_todo()
        {
            limpia_campos_fusing();
            limpia_campos_cierre();
            tbSubF.Text = "";
            tbSubCierre.Text = "";
        }
        #endregion

        private void tbArticuloC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloC.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
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
            if (tbArticuloC.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloC.Focus();
                return;
            }
            if (tbConsumoPC.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPC.Focus();
                return;
            }
            if (tbCostoC.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoC.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoC.Text);
            consumo = Convert.ToDecimal(tbConsumoPC.Text);

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvCierre.Rows.Add(tbTipoC.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoC.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvCierre.Rows.Add(tbTipoC.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoC.Text, total);
            }

            if (tbSubCierre.Text != "")
            {
                tbSubCierre.Text = (Convert.ToDecimal(tbSubCierre.Text) + total).ToString("N2");
                cierre = Convert.ToDecimal(tbSubCierre.Text) + total;
            }
            else
            {
                tbSubCierre.Text = total.ToString("N2");
                cierre = total;
            }

            limpia_campos_cierre();
        }

        private void tbArticuloF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloF.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddF_Click(object sender, EventArgs e)
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
            if (tbArticuloF.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloF.Focus();
                return;
            }
            if (tbConsumoPF.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPF.Focus();
                return;
            }
            if (tbCostoF.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoF.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoF.Text);
            consumo = Convert.ToDecimal(tbConsumoPF.Text);

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvFusing.Rows.Add(tbTipoF.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoF.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvFusing.Rows.Add(tbTipoF.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "",tbCostoF.Text, total);
            }

            if (tbSubF.Text != "")
            {
                tbSubF.Text = (Convert.ToDecimal(tbSubF.Text) + total).ToString("N2");
                fusing = Convert.ToDecimal(tbSubF.Text) + total;
            }
            else
            {
                tbSubF.Text = total.ToString("N2");
                fusing = total;
            }

            limpia_campos_fusing();
        }
    }
}
