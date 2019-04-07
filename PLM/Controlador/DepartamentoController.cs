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
    public class DepartamentoController
    {            
        public void Departamento(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Departamentos.Select(x => new { x.id, x.IdDepartamento, x.Descripción,x.TResp }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "ID DEPARTAMENTO";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                    controlView.Columns[3].HeaderText = "T/RESP.";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void DepartamentoSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip,MetroFramework.Controls.MetroTextBox Tresp, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Departamentos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdDepartamento.ToString();
                        descrip.Text = datos.Descripción.ToString();
                        Tresp.Text = datos.TResp.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }
        public bool EliminarDepartamento(string dato)
        {
            using (PLMContext db = new PLMContext())
            {
                var datos = (from x in db.Trims where x.Departamento == dato select x).Count();
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
    
        public bool AddDepartamento(string IDDepartamento, string Descripcion,string Tresp, int thread)
        {
            using (PLMContext db = new PLMContext())
            {
                var Departamento = new Departamentos();
                Departamento.IdDepartamento = IDDepartamento;
                Departamento.Descripción = Descripcion; 
                Departamento.TResp= double.Parse(Tresp);
                Departamento.Dthread = thread;
                try
                {
                    db.Departamentos.Add(Departamento);
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

        public bool UpdateDepartamento(string IDDepartamento, string Descripcion, string Tresp, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {                   
                    var Departamento = db.Departamentos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Departamento.IdDepartamento = IDDepartamento;
                    Departamento.Descripción = Descripcion;
                    Departamento.TResp = double.Parse(Tresp);
                    db.Entry(Departamento).State = EntityState.Modified;
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

        public bool DeleteDepartamento(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var respuestaEsIngenieria = db.Departamentos.Where(x => x.id == id).Select(x => new { x.Dthread }).FirstOrDefault().Dthread;
                    int esIngenieria = respuestaEsIngenieria;                   
                    if(esIngenieria == 0)
                    {
                        var Departamento = (from x in db.Departamentos where x.id == id select x).FirstOrDefault();
                        db.Departamentos.Remove(Departamento);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }                    
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
                var Departamento = (from x in db.Departamentos where x.IdDepartamento == nom select x).Count();
                if (Departamento == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarDepartamento(string Descripcion, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Departamento = from x in db.Departamentos where (x.Descripción.Contains(Descripcion) || x.IdDepartamento.Contains(Descripcion)) select x;
                    if (Departamento != null)
                    {
                        controlView.DataSource = Departamento.ToList();
                        controlView.Columns[0].Visible = false;
                        controlView.Columns[2].Width = 500;
                        controlView.Columns[0].HeaderText = "ID";
                        controlView.Columns[1].HeaderText = "ID DEPARTAMENTO";
                        controlView.Columns[2].HeaderText = "DESCRIPCION"; 
                        controlView.Columns[3].HeaderText = "T/RESP.";
                        controlView.Columns[4].Visible = false;
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