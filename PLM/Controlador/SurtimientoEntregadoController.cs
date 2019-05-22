using ArcangelDialogs;
using MetroFramework.Controls;
using PLM.Modelo;
using PLM.Reportes;
using PLM.Vista.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM.Controlador
{
    class SurtimientoEntregadoController
    {
        public Dynamics dbd = new Dynamics();

        public bool GetClientes(ComboBox comboBox)
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

        public bool GetReporte(DateTime fecha1, DateTime fecha2, string id_cliente, MetroProgressBar view_r, CheckedListBox Wonbr)
        {

            string consulta = "";
            string consulta2 = "";
            string fecha = "DEL " + fecha1.ToString("dd/MMMM/yyyy") + " AL " + fecha2.ToString("dd/MMMM/yyyy");
            string cliente = "";
            int contador = 0;
            int diasF = 0;
            int diasA = 0;
            int diasMargen = 0;
            int dias = 0;

            dsResurtimineto res = new dsResurtimineto();
            crSurtimientoEntregado cr = new crSurtimientoEntregado();

            res.dsGeneral.AdddsGeneralRow(fecha, cliente);
            try
            {
                //ARMAMOS LA CONUSLTA PARA LOS CLIENTES
                if (id_cliente == String.Empty)
                {
                    consulta = "";
                }
                else
                {
                    consulta = "and CustID = '" + id_cliente + "'";
                }
                //ARMAMOS LA CONUSLTA PARA LAS ORDENES DE TRABAJO
                if (Wonbr.CheckedItems.Count > 0)
                {
                    consulta2 = "and (";
                    foreach (string item in Wonbr.CheckedItems)
                    {
                        consulta2 = consulta2 + "WONbr = '" + item + "' OR ";
                    }
                    consulta2 = consulta2.TrimEnd(' ');
                    consulta2 = consulta2.TrimEnd('R');
                    consulta2 = consulta2.TrimEnd('O');
                    consulta2 = consulta2 + ")";
                }

                using (PLMContext db = new PLMContext())
                {
                    var resurtimineto = dbd.RSVW_REPSURTIMIENTOCANTSURTIDAs(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"), consulta, consulta2);
                    //OBTENEMOS LOS DIAS DE ANTICIPACION Y LOS DIAS DE MARGEN
                    try
                    {
                        diasA = (from x in db.DiasAnticipacion select new { x.DiasA }).FirstOrDefault().DiasA;
                        diasMargen = (from x in db.DiasAnticipacion select new { x.DiasdeMargen }).FirstOrDefault().DiasdeMargen;
                    }
                    catch (Exception e)
                    {
                        diasA = 0;
                    }

                    if(resurtimineto == null)
                    {
                        return false;
                    }

                    contador = resurtimineto.Count;
                    view_r.Minimum = 0;
                    view_r.Maximum = contador;

                    foreach (var item in resurtimineto)
                    {
                        view_r.Value = view_r.Value + 1;
                        //OBTENEMOS LOS DIAS FERIADOS
                        diasF = (from x in db.DiasFeriados where x.DiasF >= fecha1 && x.DiasF <= fecha2 && x.Proveedor == item.Proveedor select new { x.id }).Count();
                        
                        DateTime fecha_embarque = Convert.ToDateTime(item.FechaEmbarque);
                        DateTime fecha_recepcion = new DateTime();
                        decimal cantidad_recepcion = 0;
                        if (item.FechaRecepcion != "")
                        {
                            fecha_recepcion = Convert.ToDateTime(item.FechaRecepcion);
                        }
                        if (item.CantidadRecepcion != "")
                        {
                            cantidad_recepcion = Convert.ToDecimal(item.CantidadRecepcion);
                        }

                        res.dsReporte2.AdddsReporte2Row(item.InvtID,"",item.WONbr,item.OrdenVenta,item.Po,
                            fecha_embarque.ToString("dd/MMMM/yyyy"),
                            fecha_recepcion.ToString("dd/MMMM/yyyy"),
                            cantidad_recepcion,item.Proveedor);
                    }
                }

                cr.SetDataSource(res);
                vistaReporte2 view = new vistaReporte2();
                view.crv.ReportSource = cr;
                view.ShowDialog();
                view.BringToFront();

                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
