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
    public  class TemporadasController 
    {                        
        public void Temporadas(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {              
                try
                {
                    var datos = db.Temporadas.Select(x => new { x.id, x.IdTemporadas, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "IDTEMPORADA";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);                  
                }
            }            
        }

        public void Temporadase(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 13:
                        try
                        {
                            var datos = db.Temporadas.Select(x => new { x.Descripción }).ToList();
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

        public void TemporadasSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Temporadas.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdTemporadas.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddTemporadas(string IDTemporadas, string Descripcion)
        {
            using(PLMContext db = new PLMContext())
            {
                var Temporadas = new Temporadas();
                Temporadas.IdTemporadas = IDTemporadas;
                Temporadas.Descripción = Descripcion;
                try
                {
                    db.Temporadas.Add(Temporadas);
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

        public bool UpdateTemporadas(string IDTemporadas, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {            
                try
                {
                    var Temporadas = db.Temporadas.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Temporadas.IdTemporadas = IDTemporadas;
                    Temporadas.Descripción = Descripcion;
                    db.Entry(Temporadas).State = EntityState.Modified;
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

        public bool DeleteTemporadas( int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Temporadas = (from x in db.Temporadas where x.id == id select x).FirstOrDefault();
                    db.Temporadas.Remove(Temporadas);
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

        public void Temporadas(MetroComboBox dato)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Temporadas.Select(x => new { x.IdTemporadas, x.Descripción }).ToList();
                    dato.Items.Clear();
                    dato.ValueMember = "IdTemporadas";
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
                var Temporada = (from x in db.Temporadas where x.IdTemporadas == nom select x).Count();
                if (Temporada == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarTemporadas(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Temporadas = from x in db.Temporadas where (x.Descripción.Contains(Descripcion) || x.IdTemporadas.Contains(Descripcion)) select x;
                    if (Temporadas != null)
                    {
                        controlView.DataSource = Temporadas.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "IDTEMPORADA";
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