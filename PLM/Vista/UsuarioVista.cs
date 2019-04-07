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
    public partial class UsuarioVista : MetroForm
    {
        Controlador.BitacoradeEventosController Bitacora;
        Controlador.UsuarioController controlador;
        private int flag = 0;

        public UsuarioVista()
        {
            InitializeComponent();
            controlador = new Controlador.UsuarioController();
            Bitacora = new Controlador.BitacoradeEventosController();
        }
      

        public void clearTxt()
        {
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            cmbDepartamento.Text = string.Empty;
            chbAutorizado.Checked = false;
            chbAgregar.Checked = false;
            chbEliminar.Checked = false;
            chbLiberar.Checked = false;
            chbModificar.Checked = false;
            chbReabrir.Checked = false;

        }

        private void pbxOjo_MouseHover(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';            
        }

        private void pbxOjo_MouseLeave(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';          
        }
        
        private void UsuarioVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar);
            controlador.Usuarios(dtDatos);
            controlador.Departamentos(cmbDepartamento);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
         
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;
                controlador.BuscarUsuario(descrip, dtDatos);
                if (dtDatos.Rows.Count > 0)
                {
                   
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Usuario";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else
                {
                    controlador.Usuarios(dtDatos);
                 
                }
            }
            else
            {
                controlador.Usuarios(dtDatos);
        
            }
        }

       
       

       

        private void txtUser_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtUser.Text;
            controlador.Existe(Exist);
            if (controlador.Existe(Exist))
            {
                Dialogs.Show("El usuario que intenta crear ya existe Intente de nuevo", DialogsType.Info);
                txtUser.Text = string.Empty;
                txtUser.Focus();
            }
            else
            {


            }
        }

       

        

        private void dtDatos_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                controlador.UsuarioSelect(txtUser, txtPass, cmbDepartamento, txtCorreo, chbAutorizado, chbLiberar, chbReabrir, chbAgregar, chbModificar, chbEliminar, id);
            }
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            dtDatos.Enabled = false;
            btnAlta.Enabled = false;
            btnEliminar.Enabled = false;
            clearTxt();
            flag = 1; 
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        { 
             if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string usuario, clave, correo, departamento;
                    int autorizar, liberar, reabrir, agregar, modificar, eliminar;
                    if (txtUser.Text != string.Empty && txtPass.Text != string.Empty && txtCorreo.Text != string.Empty)
                    {
                        if (cmbDepartamento.Items.Count > 0)
                        {
                            usuario = txtUser.Text;
                            clave = txtPass.Text;
                            correo = txtCorreo.Text;
                            departamento = cmbDepartamento.SelectedValue.ToString();
                            if (chbAutorizado.Checked == true)
                                autorizar = 1;
                            else
                                autorizar = 0;
                            if (chbLiberar.Checked == true)
                                liberar = 1;
                            else
                                liberar = 0;
                            if (chbReabrir.Checked == true)
                                reabrir = 1;
                            else
                                reabrir = 0;
                            if (chbAgregar.Checked == true)
                                agregar = 1;
                            else
                                agregar = 0;
                            if (chbModificar.Checked == true)
                                modificar = 1;
                            else
                                modificar = 0;
                            if (chbEliminar.Checked == true)
                                eliminar = 1;
                            else
                                eliminar = 0;
                            bool resultado = controlador.AddUsuario(usuario, clave, departamento, correo, autorizar, liberar, reabrir, agregar, modificar, eliminar);
                            if (resultado == true)
                            {
                                Dialogs.Show(Properties.Resources.Agregar + " el usuario", DialogsType.Info);
                                controlador.Usuarios(dtDatos);
                                string idcatalogo;
                                idcatalogo = "Alta de un Usuario";
                                Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                                dtDatos.Enabled = true;
                                btnAlta.Enabled = true;
                                btnEliminar.Enabled = true;
                                flag = 0; 
                            }
                        }
                        else
                        {
                            Dialogs.Show("Debe poseer como minimo 1 departamento previamnete registrado", DialogsType.Info);
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
                     string usuario, clave, correo, departamento;
                     int autorizar, liberar, reabrir, agregar, modificar, eliminar, id;
                     if (txtUser.Text != string.Empty && txtPass.Text != string.Empty && txtCorreo.Text != string.Empty)
                     {
                         if (cmbDepartamento.Items.Count > 0)
                         {
                             id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                             usuario = txtUser.Text;
                             clave = txtPass.Text;
                             correo = txtCorreo.Text;
                             departamento = cmbDepartamento.SelectedValue.ToString();
                             if (chbAutorizado.Checked == true)
                                 autorizar = 1;
                             else
                                 autorizar = 0;
                             if (chbLiberar.Checked == true)
                                 liberar = 1;
                             else
                                 liberar = 0;
                             if (chbReabrir.Checked == true)
                                 reabrir = 1;
                             else
                                 reabrir = 0;
                             if (chbAgregar.Checked == true)
                                 agregar = 1;
                             else
                                 agregar = 0;
                             if (chbModificar.Checked == true)
                                 modificar = 1;
                             else
                                 modificar = 0;
                             if (chbEliminar.Checked == true)
                                 eliminar = 1;
                             else
                                 eliminar = 0;
                             bool resultado = controlador.UpdateUsuario(clave, departamento, correo, autorizar, liberar, reabrir, agregar, modificar, eliminar, id);
                             if (resultado == true)
                             {
                                 Dialogs.Show(Properties.Resources.Editar + " el usuario", DialogsType.Info);
                                 controlador.Usuarios(dtDatos);
                                 string idcatalogo1;
                                 idcatalogo1 = "Actualización de un Usuario";
                                 Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                                 dtDatos.Enabled = true;
                                 btnAlta.Enabled = true;
                                 btnEliminar.Enabled = true;

                             }
                         }
                         else
                         {
                             Dialogs.Show("Debe poseer como minimo 1 departamento previamente registrado", DialogsType.Info);
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

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBusqueda.Text != string.Empty)
                {
                    string descrip = txtBusqueda.Text;
                    controlador.BuscarUsuario(descrip, dtDatos);
                    if (dtDatos.Rows.Count > 0)
                    {

                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Usuario";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        controlador.Usuarios(dtDatos);

                    }
                }
                else
                {
                    controlador.Usuarios(dtDatos);

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = controlador.DeleteUsuario(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el usuario", DialogsType.Info);
                        controlador.Usuarios(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Usuario";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                    }
                }
            }
        }
    }
}
