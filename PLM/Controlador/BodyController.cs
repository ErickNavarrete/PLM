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
    public  class BodyController
    {                                        
        public void Body(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {              
                try
                {
                    var datos = db.Body.Select(x => new { x.id, x.IdBody, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "IDBODY";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);                  
                }
            }            
        }

        public void BodySelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Body.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdBody.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void Bodye(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 9:
                        try
                        {
                            var datos = db.Body.Select(x => new { x.Descripción }).ToList();
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

        public bool AddBody(string IDBody, string Descripcion)
        {
            using(PLMContext db = new PLMContext())
            {
                var Body = new Body();
                Body.IdBody = IDBody;
                Body.Descripción = Descripcion;
                try
                {
                    db.Body.Add(Body);
                    db.SaveChanges();
                    return true; 
                }
                catch(Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }            
        }

        public bool UpdateBody(string IDBody, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {            
                try
                {
                    var Body = db.Body.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Body.IdBody = IDBody;
                    Body.Descripción = Descripcion;
                    db.Entry(Body).State = EntityState.Modified;
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

        public bool DeleteBody( int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Body = (from x in db.Body where x.id == id select x).FirstOrDefault();
                    db.Body.Remove(Body);
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

        public void Body(MetroComboBox dato)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Body.Select(x => new { x.IdBody, x.Descripción }).ToList();
                    dato.Items.Clear();
                    dato.ValueMember = "IdBody";
                    dato.DisplayMember = "Descripción";
                    dato.DataSource = datos;
                    if (dato.Items.Count > 0)
                    {
                        dato.SelectedIndex = 0;
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
                var Body = (from x in db.Body where x.IdBody == nom select x).Count();
                if (Body == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarBody(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                  var Body = from x in db.Body where (x.Descripción.Contains(Descripcion) || x.IdBody.Contains(Descripcion) ) select x ;
                  if (Body != null) 
                  {
                      controlView.DataSource = Body.ToList();
                      controlView.Columns[0].HeaderText = "ID";
                      controlView.Columns[1].HeaderText = "IDBODY";
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
