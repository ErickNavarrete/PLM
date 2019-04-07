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
    public partial class ProcesosVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora; 
        private Controlador.ProcesosController Procesos;
        private int flag = 0;

        public ProcesosVista()
        {
            InitializeComponent();
            Procesos = new Controlador.ProcesosController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Procesos.ProcesosSelect(txtIdProcesos,txtDescripcion, id); 
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
                       bool resultado = Procesos.DeleteProcesos(id);
                       if (resultado == true)
                       {
                           Dialogs.Show(Properties.Resources.Eliminar + " el Proceso", DialogsType.Info);
                           txtDescripcion.Text = string.Empty;
                           txtIdProcesos.Text = string.Empty;
                           Procesos.Procesos(dtDatos);
                           string idcatalogo2;
                           idcatalogo2 = "Eliminación de un Proceso";
                           Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                       }
                   }
               }
        }

    
        public void clearTxt()
        {
            txtIdProcesos.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             if (txtBusqueda.Text != string.Empty)
            {  
                string descrip = txtBusqueda.Text;
                Procesos.BuscarProcesos(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                   
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Proceso";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Procesos.Procesos(dtDatos);
                 
                }
               }
            else
            {
                Procesos.Procesos(dtDatos);
       
            }
        }
     
        private void ProcesosVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            // GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Procesos.Procesos(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idProcesos, descrip;
                    if (txtIdProcesos.Text != string.Empty && txtDescripcion.Text != string.Empty && Procesos.Existe(txtIdProcesos.Text) == false && Procesos.ExisteD(txtDescripcion.Text) == false)
                    {
                        idProcesos = txtIdProcesos.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Procesos.AddProcesos(idProcesos, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Proceso", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdProcesos.Text = string.Empty;
                            Procesos.Procesos(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Proceso";
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
                    string idProcesos, descrip;
                    int id;
                    if (txtIdProcesos.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idProcesos = txtIdProcesos.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Procesos.UpdateProcesos(idProcesos, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el Proceso", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdProcesos.Text = string.Empty;
                            Procesos.Procesos(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Proceso";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                            

                        }
                    }
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    Procesos.BuscarProcesos(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Proceso";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Procesos.Procesos(dtDatos);

                    }
                }
                else
                {
                    Procesos.Procesos(dtDatos);

                }
            }
        }
    }
}

