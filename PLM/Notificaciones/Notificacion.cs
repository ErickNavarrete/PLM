using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace PLM.Notificaciones
{
    public partial class Notificacion : MetroForm
    {
        Controlador.BOMController Bom;
        private int interval = 0;

        public Notificacion()
        {
            InitializeComponent();
            Bom = new Controlador.BOMController();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            _close.Start();
        }

        private void show_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval;
                interval += 2;
            }
            else
            {
                show.Stop();
            }
        }

        private void _close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.2;

            }
            else
            {
                this.Close();
            }
        }

        private void Notificacion_Load(object sender, EventArgs e)
        {
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - (this.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 200);            
            show.Start();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int sum;
            sum = 34;
            Vista.Busqueda.Busqueda frmBusqueda = new Vista.Busqueda.Busqueda(sum);
            frmBusqueda.ShowDialog();                        
        }

    }
}
