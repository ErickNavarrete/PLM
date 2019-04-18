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

namespace PLM.Vista.Reporte
{
    public partial class Resurtimiento : MetroForm
    {
        private Controlador.ResurtimientoController Res;

        public Resurtimiento()
        {
            InitializeComponent();
            Res = new Controlador.ResurtimientoController();
        }

        private void Resurtimiento_Load(object sender, EventArgs e)
        {
            Res.GetClientes(cbClientes);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string cliente = "";
            string c_cliente = "TODOS";

            if (chbOpcion.Checked == false)
            {
                c_cliente = cbClientes.Text.ToUpper();
                cliente = Res.GetIdCliente(cbClientes.Text);
            }

            this.pbResurtimiento.Value = 0;
            
            if (!Res.GetReporte(dtpFechaI.Value, dtpFechaF.Value, cliente, dtpFechaOC.Value, this.pbResurtimiento, c_cliente))
            {
                Dialogs.Show("Sin datos por mostrar", DialogsType.Info);
            }
        }

    }
}
