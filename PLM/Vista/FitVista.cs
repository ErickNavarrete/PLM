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
    public partial class FitVista : MetroForm
    {
        private Controlador.FitController fit;
        public Controlador.BitacoradeEventosController Bitacora;
        private int flag = 0;

        public FitVista()
        {            
            InitializeComponent(); 
            fit = new Controlador.FitController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

      

        public void clearTxt()
        {
            txtIdFit.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

      

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                fit.FitSelect(txtIdFit, txtDescripcion, id);
            }
        }
      
        private void FitVista_Load_1(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            fit.Fit(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
                fit.BuscarFit(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                   
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Fit";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    fit.Fit(dtDatos);
                  
                }
            }
            else
            {
                fit.Fit(dtDatos);
              
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = fit.DeleteFit(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el Fit", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdFit.Text = string.Empty;
                        fit.Fit(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Fit";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                    }
                }
            }
        }

        private void txtIdFit_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdFit.Text;
            fit.Existe(Exist);
            if (fit.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdFit.Text = string.Empty;
                txtIdFit.Focus();
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
                    string idFit, descrip;
                    if (txtIdFit.Text != string.Empty && txtDescripcion.Text != string.Empty && fit.Existe(txtIdFit.Text) == false)
                    {
                        idFit = txtIdFit.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = fit.AddFit(idFit, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Fit", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdFit.Text = string.Empty;
                            fit.Fit(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Fit";
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
                    string idFit, descrip;
                    int id;
                    if (txtIdFit.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idFit = txtIdFit.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = fit.UpdateFit(idFit, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el fit", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdFit.Text = string.Empty;
                            fit.Fit(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Fit";
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
                    fit.BuscarFit(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Fit";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        fit.Fit(dtDatos);

                    }
                }
                else
                {
                    fit.Fit(dtDatos);

                }
            }
        }
    }
}
