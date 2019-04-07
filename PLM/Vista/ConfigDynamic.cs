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
    public partial class ConfigDynamic : MetroForm
    {
        public ConfigDynamic()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtServidor.Text != string.Empty && txtBd.Text != string.Empty && txtUsuario.Text != string.Empty && txtClave.Text != string.Empty)
            {
                string path = Path.GetFullPath("Conexion.ini");
                ConfigIni config = new Clases.ConfigIni(path);
                config.EscribirValores("Dynamic", "Host", txtServidor.Text.Trim());
                config.EscribirValores("Dynamic", "Bd", txtBd.Text.Trim());
                config.EscribirValores("Dynamic", "Id", txtUsuario.Text.Trim());
                config.EscribirValores("Dynamic", "Password", txtClave.Text.Trim());
                ConfigIni PropiedadesConexion = new ConfigIni(path);
                this.Close();
            }
            else
            {
                Dialogs.Show("Debes rellenar todos los campos", DialogsType.Info);
            }
        }

        private void ConfigDynamic_Load(object sender, EventArgs e)
        {
            string path = Path.GetFullPath("Conexion.ini");
            ConfigIni config = new Clases.ConfigIni(path);
            txtServidor.Text = config.LeerValores("Dynamic", "Host").ToString();
            txtBd.Text = config.LeerValores("Dynamic", "Bd");
            txtUsuario.Text = config.LeerValores("Dynamic", "Id");
            txtClave.Text = config.LeerValores("Dynamic", "Password");                                         
        }
    }
}
