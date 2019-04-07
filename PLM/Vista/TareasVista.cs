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
using ArcangelDialogs;
namespace PLM.Vista
{
    public partial class TareasVista : MetroForm
    {
        public Controlador.TareaController Tarea;
        
        public TareasVista()
        {
            InitializeComponent();
            Tarea = new Controlador.TareaController();
        }

        private void dtDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dtDatos.CurrentRow.Cells[0].Value.ToString();
            txtBusqueda.Text = id;
          Tarea.BuscarTareaU(id, dtDatos);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty && checkBox1.Checked == false)
            {
                if (checkBox2.Checked == false)
                {
                   Tarea.BuscarTareaU(txtBusqueda.Text, dtDatos);
                }
                else if (checkBox2.Checked == true)
                {
                  Tarea.BuscarTareaF(txtBusqueda.Text, dateTimePicker1.Value, dtDatos);
                  txtBusqueda.Text = string.Empty; 
                }
            }
            else if (txtBusqueda.Text == string.Empty && checkBox1.Checked == true)
            {
               Tarea.MostrarTareas(dtDatos);
            }
            else
            {
                {
                    DialogsResults respuesta = Dialogs.Show("Desea consultar los usuarios con eventos existentes?", DialogsType.Question);
                    if (respuesta == DialogsResults.Yes)
                    {
                       Tarea.BuscarTareafiltro(dtDatos);
                    }
                }
            }
        }

        private void TareasVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
        }
    }
}
