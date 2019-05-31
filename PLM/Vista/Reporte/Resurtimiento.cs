using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using ArcangelDialogs;
using PLM.Modelo;

namespace PLM.Vista.Reporte
{
    public partial class Resurtimiento : MetroForm
    {
        private List<OrdenVenta> ordenVenta;
        private Controlador.ResurtimientoController Res;

        public Resurtimiento()
        {
            InitializeComponent();
            Res = new Controlador.ResurtimientoController();
        }

        private void Resurtimiento_Load(object sender, EventArgs e)
        {
            Res.GetClientes(cbClientes);
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo, dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string cliente = "";
            string c_cliente = "TODOS";

            Cursor.Current = Cursors.WaitCursor;
            if (chbOpcion.Checked == false)
            {
                //if(cbClientes.Text == "")
                //{
                //    Dialogs.Show("Sin datos por mostrar", DialogsType.Warning);
                //    return;
                //}
                c_cliente = cbClientes.Text.ToUpper();
                cliente = Res.GetIdCliente(cbClientes.Text);
            }

            this.pbResurtimiento.Value = 0;
            
            if (!Res.GetReporte(dtpFechaI.Value, dtpFechaF.Value, cliente, dtpFechaOC.Value, this.pbResurtimiento, c_cliente ,clbOrdenTrabajo, this.Cursor))
            {
                Dialogs.Show("Sin datos por mostrar", DialogsType.Info);
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string cliente = "";
            string c_cliente = "TODOS";
            int opcion = 0;
            ordenVenta = new List<OrdenVenta>();
            this.pbResurtimiento.Value = 0;

            Cursor.Current = Cursors.WaitCursor;
            if (chbOpcion.Checked == false)
            {
                c_cliente = cbClientes.Text.ToUpper();
                cliente = Res.GetIdCliente(cbClientes.Text);
            }
            var Wonbr = Res.GetWONBR(dtpFechaI.Value, dtpFechaF.Value, cliente, dtpFechaOC.Value, c_cliente, this.pbResurtimiento);

            this.pbResurtimiento.Value = 0;
            this.pbResurtimiento.Minimum = 0;
            this.pbResurtimiento.Maximum = Wonbr.Count;
            if (Wonbr.Count > 0)
            {
                foreach (string item in Wonbr)
                {
                    opcion = Res.CreateOrdenVenta(item, "", "", dtpFechaOC.Value, ordenVenta);
                    this.pbResurtimiento.Value = this.pbResurtimiento.Value + 1;
                    if (opcion == 2)
                    {
                        break;
                    }
                }
                if(opcion != 2)
                {
                    Res.create_reporte_orden_venta(ordenVenta);
                }
                Dialogs.Show("Proceso terminado", DialogsType.Info);
            }
            else
            {
                Dialogs.Show("No se encontraron Ordenes de Trabajo en este periodo", DialogsType.Info);
            }
            Cursor.Current = Cursors.Default;
        }

        private void tbOrdenTrabajo_TextChanged(object sender, EventArgs e)
        {
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo, dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }

        private void dtpFechaI_ValueChanged(object sender, EventArgs e)
        {
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo, dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }

        private void dtpFechaF_ValueChanged(object sender, EventArgs e)
        {
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo, dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }
    }
}
