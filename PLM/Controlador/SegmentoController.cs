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
    public class SegmentoController
    {
        public void Segmento(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Segmentos.Select(x => new { x.id, x.IdSegmento, x.Descripción, x.SecuenciaSegmento, x.TiempoDeRespuesta }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "ID SEGMENTO";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                    controlView.Columns[4].HeaderText = "TIEMPO DE RESPUESTA";
                    controlView.Columns[3].HeaderText = "SECUENCIA";                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void SegmentoSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, MetroFramework.Controls.MetroTextBox SecuenciaSegmento, MetroFramework.Controls.MetroTextBox TiempoDeRespuesta,  int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Segmentos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdSegmento.ToString();
                        descrip.Text = datos.Descripción.ToString();
                        TiempoDeRespuesta.Text = datos.TiempoDeRespuesta.ToString();
                        SecuenciaSegmento.Text = datos.SecuenciaSegmento.ToString();                        
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddSegmento(string IDSegmento, string Descripcion,  string SecuenciaSegmento,string TiempoDeRespuesta)
        {
            using (PLMContext db = new PLMContext())
            {
                var Segmento = new Segmentos();
                Segmento.IdSegmento = IDSegmento;
                Segmento.Descripción = Descripcion;
                Segmento.TiempoDeRespuesta = int.Parse(TiempoDeRespuesta);
                Segmento.SecuenciaSegmento = int.Parse(SecuenciaSegmento);
                try
                {
                    db.Segmentos.Add(Segmento);
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
        public bool EliminarSegmento(string dato)
        {
            using (PLMContext db = new PLMContext())
            {
                var datos = (from x in db.BomsDetails where x.Segmento == dato select x).Count();
                var datoss = (from x in db.Trims where x.Segmento == dato select x).Count();
                if (datos == 0 && datoss == 0)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }
        public bool UpdateSegmento(string IDSegmento, string Descripcion, string SecuenciaSegmento, string TiempoDeRespuesta, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segmento = db.Segmentos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Segmento.IdSegmento = IDSegmento;
                    Segmento.Descripción = Descripcion;
                    Segmento.SecuenciaSegmento = int.Parse(SecuenciaSegmento);
                    Segmento.TiempoDeRespuesta = int.Parse(TiempoDeRespuesta);
                    db.Entry(Segmento).State = EntityState.Modified;
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

        public bool DeleteSegmento(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segmento = (from x in db.Segmentos where x.id == id select x).FirstOrDefault();
                    db.Segmentos.Remove(Segmento);
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

        public bool ExisteSec(int nom )
        {
            using (PLMContext db = new PLMContext())
            {
                var Segmento = (from x in db.Segmentos where x.SecuenciaSegmento == nom select x).Count();
                if (Segmento == 0)
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
                var Segmento = (from x in db.Segmentos where x.IdSegmento == nom select x).Count();
                if (Segmento == 0) 
                {
                    return false; 
                } 
                else
                {
                  return true ;
                }
            }
        }

        public void BuscarSegmento(string Descripcion, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segmento = from x in db.Segmentos where (x.Descripción.Contains(Descripcion) || x.IdSegmento.Contains(Descripcion)) select x;
                    if (Segmento != null)
                    {
                        controlView.DataSource = Segmento.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "ID SEGMENTO";
                        controlView.Columns[2].HeaderText = "DESCRIPCION";
                        controlView.Columns[4].HeaderText = "SECUENCIA";
                        controlView.Columns[3].HeaderText = "TIEMPO DE RESPUESTA";
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