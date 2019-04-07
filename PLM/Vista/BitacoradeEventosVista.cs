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
    public partial class BitacoradeEventosVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;

        public BitacoradeEventosVista()
        {
            InitializeComponent();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty && checkBox1.Checked == false)
            {
                if (checkBox2.Checked == false)
                {
                    Bitacora.BuscarBitacoradeEventoss(txtBusqueda.Text, dtDatos);
                }
                else if (checkBox2.Checked == true) 
                {
                    Bitacora.BuscarBitacoradeEventossF(txtBusqueda.Text, dateTimePicker1.Value, dtDatos);
                }
            }
            else if (txtBusqueda.Text == string.Empty && checkBox1.Checked == true)
            {
                Bitacora.BitacoradeEventos(dtDatos);
            }
            else
            {
                {
                    DialogsResults respuesta = Dialogs.Show("Desea consultar los usuarios con eventos existentes?", DialogsType.Question);
                    if (respuesta == DialogsResults.Yes)
                    {
                        Bitacora.BuscarBitacoradeEventossfiltro(dtDatos);
                    }
                }
            }
        }

        private void dtDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dtDatos.CurrentRow.Cells[0].Value.ToString();
            Bitacora.BuscarBitacoradeEventoss(id, dtDatos);           
        }

        private void BitacoradeEventosVista_Load(object sender, EventArgs e)
        {
            pnlMenu.Left = Screen.PrimaryScreen.Bounds.Width - (pnlMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
        }
    }
}