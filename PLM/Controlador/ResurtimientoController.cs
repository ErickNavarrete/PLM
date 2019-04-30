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
                int diasMargen = 0;
                int dias = 0;

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
                    try
                    {
                        diasA = (from x in db.DiasAnticipacion select new { x.DiasA }).FirstOrDefault().DiasA;
                        diasMargen = (from x in db.DiasAnticipacion select new { x.DiasdeMargen }).FirstOrDefault().DiasdeMargen;
                    }
                    catch (Exception e)
                    {
                        diasA = 0;
                    }
                    
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

                                DateTime fecha_ent = fecha_r.AddDays(Convert.ToInt64(item.tiempo_entrega));
                                DateTime fecha_proy = Convert.ToDateTime(item.fecha_embarque);
                                DateTime fecha_embarque = Convert.ToDateTime(item.fecha_embarque);

                                dias = (diasA + diasMargen) * -1;
                                fecha_proy = fecha_proy.AddDays(dias);

                                fecha_ent = fecha_ent.AddDays(diasF);

                                TimeSpan timeSpan = fecha_proy - fecha_ent;

                                orden.OT = item.ot;
                                orden.PO = item.po;
                                orden.CantFab = item.cant_fabr;
                                vs.Add(item.po);
                                ordenes_trabajo.Add(orden);

                                res.dsReporte.AdddsReporteRow(item.clave, item.descripcion, Convert.ToDecimal(item.cant_ord), item.ot, item.tipo_material, Convert.ToDecimal(item.existencia)
                                    , item.unidad_compra, item.orden_venta, item.po, Convert.ToDecimal(item.adicional), Convert.ToDecimal(item.cantidad_ordenes_venta), item.cod_proveedor, item.desc_proveedor, item.proveedor,
                                    item.tiempo_entrega, fecha_proy.ToString("dd/MM/yyyy"), item.cliente_id, fecha_r.ToString("dd/MM/yyyy"), fecha_ent.ToString("dd/MM/yyyy"), timeSpan.Days, fecha_embarque.ToString("dd/MM/yyyy"));
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
                                c = c + " , " + item2.OT;
                                suma = suma + Convert.ToDecimal(item2.CantFab);
                            }

                            c = c.Substring(2);
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

        public bool CreateOrdenVenta(string WONbr)
        {
            #region VARIABLES
            decimal TC,Qty;
            decimal costext = 0, costo = 0;
            string InvtID,VendID = "";
            string tax1 = "";
            string tax2 = "";
            string tax3 = "";
            string tax4 = "";
            string Terms = "";
            string va1 = "";
            string va2 = "";
            string vf = "";
            string vp = "";
            string vn = "";
            string ve = "";
            string va = "";
            string vci = "";
            string vc = "";
            string vs = "";
            string vz = "";
            string vcuryid = "";
            string CuryID = "";
            string Addr1 = "";
            string Addr2 = "";
            string City = "";
            string State = "";
            string Attn = "";
            string email = "";
            string Fax = "";
            string NameR = "";
            string Phone = "";
            string Zip = "";
            string Country = "";
            string OC = "";

            DateTime FechaAct;
            #endregion

            //OBTENEMOS EL PONBR DEPENDIENDO LA ORDEN DE TRABAJO
            string purorddet = dbd.PURORDDET(WONbr);
            if(purorddet == ""){
                return false;
            }

            string status = dbd.PURCHORD(purorddet);
            if (status != "X")
            {
                MessageBox.Show("No se puede Generar Orden de Compra para esta Orden de Trabajo");
                return false;
            }

            FechaAct = DateTime.Now;
            string CuryRate = dbd.CuryRate(FechaAct.ToString("yyyy-MM-dd"));
            TC = Convert.ToDecimal(CuryRate);
            //HACEMOS TRUNCATE A LAS TABLAS
            dbd.Truncate_Rstb_GeneraOC();
            dbd.Truncate_RsTb_Vendid();
            var bWOMatlReq = (from x in dbd.wOMatlReqs() select new {x}).Where(x=> x.x.WONbr == WONbr).ToList();

            if(bWOMatlReq == null)
            {
                MessageBox.Show("No hay lista de Materiales asignada a esta Orden de Trabajo");
                return false;
            }

            foreach (var item in bWOMatlReq)
            {
                InvtID = item.x.InvtID;
                Qty = Convert.ToDecimal(item.x.QtyWOReqd);
                if(item.x.SiteID == "MAT. PRIMA")
                {
                    var bInventario = (from x in dbd.Inventario5() select new {x}).Where(x=> x.x.InvtID == item.x.InvtID).FirstOrDefault();
                    if(bInventario != null)
                    {
                        VendID = bInventario.x.Supplr1;
                        if(bInventario.x.user3 == "0")
                        {
                            costext = Convert.ToDecimal(Qty) * Convert.ToDecimal(bInventario.x.LastCost);
                            costo = Convert.ToDecimal(bInventario.x.LastCost);
                        }
                        else
                        {
                            costext = Convert.ToDecimal(Qty) * Convert.ToDecimal(bInventario.x.user3);
                            costo = Convert.ToDecimal(bInventario.x.user3);
                        }
                        if(VendID == "")
                        {
                            MessageBox.Show("El Articulo No tiene Proveedor..  " + item.x.InvtID + "   NO SE GENERAR� LA OC");
                        }
                        
                    }
                    dbd.Insert_Rstb_GeneraOC(InvtID, Qty, VendID, WONbr, item.x.SiteID, costext, costo);
                }                
            }

            var bRsTb_GeneraOC = dbd.RsTb_GeneraOC();   
            foreach(var item in bRsTb_GeneraOC)
            {
                var bInventory = (from x in dbd.Inventario5() select new { x }).Where(x => x.x.InvtID == item.InvtId ).FirstOrDefault();
                if(bInventory.x.ReordQty != "0" && bInventory.x.ReordPt != "0")
                {
                    dbd.delete_Rstb_GeneraOC(item.InvtId);
                }
            }

            //LLAMAMOS AL STORED PROCEDURE

            var bRsTb_Vendid = dbd.Rstb_Vendid();
            foreach(var item in bRsTb_Vendid)
            {
                var bVendor = (from x in dbd.Vendor() select new {x}).Where(x=> x.x.VendId == item).FirstOrDefault();
                if(bVendor != null)
                {
                    if(bVendor.x.CuryId == "MN")
                    {
                        TC = 1;
                    }
                    if(bVendor.x.CuryId == "")
                    {
                        CuryID = "USD";
                    }
                    else
                    {
                        CuryID = bVendor.x.CuryId;
                    }
                    tax1 = bVendor.x.TaxId00;
                    tax2 = bVendor.x.TaxId01;
                    tax3 = bVendor.x.TaxId02;
                    tax4 = bVendor.x.TaxId03;
                    Terms = bVendor.x.Terms;
                    va1 = bVendor.x.Addr1;
                    va2 = bVendor.x.Addr2;
                    vf = bVendor.x.Fax;
                    vp = bVendor.x.Phone;
                    vn = bVendor.x.Name;
                    ve = bVendor.x.EMailAddr;
                    va = bVendor.x.Attn;
                    vci = bVendor.x.City;
                    vc = bVendor.x.Country;
                    vs = bVendor.x.State;
                    vz = bVendor.x.Zip;
                    vcuryid = bVendor.x.CuryId;
                }
                var bPOSetup = dbd.PoSetup();
                Addr1 = bPOSetup.ShipAddr1;
                Addr2 = bPOSetup.ShipAddr2;
                City = bPOSetup.ShipCity;
                State = bPOSetup.ShipState;
                Attn = bPOSetup.ShipAttn;
                email = bPOSetup.ShipEmail;
                Fax = bPOSetup.ShipFax;
                NameR = bPOSetup.ShipName;
                Phone = bPOSetup.ShipPhone;
                Zip = bPOSetup.ShipZip;
                Country = bPOSetup.ShipCountry;
                OC = bPOSetup.LastPONbr + 1;
            }
            return true;
        }
    }

    public partial class ot
    {
        public string PO;
        public string OT;
        public string CantFab;
    }

    public partial class RsTb_GeneraOC
    {
        public string InvtId;
        public decimal Qty;
        public string VendId;
        public string WonBr;
        public string User1;
        public decimal User5;
        public decimal User6;
    }
}
