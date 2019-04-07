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
    public partial class CategoryDosVista : MetroForm
    {
        private Controlador.CategoryDosController CategoryDos;
        public Controlador.BitacoradeEventosController Bitacora;
        private int flag = 0; 
        public CategoryDosVista()
        { 
            InitializeComponent();
            CategoryDos = new Controlador.CategoryDosController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                CategoryDos.CategoryDosSelect(txtIdCategoryDos, txtDescripcion, id);
            }
        }

        private void CategoryDosVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            CategoryDos.CategoryDos(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
           
        }

       

      

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
             DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
             if (respuesta == DialogsResults.Yes)
             {
                 if (dtDatos.Rows.Count > 0)
                 {
                     int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                     bool resultado = CategoryDos.DeleteCategoryDos(id);
                     if (resultado == true)
                     {
                         Dialogs.Show(Properties.Resources.Eliminar + " el Category-2", DialogsType.Info);
                         txtDescripcion.Text = string.Empty;
                         txtIdCategoryDos.Text = string.Empty;
                         CategoryDos.CategoryDos(dtDatos);
                         string idcatalogo2;
                         idcatalogo2 = "Eliminación de un Category - 2";
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
                CategoryDos.BuscarCategoryDos(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                    string idcatalogo3;
                    
                    idcatalogo3 = "Consulta de un Category - 2";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    CategoryDos.CategoryDos(dtDatos);
                  
                }
               }
            else
            {
                CategoryDos.CategoryDos(dtDatos);
                
            }
        }

        private void txtIdCategoryDos_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdCategoryDos.Text;
            CategoryDos.Existe(Exist);
            if (CategoryDos.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdCategoryDos.Text = string.Empty;
                txtIdCategoryDos.Focus();
            }
            else
            {


            }
        }

    

        public void clearTxt()
        {
            txtIdCategoryDos.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idCategoryDos, descrip;
                    if (txtIdCategoryDos.Text != string.Empty && txtDescripcion.Text != string.Empty && CategoryDos.Existe(txtIdCategoryDos.Text) == false)
                    {
                        idCategoryDos = txtIdCategoryDos.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = CategoryDos.AddCategoryDos(idCategoryDos, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Category-2", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdCategoryDos.Text = string.Empty;
                            CategoryDos.CategoryDos(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Category - 2";
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
                string idCategoryDos, descrip;
                int id;
                if (txtIdCategoryDos.Text != string.Empty && txtDescripcion.Text != string.Empty)
                {
                    id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    idCategoryDos = txtIdCategoryDos.Text;
                    descrip = txtDescripcion.Text;
                    bool resultado = CategoryDos.UpdateCategoryDos(idCategoryDos, descrip, id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Editar + " el Category-2", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdCategoryDos.Text = string.Empty;
                        CategoryDos.CategoryDos(dtDatos);
                        string idcatalogo1;
                        idcatalogo1 = "Actualización de un Category - 2";
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
                    CategoryDos.BuscarCategoryDos(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {
                        string idcatalogo3;

                        idcatalogo3 = "Consulta de un Category - 2";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        CategoryDos.CategoryDos(dtDatos);

                    }
                }
                else
                {
                    CategoryDos.CategoryDos(dtDatos);

                }
            } 
        }
    }
}
