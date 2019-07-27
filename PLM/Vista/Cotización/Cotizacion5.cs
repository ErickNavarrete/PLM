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
    public partial class Cotizacion5 : UserControl
    {
        ArticulosCot articulosCot = new ArticulosCot();
        Proceso proceso = new Proceso();
        public string nacionalidad;
        public decimal porcentaje_tela = 0, tipo_cambio = 0;
        public bool t_cambio = false, cliente = false;
        public decimal varios = 0, procesos = 0;

        public Cotizacion5()
        {
            InitializeComponent();
        }

        #region FUNCIONES
        public void limpia_campos_varios()
        {
            tbArticuloV.Text = String.Empty;
            tbConsumoPV.Text = String.Empty;
            tbCostoV.Text = String.Empty;
        }

        public void limpia_campos_procesos()
        {
            tbProcesos.Text = String.Empty;
            tbUnidad.Text = String.Empty;
            tbConsumoP.Text = String.Empty;
            tbCostoP.Text = String.Empty;
        }

        public void activa_campos(bool tipo)
        {
            tbArticuloV.Enabled = tipo;
            tbConsumoPV.Enabled = tipo;
            tbCostoV.Enabled = tipo;
            tbSubV.Enabled = tipo;
            btnAddV.Enabled = tipo;
            tbFletesV.Enabled = tipo;

            tbProcesos.Enabled = tipo;
            tbUnidad.Enabled = tipo;
            tbConsumoP.Enabled = tipo;
            tbCostoP.Enabled = tipo;
            tbSubP.Enabled = tipo;
            btnAddP.Enabled = tipo;
        }

        public void limpia_todo()
        {
            limpia_campos_varios();
            limpia_campos_procesos();
            tbSubP.Text = "";
            tbSubV.Text = "";
            tbFletesV.Text = "";
        }
        #endregion

        private void tbArticuloV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(43);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.articulosCot != null)
                {
                    articulosCot = new ArticulosCot();
                    articulosCot = frmBusqueda.articulosCot;
                    tbArticuloV.Text = articulosCot.Clave;
                }
            }
        }

        private void btnAddV_Click(object sender, EventArgs e)
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
            if (tbArticuloV.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbArticuloV.Focus();
                return;
            }
            if (tbConsumoPV.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbConsumoPV.Focus();
                return;
            }
            if (tbCostoV.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoV.Focus();
                return;
            }

            costo = Convert.ToDecimal(tbCostoV.Text);
            consumo = Convert.ToDecimal(tbConsumoPV.Text);

            if (nacionalidad.Trim() == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvVarios.Rows.Add(articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, tbCostoV.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvVarios.Rows.Add(articulosCot.Descr, articulosCot.Proveedor, consumo, articulosCot.UnidadMedida, "", tbCostoV.Text, total);
            }

            if (tbSubV.Text != "")
            {
                tbSubV.Text = (Convert.ToDecimal(tbSubV.Text) + total).ToString("N2");
                varios = Convert.ToDecimal(tbSubV.Text) + total;
            }
            else
            {
                tbSubV.Text = total.ToString("N2");
                varios = total;
            }
            limpia_campos_varios();
        }

        private void tbProcesos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(44);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.proceso != null)
                {
                    proceso = new Proceso();
                    proceso = frmBusqueda.proceso;
                    tbProcesos.Text = proceso.IdProceso;
                }
            }
        }

        private void btnAddP_Click(object sender, EventArgs e)
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
            if (tbProcesos.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbProcesos.Focus();
                return;
            }
            if (tbUnidad.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbUnidad.Focus();
                return;
            }
            if (tbCostoP.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoV.Focus();
                return;
            }
            if (tbConsumoP.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbCostoV.Focus();
                return;
            }
            costo = Convert.ToDecimal(tbCostoP.Text);
            consumo = Convert.ToDecimal(tbConsumoP.Text);

            if (nacionalidad.Trim() == "USD")
            {
                total = costo + (costo * porcentaje_tela * consumo * tipo_cambio);
                dgvProcesos.Rows.Add(proceso.IdProceso, proceso.Descripción, consumo, tbUnidad.Text, tbCostoP.Text, "", total);
            }
            else
            {
                total = costo + (costo * porcentaje_tela * consumo);
                dgvProcesos.Rows.Add(proceso.IdProceso, proceso.Descripción, consumo, tbUnidad.Text, "", tbCostoP.Text, total);
            }

            if (tbSubP.Text != "")
            {
                tbSubP.Text = (Convert.ToDecimal(tbSubP.Text) + total).ToString("N2");
                procesos = Convert.ToDecimal(tbSubP.Text) + total;
            }
            else
            {
                tbSubP.Text = total.ToString("N2");
                procesos = total;
            }

            limpia_campos_procesos();
        }
    }
}
