using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcangelDialogs;
using MetroFramework.Controls;
using PLM.Modelo;
using PLM.Modelo.Reportes;
using PLM.Reportes;
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

        public bool GetReporte(DateTime fecha1, DateTime fecha2,string id_cliente)
        {
            try
            {
                dsResurtimineto res = new dsResurtimineto();
                crResurtimineto cr = new crResurtimineto();

                var resurtimineto = dbd.Reporte1(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"),"");

                foreach (var item in resurtimineto)
                {
                    res.dsReporte.AdddsReporteRow(item.clave,item.descripcion,item.cant_ord,item.ot,item.tipo_material, item.existencia
                    ,item.unidad_compra,item.orden_venta,item.po,item.adicional,item.cantidad_ordenes_venta,item.cod_proveedor,item.desc_proveedor,item.proveedor,
                    item.tiempo_entrega,item.fecha_embarque,item.cliente_id);
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
