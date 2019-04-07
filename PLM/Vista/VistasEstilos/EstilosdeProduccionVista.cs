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
    public partial class EstilosdeProduccionVista : MetroForm
    {
        public int idFuncion;
        public Controlador.BitacoradeEventosController Bitacora;
        public Controlador.BodyController Body;
        public Controlador.CategoryDosController Category2;
        public Controlador.FitController Fit;
        public Controlador.InseamController Inseam;
        public Controlador.EstilosdeProduccionController Estilos;
        public Controlador.EmpaqueController Empaque;
        public Controlador.TemporadasController Temporada;
        private string identity;
        private string TemporalStream;
        private int IdPoD;

        public EstilosdeProduccionVista(string _identity, int _IdPoD )
        {
            InitializeComponent();
            Bitacora = new Controlador.BitacoradeEventosController();
            Body = new Controlador.BodyController();
            Category2 = new Controlador.CategoryDosController();
            Fit = new Controlador.FitController();
            Inseam = new Controlador.InseamController();
            Estilos = new Controlador.EstilosdeProduccionController();
            Empaque = new Controlador.EmpaqueController();
            Temporada = new Controlador.TemporadasController();
            identity = _identity;
            IdPoD = _IdPoD;
            TemporalStream = string.Empty;
        }

        private void EstilosdeProduccionVista_Load(object sender, EventArgs e)
        {
            if (identity != string.Empty)
            {     
                Estilos.Mostrar(txtIdEstilos, cmbDescrip, cmbCategoria, cmbMarca, cmbLavado,cmbDivision, identity,IdPoD);
                Estilos.MostrarPLM(txtIdEstilos, cmbDescrip, cmbCategoria, cmbDivision, cmbEstacion, cmbCliente, cmbMarca, cmbCategory2, txtEspec, cmbFit, cmbBody, cmbLavado, cmbInseam, cmbEmpaque, identity, IdPoD);    
            }
            else 
            {
                                              
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                if((identity == string.Empty && IdPoD == 0 ) || (identity!= string.Empty && IdPoD == 2 ))
                {
                    string Descripcion; string Categoria; string Division; string Estacion; string Cliente; string Marca; string Category2; string Espec; string IdEstilosdeProduccion; string Fit; string Body; string Lavado; string Inseam; string Empaque;
                    //&& cmbDescrip.Text != string.Empty && cmbCategoria.Text != string.Empty && cmbDivision.Text != string.Empty && cmbEstacion.Text != string.Empty && cmbCliente.Text != string.Empty && cmbMarca.Text != string.Empty && cmbCategory2.Text != string.Empty && txtEspec.Text != string.Empty && cmbFit.Text != string.Empty && cmbBody.Text != string.Empty && cmbLavado.Text != string.Empty && cmbInseam.Text != string.Empty && cmbEmpaque.Text != string.Empty
                    if (txtIdEstilos.Text != string.Empty )
                    {
                        IdEstilosdeProduccion = txtIdEstilos.Text;
                        Descripcion = cmbDescrip.Text;
                        Categoria = cmbCategoria.Text;
                        Division = cmbDivision.Text;
                        Estacion = cmbEstacion.Text;
                        Cliente = cmbCliente.Text;
                        Marca = cmbMarca.Text;
                        Category2 = cmbCategory2.Text;
                        Espec = txtEspec.Text;
                        Fit = cmbFit.Text;
                        Body = cmbBody.Text;
                        Lavado = cmbLavado.Text;
                        Inseam = cmbInseam.Text;
                        Empaque = cmbEmpaque.Text;
                        bool resultado = Estilos.AddEstilosdeProduccion(Descripcion, Categoria, Division, Estacion, Cliente, Marca, Category2, Espec, IdEstilosdeProduccion, Fit, Body, Lavado, Inseam, Empaque);
                        if (resultado == true)
                        {
                            Dialogs.Show("El Estilo de producción ha sido registrado con exito", DialogsType.Info);                   
                            string idcatalogo;
                            idcatalogo = "Alta de un item de un documento de Estilos";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                            this.Close();
                        }  
                    }
                    else
                    {
                        Dialogs.Show("Existe campo sin datos, o datos erroneos, intente de nuevo", DialogsType.Error);
                    }        
                }
                else
                {
                    string Descripcion; string Categoria; string Division; string Estacion; string Cliente; string Marca; string Category2; string Espec; string IdEstilosdeProduccion; string Fit; string Body; string Lavado; string Inseam; string Empaque;
                    //int id;
                    if (txtIdEstilos.Text != string.Empty && cmbCliente.Text !=string.Empty && cmbDescrip.Text != string.Empty && cmbCategoria.Text != string.Empty && cmbDivision.Text != string.Empty && cmbEstacion.Text != string.Empty && cmbCliente.Text != string.Empty && cmbMarca.Text != string.Empty && cmbCategory2.Text != string.Empty && txtEspec.Text != string.Empty && cmbFit.Text != string.Empty && cmbBody.Text != string.Empty && cmbLavado.Text != string.Empty && cmbInseam.Text != string.Empty && cmbEmpaque.Text != string.Empty)
                    {
                        IdEstilosdeProduccion = txtIdEstilos.Text;
                        Descripcion = cmbDescrip.Text;
                        Categoria = cmbCategoria.Text;
                        Division = cmbDivision.Text;
                        Estacion = cmbEstacion.Text;
                        Cliente = cmbCliente.Text;
                        Marca = cmbMarca.Text;
                        Category2 = cmbCategory2.Text;
                        Espec = txtEspec.Text;
                        Fit = cmbFit.Text;
                        Body = cmbBody.Text;
                        Lavado = cmbLavado.Text;
                        Inseam = cmbInseam.Text;
                        Empaque = cmbEmpaque.Text;
                        bool resultado = Estilos.UpdateEstilosdeProduccion(Descripcion, Categoria, Division, Estacion, Cliente, Marca, Category2, Espec, IdEstilosdeProduccion, Fit, Body, Lavado, Inseam, Empaque);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " Estilo de producción", DialogsType.Info);                       
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un documneto de Estilos de Producción ";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                            this.Close();
                        }
                    }
                    else
                    {
                        Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                    }
                }     
            }

        private void txtIdEstilos_Leave(object sender, EventArgs e)
        {
            string Exis;            
            Exis = txtIdEstilos.Text;
            Estilos.Existe(Exis); 
            if (Estilos.Existe(Exis))
            {
                Dialogs.Show("el ID de estilo que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdEstilos.Text = string.Empty;
                txtIdEstilos.Focus();
            }
            else
            {


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbDescrip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                    idFuncion = 0;
                    Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                    frmBusqueda.ShowDialog();
                    cmbDescrip.Items.Add(frmBusqueda.dato);
                    cmbDescrip.SelectedIndex = 0; 
                }
            }

        private void cmbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 2;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbCategoria.Items.Add(frmBusqueda.dato);
                cmbCategoria.SelectedIndex = 0;
            }
        }

        private void cmbDivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 6;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbDivision.Items.Add(frmBusqueda.dato);
                cmbDivision.SelectedIndex = 0;
            }
        }

        private void cmbMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 1;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbMarca.Items.Add(frmBusqueda.dato);
                cmbMarca.SelectedIndex = 0;
            }
        }

        

        private void cmbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 7;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbCliente.Items.Add(frmBusqueda.dato);
                cmbCliente.SelectedIndex = 0;
            }
        }

        private void cmbLavado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 3;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbLavado.Items.Add(frmBusqueda.dato);
                cmbLavado.SelectedIndex = 0;
            }
        }

        private void cmbFit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 8;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbFit.Items.Add(frmBusqueda.dato);
                cmbFit.SelectedIndex = 0;
            }
        }

        private void cmbBody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 9;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbBody.Items.Add(frmBusqueda.dato);
                cmbBody.SelectedIndex = 0;
            }
        }

        private void cmbCategory2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 10;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbCategory2.Items.Add(frmBusqueda.dato);
                cmbCategory2.SelectedIndex = 0;
            }
        }

        private void cmbInseam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
            idFuncion = 11;
            Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
            frmBusqueda.ShowDialog();
            cmbInseam.Items.Add(frmBusqueda.dato);
            cmbInseam.SelectedIndex = 0;
        }
    }

        private void cmbEmpaque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {

                idFuncion = 12;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbEmpaque.Items.Add(frmBusqueda.dato);
                cmbEmpaque.SelectedIndex = 0;
            }
        }

        private void cmbEstacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                idFuncion = 13;
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                frmBusqueda.ShowDialog();
                cmbEstacion.Items.Add(frmBusqueda.dato);
                cmbEstacion.SelectedIndex = 0;
            }
        }

        private void txtEspec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                //idFuncion = 5;
                //Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(idFuncion);
                //frmBusqueda.ShowDialog();
                //txtEspec.Text = (frmBusqueda.dato.ToString());
                OpenFileDialog miBsqueda = new OpenFileDialog();
                miBsqueda.Title = "Seleccione archivo a guardar";
                miBsqueda.Filter = "Todos los archivos (*.*)|*.*";
                DialogResult result = miBsqueda.ShowDialog();
                if (result != DialogResult.Cancel && result != DialogResult.Abort)
                {
                    txtEspec.Text = miBsqueda.FileName;
                }
            }
        }

        private void cmbBody_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
                          

    }
}   
