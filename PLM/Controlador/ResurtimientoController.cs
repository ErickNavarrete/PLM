using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcangelDialogs;
using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Controls;
using PLM.Modelo;
using PLM.Modelo.Reportes;
using PLM.Reportes;
using PLM.Vista.BOM;
using PLM.Vista.Reporte;

namespace PLM.Controlador
{
    class ResurtimientoController
    {
        public Dynamics dbd = new Dynamics();

        public bool GetClientes(MetroComboBox comboBox)
        {
            try
            {
                var clientes = dbd.Inventario2();

                comboBox.Items.Clear();

                foreach (Inventory item in clientes)
                {
                    comboBox.Items.Add(item.Cliente);
                }

                return true;
            }
            catch (Exception ex)
            {
                Dialogs.Show(ex.Message, DialogsType.Error);
                return false;
            }
        }

        public bool GetReporte(DateTime fecha1, DateTime fecha2,string id_cliente, DateTime fecha_r, MetroProgressBar view_r, string c_cliente)
        {
            try
            {
                dsResurtimineto res = new dsResurtimineto();
                crResurtimineto cr = new crResurtimineto();
                string consulta = "";
                string fecha = "DEL " + fecha1.ToString("dd/MMMM/yyyy") + " AL " + fecha2.ToString("dd/MMMM/yyyy");
                string cliente = c_cliente.ToUpper();

                int contador = 0;
                int diasF = 0;
                int diasA = 0;

                List <ot> ordenes_trabajo = new List<ot>();
                List<string> vs = new List<string>();

                res.dsGeneral.AdddsGeneralRow(fecha, cliente);
                
                if (id_cliente == String.Empty)
                {
                    consulta = "";
                }
                else
                {
                    consulta = "AND SOHeader.CustID = '"+ id_cliente +"'";
                }

                using (PLMContext db = new PLMContext())
                {
                    var resurtimineto = dbd.Reporte1(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"), consulta);
                    diasA = (from x in db.DiasAnticipacion select new { x.DiasdeMargen }).FirstOrDefault().DiasdeMargen;

                    if (resurtimineto != null)
                    {
                        contador = resurtimineto.Count;
                        view_r.Minimum = 0;
                        view_r.Maximum = contador;

                        foreach (var item in resurtimineto)
                        {
                            view_r.Value = view_r.Value + 1;
                            try
                            {
                                ot orden = new ot();
                                diasF = (from x in db.DiasFeriados where x.DiasF >= fecha1 && x.DiasF <= fecha2 && x.Proveedor == item.proveedor select new { x.id }).Count();

                                DateTime fecha_aux = fecha_r.AddDays(Convert.ToInt64(item.tiempo_entrega));
                                DateTime aux = Convert.ToDateTime(item.fecha_embarque);

                                aux = aux.AddDays((diasF * -1));
                                aux = aux.AddDays(diasA);


                                fecha_aux = fecha_aux.AddDays(diasF);

                                TimeSpan timeSpan = fecha_aux - aux;

                                orden.OT = item.ot;
                                orden.PO = item.po;
                                orden.CantFab = item.cant_fabr;
                                vs.Add(item.po);
                                ordenes_trabajo.Add(orden);

                                res.dsReporte.AdddsReporteRow(item.clave, item.descripcion, Convert.ToDecimal(item.cant_ord), item.ot, item.tipo_material, Convert.ToDecimal(item.existencia)
                                    , item.unidad_compra, item.orden_venta, item.po, Convert.ToDecimal(item.adicional), Convert.ToDecimal(item.cantidad_ordenes_venta), item.cod_proveedor, item.desc_proveedor, item.proveedor,
                                    item.tiempo_entrega, aux.ToString("dd/MM/yyyy"), item.cliente_id, fecha_r.ToString("dd/MM/yyyy"), fecha_aux.ToString("dd/MM/yyyy"), timeSpan.Days);
                            }
                            catch (Exception e)
                            {

                            }
                        }

                        var aux2 = vs.Distinct().ToList();
                        string c = "";
                        decimal suma = 0;

                        foreach (var item in aux2)
                        {
                            c = "";
                            suma = 0;
                            var concat = (from x in ordenes_trabajo where x.PO == item select new { x.OT, x.CantFab }).Distinct().ToList();
                            foreach (var item2 in concat)
                            {
                                c = c + "," + item2.OT;
                                suma = suma + Convert.ToDecimal(item2.CantFab);
                            }

                            c = c.Substring(1);
                            res.dsOT.AdddsOTRow(item, c, suma);
                        }

                        //cr.Load(Path.GetFullPath("crResurtimineto.rpt"));
                        cr.SetDataSource(res);
                        vistaReporte2 view = new vistaReporte2();
                        view.crv.ReportSource = cr;
                        view.ShowDialog();
                        view.BringToFront();

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public string GetIdCliente(string nombre)
        {
            string id_cliente = "";
            try
            {
                var resurtimiento = (from x in dbd.Inventario2() where x.Cliente == nombre select new {x.IdCliente}).ToList().FirstOrDefault();

                if (resurtimiento != null)
                {
                    id_cliente = resurtimiento.IdCliente;
                }

                return id_cliente;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }

    public partial class ot
    {
        public string PO;
        public string OT;
        public string CantFab;
    }
}
