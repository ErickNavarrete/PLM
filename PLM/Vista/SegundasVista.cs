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
    public partial class SegundasVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.SegundasController Segundas;
        private int flag = 0;

        public void clearTxt()
        {
            txtCliente.Text = string.Empty;
            txtTela.Text = string.Empty;
            txtAvios.Text = string.Empty;
            txtConf.Text = string.Empty;
            txtFalt.Text = string.Empty;
            txtProc.Text = string.Empty;
            txtLav.Text = string.Empty;
        }

    
      

        public SegundasVista()
        {
            InitializeComponent();
            Segundas = new Controlador.SegundasController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }

        private void txtTela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtLav_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtProc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtAvios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtFalt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            flag = 0;
            
            dtDatos.Enabled = false;
            clearTxt();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            flag = 1;
                     
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = Segundas.DeleteSegundas(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el Segundas", DialogsType.Info);
                        txtCliente.Text = string.Empty;
                        txtTela.Text = string.Empty;
                        txtConf.Text = string.Empty;
                        txtLav.Text = string.Empty;
                        txtProc.Text = string.Empty;
                        txtAvios.Text = string.Empty;
                        txtFalt.Text = string.Empty;
                        Segundas.Segundas(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un item de un documento de 2das y faltantes";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                    }
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
                    string Cliente, Tela, Conf, Lav, Proc, Avios, Falt, total;
                    if (txtCliente.Text != string.Empty && txtTela.Text != string.Empty && txtConf.Text != string.Empty && txtLav.Text != string.Empty && txtProc.Text != string.Empty && txtAvios.Text != string.Empty && txtFalt.Text != string.Empty && Segundas.Existe(txtCliente.Text) == false)
                    {
                        Cliente = txtCliente.Text;
                        Tela = txtTela.Text;
                        Conf = txtConf.Text;
                        Lav = txtLav.Text;
                        Proc = txtProc.Text;
                        Avios = txtAvios.Text;
                        Falt = txtFalt.Text;
                        Tela = Tela.Replace("%", string.Empty);
                        Conf = Conf.Replace("%", string.Empty);
                        Lav = Lav.Replace("%", string.Empty);
                        Proc = Proc.Replace("%", string.Empty);
                        Avios = Avios.Replace("%", string.Empty);
                        Falt = Falt.Replace("%", string.Empty);
                        total = (float.Parse(Tela) + float.Parse(Conf) + float.Parse(Lav) + float.Parse(Proc) + float.Parse(Avios) + float.Parse(Falt)).ToString();
                        bool resultado = Segundas.AddSegundas(Cliente, Tela, Conf, Lav, Proc, Avios, Falt, total);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Segundas", DialogsType.Info);
                            txtCliente.Text = string.Empty;
                            txtTela.Text = string.Empty;
                            txtConf.Text = string.Empty;
                            txtLav.Text = string.Empty;
                            txtProc.Text = string.Empty;
                            txtAvios.Text = string.Empty;
                            txtFalt.Text = string.Empty;
                            dtDatos.Enabled = true;
                            Segundas.Segundas(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de 2das y faltantes";
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
                    string Cliente, Tela, Conf, Lav, Proc, Avios, Falt, total;
                    int id;
                    if (txtCliente.Text != string.Empty && txtTela.Text != string.Empty && txtConf.Text != string.Empty && txtLav.Text != string.Empty && txtProc.Text != string.Empty && txtAvios.Text != string.Empty && txtFalt.Text != string.Empty && Segundas.Existe(txtCliente.Text) == false)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());

                        Cliente = txtCliente.Text;
                        Tela = txtTela.Text;
                        Conf = txtConf.Text;
                        Lav = txtLav.Text;
                        Proc = txtProc.Text;
                        Avios = txtAvios.Text;
                        Falt = txtFalt.Text;
                        Tela = Tela.Replace("%", string.Empty);
                        Conf = Conf.Replace("%", string.Empty);
                        Lav = Lav.Replace("%", string.Empty);
                        Proc = Proc.Replace("%", string.Empty);
                        Avios = Avios.Replace("%", string.Empty);
                        Falt = Falt.Replace("%", string.Empty);
                        total = (float.Parse(Tela) + float.Parse(Conf) + float.Parse(Lav) + float.Parse(Proc) + float.Parse(Avios) + float.Parse(Falt)).ToString();
                        bool resultado = Segundas.UpdateSegundas(Cliente, Tela, Conf, Lav, Proc, Avios, Falt, total, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el Segundas", DialogsType.Info);
                            txtCliente.Text = string.Empty;
                            txtTela.Text = string.Empty;
                            txtConf.Text = string.Empty;
                            txtLav.Text = string.Empty;
                            txtProc.Text = string.Empty;
                            txtAvios.Text = string.Empty;
                            txtFalt.Text = string.Empty;
                            dtDatos.Enabled = true;
                            Segundas.Segundas(dtDatos);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de  2das y faltantes ";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                        }
                    }
                    else
                    {
                        Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                    }
                }
            }
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Segundas.SegundasSelect(txtCliente,txtTela,txtConf,txtLav,txtProc,txtAvios,txtFalt,id);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;

                if (Segundas.Existe(descrip))
                {
                    Segundas.BuscarSegundas(descrip, dtDatos);
                    
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de 2das y faltantes";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Segundas.Segundas(dtDatos);
                  
                }
            }
        }
        

       

        private void SegundasVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            // GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar, btnGuardar);
            Segundas.Segundas(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtDatos.Enabled = true;
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

                    if (Segundas.Existe(descrip))
                    {
                        Segundas.BuscarSegundas(descrip, dtDatos);

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de 2das y faltantes";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Segundas.Segundas(dtDatos);

                    }
                }
            }
        }
    }
}
