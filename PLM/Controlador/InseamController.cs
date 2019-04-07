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
    public class InseamController 
    {
        public void Inseam(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Inseam.Select(x => new { x.id, x.IdInseam, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "IDINSEAM";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void InseamSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Inseam.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdInseam.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddInseam(string IDInseam, string Descripcion)
        {
            using (PLMContext db = new PLMContext())
            {
                var Inseam = new Inseam();
                Inseam.IdInseam = IDInseam;
                Inseam.Descripción = Descripcion;
                try
                {
                    db.Inseam.Add(Inseam);
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

        public bool UpdateInseam(string IDInseam, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Inseam = db.Inseam.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Inseam.IdInseam = IDInseam;
                    Inseam.Descripción = Descripcion;
                    db.Entry(Inseam).State = EntityState.Modified;
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

        public bool DeleteInseam(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Inseam = (from x in db.Inseam where x.id == id select x).FirstOrDefault();
                    db.Inseam.Remove(Inseam);
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

        public bool Existe(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Inseam = (from x in db.Inseam where x.IdInseam == nom select x).Count();
                if (Inseam == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public void Inseam(MetroComboBox dato)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Inseam.Select(x => new { x.IdInseam, x.Descripción }).ToList();
                    dato.Items.Clear();
                    dato.ValueMember = "IdInseam";
                    dato.DisplayMember = "Descripción";
                    dato.DataSource = datos;                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void Inseame(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 11:
                        try
                        {
                            var datos = db.Inseam.Select(x => new { x.Descripción }).ToList();
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

        public void BuscarInseam(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Inseam = from x in db.Inseam where (x.Descripción.Contains(Descripcion) || x.IdInseam.Contains(Descripcion)) select x;
                    if (Inseam != null)
                    {
                        controlView.DataSource = Inseam.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "IDINSEAM";
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

