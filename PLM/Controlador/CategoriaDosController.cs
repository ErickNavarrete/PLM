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
    public class CategoryDosController
    {                                 
        public void CategoryDos(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {              
                try
                {
                    var datos = db.Category_2.Select(x => new { x.id, x.IdCategory2, x.Descripción }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[2].Width = 500;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "IDCATEGORY-2";
                    controlView.Columns[2].HeaderText = "DESCRIPCION";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);                  
                }
            }            
        }

        public void CategoryDosSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Category_2.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdCategory2.ToString();
                        descrip.Text = datos.Descripción.ToString();
                    }                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddCategoryDos(string IDCategoryDos, string Descripcion)
        {
            using(PLMContext db = new PLMContext())
            {
                var CategoryDos = new Category_2();
                CategoryDos.IdCategory2 = IDCategoryDos;
                CategoryDos.Descripción = Descripcion;
                try
                {
                    db.Category_2.Add(CategoryDos);
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

        public bool UpdateCategoryDos(string IDCategoryDos, string Descripcion, int id)
        {
            using (PLMContext db = new PLMContext())
            {            
                try
                {
                    var CategoryDos = db.Category_2.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    CategoryDos.IdCategory2 = IDCategoryDos;
                    CategoryDos.Descripción = Descripcion;
                    db.Entry(CategoryDos).State = EntityState.Modified;
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

        public void Category2e(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 10:
                        try
                        {
                            var datos = db.Category_2.Select(x => new { x.Descripción }).ToList();
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

        public bool DeleteCategoryDos(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var CategoryDos = (from x in db.Category_2 where x.id == id select x).FirstOrDefault();
                    db.Category_2.Remove(CategoryDos);
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

        public void Category2(MetroComboBox dato)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Category_2.Select(x => new { x.IdCategory2, x.Descripción }).ToList();
                    dato.Items.Clear();
                    dato.ValueMember = "IdCategory2";
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
                var CategoryDos = (from x in db.Category_2 where x.IdCategory2 == nom select x).Count();
                if (CategoryDos == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarCategoryDos(string Descripcion, DataGridView controlView) 
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                  var CategoryDos = from x in db.Category_2 where (x.Descripción.Contains(Descripcion) || x.IdCategory2.Contains(Descripcion) ) select x ;
                  if (CategoryDos != null) 
                  {
                      controlView.DataSource = CategoryDos.ToList();
                      controlView.Columns[0].Visible = false;
                      controlView.Columns[2].Width = 500;
                      controlView.Columns[0].HeaderText = "ID";
                      controlView.Columns[1].HeaderText = "IDCATEGORY-2";
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
    

