using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcangelDialogs;
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

        public bool GetReporte(DateTime fecha1, DateTime fecha2,string id_cliente, DateTime fecha_r)
        {
            try
            {
                dsResurtimineto res = new dsResurtimineto();
                crResurtimineto cr = new crResurtimineto();

                string consulta = "";

                if (id_cliente == String.Empty)
                {
                    consulta = "";
                }
                else
                {
                    consulta = "AND SOHeader.CustID = '"+ id_cliente +"'";
                }

                var resurtimineto = dbd.Reporte1(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"), consulta);

                foreach (var item in resurtimineto)
                {
                    try
                    {
                        DateTime fecha_aux = fecha_r.AddDays(Convert.ToInt64(item.tiempo_entrega));
                        DateTime aux = Convert.ToDateTime(item.fecha_embarque);

                        TimeSpan timeSpan = fecha_aux - aux;

                        res.dsReporte.AdddsReporteRow(item.clave, item.descripcion, Convert.ToDecimal(item.cant_ord), item.ot, item.tipo_material, Convert.ToDecimal(item.existencia)
                            , item.unidad_compra, item.orden_venta, item.po, Convert.ToDecimal(item.adicional), Convert.ToDecimal(item.cantidad_ordenes_venta), item.cod_proveedor, item.desc_proveedor, item.proveedor,
                            item.tiempo_entrega, aux.ToString("dd/MM/yyyy"), item.cliente_id,fecha_r.ToString("dd/MM/yyyy"),fecha_aux.ToString("dd/MM/yyyy"), timeSpan.Days);
                    }
                    catch (Exception e)
                    {
                        
                    }
                    
                }

                cr.SetDataSource(res);
                vistaReporte2 view = new vistaReporte2();
                view.crv.ReportSource = cr;
                view.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
