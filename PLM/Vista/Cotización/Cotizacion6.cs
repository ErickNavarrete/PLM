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
    public partial class Cotizacion6 : UserControl
    {
        ManodeObra obra = new ManodeObra();
        Presupuestos presupuestos = new Presupuestos();
        public string nacionalidad;
        public bool t_cambio = false, cliente = false;

        public Cotizacion6()
        {
            InitializeComponent();
        }

        #region FUNCIONES
        public void sumas(decimal segmento1, decimal segmento2)
        {
            if(tbCostoT.Text != "")
            {
                tbCostoT.Text = (Convert.ToDecimal(tbCostoT.Text) + segmento1 + segmento2).ToString("N2");
            }
            else
            {
                tbCostoT.Text = (segmento1 + segmento2).ToString("N2");
            }
        }

        public void limpia_sumas()
        {
            tbCostoT.Text = "";
        }
        #endregion

        private void tbManoObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(45);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.proceso != null)
                {
                    obra = new ManodeObra();
                    presupuestos = new Presupuestos();
                    obra = frmBusqueda.obra;
                    presupuestos = frmBusqueda.presupuestos;
                    tbManoObra.Text = obra.Descripción;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal presupuesto = 0, desgloce = 0, piezas = 0;

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
            if (tbManoObra.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbManoObra.Focus();
                return;
            }
            if (tbUnidad.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbUnidad.Focus();
                return;
            }
            if (tbPiezas.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbPiezas.Focus();
                return;
            }
            if (tbDesgloce.Text == "")
            {
                Dialogs.Show("Campo obligatorio", DialogsType.Warning);
                tbDesgloce.Focus();
                return;
            }

            desgloce = Convert.ToDecimal(tbDesgloce.Text);
            piezas = Convert.ToDecimal(tbPiezas.Text);

            switch (obra.IdManodeObra)
            {
                case "PRESTACIONES":
                    presupuesto = Convert.ToDecimal(presupuestos.Prestaciones);
                    break;
            }

            if (nacionalidad.Trim() == "USD")
            {
                dgvProcesos.Rows.Add(obra.IdManodeObra, obra.Descripción, presupuesto, tbPiezas.Text, tbUnidad.Text, desgloce,"",(presupuesto/piezas));
            }
            else
            {
                dgvProcesos.Rows.Add(obra.IdManodeObra, obra.Descripción, presupuesto, tbPiezas.Text, tbUnidad.Text, desgloce, (presupuesto / piezas),"");
            }
        }
    }
}
