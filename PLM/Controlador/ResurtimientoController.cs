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

        public bool GetReporte(DateTime fecha1, DateTime fecha2,string id_cliente, DateTime fecha_r, MetroProgressBar view_r, string c_cliente, CheckedListBox Wonbr)
        {
            try
            {
                dsResurtimineto res = new dsResurtimineto();
                crResurtimineto cr = new crResurtimineto();
                string consulta = "";
                string consulta2 = "";
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

                if(Wonbr.CheckedItems.Count > 0)
                {
                    consulta2 = "and (";
                    foreach(string item in Wonbr.CheckedItems)
                    {
                        consulta2 = consulta2 + "A.WONbr = '" + item + "' OR ";
                    }
                    consulta2 = consulta2.TrimEnd(' ');
                    consulta2 = consulta2.TrimEnd('R');
                    consulta2 = consulta2.TrimEnd('O');
                    consulta2 = consulta2 + ")";
                }

                using (PLMContext db = new PLMContext())
                {
                    var resurtimineto = dbd.Reporte1(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"), consulta, consulta2);
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

        public bool CreateOrdenVenta(string WONbr, string UserId, string CpnyID, DateTime fecha_r)
        {
            #region VARIABLES
            decimal TC = 0,Qty = 0;
            decimal costext = 0, costo = 0;
            string InvtID = "",VendID = "", periodo = "";
            string tax1 = "",tax2 = "",tax3 = "",tax4 = "",Terms = "",va1 = "",va2 = "",vf = "",vp = "",vn = "",ve = "",va = "",vci = "",vc = "",vs = "",vz = "";
            string vcuryid = "",CuryID = "",Addr1 = "",Addr2 = "",City = "",State = "",Attn = "",email = "",Fax = "",NameR = "",Phone = "";
            string Zip = "",Country = "",OC = "", LineRef = "", SiteID = "", cantidad = "", factalmac = "", factcomp = "", Descr = "", tipomaterial = "";
            decimal sumcuryextcost = 0, cantcost = 0, GranTotal = 0, sumextcost = 0, total = 0, factor = 0, ultimocosto = 0, nvacant = 0, CuryExtCost = 0;
            decimal CuryUnitCost = 0, ExtCost = 0 , cantidadcomp = 0;
            int Num = 0;

            DateTime FechaAct;
            #endregion
            WONbr = "9124290";

            //OBTENEMOS EL PONBR DEPENDIENDO LA ORDEN DE TRABAJO
            string purorddet = dbd.PURORDDET(WONbr);
            if (purorddet != "")
            {
                return false;
            }

            string status = dbd.PURCHORD(purorddet);
            if (status == "X")
            {
                MessageBox.Show("No se puede Generar Orden de Compra para esta Orden de Trabajo");
                return false;
            }

            FechaAct = fecha_r;
            string CuryRate = dbd.CuryRate(FechaAct.ToString("yyyy-MM-dd"));
            string Fecha = FechaAct.ToString("yyyy-MM-dd");
            periodo = FechaAct.ToString("yyyyMM");
            //string CuryRate = dbd.CuryRate("2017-11-30");
            if (CuryRate == "")
            {
                MessageBox.Show("No hay tipo de cambio registrado en el sistema");
                return false;
            } 
            TC = Convert.ToDecimal(CuryRate);
            //HACEMOS TRUNCATE A LAS TABLAS
            dbd.Truncate_Rstb_GeneraOC();
            dbd.Truncate_RsTb_Vendid();
            var bWOMatlReq = (from x in dbd.wOMatlReqs() select new {x}).Where(x=> x.x.WONbr == WONbr).ToList();

            if(bWOMatlReq.Count == 0)
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
            
            if(bRsTb_GeneraOC == null)
            {
                return false;
            }

            foreach (var item in bRsTb_GeneraOC)
            {
                var bInventory = (from x in dbd.Inventario5() select new { x }).Where(x => x.x.InvtID == item.InvtId ).FirstOrDefault();
                if (bInventory != null)
                {
                    if (bInventory.x.ReordQty != "0" && bInventory.x.ReordPt != "0")
                    {
                        dbd.delete_Rstb_GeneraOC(item.InvtId);
                    }
                }                
            }

            //LLAMAMOS AL STORED PROCEDURE
            dbd.RsSp_InsertVendid();

            var bRsTb_Vendid = dbd.Rstb_Vendid();
            foreach(var item in bRsTb_Vendid)
            {
                Num = 0;
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
                if(Convert.ToInt64(OC) >= 1000 && Convert.ToInt64(OC) < 10000)
                {
                    OC = "00" + OC;
                }else if(Convert.ToInt64(OC) >= 10000 && Convert.ToInt64(OC) < 100000)
                {
                    OC = "0" + OC;
                }
                sumcuryextcost = 0;
                sumextcost = 0;

                var bRsTb_GeneraOC2 = (from x in dbd.RsTb_GeneraOC() select new { x }).Where(x => x.x.VendId == item).ToList();
                foreach (var item2 in bRsTb_GeneraOC2)
                {
                    Num += 1;
                    if(Num < 10)
                    {
                        LineRef = "000" + Num;
                    }else if(Num >= 10 && Num < 100)
                    {
                        LineRef = "000" + Num;
                    }else if(Num >= 100 && Num< 1000)
                    {
                        LineRef = "00" + Num;
                    }
                    else
                    {
                        LineRef = "0" + Num;
                    }
                    SiteID = item2.x.User1;
                    cantidad = Convert.ToString(item2.x.Qty);
                    cantcost = item2.x.User5;
                    GranTotal = GranTotal + total;

                    var bInventory2 = (from x in dbd.Inventario5() select new { x }).Where(x => x.x.InvtID == item2.x.InvtId).FirstOrDefault();
                    if(bInventory2 != null)
                    {
                        factalmac = bInventory2.x.StkUnit;
                        factcomp = bInventory2.x.DfltPOUnit;
                        Descr = bInventory2.x.Descr;
                        tipomaterial = bInventory2.x.MaterialType;
                        decimal bINUnit = dbd.InUnit(factalmac,factcomp);
                        if(bINUnit != 0)
                        {
                            factor = bINUnit;
                        }
                        if(bInventory2.x.user3 == "0")
                        {
                            if(factcomp.Substring(1,1) == "C" || factcomp.Substring(1, 1) == "R" || factcomp.Substring(1, 1) == "Y")
                            {
                                total = TC * item2.x.User5;
                                ultimocosto = item2.x.User6 * factor / TC;
                                cantidadcomp = Convert.ToDecimal(cantidad) / factor;
                                nvacant = Math.Round(cantidadcomp, 0);
                                cantidadcomp = nvacant;
                                CuryExtCost = item2.x.User6 * factor * cantidadcomp / TC;
                                CuryUnitCost = item2.x.User6 * factor / TC;
                                ExtCost = CuryExtCost * TC;
                            }
                            else
                            {
                                total = TC * item2.x.User5;
                                ultimocosto = item2.x.User6 * factor / TC;
                                cantidadcomp = Convert.ToDecimal(cantidad) / factor;
                                CuryExtCost = item2.x.User6 * factor * cantidadcomp / TC;
                                CuryUnitCost = item2.x.User6 * factor / TC;
                                ExtCost = CuryExtCost * TC;
                            }
                        }
                        else
                        {
                            if (factcomp.Substring(1, 1) == "C" || factcomp.Substring(1, 1) == "R" || factcomp.Substring(1, 1) == "Y")
                            {
                                total = item2.x.User5;
                                ultimocosto = item2.x.User6;
                                cantidadcomp = Convert.ToDecimal(cantidad) / factor;
                                nvacant = Math.Round(cantidadcomp, 0);
                                cantidadcomp = nvacant;
                                CuryExtCost = item2.x.User6 * cantidadcomp;
                                CuryUnitCost = item2.x.User6;
                                ExtCost = CuryExtCost;
                            }
                            else
                            {
                                total = item2.x.User5;
                                ultimocosto = item2.x.User6;
                                cantidadcomp = Convert.ToDecimal(cantidad) / factor;
                                CuryExtCost = item2.x.User6 * cantidadcomp;
                                CuryUnitCost = item2.x.User6;
                                ExtCost = CuryExtCost;
                            }
                        }
                        //INSERT STATEMENTS
                        dbd.Insert_PURORDDET(factor,Qty,Fecha,UserId,CuryExtCost,CuryID,TC,CuryUnitCost,ExtCost,InvtID,Num,LineRef,OC,WONbr,factcomp, cantidadcomp,Fecha, SiteID,
                            tax1,tax2,tax3,tax4,Descr,item2.x.User6.ToString());

                        dbd.Insert_POREQDET(factor, Fecha,UserId,CuryExtCost,CuryID,TC,CuryUnitCost,ExtCost,InvtID,Num,LineRef,OC,factcomp,cantidadcomp,Fecha,SiteID,tax1,tax2,
                            tax3,tax4,Descr,item2.x.User6.ToString(),tipomaterial);

                        var bPOReqDet = (from x in dbd.POREQDET() select new { x }).Where(x => x.x.ReqNbr == OC).ToList();
                        foreach(var item3 in bPOReqDet)
                        {
                            sumextcost = sumextcost + item3.x.ExtCost;
                            sumcuryextcost = sumcuryextcost + item3.x.CuryCuryExtCost;
                        }

                    }
                }

                //INSERT STATEMENTS
                dbd.Insert_PurchOrd(Fecha, UserId, CuryID, CpnyID, sumcuryextcost, WONbr, periodo, sumextcost, email, TC, Num, OC, tax1, tax2, tax3, tax4, Addr1, Addr2, Attn, City, Country, Fax, NameR,
                    Phone, State, Zip, Terms, va, va2, va1, vci, vc, vf, ve, VendID, vn, vp, vs, vz);

                dbd.Insert_PoReqHdr(Fecha, UserId, CuryID, CpnyID, sumcuryextcost, WONbr, periodo, sumextcost, email, TC, Num, OC, tax1, tax2, tax3, tax4, Addr1, Addr2, Attn, City, Country, Fax,
                    NameR, Phone, State, Zip, Terms, va, va2, va1, vci, vc, vf, ve, VendID, vn, vp, vs, vz);

                dbd.Update_PoSetUp(OC);
            }

            dbd.Update_WoHeader(WONbr);
            return true;
        }

        public List<string> GetWONBR(DateTime fecha1, DateTime fecha2, string id_cliente, DateTime fecha_r, string c_cliente, MetroProgressBar view_r)
        {
            try
            {
                int contador = 0;
                string consulta = "";
                List<string> vs = new List<string>();

                if (id_cliente == String.Empty)
                {
                    consulta = "";
                }
                else
                {
                    consulta = "AND SOHeader.CustID = '" + id_cliente + "'";
                }

                var resurtimineto = dbd.Reporte1(fecha1.ToString("yyyy-MM-dd"), fecha2.ToString("yyyy-MM-dd"), consulta, "");
                if (resurtimineto != null)
                {
                    contador = resurtimineto.Count;
                    view_r.Minimum = 0;
                    view_r.Maximum = contador;
                    foreach (var item in resurtimineto)
                    {
                        view_r.Value = view_r.Value + 1;
                        vs.Add(item.po);
                    }
                }
                
                var WONBR = vs.Distinct().ToList();
                return WONBR;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public bool PutWonbr(CheckedListBox Wonbr, MetroTextBox tbWonbr)
        {
            List<string> OT = new List<string>();
            Wonbr.Items.Clear();
            
            try
            {
                if(tbWonbr.Text == "")
                {
                    OT = (from x in dbd.GetWonbr() select new { x }).Where(x => x.x.Contains(tbWonbr.Text)).Select(x => x.x).ToList();
                }
                else
                {
                    OT = (from x in dbd.GetWonbr() select new { x }).Where(x => x.x.Contains(tbWonbr.Text)).Select(x => x.x).ToList();
                }

                foreach(string item in OT)
                {
                    Wonbr.Items.Add(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Dialogs.Show(ex.Message, DialogsType.Error);
                return false;
            }
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
