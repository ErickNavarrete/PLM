using DevComponents.DotNetBar.Metro;
using PLM.Vista.Cotización;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM.Vista
{
    public partial class SimulacionCotizacion : MetroForm
    {
        int pantalla = 1;

        #region FUNCIONES
        private void hide_show_cu(UserControl cu)
        {
            cotizacion1.Visible = false;
            cotizacion2.Visible = false;
            cotizacion3.Visible = false;
            cotizacion4.Visible = false;
            cotizacion5.Visible = false;
            cotizacion6.Visible = false;

            cu.Visible = true;
        }
        private void control_uc(int pantalla)
        {
            switch (pantalla)
            {
                case 1:
                    hide_show_cu(cotizacion1);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = false;
                    break;
                case 2:
                    hide_show_cu(cotizacion2);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 3:
                    hide_show_cu(cotizacion3);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 4:
                    hide_show_cu(cotizacion4);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 5:
                    hide_show_cu(cotizacion5);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 6:
                    hide_show_cu(cotizacion6);
                    btnSiguiente.Visible = false;
                    btnAnterior.Visible = true;
                    break;
            }
        }
        #endregion

        public SimulacionCotizacion()
        {
            InitializeComponent();
            hide_show_cu(cotizacion1);
            pantalla = 1;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pantalla += 1;
            control_uc(pantalla);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pantalla -= 1;
            control_uc(pantalla);
        }
    }
}
