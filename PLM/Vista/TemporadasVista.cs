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
    public partial class TemporadasVista : MetroForm
    {
        private Controlador.TemporadasController Temporadas;
        public Controlador.BitacoradeEventosController Bitacora;
        private int flag = 0; 

        public TemporadasVista()
        {
            InitializeComponent();
            Temporadas = new Controlador.TemporadasController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Temporadas.TemporadasSelect(txtIdTemporadas, txtDescripcion, id);
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
                    bool resultado = Temporadas.DeleteTemporadas(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " la Temporada", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdTemporadas.Text = string.Empty;
                        Temporadas.Temporadas(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de una Temporada";
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
                Temporadas.BuscarTemporadas(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                  
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de una Temporada";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                  
                    Temporadas.Temporadas(dtDatos);
                }
               }
            else
            {
              
                Temporadas.Temporadas(dtDatos);
            }
        }

        private void txtIdTemporadas_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdTemporadas.Text;
            Temporadas.Existe(Exist);
            if (Temporadas.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdTemporadas.Text = string.Empty;
                txtIdTemporadas.Focus();
            }
            else
            {


            }
        }

        private void TemporadasVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            // GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Temporadas.Temporadas(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
             
        }
       

        public void clearTxt()
        {
            txtIdTemporadas.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idTemporadas, descrip;
                    if (txtIdTemporadas.Text != string.Empty && txtDescripcion.Text != string.Empty && Temporadas.Existe(txtIdTemporadas.Text) == false)
                    {
                        idTemporadas = txtIdTemporadas.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Temporadas.AddTemporadas(idTemporadas, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " la Temporada", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdTemporadas.Text = string.Empty;
                            Temporadas.Temporadas(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de una Temporada";
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
                    string idTemporadas, descrip;
                    int id;
                    if (txtIdTemporadas.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idTemporadas = txtIdTemporadas.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = Temporadas.UpdateTemporadas(idTemporadas, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " la Temporada", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdTemporadas.Text = string.Empty;
                            Temporadas.Temporadas(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de una Temporada";
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

            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
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
                    Temporadas.BuscarTemporadas(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de una Temporada";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {

                        Temporadas.Temporadas(dtDatos);
                    }
                }
                else
                {

                    Temporadas.Temporadas(dtDatos);
                }
            
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
