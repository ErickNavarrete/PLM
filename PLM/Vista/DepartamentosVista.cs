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
    public partial class DepartamentosVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora;
        private Controlador.DepartamentoController Departamento;
        private int flag = 0; 
        public DepartamentosVista()
        {
            Bitacora = new Controlador.BitacoradeEventosController();
            Departamento = new Controlador.DepartamentoController();
            InitializeComponent();
        }
       
       
        public void clearTxt()
        {
            txtIdDepartamento.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtTresp.Text = string.Empty;
        }

        private void DepartamentosVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            // GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            Departamento.Departamento(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
          
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Departamento.DepartamentoSelect(txtIdDepartamento, txtDescripcion,txtTresp, id);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    if (Departamento.EliminarDepartamento(dtDatos.CurrentRow.Cells[1].Value.ToString()) == false)
                    {
                        int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        bool resultado = Departamento.DeleteDepartamento(id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Eliminar + " el Departamento", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdDepartamento.Text = string.Empty;
                            txtTresp.Text = string.Empty;
                            Departamento.Departamento(dtDatos);
                            string idcatalogo2;
                            idcatalogo2 = "Eliminación de un Departamento";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                        }
                    }
                    else 
                    {
                        Dialogs.Show("Existen trims asignados a este departamento", DialogsType.Error);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
                Departamento.BuscarDepartamento(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                   
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Departamento";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    Departamento.Departamento(dtDatos);
                   
                }
               }
            else
            {
                Departamento.Departamento(dtDatos);
                
            }
        }

        private void txtIdDepartamento_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdDepartamento.Text;
            Departamento.Existe(Exist);
            if (Departamento.Existe(Exist))
            {
                Dialogs.Show("El id que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtIdDepartamento.Text = string.Empty;
                txtIdDepartamento.Focus();
            }
            else
            {


            }
        }

        private void txtTresp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.')
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
                    string idDepartamento, descrip, Tresp;
                    if (txtIdDepartamento.Text != string.Empty && txtDescripcion.Text != string.Empty && txtTresp.Text != string.Empty && Departamento.Existe(txtIdDepartamento.Text) == false)
                    {
                        idDepartamento = txtIdDepartamento.Text;
                        descrip = txtDescripcion.Text;
                        Tresp = txtTresp.Text;
                        bool resultado = Departamento.AddDepartamento(idDepartamento, descrip, Tresp, 0);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Departamento", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdDepartamento.Text = string.Empty;
                            txtTresp.Text = string.Empty;
                            Departamento.Departamento(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Departamento";
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
                    string idDepartamento, descrip, Tresp;
                    int id;
                    if (txtIdDepartamento.Text != string.Empty && txtDescripcion.Text != string.Empty && txtTresp.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idDepartamento = txtIdDepartamento.Text;
                        descrip = txtDescripcion.Text;
                        Tresp = txtTresp.Text;
                        bool resultado = Departamento.UpdateDepartamento(idDepartamento, descrip, Tresp, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el Departamento", DialogsType.Info);
                            txtDescripcion.Text = string.Empty;
                            txtIdDepartamento.Text = string.Empty;
                            txtTresp.Text = string.Empty;
                            Departamento.Departamento(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Departamento";
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

        private void btnAlta_Click(object sender, EventArgs e)
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
                    Departamento.BuscarDepartamento(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Departamento";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Departamento.Departamento(dtDatos);

                    }
                }
                else
                {
                    Departamento.Departamento(dtDatos);

                }
            }
        }
    }
}
