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
    public partial class SegmentosVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.SegmentoController Segmento;
        private int flag = 0; 

        public SegmentosVista()
        {
            InitializeComponent();
            Segmento = new Controlador.SegmentoController();
            Bitacora = new Controlador.BitacoradeEventosController(); 
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Segmento.SegmentoSelect(txtIdSegmento, txtDescripcion, txtSecuenciaSegmento, txtTiempoDeEspera, id);
            }
        }

     

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    if(Segmento.EliminarSegmento(dtDatos.CurrentRow.Cells[1].Value.ToString()) == false)
 
                    {
                        int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        bool resultado = Segmento.DeleteSegmento(id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Eliminar + " el Segmento", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdSegmento.Text = string.Empty;             
                            txtTiempoDeEspera.Text = string.Empty;
                            txtSecuenciaSegmento.Text = string.Empty;
                            Segmento.Segmento(dtDatos);
                            string idcatalogo2;
                            idcatalogo2 = "Eliminación de un Segmento";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);          
                      }
                   }
                    else 
                    {
                        Dialogs.Show("Existen trims asignados a este segmento o Boms abiertos con este segmento involucrado", DialogsType.Error);
                    }
                }
             }
          }

          
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
                Segmento.BuscarSegmento(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Segmento";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Segmento.Segmento(dtDatos);
                  
                }
            }
            else
            {
                Segmento.Segmento(dtDatos);
              
            }
        }

       

        public void clearTxt()
        {
            txtIdSegmento.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSecuenciaSegmento.Text = string.Empty;
            txtTiempoDeEspera.Text = string.Empty;
        }
     
        private void SegmentosVista_Load_1(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            // GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Segmento.Segmento(dtDatos);
               dtDatos.Enabled = true;
               btnAlta.Enabled = true;
               btnEliminar.Enabled = true;
                               
        }

        private void txtIdSegmento_Leave(object sender, EventArgs e)
        { 
            string Exist;
            Exist = txtIdSegmento.Text;
            Segmento.Existe(Exist);
            if (Segmento.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdSegmento.Text = string.Empty;
                txtIdSegmento.Focus(); 
            }
            else 
            {
                

            } 
        }

        private void txtSecuenciaSegmento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) )
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTiempoDeEspera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtSecuenciaSegmento_Leave(object sender, EventArgs e)
        {
            int Exist;
            if (txtSecuenciaSegmento.Text != string.Empty)
            {
                Exist = int.Parse(txtSecuenciaSegmento.Text);
                Segmento.ExisteSec(Exist);

                if (Segmento.ExisteSec(Exist))
                {
                    Dialogs.Show("La secuencia que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                    txtSecuenciaSegmento.Text = string.Empty;
                    txtSecuenciaSegmento.Focus();
                }
                else
                {


                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idSegmento, descrip, TiempoDeEspera, SecuenciaSegmento;

                    if (txtIdSegmento.Text != string.Empty && txtDescripcion.Text != string.Empty && txtSecuenciaSegmento.Text != string.Empty && txtTiempoDeEspera.Text != string.Empty && Segmento.Existe(txtIdSegmento.Text) == false && Segmento.ExisteSec(int.Parse(txtSecuenciaSegmento.Text)) == false)
                    {

                        idSegmento = txtIdSegmento.Text;
                        descrip = txtDescripcion.Text;
                        SecuenciaSegmento = txtSecuenciaSegmento.Text;
                        TiempoDeEspera = txtTiempoDeEspera.Text;
                        bool resultado = Segmento.AddSegmento(idSegmento, descrip, SecuenciaSegmento, TiempoDeEspera);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Segmento", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdSegmento.Text = string.Empty;
                            txtSecuenciaSegmento.Text = string.Empty;
                            txtTiempoDeEspera.Text = string.Empty;
                            Segmento.Segmento(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Segmento";
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
                        string idSegmento, descrip, TiempoDeEspera, SecuenciaSegmento;
                        int id;
                        if (txtIdSegmento.Text != string.Empty && txtDescripcion.Text != string.Empty && txtSecuenciaSegmento.Text != string.Empty && txtTiempoDeEspera.Text != string.Empty)
                        {
                            id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                            idSegmento = txtIdSegmento.Text;
                            descrip = txtDescripcion.Text;
                            SecuenciaSegmento = txtSecuenciaSegmento.Text;
                            TiempoDeEspera = txtTiempoDeEspera.Text;
                            bool resultado = Segmento.UpdateSegmento(idSegmento, descrip, SecuenciaSegmento, TiempoDeEspera, id);
                            if (resultado == true)
                            {
                                Dialogs.Show(Properties.Resources.Editar + " el Segmento", DialogsType.Info);
                                txtDescripcion.Text = string.Empty;
                                txtIdSegmento.Text = string.Empty;
                                txtSecuenciaSegmento.Text = string.Empty;
                                txtTiempoDeEspera.Text = string.Empty;
                                Segmento.Segmento(dtDatos);
                                string idcatalogo1;
                                idcatalogo1 = "Actualización de un Segmento";
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
                    Segmento.BuscarSegmento(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Segmento";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Segmento.Segmento(dtDatos);

                    }
                }
                else
                {
                    Segmento.Segmento(dtDatos);

                }
            }
        }
    }
}
