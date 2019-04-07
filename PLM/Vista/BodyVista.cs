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
    public partial class BodyVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.BodyController Body;
        private int flag = 0;

        public void  clearTxt() 
        {
            txtIdBody.Text = string.Empty; 
            txtDescripcion.Text = string.Empty;
        }

        public BodyVista()
        {
            InitializeComponent();
            Body = new Controlador.BodyController();
            Bitacora = new Controlador.BitacoradeEventosController();            
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Body.BodySelect(txtIdBody, txtDescripcion, id);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            flag = 0;
           
            dtDatos.Enabled = false;
            clearTxt();          
        }

     
        private void busqueda()
        {
            if (dtDatos.Rows.Count > 0)
            {
                btnAlta.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = false;
            }
        }
        private void deshacer_busqueda()
        {
            btnAlta.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
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
                    bool resultado = Body.DeleteBody(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el body", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdBody.Text = string.Empty;
                        Body.Body(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Body";
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
                Body.BuscarBody(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Body";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Body.Body(dtDatos);                   
                }
            }
            else
            {
                Body.Body(dtDatos);               
            }
        }

        private void BodyVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            Body.Body(dtDatos);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void txtIdBody_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdBody.Text;
            Body.Existe(Exist);
            if (Body.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe intente de nuevo", DialogsType.Info);
                txtIdBody.Text = string.Empty;
                txtIdBody.Focus();
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
                    string idBody, descrip;
                    if (txtIdBody.Text != string.Empty && txtDescripcion.Text != string.Empty && Body.Existe(txtIdBody.Text) == false)
                    {
                        idBody = txtIdBody.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Body.AddBody(idBody, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el body", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdBody.Text = string.Empty;
                            Body.Body(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Body";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                            flag = 0;
                        }
                    }
                }
            }
                else if (flag == 0)
                   {
                    DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                    if (respuesta == DialogsResults.Yes)
                    {
                        string idBody, descrip;
                        int id;
                        if (txtIdBody.Text != string.Empty && txtDescripcion.Text != string.Empty)
                        {
                            id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                            idBody = txtIdBody.Text;
                            descrip = txtDescripcion.Text;
                            bool resultado = Body.UpdateBody(idBody, descrip, id);
                            if (resultado == true)
                            {
                                Dialogs.Show(Properties.Resources.Editar + " el body", DialogsType.Info);
                                txtDescripcion.Text = string.Empty;
                                txtIdBody.Text = string.Empty;
                                Body.Body(dtDatos);
                                string idcatalogo1;
                                idcatalogo1 = "Actualización de un Body";
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

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAlta_Click_1(object sender, EventArgs e)
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
                    Body.BuscarBody(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {
                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Body";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Body.Body(dtDatos);
                    }
                }
                else
                {
                    Body.Body(dtDatos);
                }
            }
        }
    }
}
