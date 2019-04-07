using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcangelDialogs;
using System.Windows.Forms;
using PLM.Modelo;
using System.Data.Entity;
using System.Data;
using MetroFramework;
using MetroFramework.Controls;

namespace PLM.Controlador
{
    public class UsuarioController
    {
        public bool LoginUser(string user, string clave, out string departamento)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var usuario = db.Usuarios.Where(x => x.Usser == user && x.Password == clave).Select(x => x).FirstOrDefault();
                    if(usuario != null)
                    {
                        departamento = usuario.Departamento;
                        return true;
                    }
                    else
                    {
                        Dialogs.Show("Usuario y/o clave invalidos", DialogsType.Info);
                        departamento = string.Empty;
                        return false;
                    }                    
                }
                catch(Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    departamento = string.Empty;
                    return false;
                }
            }
        }

        public void Usuarios(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Usuarios.Select(x => new { x.id, x.Usser}).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[1].Width = 500;
                    controlView.Columns[1].HeaderText = "USUARIO";   
                    
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void Departamentos(MetroComboBox cmb)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Departamentos.Select(x => new { x.IdDepartamento, x.Descripción }).ToList();
                    cmb.ValueMember = "IdDepartamento";
                    cmb.DisplayMember = "Descripción";
                    cmb.DataSource = datos;
                    if(cmb.Items.Count > 0)
                    {
                        cmb.SelectedIndex = 0;
                    }              
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddUsuario(string user, string clave, string departamento, string correo, int autorizado, int liberar, int reabrir, int agregar, int modificar, int eliminar)
        {
            using (PLMContext db = new PLMContext())
            {
                var usuario = new Usuario();
                usuario.Usser = user;
                usuario.Password = clave;
                usuario.Departamento = departamento;
                usuario.Correo = correo;
                usuario.Autorizado = autorizado;
                usuario.Liberar = liberar;
                usuario.Reabrir = reabrir;
                usuario.Agregar = agregar;
                usuario.Modificar = modificar;
                usuario.Eliminar = eliminar;               
                try
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }

        public bool UpdateUsuario(string clave, string departamento, string correo, int autorizado, int liberar, int reabrir, int agregar, int modificar, int eliminar, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var usuario = db.Usuarios.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    usuario.Password = clave;
                    usuario.Departamento = departamento;
                    usuario.Correo = correo;
                    usuario.Autorizado = autorizado;
                    usuario.Liberar = liberar;
                    usuario.Reabrir = reabrir;
                    usuario.Agregar = agregar;
                    usuario.Modificar = modificar;
                    usuario.Eliminar = eliminar;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }

        public bool DeleteUsuario(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var usuario = (from x in db.Usuarios where x.id == id select x).FirstOrDefault();
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }

        public void BuscarUsuario(string Descripcion, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var usuario = from x in db.Usuarios where (x.Usser.Contains(Descripcion)) select new { x.id,x.Usser};
                    if (usuario != null)
                    {
                        controlView.DataSource = usuario.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[1].Width = 500;
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool Existe(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Usuario = (from x in db.Usuarios where x.Usser == nom select x).Count();
                if (Usuario == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void UsuarioSelect(MetroTextBox usuario, MetroTextBox clave, MetroComboBox departamento, MetroTextBox correo, MetroCheckBox autorizado, MetroCheckBox liberar, MetroCheckBox reabrir, MetroCheckBox agregar, MetroCheckBox editar, MetroCheckBox eliminar, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Usuarios.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        usuario.Text = datos.Usser;
                        clave.Text = datos.Password;
                        correo.Text = datos.Correo;
                        departamento.Text = datos.Departamento;
                        if (datos.Autorizado == 1)
                            autorizado.Checked = true;
                        else
                            autorizado.Checked = false;
                        if (datos.Liberar == 1)
                            liberar.Checked = true;
                        else
                            liberar.Checked = false;
                        if (datos.Reabrir == 1)
                            reabrir.Checked = true;
                        else
                            reabrir.Checked = false;
                        if (datos.Agregar == 1)
                            agregar.Checked = true;
                        else
                            agregar.Checked = false;
                        if (datos.Modificar == 1)
                            editar.Checked = true;
                        else
                            editar.Checked = false;
                        if (datos.Eliminar == 1)
                            eliminar.Checked = true;
                        else
                            eliminar.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }
    }
}
