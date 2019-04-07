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

namespace PLM.Vista.Busqueda
{
    public partial class Input : MetroForm
    {
        public string dato;
        public int consulta;
        string i;

        public Input(int _consulta,string _i)
        {
            InitializeComponent();
            consulta = _consulta;
            i = _i;
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (consulta == 28 || consulta == 41 || consulta == 43)
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
                {
                    e.Handled = true;
                    return;
                }                               
            }            
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text != string.Empty)
            {
                dato =  metroTextBox1.Text.Trim();
                this.Close();
            }
            else
            {
                Dialogs.Show("Debe rellenar los campos", DialogsType.Info);
            }
        }

        private void Input_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = i; 
        }

        private void Input_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (metroTextBox1.Text == string.Empty)
            {
                dato = i;
            }
            else
            {
                dato = metroTextBox1.Text.Trim();                
            }
        }        
    }
}
