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
    public partial class DiasFeriadosVista : MetroForm
    {
        Controlador.BitacoradeEventosController Bitacora;
        Controlador.DiasFeriadoseInhabiles DiasF;
        
        public DiasFeriadosVista()
        {
            InitializeComponent();
            Bitacora = new Controlador.BitacoradeEventosController();
            DiasF = new Controlador.DiasFeriadoseInhabiles();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {            
            if( DiasF.ExisteDiasFeriadossF(txtBusqueda.Text,dateTimePicker1.Value) == false && txtBusqueda.Text != string.Empty) 
            {
                DiasF.AddDiaF(txtBusqueda.Text, dateTimePicker1.Value);
                DiasF.DiasF(txtBusqueda.Text, dtDatos);
                string idcatalogo1;
                idcatalogo1 = "Alta de un Dia Feriado";
                Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
            }
            else if (DiasF.ExisteDiasFeriadossF(txtBusqueda.Text, dateTimePicker1.Value) == true)
            {
                Dialogs.Show("El proveedor ya tiene asigando este dia como feriado o inhabil", DialogsType.Error);
            }
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                int sum;
                sum = 27;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                txtBusqueda.Text = frmBusqueda.dato;
                if (DiasF.ExisteDiasFeriadossP(frmBusqueda.dato))
                {
                    Dialogs.Show("El proveedor ya se encuentra registrado", DialogsType.Error);
                    txtBusqueda.Text = string.Empty;
                    DiasF.DiasF(txtBusqueda.Text, dtDatos);
                }
                DiasF.DiasF(txtBusqueda.Text, dtDatos);                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int sum;
            sum = 33;
            Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
            frmBusqueda.ShowDialog();
            txtBusqueda.Text = frmBusqueda.dato;
            DiasF.DiasF(txtBusqueda.Text, dtDatos); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
            bool resultado = DiasF.DeleteDiasF(id);
            if (resultado == true)
            {
                Dialogs.Show(Properties.Resources.Eliminar + " el dia feriado", DialogsType.Info);

                DiasF.DiasF(txtBusqueda.Text, dtDatos);
                string idcatalogo2;
                idcatalogo2 = "Eliminación de un Dia Feriado";
                Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
            }
        }

        private void DiasFeriadosVista_Load(object sender, EventArgs e)
        {
            pnlMenu.Left = Screen.PrimaryScreen.Bounds.Width - (pnlMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
        }
    }
}
