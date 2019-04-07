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
using PLM.Modelo;
using ArcangelDialogs;

namespace PLM.Vista
{
    public partial class MenuPrincipalVista : MetroForm
    {
        Controlador.NotificacionesController controlador;
        Controlador.DepartamentoController controladorDepart;
                            
        public MenuPrincipalVista()
        {
            InitializeComponent();
            controlador = new Controlador.NotificacionesController();
            controladorDepart = new Controlador.DepartamentoController();
        }

        private void MenuPrincipalVista_Load(object sender, EventArgs e)
        {
            lblIP.Text = "IP: " + GLOBALS.IP;
            lblMac.Text = "MAC Address: " + GLOBALS.MacAddress;
            lblHora.Text = "Fecha: " + DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");
            lblUsuario.Text = "Usuario: " + GLOBALS.USUARIO;            
            using (PLMContext db = new PLMContext())
            {
                var datosDepart = db.Departamentos.Where(x => x.Dthread == 1).Select(x => x).ToList().FirstOrDefault();
                if(datosDepart == null)
                {
                    controladorDepart.AddDepartamento("V001", "INGENIERIA", "1", 1);
                }                
            }                  
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Fecha: " + DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt");
        }

        private void MenuPrincipalVista_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
            GC.Collect();
        }

        private void segmentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SegmentosVista"] == null)
            {
                SegmentosVista frm = new SegmentosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void trimsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TrimsVista"] == null)
            {
                TrimsVista frm = new TrimsVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                 
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DepartamentoVista"] == null)
            {
                DepartamentosVista frm = new DepartamentosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }               
        }

        private void temporadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TemporadaVista"] == null)
            {
                TemporadasVista frm = new TemporadasVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }               
        }

        private void category2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["CategoryDosVista"] == null)
            {
                CategoryDosVista frm = new CategoryDosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void fitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FitVista"] == null)
            {
                FitVista frm = new FitVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void bodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["BodyVista"] == null)
            {
                BodyVista frm = new BodyVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void inseamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["InseamVista"] == null)
            {
                InseamVista frm = new InseamVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void empaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["EmpaqueVista"] == null)
            {
                EmpaqueVista frm = new EmpaqueVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ProcesosVista"] == null)
            {
                ProcesosVista frm = new ProcesosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void manoDeObraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ManoDeObraVista"] == null)
            {
                ManoDeObraVista frm = new ManoDeObraVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }               
        }
       
        private void estilosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["EstilosdeProduccionAM"] == null)
            {
                VistasEstilos.EstilosdeProduccionAM frm = new VistasEstilos.EstilosdeProduccionAM();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["UsuarioVista"] == null)
            {
                UsuarioVista frm = new UsuarioVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }              
        }

        private void dasYFaltantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SegundasVista"] == null)
            {
                SegundasVista frm = new SegundasVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void presupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["PresupuestosVista"] == null)
            {
                PresupuestosVista frm = new PresupuestosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void bitacoraDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["BitacoradeEventosVista"] == null)
            {
                BitacoradeEventosVista frm = new BitacoradeEventosVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["TareasVista"] == null)
            {
                TareasVista frm = new TareasVista();
                frm.Show();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }                
        }

        private void diasDeAnticipaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DiasFeriadosVista"] == null)
            {
                DiasAnticipacion frm = new DiasAnticipacion();
                frm.Show(); 
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }       
           
        }

        private void diasInhabilesYoFestivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["DiasAnticipacion"] == null)
            {
                DiasFeriadosVista frm = new DiasFeriadosVista();
                frm.Show(); 
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }       
           
        }

        private void registroBOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (Application.OpenForms["BOM"] == null)
            {
                BOM.BOM frm = new BOM.BOM();
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }       
           
        }

        private void conexiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ConfigDynamic"] == null)
            {
                Vista.ConfigDynamic view = new ConfigDynamic();
                view.ShowDialog();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }          
        }

        private void bOMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ConsultaBom"] == null)
            {
                BOM.ConsultaBom view = new  BOM.ConsultaBom() ;
                view.ShowDialog();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }   
        }

        private void bOMCosteadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ConsultaBomCosteado"] == null)
            {
                BOM.ConsultaBomCosteado view = new BOM.ConsultaBomCosteado();
                view.ShowDialog();
            }
            else
            {
                Dialogs.Show(Properties.Resources.Abierto, DialogsType.Info);
            }   
        }

        private void notificacionesShow_Tick(object sender, EventArgs e)
        {
            bool response = controlador.BuscarNotificacion();
            if(response)
            {
                Notificaciones.Notificacion notificacion = new Notificaciones.Notificacion();
                notificacionesShow.Enabled = false;
                pbxNotificacion.Image = Properties.Resources.Notification64pxRed;
                pbxNotificacion.Image.Tag = "rojo"; 
                notificacion.ShowDialog();                                
            }
        }

        private void pbxNotificacion_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbxNotificacion_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pbxNotificacion_Click(object sender, EventArgs e)
        {
            int sum;
            sum = 34;
            Vista.Busqueda.Busqueda frmBusqueda = new Vista.Busqueda.Busqueda(sum);
            frmBusqueda.ShowDialog(); 
        }

        private void CampanaTick_Tick(object sender, EventArgs e)
        {
            bool response = controlador.BuscarNotificacion(); //Notificacion 
            if (response)
            {
               LTick.Enabled = true ; 
            }
            else
            {                 
                LTick.Enabled = false;                
            }
        }

        private void LTick_Tick(object sender, EventArgs e)
        {
              if (pbxNotificacion.Image.Tag == "rojo") 
              { 
                  pbxNotificacion.Image = Properties.Resources.Notification64px;
                  pbxNotificacion.Image.Tag = "gris";
              }   
              else 
              {
                  pbxNotificacion.Image = Properties.Resources.Notification64pxRed;
                  pbxNotificacion.Image.Tag = "rojo";
              }
        }
    }
}

