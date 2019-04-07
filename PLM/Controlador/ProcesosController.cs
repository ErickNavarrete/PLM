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

namespace PLM.Controlador
{
    public class ProcesosController
    {
        public void Procesos(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Procesos.Select(x => new { x.id, x.IdProceso, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "IDPROCESOS";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void ProcesosSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Procesos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdProceso.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddProcesos(string IDProcesos, string Descripcion)
        {
            using (PLMContext db = new PLMContext())
            {
                var Procesos = new Proceso();
                Procesos.IdProceso = IDProcesos;
                Procesos.Descripción = Descripcion;
                try
                {
                    db.Procesos.Add(Procesos);
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

        public bool UpdateProcesos(string IDProcesos, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Procesos = db.Procesos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Procesos.IdProceso = IDProcesos;
                    Procesos.Descripción = Descripcion;
                    db.Entry(Procesos).State = EntityState.Modified;
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
                var Descripcion = (from x in db.Procesos where x.IdProceso == nom select x).Count();
                if (Descripcion == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool ExisteD(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Descripcion = (from x in db.Procesos where x.Descripción == nom select x).Count();
                if (Descripcion == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool DeleteProcesos(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Procesos = (from x in db.Procesos where x.id == id select x).FirstOrDefault();
                    db.Procesos.Remove(Procesos);
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

        public void BuscarProcesos(string Descripcion, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Procesos = from x in db.Procesos where (x.Descripción.Contains(Descripcion) || x.IdProceso.Contains(Descripcion)) select x;
                    if (Procesos != null)
                    {
                        controlView.DataSource = Procesos.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "IDPROCESOS";
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