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
    public class PresupuestosController
    {
        public void Presupuestos(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Presupuestos.Select(x => new {x.id, x.IdPresupuesto,x.Diario,x.Mo,x.Prestaciones,x.Admon, x.Prod,x.Ventas,x.Varios }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[2].HeaderText = "DIARIO";
                    controlView.Columns[3].HeaderText = "M.O. DIRECTA";
                    controlView.Columns[4].HeaderText = "PRESTACIONES";
                    controlView.Columns[5].HeaderText = "ADMON";
                    controlView.Columns[6].HeaderText = "PROD";
                    controlView.Columns[7].HeaderText = "VENTAS";
                    controlView.Columns[8].HeaderText = "VARIOS";
                    controlView.Columns[1].HeaderText = "ID PRESUPUESTO"; 
                    
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void PresupuestosSelect(MetroFramework.Controls.MetroTextBox idtext, MetroFramework.Controls.MetroTextBox descrip, MetroFramework.Controls.MetroTextBox idtext1, MetroFramework.Controls.MetroTextBox idtext2, MetroFramework.Controls.MetroTextBox idtext3, MetroFramework.Controls.MetroTextBox idtext4, MetroFramework.Controls.MetroTextBox idtext5,MetroFramework.Controls.MetroTextBox idtext6,  int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Presupuestos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {
                        idtext.Text = datos.IdPresupuesto.ToString();
                        descrip.Text = datos.Diario.ToString();
                        idtext1.Text = datos.Mo.ToString();
                        idtext2.Text = datos.Prestaciones.ToString();
                        idtext3.Text = datos.Admon.ToString();
                        idtext4.Text = datos.Prod.ToString();
                        idtext5.Text = datos.Ventas.ToString();
                        idtext6.Text = datos.Varios.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddPresupuestos(string Diario, string Mo, string Prestaciones, string Admon, string Prod, string Ventas, string Varios, string IdPresupuestos)
        {
            using (PLMContext db = new PLMContext())
            {
                var Presupuestos = new Presupuestos();
                Presupuestos.IdPresupuesto = IdPresupuestos;
                Presupuestos.Diario = Diario;
                Presupuestos.Mo = "MX$" + Mo ;
                Presupuestos.Prestaciones = "MX$" + Prestaciones ;
                Presupuestos.Admon = "MX$" + Admon ;
                Presupuestos.Prod = "MX$" + Prod ;
                Presupuestos.Ventas = "MX$" + Ventas ;
                Presupuestos.Varios = "MX$" + Varios ;                
                try
                {
                    db.Presupuestos.Add(Presupuestos);
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

        public bool UpdatePresupuestos(string Diario, string Mo, string Prestaciones, string Admon, string Prod, string Ventas, string Varios, string IdPresupuestos, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Presupuestos = db.Presupuestos.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Presupuestos.IdPresupuesto = IdPresupuestos;
                    Presupuestos.Diario = Diario;
                    Presupuestos.Mo = "MX$" + Mo;
                    Presupuestos.Prestaciones = "MX$" + Prestaciones;
                    Presupuestos.Admon = "MX$" + Admon;
                    Presupuestos.Prod = "MX$" + Prod;
                    Presupuestos.Ventas = "MX$" + Ventas;
                    Presupuestos.Varios = "MX$" + Varios;               
                    db.Entry(Presupuestos).State = EntityState.Modified;
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

        public bool DeletePresupuestos(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Presupuestos = (from x in db.Presupuestos where x.id == id select x).FirstOrDefault();
                    db.Presupuestos.Remove(Presupuestos);
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
                var Presupuestos = (from x in db.Presupuestos where x.IdPresupuesto == nom select x).Count();
                if (Presupuestos == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarPresupuestos(string IdPresupuestos, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Presupuestos = (from x in db.Presupuestos where (x.IdPresupuesto == IdPresupuestos) select new {x.id, x.IdPresupuesto,x.Diario,x.Mo,x.Prestaciones,x.Admon, x.Prod,x.Ventas,x.Varios }).ToList();
                    if (Presupuestos != null)
                    {
                        if (Presupuestos.Count > 0)
                        {
                            controlView.DataSource = Presupuestos;
                            controlView.Columns[0].Visible = false;
                            controlView.Columns[0].HeaderText = "ID";
                            controlView.Columns[2].HeaderText = "DIARIO";
                            controlView.Columns[3].HeaderText = "M.O. DIRECTA";
                            controlView.Columns[4].HeaderText = "PRESTACIONES";
                            controlView.Columns[5].HeaderText = "ADMON";
                            controlView.Columns[6].HeaderText = "PROD";
                            controlView.Columns[7].HeaderText = "VENTAS";
                            controlView.Columns[8].HeaderText = "VARIOS";
                            controlView.Columns[1].HeaderText = "ID PRESUPUESTO";                           
                        }
                        else
                        {
                            controlView.DataSource = null;
                        }
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
