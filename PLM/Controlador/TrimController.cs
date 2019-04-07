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
    public class TrimController
    {
        public void Trim(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Trims.Select(x => new { x.id, x.IdTrim, x.Descripción,x.Departamento,x.Segmento,x.Secuencia }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "ID TRIM";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                    controlView.Columns[4].HeaderText = "SEGMENTO";
                    controlView.Columns[5].HeaderText = "SECUENCIA";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool EliminarTrim(string dato)
        {
            using (PLMContext db = new PLMContext())
            {
                var datos = (from x in db.BomsDetails where x.Trims == dato select x).Count();
                if (datos == 0)
                {
                    return false;

                }
                else
                {
                    return true;
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
                    if (cmb.Items.Count > 0)
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

        public void Segmentos(MetroComboBox cmb)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Segmentos.Select(x => new { x.IdSegmento, x.Descripción }).ToList();
                    cmb.ValueMember = "IdSegmento";
                    cmb.DisplayMember = "Descripción";
                    cmb.DataSource = datos;
                    if (cmb.Items.Count > 0)
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

        public void TrimSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, MetroComboBox Departamento, MetroComboBox Segmento, MetroFramework.Controls.MetroTextBox Secuencia, int id) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Trims.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdTrim.ToString();
                        descrip.Text = datos.Descripción.ToString();
                        Departamento.Text = datos.Departamento.ToString();
                        Segmento.Text = datos.Segmento.ToString();
                        Secuencia.Text = datos.Secuencia.ToString(); 
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddTrim(string IDTrim, string Descripcion, string Departamento, string Segmento, string Secuencia)
        {
            using (PLMContext db = new PLMContext())
            {
                var Trim = new Trims();
                Trim.IdTrim = IDTrim;
                Trim.Descripción = Descripcion;
                Trim.Departamento = Departamento;
                Trim.Segmento = Segmento;
                Trim.Secuencia = int.Parse(Secuencia); 
                try
                {
                    db.Trims.Add(Trim);
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

        public bool UpdateTrim(string IDTrim, string Descripcion, string Departamento, string Segmento, string Secuencia, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Trim = db.Trims.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Trim.IdTrim = IDTrim;
                    Trim.Descripción = Descripcion;
                    Trim.Departamento = Departamento;
                    Trim.Segmento = Segmento;
                    Trim.Secuencia = int.Parse(Secuencia);
                    db.Entry(Trim).State = EntityState.Modified;
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

        public bool DeleteTrim(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Trim = (from x in db.Trims where x.id == id select x).FirstOrDefault();
                    db.Trims.Remove(Trim);
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
                var Trim = (from x in db.Trims where x.IdTrim == nom select x).Count();
                if (Trim == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool ExisteSecuencia(string noms , int nums )
        {
            using (PLMContext db = new PLMContext())
            {
                var Trim = (from x in db.Trims where( x.Secuencia == nums && x.Segmento == noms) select x).Count(); 
                if(Trim == 0 )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarTrim(string Descripcion, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Trim = from x in db.Trims where (x.Descripción.Contains(Descripcion) || x.IdTrim.Contains(Descripcion)) select x;
                    if (Trim != null)
                    {
                        controlView.DataSource = Trim.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "ID TRIM";
                        controlView.Columns[2].HeaderText = "DESCRIPCION";
                        controlView.Columns[4].HeaderText = "SEGMENTO";
                        controlView.Columns[5].HeaderText = "SECUENCIA";
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