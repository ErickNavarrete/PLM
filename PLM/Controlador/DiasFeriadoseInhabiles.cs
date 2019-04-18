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
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var Proveedoress = (from x in db.DiasFeriados select x).ToList();
                    if (Proveedoress != null)
                    {
                        if (Proveedoress.Count > 0)
                        {
                            List<ProveedoressTemp> tempProveedores = new List<ProveedoressTemp>();
                            foreach (var Proveedores in Proveedoress)
                            {
                                if (tempProveedores.Where(x => x.id == Proveedores.Proveedor).FirstOrDefault() == null)
                                {
                                    tempProveedores.Add(new ProveedoressTemp { id = Proveedores.Proveedor });
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            controlView.DataSource = tempProveedores;
                            controlView.Columns[0].HeaderText = "PROVEEDORES";
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
            public string id { get; set; }
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
                try
                {
                    var datos = (from x in db.DiasFeriados where (x.Proveedor == proveedor) select x).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false; 
                    controlView.Columns[1].HeaderText = "PROVEEDOR";
                    controlView.Columns[2].HeaderText = "DIAS FERIADOS E INAHBILES";
                    controlView.Columns[1].Width = 320;
                    controlView.Columns[2].Width = 364;
                    
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
