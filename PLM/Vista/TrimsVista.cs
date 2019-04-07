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
    public partial class TrimsVista : MetroForm
    {
        private Controlador.TrimController Trim;
        public Controlador.BitacoradeEventosController Bitacora;
        private int flag = 0; 

        public TrimsVista()
        {
            InitializeComponent();
            Trim = new Controlador.TrimController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }
        public void clearTxt()
        {
            txtIdTrim.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSecuencia.Text = string.Empty;
            cmbDepartamentos.Text = string.Empty;
            cmbSegmentos.Text = string.Empty;
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Trim.TrimSelect(txtIdTrim, txtDescripcion, cmbDepartamentos, cmbSegmentos,txtSecuencia, id);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    if (Trim.EliminarTrim(dtDatos.CurrentRow.Cells[1].Value.ToString()) == false)
                    {
                        int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        bool resultado = Trim.DeleteTrim(id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Eliminar + " el Trim", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdTrim.Text = string.Empty;
                            if (cmbDepartamentos.Items.Count > 0)
                            {
                                cmbDepartamentos.SelectedIndex = 0;
                            }
                            if (cmbSegmentos.Items.Count > 0)
                            {
                                cmbSegmentos.SelectedIndex = 0;
                            }
                            txtSecuencia.Text = string.Empty;
                            Trim.Trim(dtDatos);
                            string idcatalogo2;
                            idcatalogo2 = "Eliminación de un Trim";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                        }
                    }
                    else
                    {
                        Dialogs.Show("Existen boms abiertos con este trim involucrado", DialogsType.Error);
                    }
                }
            }
           
        }
      
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
               
                
                    Trim.BuscarTrim(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {
                 
                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Trim";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else 
                    {
                 
                        Trim.Trim(dtDatos);
                    }
            }
            else
            {
                Trim.Trim(dtDatos);
            }
        }

        private void TrimsVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Trim.Trim(dtDatos);
            Trim.Departamentos(cmbDepartamentos);
            Trim.Segmentos(cmbSegmentos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
            
       
        }

        private void txtIdTrim_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdTrim.Text;
            Trim.Existe(Exist);
            if (Trim.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdTrim.Text = string.Empty;
                txtIdTrim.Focus();
            }
            else
            {


            }
        }

        private void txtSecuencia_Leave(object sender, EventArgs e)
        {
            if (txtSecuencia.Text != string.Empty)
            {
                string Exist; int nums;
                Exist = txtIdTrim.Text;
                nums = int.Parse(txtSecuencia.Text);
                Trim.ExisteSecuencia(Exist, nums);
                if (Trim.ExisteSecuencia(Exist, nums))
                {
                    Dialogs.Show("La secuencia que intenta asignar al trim ya existe en ese segmento intente de nuevo", DialogsType.Info);
                    txtSecuencia.Text = string.Empty;
                    txtSecuencia.Focus();
                }
                else
                {


                }
            }            
        }

        private void txtSecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idTrim, descrip, Departamento, Segmento, Secuencia;
                    if (txtIdTrim.Text != string.Empty && txtDescripcion.Text != string.Empty && txtSecuencia.Text != string.Empty && Trim.Existe(txtIdTrim.Text) == false && Trim.ExisteSecuencia(cmbSegmentos.SelectedValue.ToString(), int.Parse(txtSecuencia.Text)) == false)
                    {
                        if (cmbSegmentos.Items.Count > 0)
                        {
                            if (cmbDepartamentos.Items.Count > 0)
                            {
                                idTrim = txtIdTrim.Text;
                                descrip = txtDescripcion.Text;
                                Departamento = cmbDepartamentos.SelectedValue.ToString();
                                Segmento = cmbSegmentos.SelectedValue.ToString();
                                Secuencia = txtSecuencia.Text;
                                bool resultado = Trim.AddTrim(idTrim, descrip, Departamento, Segmento, Secuencia);
                                if (resultado == true)
                                {
                                    Dialogs.Show(Properties.Resources.Agregar + " el Trim", DialogsType.Info);
                                    txtDescripcion.Text = string.Empty;
                                    txtIdTrim.Text = string.Empty;
                                    if (cmbDepartamentos.Items.Count > 0)
                                    {
                                        cmbDepartamentos.SelectedIndex = 0;
                                    }
                                    if (cmbSegmentos.Items.Count > 0)
                                    {
                                        cmbSegmentos.SelectedIndex = 0;
                                    }
                                    txtSecuencia.Text = string.Empty;
                                    Trim.Trim(dtDatos);
                                    string idcatalogo;
                                    idcatalogo = "Alta de un Trim";
                                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                                    dtDatos.Enabled = true;
                                    btnAlta.Enabled = true;
                                    btnEliminar.Enabled = true;
                                    flag = 0;
                                }
                            }
                            else
                            {
                                Dialogs.Show("Debe poseer almenos 1 departamento previamente creado", DialogsType.Info);
                            }
                        }
                        else
                        {
                            Dialogs.Show("Debe poseer almenos 1 segmento previamente creado", DialogsType.Info);
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
                    string idTrim, descrip, Departamento, Segmento, Secuencia;
                    int id;
                    if (txtIdTrim.Text != string.Empty && txtDescripcion.Text != string.Empty && txtSecuencia.Text != string.Empty)
                    {
                        if (cmbSegmentos.Items.Count > 0)
                        {
                            if (cmbDepartamentos.Items.Count > 0)
                            {
                                id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                                idTrim = txtIdTrim.Text;
                                descrip = txtDescripcion.Text;
                                Departamento = cmbDepartamentos.SelectedValue.ToString();
                                Segmento = cmbSegmentos.SelectedValue.ToString();
                                Secuencia = txtSecuencia.Text;
                                bool resultado = Trim.UpdateTrim(idTrim, descrip, Departamento, Segmento, Secuencia, id);
                                if (resultado == true)
                                {
                                    Dialogs.Show(Properties.Resources.Editar + " el Trim", DialogsType.Info);
                                    txtDescripcion.Text = string.Empty;
                                    txtIdTrim.Text = string.Empty;
                                    if (cmbDepartamentos.Items.Count > 0)
                                    {
                                        cmbDepartamentos.SelectedIndex = 0;
                                    }
                                    if (cmbSegmentos.Items.Count > 0)
                                    {
                                        cmbSegmentos.SelectedIndex = 0;
                                    }
                                    txtSecuencia.Text = string.Empty;
                                    Trim.Trim(dtDatos);
                                    string idcatalogo1;
                                    idcatalogo1 = "Actualización de un Trim";
                                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                                    dtDatos.Enabled = true;
                                    btnAlta.Enabled = true;
                                    btnEliminar.Enabled = true;
                                    

                                }
                            }
                            else
                            {
                                Dialogs.Show("Debe poseer almenos 1 departamento previamente creado", DialogsType.Info);
                            }
                        }
                        else
                        {
                            Dialogs.Show("Debe poseer almenos 1 segmento previamente creado", DialogsType.Info);
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


                    Trim.BuscarTrim(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Trim";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {

                        Trim.Trim(dtDatos);
                    }
                }
                else
                {
                    Trim.Trim(dtDatos);
                }
            }
        }
    }
} 
    

    

