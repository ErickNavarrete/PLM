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
            Res.GetReporte(dtpFechaI.Value, dtpFechaF.Value,"302");

            
            
        }
    }
}
