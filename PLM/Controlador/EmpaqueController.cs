using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLM.Modelo;
using System.Data.Entity;
using System.Data;
using System.Windows.Forms;
using ArcangelDialogs;
using MetroFramework.Forms;
using MetroFramework.Controls;
namespace PLM.Controlador
{
    public class EmpaqueController
    {
        public void Empaque(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Empaques.Select(x => new { x.id, x.IdEmpaque, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "ID-EMPAQUE";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void Empaquee(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 12:
                        try
                        {
                            var datos = db.Empaques.Select(x => new { x.Descripción }).ToList();
                            dtdatos.Columns.Clear();
                            dtdatos.DataSource = datos;
                            dtdatos.Columns[0].Width = 500; 
                        }
                        catch (Exception ex)
                        {
                            Dialogs.Show(ex.Message, DialogsType.Error);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void EmpaqueSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Empaques.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdEmpaque.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddEmpaque(string IDEmpaque, string Descripcion)
        {
            using (PLMContext db = new PLMContext())
            {
                var Empaque = new Empaques();
                Empaque.IdEmpaque = IDEmpaque;
                Empaque.Descripción = Descripcion;
                try
                {
                    db.Empaques.Add(Empaque);
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

        public bool UpdateEmpaque(string IDEmpaque, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Empaque = db.Empaques.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Empaque.IdEmpaque = IDEmpaque;
                    Empaque.Descripción = Descripcion;
                    db.Entry(Empaque).State = EntityState.Modified;
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

        public bool DeleteEmpaque(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Empaque = (from x in db.Empaques where x.id == id select x).FirstOrDefault();
                    db.Empaques.Remove(Empaque);
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

        public void Empaque(MetroComboBox dato)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Empaques.Select(x => new { x.IdEmpaque, x.Descripción }).ToList();
                    dato.Items.Clear();
                    dato.ValueMember = "IdEmpaque";
                    dato.DisplayMember = "Descripción";
                    dato.DataSource = datos;                   
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
                var Empaque = (from x in db.Empaques where x.IdEmpaque == nom select x).Count();
                if (Empaque == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarEmpaque(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Empaque = from x in db.Empaques where (x.Descripción.Contains(Descripcion) || x.IdEmpaque.Contains(Descripcion)) select x;
                    if (Empaque != null)
                    {
                        controlView.DataSource = Empaque.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "IDEMPAQUE";
                        controlView.Columns[2].HeaderText = "DESCRIPCION";
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

