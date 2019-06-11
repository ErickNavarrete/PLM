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
    public partial class Cotizacion4 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        public string nacionalidad;
        public decimal porcentaje_tela = 0, tipo_cambio = 0;
        public bool t_cambio = false, cliente = false;

        public Cotizacion4()
        {
            InitializeComponent();
        }

        #region FUNCIONES
        public void limpia_campos_etiq()
        {
            tbTipoE.Text = String.Empty;
            tbArticuloE.Text = String.Empty;
            tbConsumoPE.Text = String.Empty;
            tbCostoE.Text = String.Empty;
        }

        public void limpia_campos_emp()
        {
            tbTipoEE.Text = String.Empty;
            tbArticuloEE.Text = String.Empty;
            tbConsumoPEE.Text = String.Empty;
            tbCostoEE.Text = String.Empty;
        }

        public void activa_campos(bool tipo)
        {
            tbTipoEE.Enabled = tipo;
            tbArticuloEE.Enabled = tipo;
            tbConsumoPEE.Enabled = tipo;
            tbCostoEE.Enabled = tipo;
            tbSubEE.Enabled = tipo;
            btnAddEE.Enabled = tipo;

            tbTipoE.Enabled = tipo;
            tbArticuloE.Enabled = tipo;
            tbConsumoPE.Enabled = tipo;
            tbCostoE.Enabled = tipo;
            tbSubE.Enabled = tipo;
            btnAddE.Enabled = tipo;
        }

        public void limpia_todo()
        {
            limpia_campos_emp();
            limpia_campos_etiq();
            tbSubEE.Text = "";
            tbSubE.Text = "";
        }
        #endregion

        private void tbArticuloE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloE.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddE_Click(object sender, EventArgs e)
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
            if (tbArticuloE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloE.Focus();
                return;
            }
            if (tbConsumoPE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPE.Focus();
                return;
            }
            if (tbCostoE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoE.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoE.Text);
            consumo = Convert.ToDecimal(tbConsumoPE.Text);

            if (nacionalidad.Trim() == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvEtiqEx.Rows.Add(tbTipoE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoE.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvEtiqEx.Rows.Add(tbTipoE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoE.Text, total);
            }

            if (tbSubE.Text != "")
            {
                tbSubE.Text = (Convert.ToDecimal(tbSubE.Text) + total).ToString("N2");
            }
            else
            {
                tbSubE.Text = total.ToString("N2");
            }

            limpia_campos_etiq();
        }

        private void tbArticuloEE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloEE.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddEE_Click(object sender, EventArgs e)
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
            if (tbArticuloEE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloEE.Focus();
                return;
            }
            if (tbConsumoPEE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPE.Focus();
                return;
            }
            if (tbCostoEE.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoEE.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoEE.Text);
            consumo = Convert.ToDecimal(tbConsumoPEE.Text);

            if (nacionalidad.Trim() == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvEtiqEm.Rows.Add(tbTipoEE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoEE.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvEtiqEm.Rows.Add(tbTipoEE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoEE.Text, total);
            }

            if (tbSubEE.Text != "")
            {
                tbSubEE.Text = (Convert.ToDecimal(tbSubEE.Text) + total).ToString("N2");
            }
            else
            {
                tbSubEE.Text = total.ToString("N2");
            }

            limpia_campos_emp();
        }
    }
}
