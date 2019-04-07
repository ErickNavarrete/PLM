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
    public partial class EmpaqueVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.EmpaqueController Empaque;
        private int flag = 0; 
        public EmpaqueVista()
        {
            InitializeComponent();
            Empaque = new Controlador.EmpaqueController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Empaque.EmpaqueSelect(txtIdEmpaque, txtDescripcion, id);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id;
                    id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = Empaque.DeleteEmpaque(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el empaque", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdEmpaque.Text = string.Empty;
                        Empaque.Empaque(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Empaque";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
                Empaque.BuscarEmpaque(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                    
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Empaque";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Empaque.Empaque(dtDatos);
                   
                }
               }
            else
            {
                Empaque.Empaque(dtDatos);
                
            }
        }
      
        private void EmpaqueVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Empaque.Empaque(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
          
        }

        private void txtIdEmpaque_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdEmpaque.Text;
            Empaque.Existe(Exist);
            if (Empaque.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdEmpaque.Text = string.Empty;
                txtIdEmpaque.Focus();
            }
            else
            {


            }
        }
       

        public void clearTxt()
        {
            txtIdEmpaque.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idEmpaque, descrip;
                    if (txtIdEmpaque.Text != string.Empty && txtDescripcion.Text != string.Empty && Empaque.Existe(txtIdEmpaque.Text) == false)
                    {
                        idEmpaque = txtIdEmpaque.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Empaque.AddEmpaque(idEmpaque, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el empaque", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdEmpaque.Text = string.Empty;
                            Empaque.Empaque(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Empaque";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                            flag = 0; 

                        }
                    }
                    else
                    {
                        Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                    }
                }
            }
            else if (flag == 0)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idEmpaque, descrip;
                    int id;
                    if (txtIdEmpaque.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idEmpaque = txtIdEmpaque.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Empaque.UpdateEmpaque(idEmpaque, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el empaque", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdEmpaque.Text = string.Empty;
                            Empaque.Empaque(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Empaque";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;

                        }
                    }
                    else
                    {
                        Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            dtDatos.Enabled = false;
            btnAlta.Enabled = false;
            btnEliminar.Enabled = false;
            clearTxt();
            flag = 1; 
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBusqueda.Text != string.Empty)
                {
                    string descrip = txtBusqueda.Text;
                    Empaque.BuscarEmpaque(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Empaque";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Empaque.Empaque(dtDatos);

                    }
                }
                else
                {
                    Empaque.Empaque(dtDatos);

                }
            }
        }
    }
}
