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
using System.IO;
using System.Diagnostics;
using ArcangelDialogs;

namespace PLM.Vista.BOM
{
    public partial class BOM : MetroForm
    {
        private Controlador.EstilosdeProduccionController Estilos;
        private Controlador.BOMController Bom;
        private int flag, flagEstado;
        private EncabezadoBom tempEncabezado;
        private TareaTemporal tempTarea;
        private List<TareaTemporal> listaTemporal;
        private string TemporalStream;
        private string snotas;
        private class TareaTemporal
        {
            public string segmento { get; set; }
            public string trim { get; set; }
            public string bom { get; set; }
            public string nacionalidad { get; set; }
            public int flagNota { get; set; }
        }

        private class EncabezadoBom
        {
            public string TC { get; set; }
            public string Estilo { get; set; }
            public string Nacional { get; set; }
            public string Usuario { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime UFM { get; set; }
            public int Revisiones { get; set; }
            public int Estado{ get; set; }
            public int Etapa { get; set; }
            public string PO { get; set; }
            public string Hilos { get; set; }
        }

        public BOM()
        {
            InitializeComponent();
            Estilos = new Controlador.EstilosdeProduccionController();
            Bom = new Controlador.BOMController();
            flag = 0;
            flagEstado = 0;
            //pbEstadoThread.Image.Tag = 0; 
        }

        private void BloquearObj()
        {
            btnGuardar.Visible = false;
            btnCancelar.Visible = false;
            btnGuardarBOM.Visible = true;
            btnCopiar.Visible = true;
            btnModificar.Visible = true;
            btnLiberar.Visible = true;
            btnReabrir.Visible = true;
            groupBox1.Enabled = false;
        }

        private void DesbloquearObj()
        {
            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
            btnGuardarBOM.Visible = false;
            btnCopiar.Visible = false;
            btnModificar.Visible = false;
            btnLiberar.Visible = false;
            btnReabrir.Visible = false;
            groupBox1.Enabled = true;
        }

        public void Limpiar()
        {
            txtNroBom.Text = string.Empty;
            txtPO.Text = string.Empty;
            txtSPO.Text = string.Empty;
            txtEstilo.Text = string.Empty;
            lblEtapa.Text = string.Empty;
            lblStatus.Text = string.Empty;
            DtBOM.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtEstilo.Text == string.Empty)
            {
                Dialogs.Show("Debe realizar la busqueda de un estilo ya existente (F3)", DialogsType.Info);
            }
            else
            {
                string estiloI = txtEstilo.Text;
                DetailBomVista frm = new DetailBomVista(estiloI);
                frm.ShowDialog();
            }
        }

        private void txtEstilo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(15);
                frmBusqueda.ShowDialog();
                txtEstilo.Text = frmBusqueda.dato.ToString();
                //busacmos el estilo para rellenar los campos
                int idPod = 1;
                String Estilo=frmBusqueda.dato.ToString();
                Controlador.EstilosdeProduccionController Estilos= new Controlador.EstilosdeProduccionController();
                Estilos.MostrarPLML(txtEstilo, lblDescr, LblCategoria, LblDivision, LblEstacion, LblCliente, LbLMarca, lblCategory2, txtEspec, LblFit, lblBody, LblLavado, lblInseam, Txtempaque, Estilo, idPod);           
            }
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            LblUsuario.Text=GLOBALS.USUARIO;
            lblInputDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblLasMod.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void DtBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Ncolumna = 0;
            Ncolumna = e.ColumnIndex;
            if (Ncolumna == 1)
            {
                TareaTemporal tempTask;
                var imagen = DtBOM.CurrentCell.Value;
                Image _imagen = (Image)imagen;
                string tempBom = txtNroBom.Text.Trim().Replace("N", "").Replace("E", "");
                string tempNacionalidad;
                if (txtNroBom.Text.Contains("N"))
                    tempNacionalidad = "N";
                else
                    tempNacionalidad = "E";
                switch ((int)_imagen.Tag)
                {
                    case 0:
                        DialogsResults result = Dialogs.Show("¿Desea cambiar el estado de la tarea?", DialogsType.Question);
                        if (result == DialogsResults.Yes)
                        {
                            _imagen = null;
                            _imagen = Properties.Resources.estado2;
                            _imagen.Tag = 1;
                            DtBOM.CurrentCell.Value = _imagen;
                            int flagNota;
                            if (DtBOM.CurrentRow.Cells[11].Value.ToString() == string.Empty)
                            {
                                flagNota = 0;
                            }
                            else
                            {
                                flagNota = 1;
                            }
                            tempTask = new TareaTemporal
                            {
                                segmento = DtBOM.CurrentRow.Cells[0].Value.ToString(),
                                trim = DtBOM.CurrentRow.Cells[2].Value.ToString(),
                                bom = tempBom,
                                nacionalidad = tempNacionalidad,
                                flagNota = flagNota
                            };
                            listaTemporal.Add(tempTask);
                            //Bom.Tasks(DtBOM.CurrentRow.Cells[0].Value.ToString(), DtBOM.CurrentRow.Cells[2].Value.ToString(), tempBom, tempNacionalidad, flagNota);
                        }
                        break;
                   
                }
                //if((int)_imagen.Tag == 2)
                //{
                //    DialogsResults result = Dialogs.Show("¿Desea cambiar el estado de la tarea?", DialogsType.Question);
                //    if (result == DialogsResults.Yes)
                //    {

                //    }
                //}
            }
            var imagen1 = DtBOM.CurrentRow.Cells[1].Value;
            Image _imagen1 = (Image)imagen1;

            if (Ncolumna == 4 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " ")))
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }
            }
            if (Ncolumna == 5 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " ")))
            {
                int sum;
                sum = Ncolumna - 5;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                DtBOM.CurrentCell.Value = frmBusqueda.dato;
            }
            if (Ncolumna == 3 && (int)_imagen1.Tag < 1 )
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                    Bom.Itemcode(frmBusqueda.dato, DtBOM);
                    
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }
            }
            if (Ncolumna == 7 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " ")))
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }
            }
            if (Ncolumna == 6 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " ")))
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
               
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }
            }
            if (Ncolumna == 10 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " " )) )
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }
            }
            if (Ncolumna == 9 && (int)_imagen1.Tag < 1 && ((DtBOM.CurrentCell.Value.ToString() == string.Empty || DtBOM.CurrentCell.Value.ToString() == " ")))
            {
                int sum;
                sum = Ncolumna + 20;
                string _temporal = DtBOM.CurrentCell.Value.ToString();
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(sum);
                frmBusqueda.ShowDialog();

                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    DtBOM.CurrentCell.Value = frmBusqueda.dato;
                }
                else
                {
                    DtBOM.CurrentCell.Value = _temporal;
                }                               
            }
            if (Ncolumna == 8 && (int)_imagen1.Tag < 1)
            {
                string dato2;
                if (DtBOM.Rows.Count > 0)
                {

                    dato2 = DtBOM.CurrentRow.Cells[8].Value.ToString(); 
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum,dato2);
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum, "0");
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                }
            }
            if (Ncolumna == 11 && (int)_imagen1.Tag < 1)
            {
                string dato2;
                if (DtBOM.Rows.Count > 0)
                {

                    dato2 = DtBOM.CurrentRow.Cells[11].Value.ToString();
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum, dato2);
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum, "");
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtEstilo.Text != string.Empty && txtSPO.Text != string.Empty && txtPO.Text != string.Empty)
            {
                flag = 0;
                DesbloquearObj();
                listaTemporal = new List<TareaTemporal>();
                int codigo = 1;
                string codigoF;
                codigoF = string.Format("{0:000000}", codigo);
                if (txtEstilo.Text != string.Empty)
                {
                    if (Bom.BuscarCurr(txtEstilo.Text))
                    {
                        Boolean flags = true;
                        do
                        {
                            if (Bom.ExisteBom(codigoF, "N") == true)
                            {
                                flags = true;
                                codigo = codigo + 1;
                                codigoF = string.Format("{0:000000}", codigo);
                            }
                            else
                            {
                                flags = false;
                            }
                        } while (flags != false);                        
                        tempEncabezado = new EncabezadoBom
                        {
                            TC = codigoF,
                            Estilo = txtEstilo.Text,
                            Nacional = "N",
                            Usuario = GLOBALS.USUARIO,
                            Fecha = DateTime.Now,
                            UFM = DateTime.Now,
                            Revisiones = 0,
                            Estado = 0,
                            Etapa = 0,
                            PO = txtPO.Text,
                            Hilos = txtSPO.Text
                        };
                        txtNroBom.Text = "N" + codigoF;
                        lblEtapa.Text = "Registrado";
                        lblStatus.Text = "Abierto";
                       
                    }
                    else
                    {
                        Boolean flags = true;
                        do
                        {
                            if (Bom.ExisteBom(codigoF, "E") == true)
                            {
                                flags = true;
                                codigo = codigo + 1;
                                codigoF = string.Format("{0:000000}", codigo);
                            }
                            else
                            {
                                flags = false;
                            }
                        } while (flags != false);                       
                        tempEncabezado = new EncabezadoBom
                        {
                            TC = codigoF,
                            Estilo = txtEstilo.Text,
                            Nacional = "E",
                            Usuario = GLOBALS.USUARIO,
                            Fecha = DateTime.Now,
                            UFM = DateTime.Now,
                            Revisiones = 0,
                            Estado = 0,
                            Etapa = 0,
                            PO = txtPO.Text,
                            Hilos = txtSPO.Text
                        };
                        txtNroBom.Text = "E" + codigoF;
                        lblEtapa.Text = "Registrado";
                        lblStatus.Text = "Abierto";
                    }
                    
                    Bom.CargarDatos(DtBOM);
                    Dialogs.Show("Se ha registrado un nuevo Nº BOM exitosamente, puede proceder a rellenar datos de tareas", DialogsType.Info);
                }
                else
                {
                    Dialogs.Show("Existen Campos Vacios o Datos Erroneos", DialogsType.Error);
                }
            }
            else
            {
                Dialogs.Show("Existen Campos Vacios o Datos Erroneos", DialogsType.Error);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string aux = "";
            if (Bom.BuscarCurr(txtEstilo.Text))
            {
                aux = "N";
            }
            else
            {
                aux = "E";
            }

            if (flag == 0 )
            {
                //
            PLM.Modelo.Boms bom = new Modelo.Boms();

                bom.NroBom=txtNroBom.Text;
                bom.NumeroRevisiones = int.Parse(lblRevisiones.Text);
                bom.PO = txtPO.Text;
                bom.SPO = txtSPO.Text;
                bom.usuario = LblUsuario.Text;
                bom.Estado = 0;
                bom.Estilo = txtEstilo.Text;
                bom.Etapa = 1;
                bom.FechaCreacion = DateTime.Now;
                bom.FUltimaModificacion = DateTime.Now;
                bom.CodigoNacional = aux;
                bom.Hilos = txthilo.Text;
                bom.Notas = snotas;
                
                if(Bom.GuardarBom(bom))
                {
                    bool result = Bom.AddDetailBom(DtBOM, txtNroBom);
                    if (result == true)
                    {
                        if (listaTemporal != null)
                        {
                            foreach (TareaTemporal _task in listaTemporal)
                            {
                                Bom.Tasks(_task.segmento, _task.trim, _task.bom, _task.nacionalidad, _task.flagNota);
                            }
                            listaTemporal.Clear();
                        }
                        //btnCancelar.Click();
                    }
                }   
                else
                {
                    Dialogs.Show("Ocurrio un error registrando nuevo BOM", DialogsType.Error);
                }                           
            }
            if (flag == 1)
            {
                bool result = Bom.UpdateDetailBom(DtBOM, txtNroBom);
                Bom.UpdateRevisiones(txtNroBom.Text, txtEstilo.Text);
                if (result == true)
                {
                    if (listaTemporal != null )
                    {
                        foreach (TareaTemporal _task in listaTemporal)
                        {
                            Bom.Tasks(_task.segmento, _task.trim, _task.bom, _task.nacionalidad, _task.flagNota);
                        }
                        listaTemporal.Clear();
                    }
                   // btnCancelar.PerformClick();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(txtNroBom.Text != string.Empty)
            {
                flag = 1;
                DesbloquearObj();
            }
            else
            {
                Dialogs.Show("Debe realizar la busqueda del BOM a modificar", DialogsType.Info);
            }            
        }

        private void btnDetalleUsu_Click(object sender, EventArgs e)
        {
            if (txtNroBom.Text != string.Empty)
            {
                BomNotas frm = new BomNotas(snotas);
                frm.ShowDialog();
            }
            else
            {
                Dialogs.Show("Debe crear el Bom para observar el detalle de usuario", DialogsType.Error);
            }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            if (Bom.LiberarCerrar() == false)
            {
                if (txtNroBom.Text.Contains("N") == true)
                {
                    Bom.UpdateEstadoCierre(txtNroBom.Text, "N");
                    lblEtapa.Text = "Liberado";
                    lblStatus.Text = "Cerrado";

                }
                else if (txtNroBom.Text.Contains("E") == true)
                {
                    Bom.UpdateEstadoCierre(txtNroBom.Text, "E");
                    lblEtapa.Text = "Liberado";
                    lblStatus.Text = "Cerrado";
                }
            }
        }

        private void txtPO_KeyDown(object sender, KeyEventArgs e)
        {
         //   if (e.KeyCode == Keys.F3)
           // {
            //    Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(16);
             //   frmBusqueda.ShowDialog();
             //   txtPO.Text = frmBusqueda.dato.ToString();
                
            //}
        }


        private void txtHilos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {

                
                OpenFileDialog miBsqueda = new OpenFileDialog();
                miBsqueda.Title = "Seleccione archivo";
                miBsqueda.Filter = "PDF Files|*.pdf";
                DialogResult result = miBsqueda.ShowDialog();
                if(result != DialogResult.Cancel && result != DialogResult.Abort)
                {
                  txtSPO.Text = miBsqueda.FileName;
                 }
            }
        }

        private void txtNroBom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(18);
                frmBusqueda.ShowDialog();
                if(frmBusqueda.dato != string.Empty && frmBusqueda.dato1 != string.Empty)
                {
                    if (Bom.BuscarCurr(frmBusqueda.dato1))
                    { 
                        int estado;
                        txtNroBom.Text = frmBusqueda.dato;
                        txtEstilo.Text = frmBusqueda.dato1;
                        
                        Bom.VerificarEstadoCierre(txtNroBom.Text, txtEstilo.Text, lblStatus, lblEtapa);
                        TemporalStream = Bom.CargarDatosPOH(txtNroBom.Text, txtEstilo.Text, txtSPO, txtPO,snotas,txthilo);
                        Bom.CargarDatos(DtBOM, frmBusqueda.dato, "N");
                        int idPod = 1;
                        String Estilo = frmBusqueda.dato1.ToString();
                        Controlador.EstilosdeProduccionController Estilos = new Controlador.EstilosdeProduccionController();
                        Estilos.MostrarPLML(txtEstilo, lblDescr, LblCategoria, LblDivision, LblEstacion, LblCliente, LbLMarca, lblCategory2, txtEspec, LblFit, lblBody, LblLavado, lblInseam, Txtempaque, Estilo, idPod);    
       
                        estado = Bom.VerificarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "N");
                        flagEstado = estado;
                        if (estado < 1)
                        {                            
                            //pbEstadoThread.Image = Properties.Resources.estado0;
                        }
                        if (estado == 1)
                        {                            
                            //pbEstadoThread.Image = Properties.Resources.estado2;
                        }
                        if (estado > 1)
                        {                            
                            //pbEstadoThread.Image = Properties.Resources.estado3;
                        }
                    }
                    else if (Bom.BuscarCurr(frmBusqueda.dato1) == false)
                    {
                        int estado;
                        txtNroBom.Text = frmBusqueda.dato;
                        txtEstilo.Text = frmBusqueda.dato1;

                        Bom.VerificarEstadoCierre(txtNroBom.Text, txtEstilo.Text, lblStatus, lblEtapa);
                        TemporalStream = Bom.CargarDatosPOH(txtNroBom.Text, txtEstilo.Text, txtSPO, txtPO,snotas,txthilo); 
                        Bom.CargarDatos(DtBOM, frmBusqueda.dato, "E" );
                        estado = Bom.VerificarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "E");
                        flagEstado = estado;
                        if (estado < 1)
                        {                            
                            //pbEstadoThread.Image = Properties.Resources.estado0;                           
                        }
                        if (estado == 1)
                        {                           
                            //pbEstadoThread.Image = Properties.Resources.estado2;                            
                        }
                        if (estado > 1)
                        {                         
                            //pbEstadoThread.Image = Properties.Resources.estado3;                            
                        }
                    }                                   
                    btnGuardar.Visible = false;
                    btnGuardarBOM.Visible = false; 
                }                            
            }
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            flag = 0;
            BloquearObj();
            Limpiar();     
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
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "N", flagEstado );
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
                    Busqueda.Hilo frm = new Busqueda.Hilo(txtNroBom.Text, txtEstilo.Text, "E",flagEstado);
                    frm.ShowDialog();
                }
            }
        }

        private void pbEstadoThread_Click(object sender, EventArgs e)
        {  
            
            DialogsResults result = Dialogs.Show("¿Desea cambiar el estado de los hilos?", DialogsType.Question);
            if (result == DialogsResults.Yes)
            {
                if (Bom.BuscarCurr(txtEstilo.Text) == false && flagEstado == 0)
                {
                    Bom.ActualizarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "E", 1);
                    //pbEstadoThread.Image = Properties.Resources.estado2;
                    flagEstado = 1;
                    string codigohilos; 
                    codigohilos = "E"+ txtNroBom.Text + txtEstilo.Text;
                    Bom.TaskThread(codigohilos,txtNroBom.Text); 
                }

                if (Bom.BuscarCurr(txtEstilo.Text) == true && flagEstado == 0)
                {
                    Bom.ActualizarEstadoHilos(txtNroBom.Text, txtEstilo.Text, "N", 1);
                    //pbEstadoThread.Image = Properties.Resources.estado2;
                    flagEstado = 1;                    
                    string codigohilos;
                    codigohilos = "N" + txtNroBom.Text + txtEstilo.Text;
                    Bom.TaskThread(codigohilos, txtNroBom.Text); 
                }
            }
        }

        private void btnSearchDoc_Click(object sender, EventArgs e)
        {
            if(txtPO.Text != string.Empty && TemporalStream != string.Empty)
            {
                if(txtPO.Text == "Archivo almacenado")
                {                    
                    string pathTemp = Path.Combine(Application.StartupPath, @"PO/ARCHIVOPOTEMPORAL"+txtNroBom.Text.Trim()+".pdf");
                    if(Directory.Exists(Path.Combine(Application.StartupPath, "PO")) == true)
                    {
                        if (File.Exists(pathTemp) == true)
                        {
                            Process.Start(pathTemp);
                        }
                        else
                        {
                            FileStream fs = new FileStream(pathTemp, FileMode.Create);
                            BinaryWriter bw = new BinaryWriter(fs);
                            byte[] bs;
                            bs = Convert.FromBase64String(TemporalStream);
                            bw.Write(bs);
                            Process.Start(pathTemp);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, "PO"));
                        if (File.Exists(pathTemp) == true)
                        {
                            Process.Start(pathTemp);
                        }
                        else
                        {
                            FileStream fs = new FileStream(pathTemp, FileMode.Create);
                            BinaryWriter bw = new BinaryWriter(fs);
                            byte[] bs;
                            bs = Convert.FromBase64String(TemporalStream);
                            bw.Write(bs);
                            Process.Start(pathTemp);
                        }
                    }                              
                }
                else
                {
                    Dialogs.Show("Debe indicar archivo de BOM a buscar", DialogsType.Info);
                }
            }
        }

        private void grbEstilos_Enter(object sender, EventArgs e)
        {

        }

        private void txtPO_Click(object sender, EventArgs e)
        {

        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel23_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel22_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel31_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel30_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void DtBOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DtBOM_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = DtBOM.CurrentRow.Index;
            if(DtBOM.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyDown += new KeyEventHandler(tb_keyDown);
            }
        }

        void tb_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(40);
                frmBusqueda.ShowDialog();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            BomNotas notas = new BomNotas( snotas);
            notas.ShowDialog();
            snotas = notas.strNota;
        }

    }
}
