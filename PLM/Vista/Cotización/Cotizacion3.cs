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
    public partial class Cotizacion3 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        public string nacionalidad;
        public decimal porcentaje_tela = 0, tipo_cambio = 0;
        public bool t_cambio = false, cliente = false;
        public decimal metales = 0, confeccion = 0;

        public Cotizacion3()
        {
            InitializeComponent();
        }

        #region FUNCIONES
        public void limpia_campos_metal()
        {
            tbTipoM.Text = String.Empty;
            tbArticuloM.Text = String.Empty;
            tbConsumoPM.Text = String.Empty;
            tbCostoM.Text = String.Empty;
        }

        public void limpia_campos_etiq()
        {
            tbTipoE.Text = String.Empty;
            tbArticuloE.Text = String.Empty;
            tbConsumoPE.Text = String.Empty;
            tbCostoE.Text = String.Empty;
        }

        public void activa_campos(bool tipo)
        {
            tbTipoM.Enabled = tipo;
            tbArticuloM.Enabled = tipo;
            tbConsumoPM.Enabled = tipo;
            tbCostoM.Enabled = tipo;
            tbSubM.Enabled = tipo;
            btnAddM.Enabled = tipo;

            tbTipoE.Enabled = tipo;
            tbArticuloE.Enabled = tipo;
            tbConsumoPE.Enabled = tipo;
            tbCostoE.Enabled = tipo;
            tbSubE.Enabled = tipo;
            btnAddE.Enabled = tipo;
        }

        public void limpia_todo()
        {
            limpia_campos_metal();
            limpia_campos_etiq();
            tbSubM.Text = "";
            tbSubE.Text = "";
        }
        #endregion

        private void tbArticuloM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloM.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddM_Click(object sender, EventArgs e)
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
            if (tbArticuloM.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloM.Focus();
                return;
            }
            if (tbConsumoPM.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPM.Focus();
                return;
            }
            if (tbCostoM.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoM.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoM.Text);
            consumo = Convert.ToDecimal(tbConsumoPM.Text);

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvMetales.Rows.Add(tbTipoM.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoM.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvMetales.Rows.Add(tbTipoM.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoM.Text, total);
            }

            if (tbSubM.Text != "")
            {
                tbSubM.Text = (Convert.ToDecimal(tbSubM.Text) + total).ToString("N2");
                metales = Convert.ToDecimal(tbSubM.Text) + total;
            }
            else
            {
                tbSubM.Text = total.ToString("N2");
                metales = total;
            }

            limpia_campos_metal();
        }

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

            if (nacionalidad == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvEtiq.Rows.Add(tbTipoE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoE.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvEtiq.Rows.Add(tbTipoE.Text, articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoE.Text, total);
            }

            if (tbSubE.Text != "")
            {
                tbSubE.Text = (Convert.ToDecimal(tbSubE.Text) + total).ToString("N2");
                confeccion = Convert.ToDecimal(tbSubE.Text) + total;
            }
            else
            {
                tbSubE.Text = total.ToString("N2");
                confeccion = total;
            }

            limpia_campos_etiq();
        }
    }
}
