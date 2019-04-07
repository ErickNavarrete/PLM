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
    public partial class ManoDeObraVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.ManodeObraController ManodeObra;
        private int flag = 0;
        public ManoDeObraVista()
        {
            InitializeComponent();
            ManodeObra = new Controlador.ManodeObraController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }
    

        public void clearTxt()
        {
            txtIdManoDeObra.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }
        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                ManodeObra.ManodeObraSelect(txtIdManoDeObra, txtDescripcion, id);
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
                    bool resultado = ManodeObra.DeleteManodeObra(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Agregar + "la Mano de Obra", DialogsType.Info);
                        txtDescripcion.Text = string.Empty;
                        txtIdManoDeObra.Text = string.Empty;
                        ManodeObra.ManodeObra(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de una Mano de Obra";
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
                ManodeObra.BuscarManodeObra(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                   
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de una Mano de Obra";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    ManodeObra.ManodeObra(dtDatos);
                  
                }
            } 
            else
            {
                ManodeObra.ManodeObra(dtDatos);
                
            }
        }

        private void ManoDeObraVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            ManodeObra.ManodeObra(dtDatos);
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
                    string idManodeObra, descrip;
                    if (txtIdManoDeObra.Text != string.Empty && txtDescripcion.Text != string.Empty && ManodeObra.Existe(txtIdManoDeObra.Text) == false && ManodeObra.ExisteD(txtDescripcion.Text) == false)
                    {
                        idManodeObra = txtIdManoDeObra.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = ManodeObra.AddManodeObra(idManodeObra, descrip);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " la Mano de Obra", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdManoDeObra.Text = string.Empty;
                            ManodeObra.ManodeObra(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de una Mano de Obra";
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
                    string idManodeObra, descrip;
                    int id;
                    if (txtIdManoDeObra.Text != string.Empty && txtDescripcion.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idManodeObra = txtIdManoDeObra.Text;
                        descrip = txtDescripcion.Text;
                        bool resultado = ManodeObra.UpdateManodeObra(idManodeObra, descrip, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " la mano de Obra", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdManoDeObra.Text = string.Empty;
                            ManodeObra.ManodeObra(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de una Mano de Obra";
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
                    ManodeObra.BuscarManodeObra(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de una Mano de Obra";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        ManodeObra.ManodeObra(dtDatos);

                    }
                }
                else
                {
                    ManodeObra.ManodeObra(dtDatos);

                }
            }
        }
    }
}
