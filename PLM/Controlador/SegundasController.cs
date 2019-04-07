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
    public class SegundasController
    {
        public void Segundas(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Segundas.Select(x => new { x.id, x.Cliente, x.Tela, x.Conf, x.Lavado, x.proc, x.avios, x.faltantes, x.total }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[0].HeaderText = "ID";
                    controlView.Columns[1].HeaderText = "CLIENTE";
                    controlView.Columns[2].HeaderText = "TELA";
                    controlView.Columns[3].HeaderText = "CONF";
                    controlView.Columns[4].HeaderText = "LAV";
                    controlView.Columns[5].HeaderText = "PROC";
                    controlView.Columns[6].HeaderText = "AVIOS";
                    controlView.Columns[7].HeaderText = "FALT";
                    controlView.Columns[8].HeaderText = "TOTAL";
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void SegundasSelect(MetroFramework.Controls.MetroTextBox descrip, MetroFramework.Controls.MetroTextBox idtext1, MetroFramework.Controls.MetroTextBox idtext2, MetroFramework.Controls.MetroTextBox idtext3, MetroFramework.Controls.MetroTextBox idtext4, MetroFramework.Controls.MetroTextBox idtext5, MetroFramework.Controls.MetroTextBox idtext6, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.Segundas.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    if (datos != null)
                    {

                        descrip.Text = datos.Cliente.ToString();
                        idtext1.Text = datos.Tela.ToString();
                        idtext2.Text = datos.Conf.ToString();
                        idtext3.Text = datos.Lavado.ToString();
                        idtext4.Text = datos.proc.ToString();
                        idtext5.Text = datos.avios.ToString();
                        idtext6.Text = datos.faltantes.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddSegundas(string cliente, string Tela, string Conf, string Lav, string proc, string avios, string falt, string total)
        {
            using (PLMContext db = new PLMContext())
            {
                var Segundas = new Segundas();
                Segundas.Cliente = cliente;
                Segundas.avios = avios + "%";
                Segundas.Tela = Tela + "%";
                Segundas.Conf = Conf + "%";
                Segundas.Lavado = Lav + "%";
                Segundas.proc = proc + "%";
                Segundas.faltantes = falt + "%";
                Segundas.total = total + "%";
                try
                {
                    db.Segundas.Add(Segundas);
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

        public bool UpdateSegundas(string cliente, string Tela, string Conf, string Lav, string proc, string avios, string falt, string total, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segundas = db.Segundas.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    Segundas.Cliente = cliente;
                    Segundas.avios = avios + "%";
                    Segundas.Tela = Tela + "%";
                    Segundas.Conf = Conf + "%";
                    Segundas.Lavado = Lav + "%";
                    Segundas.proc = proc + "%";
                    Segundas.faltantes = falt + "%";
                    Segundas.total = total + "%";
                    db.Entry(Segundas).State = EntityState.Modified;
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

        public bool DeleteSegundas(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segundas = (from x in db.Segundas where x.id == id select x).FirstOrDefault();
                    db.Segundas.Remove(Segundas);
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
                var Segundas = (from x in db.Segundas where x.Cliente == nom select x).Count();
                if (Segundas == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void BuscarSegundas(string Cliente, DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Segundas = (from x in db.Segundas where (x.Cliente == Cliente) select x).ToList();
                    if (Segundas != null)
                    {
                        if (Segundas.Count > 0)
                        {
                            controlView.DataSource = Segundas;
                            controlView.Columns[0].Visible = false;
                            controlView.Columns[0].HeaderText = "ID";
                            controlView.Columns[1].HeaderText = "CLIENTE";
                            controlView.Columns[2].HeaderText = "TELA";
                            controlView.Columns[3].HeaderText = "CONF";
                            controlView.Columns[4].HeaderText = "LAV";
                            controlView.Columns[5].HeaderText = "PROC";
                            controlView.Columns[6].HeaderText = "AVIOS";
                            controlView.Columns[7].HeaderText = "FALT";
                            controlView.Columns[8].HeaderText = "TOTAL";
                            controlView.Columns[9].Visible = false;
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
