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
using System.IO;
using ArcangelDialogs;
using PLM.Controlador;

namespace PLM.Vista
{
    public partial class LoginVista : Form
    {
        private Clases.ConfigIni PropiedadesConexion; 
        private UsuarioController controlador;

        public LoginVista()
        {
            InitializeComponent();
            PropiedadesConexion = new Clases.ConfigIni(Path.GetFullPath("Conexion.ini"));
            controlador = new UsuarioController();            
        }

        private void pbxSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            GC.Collect();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            Login();
        }

        private void LoginVista_Load(object sender, EventArgs e)
        {
            GLOBALS.ObtenerIP();
            GLOBALS.ObtenerMAC();
        }

        private void pbxConfig_Click(object sender, EventArgs e)
        {
            Vista.ConfigConexionVista view = new ConfigConexionVista();
            view.ShowDialog();            
        }

        private void OkLogin(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }            
        }

        private void Login()
        {
            if(txtUser.Text != string.Empty && txtPass.Text != string.Empty)
            {
                string departamento = string.Empty;
                bool result = controlador.LoginUser(txtUser.Text, txtPass.Text, out departamento);
                if(result == true)
                {
                    GLOBALS.USUARIO = txtUser.Text.Trim();
                    GLOBALS.DEPARTAMENTO = departamento;
                    Vista.MenuPrincipalVista view = new MenuPrincipalVista();
                    view.Show();
                    this.Hide();
                }               
            }
            else
            {
                Dialogs.Show("Debe rellenar todos los campos", DialogsType.Info);
            }           
        }

        private void pbxOjo_MouseHover(object sender, EventArgs e)
        {
            txtPass.isPassword = false;
        }

        private void pbxOjo_MouseLeave(object sender, EventArgs e)
        {
            txtPass.isPassword = true;
        }

        private void txtPass_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
