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
    public class ManodeObraController
    {
        public void ManodeObra(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.ManodeObra.Select(x => new { x.id, x.IdManodeObra, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "ID MANO DE OBRA";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool ExisteD(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Descripcion = (from x in db.ManodeObra where x.Descripción == nom select x).Count();
              
                if (Descripcion == 0 ) 
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
     
        public bool Existe(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Descripcion = (from x in db.ManodeObra where x.IdManodeObra == nom select x).Count();

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
        public void ManodeObraSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.ManodeObra.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdManodeObra.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddManodeObra(string IDManodeObra, string Descripcion)
        {
            using (PLMContext db = new PLMContext())
            {
                var ManodeObra = new ManodeObra();
                ManodeObra.IdManodeObra = IDManodeObra;
                ManodeObra.Descripción = Descripcion;
                try
                {
                    db.ManodeObra.Add(ManodeObra);
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

        public bool UpdateManodeObra(string IDManodeObra, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var ManodeObra = db.ManodeObra.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    ManodeObra.IdManodeObra = IDManodeObra;
                    ManodeObra.Descripción = Descripcion;
                    db.Entry(ManodeObra).State = EntityState.Modified;
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

        public bool DeleteManodeObra(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var ManodeObra = (from x in db.ManodeObra where x.id == id select x).FirstOrDefault();
                    db.ManodeObra.Remove(ManodeObra);
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

        public void BuscarManodeObra(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var ManodeObra = from x in db.ManodeObra where (x.Descripción.Contains(Descripcion) || x.IdManodeObra.Contains(Descripcion)) select x;
                    if (ManodeObra != null)
                    {
                        controlView.DataSource = ManodeObra.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "ID MANO DE OBRA";
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
