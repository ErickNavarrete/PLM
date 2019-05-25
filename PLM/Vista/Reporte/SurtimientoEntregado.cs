using ArcangelDialogs;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM.Vista.Reporte
{
    public partial class SurtimientoEntregado : MetroForm
    {
        private Controlador.ResurtimientoController Res;
        private Controlador.SurtimientoEntregadoController Sur;

        public SurtimientoEntregado()
        {
            InitializeComponent();
            Res = new Controlador.ResurtimientoController();
            Sur = new Controlador.SurtimientoEntregadoController();
        }

        private void SurtimientoEntregado_Load(object sender, EventArgs e)
        {
            Sur.GetClientes(cbClientes);
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo, dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }

        private void tbOrdenTrabajo_TextChanged(object sender, EventArgs e)
        {
            Res.PutWonbr(clbOrdenTrabajo, tbOrdenTrabajo,dtpFechaI.Value.ToString("yyyy-MM-dd"), dtpFechaF.Value.ToString("yyyy-MM-dd"));
        }

        private void btnPrintRep_Click(object sender, EventArgs e)
        {
            string cliente = Res.GetIdCliente(cbClientes.Text);
            this.pbResurtimiento.Value = 0;

            if (!Sur.GetReporte(dtpFechaI.Value, dtpFechaF.Value, cliente, this.pbResurtimiento, clbOrdenTrabajo, this.Cursor))
            {
                Dialogs.Show("Sin datos por mostrar", DialogsType.Info);
            }
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
