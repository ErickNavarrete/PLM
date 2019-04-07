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
    public partial class InseamVista : MetroForm
    {
        private Controlador.InseamController Inseam;
        public Controlador.BitacoradeEventosController Bitacora;
        private int flag = 0;

        public InseamVista()
        {
            InitializeComponent();
            Inseam = new Controlador.InseamController();
            Bitacora = new Controlador.BitacoradeEventosController(); 
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Inseam.InseamSelect(txtIdInseam, txtDescripcion, id);
            }
        }
     

        public void clearTxt()
        {
            txtIdInseam.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = Inseam.DeleteInseam(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el Inseam", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdInseam.Text = string.Empty;
                        Inseam.Inseam(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Inseam";
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
                Inseam.BuscarInseam(descrip, dtDatos);
                if (dtDatos.Rows.Count>0)
                {
                string idcatalogo3;
                idcatalogo3 = "Consulta de un Inseam";
                Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);        
            }
                else
                {
                    Inseam.Inseam(dtDatos);
                  
                }
            }
            else
            {
                Inseam.Inseam(dtDatos);
              
            }
        }

        private void InseamVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Inseam.Inseam(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
           
        }

        private void txtIdInseam_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdInseam.Text;
            Inseam.Existe(Exist);
            if (Inseam.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdInseam.Text = string.Empty;
                txtIdInseam.Focus();
            }
            else
            {


            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idInseam, descrip;
                    if (txtIdInseam.Text != string.Empty && txtDescripcion.Text != string.Empty && Inseam.Existe(txtIdInseam.Text) == false)
                    {
                        idInseam = txtIdInseam.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Inseam.AddInseam(idInseam, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Inseam", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdInseam.Text = string.Empty;
                            Inseam.Inseam(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Inseam";
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
                    string idInseam, descrip;
                    int id;
                    if (txtIdInseam.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idInseam = txtIdInseam.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Inseam.UpdateInseam(idInseam, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el Inseam", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdInseam.Text = string.Empty;
                            Inseam.Inseam(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Inseam";
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
                    Inseam.BuscarInseam(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {
                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Inseam";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Inseam.Inseam(dtDatos);

                    }
                }
                else
                {
                    Inseam.Inseam(dtDatos);

                }
            
            }
        }
    }
}
