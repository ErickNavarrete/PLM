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
using MetroFramework;
using ArcangelDialogs;

namespace PLM.Vista.BOM
{
    public partial class ConsultaBomCosteado : MetroForm
    {
        private Controlador.EstilosdeProduccionController Estilos;
        private Controlador.BOMController Bom;
        string snotas;
        int flagEstado = 0;
        public ConsultaBomCosteado()
        {
            InitializeComponent();
            Estilos = new Controlador.EstilosdeProduccionController();
            Bom = new Controlador.BOMController();
           
        }

        private void txtNroBom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(18);
                frmBusqueda.ShowDialog();
                if (frmBusqueda.dato != string.Empty && frmBusqueda.dato1 != string.Empty)
                {
                    if (Bom.BuscarCurr(frmBusqueda.dato1))
                    {
                        txtNroBom.Text = frmBusqueda.dato;
                        txtEstilo.Text = frmBusqueda.dato1;
                        Bom.VerificarEstadoCierre(txtNroBom.Text, txtEstilo.Text, lblStatus, lblEtapa);
                        Bom.CargarDatosPOH(txtNroBom.Text, txtEstilo.Text, txtHilos, txtPO,snotas,txtHilos);
                        Bom.CargarDatos(DtBOM, frmBusqueda.dato, "N");
                        int estado;
                        estado = Bom.VerificarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "N");
                        flagEstado = estado;
                        if (estado < 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado0;
                        }
                        if (estado == 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado2;
                        }

                        if (estado > 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado3;
                        }
                        groupBox1.Enabled = true;
                      
                    }
                    else if (Bom.BuscarCurr(frmBusqueda.dato1) == false)
                    {
                        txtNroBom.Text = frmBusqueda.dato;
                        txtEstilo.Text = frmBusqueda.dato1;
                        Bom.VerificarEstadoCierre(txtNroBom.Text, txtEstilo.Text, lblStatus, lblEtapa);
                        Bom.CargarDatosPOH(txtNroBom.Text, txtEstilo.Text, txtHilos, txtPO,snotas,txtHilos);
                        Bom.CargarDatos(DtBOM, frmBusqueda.dato, "E");
                        int estado;
                        estado = Bom.VerificarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "E");
                        flagEstado = estado;
                        if (estado < 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado0;
                        }
                        if (estado == 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado2;
                        }

                        if (estado > 1)
                        {
                            pbEstadoThread.Image = Properties.Resources.estado3;
                        }
                        groupBox1.Enabled = true;                   
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtEstilo.Text == string.Empty)
            {
                Dialogs.Show("Debe realizar la busqueda de un bom para poder ver el detalle)", DialogsType.Info);
            }
            else
            {
                string estiloI = txtEstilo.Text;
                DetailBomVista frm = new DetailBomVista(estiloI);
                frm.ShowDialog();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtNroBom.Text != string.Empty)
            {
                BomNotas frm = new BomNotas(snotas);
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Show("Debe consultar el Bom para observar el detalle de usuario", DialogsType.Error);
            }
        }

        private void btnConsultaHilos_Click(object sender, EventArgs e)
        {
            if (txtEstilo.Text != string.Empty && txtNroBom.Text != string.Empty)
            {
                if (Bom.BuscarCurr(txtEstilo.Text) == true && flagEstado == 0)
                {
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "N", 0);
                    frm.ShowDialog();
                }
                else if (Bom.BuscarCurr(txtEstilo.Text) == true && flagEstado >= 1)
                {
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "N", flagEstado);
                    frm.ShowDialog();
                }
                ///Actualizar Hilo
                if (Bom.BuscarCurr(txtEstilo.Text) == false && flagEstado == 0)
                {
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "E", 0);
                    frm.ShowDialog();
                }
                else if (Bom.BuscarCurr(txtEstilo.Text) == false && flagEstado >= 1)
                {
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "E", flagEstado);
                    frm.ShowDialog();
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DataTable[] dtBoms = Bom.ExportarDatosCosteado(DtBOM, txtNroBom.Text, txtEstilo.Text);
            string[] datosConsultaBom = new string[3];
            if (dtBoms != null)
            {
                datosConsultaBom[0] = txtNroBom.Text;
                datosConsultaBom[1] = lblEtapa.Text;
                datosConsultaBom[2] = lblStatus.Text;
                Reporte.vistaReporte viewReport = new Reporte.vistaReporte(2);
                viewReport.datos = dtBoms;
                viewReport.datosConsultaBOM = datosConsultaBom;
                viewReport.ShowDialog();
            }
            else
            {
                ///
            }
        }

        private void ConsultaBomCosteado_Load(object sender, EventArgs e)
        {

        }
    }
}
