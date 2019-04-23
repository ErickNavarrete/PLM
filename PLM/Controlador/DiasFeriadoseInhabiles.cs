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
    public class DiasFeriadoseInhabiles
    {
        private Dynamics Dbd;

        public bool DeleteDiasF(int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var DiasF = (from x in db.DiasFeriados where x.id == id select x).FirstOrDefault();
                    db.DiasFeriados.Remove(DiasF);
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

        public void BuscarProveedoressfiltro(DataGridView controlView)
        {
            Dbd = new Dynamics();

            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Proveedoress = (from x in db.DiasFeriados select x).ToList();
                    var datosP = Dbd.Reporte2().ToList();
                    string nombre = "";
                    if (Proveedoress != null)
                    {
                        if (Proveedoress.Count > 0)
                        {
                            List<Proveedores> tempProveedores = new List<Proveedores>();
                            foreach (var Proveedores in Proveedoress)
                            {
                                if (tempProveedores.Where(x => x.Clave == Proveedores.Proveedor).FirstOrDefault() == null)
                                {
                                    nombre = datosP.Where(x => x.Clave == Proveedores.Proveedor).Select(x => x.Nombre).FirstOrDefault();
                                    tempProveedores.Add(new Proveedores { Clave = Proveedores.Proveedor, Nombre = nombre });
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            controlView.Columns.Clear();
                            controlView.DataSource = tempProveedores;
                            controlView.Columns[0].Width = 100;
                            controlView.Columns[1].Width = 500;
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

        private class ProveedoressTemp
        {
            public int id { get; set; }
            public string Clave { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
        }
        public void Proveedores(DataGridView dtdatos, int idFuncion)
        {
            using (PLMContext db = new PLMContext())
            {
                switch (idFuncion)
                {
                    case 33:
                        try
                        {
                            var datos = db.DiasFeriados.Select(x => new { x.Proveedor }).ToList();
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
        public bool ExisteDiasFeriadossP(string IdDiasFeriadoss)
        {           
            using (PLMContext db = new PLMContext())
            {
                var DiasFeriadoss = (from x in db.DiasFeriados where (x.Proveedor == IdDiasFeriadoss ) select x).Count();
                if (DiasFeriadoss == 0)
                {                
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool ExisteDiasFeriadossF(string IdDiasFeriadoss, DateTime fecha)
        {
            DateTime _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime _fechaTope = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
            using (PLMContext db = new PLMContext())
            {
                var DiasFeriadoss = (from x in db.DiasFeriados where (x.Proveedor == IdDiasFeriadoss && x.DiasF >= _fechaInicio && x.DiasF <= _fechaTope) select x).Count();
                if (DiasFeriadoss == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void DiasF(string proveedor ,DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                Dbd = new Dynamics();
                try
                {
                    var datosP = Dbd.Reporte2().ToList();
                    var datos = (from x in db.DiasFeriados where (x.Proveedor == proveedor) select x).ToList();

                    List<ProveedoressTemp> consulta = new List<ProveedoressTemp>();
                    string nombre = "";
                    foreach(var item in datos)
                    {
                        nombre = datosP.Where(x => x.Clave == item.Proveedor).Select(x => x.Nombre).FirstOrDefault();
                        consulta.Add(new ProveedoressTemp { Clave = item.Proveedor, Nombre = nombre, id = item.id, Fecha = item.DiasF });
                    }

                    controlView.DataSource = consulta;
                    controlView.Columns[0].Visible = false; 
                    controlView.Columns[1].HeaderText = "CLAVE PROVEEDOR";
                    controlView.Columns[2].HeaderText = "NOMBRE PROVEEDOR";
                    controlView.Columns[3].HeaderText = "DIAS FERIADOS E INAHBILES";
                    controlView.Columns[1].Width = 150;
                    controlView.Columns[2].Width = 400;
                    controlView.Columns[3].Width = 364;
                    
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void DiasF_T(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                Dbd = new Dynamics();
                try
                {
                    var datosP = Dbd.Reporte2().ToList();
                    var datos = (from x in db.DiasFeriados select x).ToList();

                    List<ProveedoressTemp> consulta = new List<ProveedoressTemp>();
                    string nombre = "";
                    foreach (var item in datos)
                    {
                        nombre = datosP.Where(x => x.Clave == item.Proveedor).Select(x => x.Nombre).FirstOrDefault();
                        consulta.Add(new ProveedoressTemp { Clave = item.Proveedor, Nombre = nombre, id = item.id, Fecha = item.DiasF });
                    }

                    controlView.DataSource = consulta;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[1].HeaderText = "CLAVE PROVEEDOR";
                    controlView.Columns[2].HeaderText = "NOMBRE PROVEEDOR";
                    controlView.Columns[3].HeaderText = "DIAS FERIADOS E INAHBILES";
                    controlView.Columns[1].Width = 150;
                    controlView.Columns[2].Width = 400;
                    controlView.Columns[3].Width = 364;

                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool AddDiaF(string IDFIt, DateTime Descripcion)
        {
            using (PLMContext db = new PLMContext())
            {
                var Fit = new DiasFeriados();
                Fit.Proveedor = IDFIt;
                Fit.DiasF = Descripcion;
                try
                {
                    db.DiasFeriados.Add(Fit);
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
    }
}
