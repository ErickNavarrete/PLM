using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLM.Reportes;

namespace PLM.Vista.Reporte
{
    public partial class vistaReporte2 : Form
    {
        public int tipoReporte;

        public vistaReporte2()
        {
            InitializeComponent();
        }

        private void crv_Load(object sender, EventArgs e)
        {
            switch (tipoReporte)
            {
                case 1:
                    break;
            }
        }

        private void vistaReporte2_Load(object sender, EventArgs e)
        {

        }
    }
}
