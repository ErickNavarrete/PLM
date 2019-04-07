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
using PLM.Clases;
using System.IO;
using ArcangelDialogs;

namespace PLM.Vista
{
    public partial class ConfigConexionVista : MetroForm
    {               
        public ConfigConexionVista()
        {
            InitializeComponent();
            string path = Path.GetFullPath("Conexion.ini");
            ConfigIni config = new Clases.ConfigIni(path);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if(txtServidor.Text != string.Empty && txtBd.Text != string.Empty && txtUsuario.Text != string.Empty && txtClave.Text != string.Empty)
            if(txtServidor.Text != string.Empty && txtBd.Text != string.Empty)
            {
                string path = Path.GetFullPath("Conexion.ini");
                ConfigIni config = new Clases.ConfigIni(path);
                config.EscribirValores("Conexion", "Host", txtServidor.Text.Trim());
                config.EscribirValores("Conexion", "Bd", txtBd.Text.Trim());
                config.EscribirValores("Conexion", "Id", txtUsuario.Text.Trim());
                config.EscribirValores("Conexion", "Password", txtClave.Text.Trim());
                ConfigIni PropiedadesConexion = new ConfigIni(path);
                Dialogs.Show("Conexión modificada exitosamente", DialogsType.Info);
                this.Close();
            }
            else
            {
                Dialogs.Show("Debes rellenar todos los campos", DialogsType.Info);
            }
        }

        private void ConfigConexionVista_Load(object sender, EventArgs e)
        {
            string path = Path.GetFullPath("Conexion.ini");
            ConfigIni config = new Clases.ConfigIni(path);
            txtServidor.Text = config.LeerValores("Conexion", "Host").ToString();
            txtBd.Text = config.LeerValores("Conexion", "Bd");
            txtUsuario.Text = config.LeerValores("Conexion", "Id");
            txtClave.Text = config.LeerValores("Conexion", "Password");                     
        }
    }
}
