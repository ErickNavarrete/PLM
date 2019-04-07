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


namespace PLM.Vista.VistasEstilos
{ 
    public partial class EstilosdeProduccionAM : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        public Controlador.EstilosdeProduccionController Estilos; 

        public EstilosdeProduccionAM()
        {
            InitializeComponent();
            Estilos = new Controlador.EstilosdeProduccionController(); 
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void EstilosdeProduccionAM_Load(object sender, EventArgs e)
        {
           

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Desea crear un nuevo estilo? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes) 
            {
              EstilosdeProduccionVista frm = new EstilosdeProduccionVista(string.Empty,0);
              frm.ShowDialog();
              Estilos.EstilosdeProduccion(dtDatosPLM);
              Estilos.EstilosDynamicsBom(dtDatosDyn);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id = dtDatosPLM.CurrentRow.Cells[0].Value.ToString();
            bool resultado = Estilos.DeleteEstilosdeProduccion(id);
            if (resultado == true )
            {
                Dialogs.Show(Properties.Resources.Eliminar + " el Estilo de Producción", DialogsType.Info);               
                Estilos.EstilosdeProduccion(dtDatosPLM);
                string idcatalogo2 = string.Empty;
                idcatalogo2 = "Eliminación de un Estilo de Producción";
                Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);          
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int idPod = 0;       
            string id = string.Empty;          
            {
                if(rdioPLM.Checked && dtDatosPLM.Rows.Count > 0 )
                {
                    if (!string.IsNullOrEmpty(dtDatosPLM.CurrentRow.Cells[0].Value.ToString()))
                    {   string estilo;
                        estilo = dtDatosPLM.CurrentRow.Cells[0].Value.ToString();
                        if (Estilos.Existe(estilo) == false)
                        {
                            id = dtDatosPLM.CurrentRow.Cells[0].Value.ToString();
                            idPod = 1;
                            Cursor.Current = Cursors.Default;
                            EstilosdeProduccionVista frm = new EstilosdeProduccionVista(id, idPod);
                            frm.ShowDialog();
                        }
                        else
                        {
                            Dialogs.Show("El Estilo ya se encuentra registrado en el sistema", DialogsType.Error);
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(dtDatosDyn.CurrentRow.Cells[0].Value.ToString()))
                    {
                        string estilo;
                        estilo = dtDatosDyn.CurrentRow.Cells[0].Value.ToString();
                        if (Estilos.Existe(estilo) == false)
                        {
                            id = dtDatosDyn.CurrentRow.Cells[0].Value.ToString();
                            idPod = 2;
                            Cursor.Current = Cursors.Default;
                            EstilosdeProduccionVista frm = new EstilosdeProduccionVista(id, idPod);
                            frm.ShowDialog();
                        }
                        else 
                        {
                            Dialogs.Show("El Estilo ya se encuentra registrado en el sistema", DialogsType.Error);
                        }
                    }
                }
                Cursor.Current = Cursors.WaitCursor;
                Estilos.EstilosdeProduccion(dtDatosPLM);
                Estilos.EstilosDynamicsBom(dtDatosDyn);
               // rdioDynamics.Checked = false;
               // rdioPLM.Checked = true;
            }
            Cursor.Current = Cursors.Default;
        }

        private void rdioPLM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioPLM.Checked)
            {
                dtDatosPLM.Enabled = true;
                btnAlta.Enabled = true;
                btnEliminar.Enabled = true;
                btnActualizar.Enabled = true;
            }
            else
            {
                btnAlta.Enabled = false;
                btnEliminar.Enabled = false;
                btnActualizar.Enabled = false;
                dtDatosPLM.Enabled = false; 
            }
        }

        private void rdioDynamics_CheckedChanged(object sender, EventArgs e)
        {
            if (rdioDynamics.Checked)
            {
                dtDatosDyn.Enabled = true;
                btnActualizar.Enabled = true;
            }
            else
            {
                dtDatosDyn.Enabled = false;
                btnActualizar.Enabled = false; 
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstilosdeProduccionAM_Activated(object sender, EventArgs e)
        {

            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            Estilos.EstilosdeProduccion(dtDatosPLM);
            Estilos.EstilosDynamicsBom(dtDatosDyn);
            rdioDynamics.Checked = true;
            dtDatosDyn.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void dtDatosDyn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnActualizar_Click(sender,e);
        }
    } 
}        

