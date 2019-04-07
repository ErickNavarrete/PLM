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
using System.Drawing;
using System.IO;

namespace PLM.Controlador
{
    public class BOMController
    {
        public Dynamics dbd;

        public BOMController()
        {
            dbd = new Dynamics();
        }

        class BOM
        {
            public string segmentos { get; set; }

            public int status { get; set; }

            public string trims { get; set; }

            public string itemCode { get; set; }

            public string category { get; set; }

            public string descripcion { get; set; }

            public string color { get; set; }

            public double cantidad { get; set; }

            public string piece { get; set; }

            public string supplier { get; set; }

            public double costo { get; set; }

            public string notas { get; set; }

            public string ntarea { get; set; }
        }

        class mostrarHilos
        {
            public double mtsvista { get; set; }

            public string Vista { get; set; }

            public string Interior { get; set; }

            public double mtsinterior { get; set; }

            public int posicion { get; set; }

            public double total { get; set; }

            public string notas { get; set; }

            public string Codigo { get; set; }
        }
     
       
        public void RealizarTarea(string NroTarea)
        {
            using (PLMContext db = new PLMContext())
            {
                string nacionalidad, Nrobom, trim, estilo, nrotarea;
                nrotarea = NroTarea;
                var datos = db.Tareas.Where(x => x.Ref == NroTarea).Select(x => x).FirstOrDefault();
                nacionalidad = datos.Nacionalidad.ToString();
                Nrobom = datos.IdBOM.ToString();
                trim = datos.Trim.ToString();
                var datos1 = db.Boms.Where(x => x.NroBom == Nrobom && x.CodigoNacional == nacionalidad).Select(x => x).FirstOrDefault();
                estilo = datos1.Estilo.ToString();
                Vista.BOM.BomTarea frm = new Vista.BOM.BomTarea(nacionalidad, Nrobom, trim, estilo, nrotarea);
                frm.ShowDialog();
            }
        }

        public bool TaskThread(string idThread, string bom)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    string task = idThread;
                    string _departamento = db.Departamentos.Where(x => x.Dthread == 1).Select(x => new { x.IdDepartamento }).FirstOrDefault().IdDepartamento;
                    TareasThread tarea = new TareasThread()
                    {
                        Ref = task,
                        IdBOM = bom,
                        UsuarioEnvio = GLOBALS.USUARIO,
                        FechaTarea = DateTime.Now,
                        DepartamentoRespuesta = null,
                        FechaRespuesta = null,
                        Dif = null,
                        Status = 1
                    };
                    Notificacion notificacion = new Notificacion()
                    {
                        UsuarioCreador = GLOBALS.USUARIO,
                        NroTarea = task,
                        DepartamentoResp = _departamento,
                        Descripcion = task + " - " + DateTime.Now.ToShortDateString(),
                        EstadoTarea = 0
                    };
                    db.TareasThread.Add(tarea);
                    db.Notificacion.Add(notificacion);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Tasks(string segmento, string trim, string bom, string nacionalidad, int flagNota)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    int refere = 1;
                    string notasTemp = string.Empty;
                    if (flagNota == 1)
                    {
                        notasTemp = "Por favor revisar notas";
                    }
                    else
                    {
                        notasTemp = "No posee notas";
                    }
                    string task = nacionalidad + bom + "-" + string.Format("{0:000}", refere);
                    string _departamento = db.Trims.Where(x => x.Descripción == trim).Select(x => new { x.Departamento }).FirstOrDefault().Departamento;
                    int tiempoResp = int.Parse(db.Departamentos.Where(x => x.IdDepartamento == _departamento).Select(x => new { x.TResp }).FirstOrDefault().TResp.ToString());
                    bool existeTask = false;
                    var _tempNro = db.Tareas.Select(x => new { x.IdBOM, x.Nacionalidad, x.Ref, x.Trim, x.Segmento }).ToList();
                    if (_tempNro != null && _tempNro.Count > 0)
                    {
                        do
                        {
                            foreach (var item in _tempNro)
                            {
                                string[] _nroTask = item.Ref.Split('-');
                                if (_nroTask[1] == string.Format("{0:000}", refere))
                                {
                                    refere++;
                                }
                                else
                                {
                                    task = nacionalidad + bom + "-" + string.Format("{0:000}", refere);
                                    existeTask = true;
                                }
                            }
                        } while (existeTask != true);
                        var _tempExiste = db.Tareas.Where(x => x.IdBOM == bom && x.Nacionalidad == nacionalidad && x.Segmento == segmento && x.Trim == trim).Select(x => x).ToList().FirstOrDefault();
                        if (_tempExiste == null)
                        {
                            Tareas tarea = new Tareas()
                            {
                                Ref = task,
                                Segmento = segmento,
                                IdBOM = bom,
                                Nacionalidad = nacionalidad,
                                TiempoRespuesta = tiempoResp,
                                Trim = trim,
                                UsuarioEnvio = GLOBALS.USUARIO,
                                FechaTarea = DateTime.Now,
                                DepartamentoRespuesta = null,
                                FechaRespuesta = null,
                                Dif = null,
                                Status = 1
                            };
                            Notificacion notificacion = new Notificacion()
                            {
                                UsuarioCreador = GLOBALS.USUARIO,
                                NroTarea = task,
                                DepartamentoResp = _departamento,
                                Descripcion = task + " - " + segmento + " - " + trim + " - " + notasTemp + " - " + DateTime.Now.ToShortDateString(),
                                EstadoTarea = 0
                            };
                            db.Tareas.Add(tarea);
                            db.Notificacion.Add(notificacion);
                            db.SaveChanges();
                            var detailBom = db.BomsDetails.Where(x => x.Segmento == segmento && x.Trims == trim).Select(x => x).ToList().FirstOrDefault();
                            if (detailBom != null)
                            {
                                detailBom.Ntarea = task;
                            }
                            db.Entry(detailBom).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            string departamentoMine = db.Usuarios.Where(x => x.Usser == GLOBALS.USUARIO).Select(x => new { x.Departamento }).FirstOrDefault().Departamento.ToString();
                            _tempExiste.UsuarioEnvio = GLOBALS.USUARIO;
                            _tempExiste.DepartamentoRespuesta = departamentoMine;
                            _tempExiste.FechaRespuesta = DateTime.Now;
                            _tempExiste.Dif = null;
                            _tempExiste.Status = 1;
                            Notificacion notificacion = new Notificacion()
                            {
                                UsuarioCreador = GLOBALS.USUARIO,
                                NroTarea = task,
                                DepartamentoResp = departamentoMine,
                                Descripcion = task + " - " + segmento + " - " + trim + " - " + notasTemp + " - " + DateTime.Now.ToShortDateString(),
                                EstadoTarea = 0
                            };
                            db.Entry(_tempExiste).State = EntityState.Modified;
                            db.Notificacion.Add(notificacion);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        Tareas tarea = new Tareas()
                        {
                            Ref = task,
                            Segmento = segmento,
                            IdBOM = bom,
                            Nacionalidad = nacionalidad,
                            TiempoRespuesta = tiempoResp,
                            Trim = trim,
                            UsuarioEnvio = GLOBALS.USUARIO,
                            FechaTarea = DateTime.Now,
                            DepartamentoRespuesta = null,
                            FechaRespuesta = null,
                            Dif = null,
                            Status = 1
                        };
                        Notificacion notificacion = new Notificacion()
                        {
                            UsuarioCreador = GLOBALS.USUARIO,
                            NroTarea = task,
                            DepartamentoResp = _departamento,
                            Descripcion = task + " - " + segmento + " - " + trim + " - " + notasTemp + " - " + DateTime.Now.ToShortDateString(),
                            EstadoTarea = 0
                        };
                        db.Tareas.Add(tarea);
                        db.Notificacion.Add(notificacion);
                        db.SaveChanges();
                        var detailBom = db.BomsDetails.Where(x => x.Segmento == segmento && x.Trims == trim).Select(x => x).ToList().FirstOrDefault();
                        if (detailBom != null)
                        {
                            detailBom.Ntarea = task;
                        }
                        db.Entry(detailBom).State = EntityState.Modified;
                        db.SaveChanges();
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

        public bool BuscarCurr(string ide)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var cliente = (from x in db.EstilosProduccion where x.IdEstilo == ide select new { x.Cliente }).ToList().FirstOrDefault();
                    string client;
                    client = cliente.Cliente;
                    string cur;

                    var curr = (from x in dbd.Inventario2() where x.Cliente == client select new { x.ClienteC }).ToList().FirstOrDefault();
                    if (curr != null)
                    {
                        cur = curr.ClienteC.Trim();
                        if (cur == "MN")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;

                    }
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
                var nbom = (from x in db.Boms where x.NroBom == nom select x).Count();
                if (nbom == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool ExisteBom(string nom, string Nacional)
        {
            using (PLMContext db = new PLMContext())
            {
                var nbom = (from x in db.Boms where x.NroBom == Nacional + nom && x.CodigoNacional == Nacional select x).Count();
                if (nbom == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool ExisteHilos(string nom)
        {
            using (PLMContext db = new PLMContext())
            {
                var Hilos = (from x in db.Hilos where x.CodigoHilos == nom select x).Count();
                if (Hilos == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public string BuscarThread(string AlternId)
        {
            string temp = string.Empty;
            temp = dbd.BuscarThreadDescripcion(AlternId);
            if (temp != string.Empty)
            {
                return temp;
            }
            else
            {
                return string.Empty;
            }
        }

        public void CargarDatos(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    List<BOM> myBom = new List<BOM>();
                    var _segmentos = db.Segmentos.Select(x => new { x.IdSegmento, x.Descripción, x.SecuenciaSegmento }).OrderBy(x => x.SecuenciaSegmento).ToList();
                    foreach (var dato in _segmentos)
                    {
                        var _trims = db.Trims.Where(x => x.Segmento == dato.IdSegmento).Select(x => x).OrderBy(x => x.Secuencia).ToList();
                        foreach (var _dato in _trims)
                        {
                            BOM _temp = new BOM()
                            {
                                segmentos = dato.Descripción,
                                status = 0,
                                trims = _dato.Descripción,
                                itemCode = "",
                                category = "",
                                descripcion = "",
                                color = "",
                                cantidad = 0,
                                piece = "",
                                supplier = "",
                                costo = 0,
                                notas = "",
                                ntarea = ""
                            };
                            myBom.Add(_temp);
                        }
                    }
                    if (controlView.Rows.Count > 0)
                    {
                        controlView.Rows.Clear();
                    }
                    for (int i = 0; i <= myBom.Count - 1; i++)
                    {
                        Image imageTemp = null;
                        if (myBom[i].status == 0)
                        {
                            imageTemp = Properties.Resources.estado0;
                            imageTemp.Tag = 0;
                        }
                        else if (myBom[i].status == 1)
                        {
                            imageTemp = Properties.Resources.estado2;
                            imageTemp.Tag = 1;
                        }
                        else
                        {
                            imageTemp = Properties.Resources.estado3;
                            imageTemp.Tag = 2;
                        }
                        controlView.Rows.Add(myBom[i].segmentos, imageTemp, myBom[i].trims, myBom[i].itemCode, myBom[i].category, myBom[i].descripcion,
                            myBom[i].color, myBom[i].supplier, myBom[i].cantidad, myBom[i].costo, myBom[i].piece, myBom[i].notas);
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void VerificarEstadoCierre(string nrobom, string estilo, MetroLabel Estado, MetroLabel Etapa)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var bom = db.Boms.Where(x => x.NroBom == nrobom && x.Estilo == estilo).Select(x => new { x.Etapa, x.Estado }).ToList().FirstOrDefault();
                    if (bom != null)
                    {
                        if (bom.Estado == 0 && bom.Etapa == 0)
                        {
                            Estado.Text = "Abierto";
                            Etapa.Text = "Registrado";

                        }
                        else
                        {
                            Etapa.Text = "Liberado";
                            Estado.Text = "Cerrado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void CargarDatosTarea(DataGridView controlView, string numeroBom, string Nacionalidad, string Trim)
        {
            using (PLMContext db = new PLMContext())
            {
                List<BOM> myBom = new List<BOM>();
                var _detailBom = db.BomsDetails.Where(x => x.NroBom == numeroBom && x.nacionalidad == Nacionalidad && x.Trims == Trim).Select(x => x).ToList();
                if (_detailBom != null)
                {
                    foreach (var dato in _detailBom)
                    {
                        BOM _temp = new BOM()
                        {
                            segmentos = dato.Segmento,
                            status = dato.Status,
                            trims = dato.Trims,
                            itemCode = dato.ItemCode,
                            category = dato.Category,
                            descripcion = dato.Descripcion,
                            color = dato.Color,
                            cantidad = dato.Cantidad,
                            piece = dato.Piece,
                            supplier = dato.Supplier,
                            costo = dato.Costo,
                            notas = dato.Notas,
                            ntarea = dato.Ntarea
                        };
                        myBom.Add(_temp);
                    }
                    if (controlView.Rows.Count > 0)
                    {
                        controlView.Rows.Clear();
                    }
                    for (int i = 0; i <= myBom.Count - 1; i++)
                    {
                        Image imageTemp = null;
                        if (myBom[i].status == 0)
                        {
                            imageTemp = Properties.Resources.estado0;
                            imageTemp.Tag = 0;
                        }
                        else if (myBom[i].status == 1)
                        {
                            imageTemp = Properties.Resources.estado2;
                            imageTemp.Tag = 1;
                        }
                        else
                        {
                            imageTemp = Properties.Resources.estado3;
                            imageTemp.Tag = 2;
                        }
                        controlView.Rows.Add(myBom[i].segmentos, imageTemp, myBom[i].trims, myBom[i].itemCode, myBom[i].category, myBom[i].descripcion,
                            myBom[i].color, myBom[i].supplier, myBom[i].cantidad, myBom[i].piece, myBom[i].notas);
                    }
                }
            }
        }

        public void CargarDatosC(DataGridView controlView, string numeroBom, string Nacionalidad)
        {
            using (PLMContext db = new PLMContext())
            {

                string Aux = "";
                if (numeroBom.Contains("N"))
                {
                    Aux = numeroBom.Replace("N", "");
                }
                else
                {
                    Aux = numeroBom.Replace("E", "");
                }

                try
                {
                    List<BOM> myBom = new List<BOM>();
                    var _detailBom = db.BomsDetails.Where(x => x.NroBom == Aux && x.nacionalidad == Nacionalidad).Select(x => x).ToList();
                    foreach (var dato in _detailBom)
                    {
                        BOM _temp = new BOM()
                        {
                            segmentos = dato.Segmento,
                            status = dato.Status,
                            trims = dato.Trims,
                            itemCode = dato.ItemCode,
                            category = dato.Category,
                            descripcion = dato.Descripcion,
                            color = dato.Color,
                            cantidad = dato.Cantidad,
                            piece = dato.Piece,
                            supplier = dato.Supplier,
                            costo = dato.Costo,
                            notas = dato.Notas,
                            ntarea = dato.Ntarea

                        };
                        myBom.Add(_temp);
                    }
                    if (controlView.Rows.Count > 0)
                    {
                        controlView.Rows.Clear();
                    }
                    for (int i = 0; i <= myBom.Count - 1; i++)
                    {
                        Image imageTemp = null;
                        if (myBom[i].status == 0)
                        {
                            imageTemp = Properties.Resources.estado0;
                            imageTemp.Tag = 0;
                        }
                        else if (myBom[i].status == 1)
                        {
                            imageTemp = Properties.Resources.estado2;
                            imageTemp.Tag = 1;
                        }
                        else
                        {
                            imageTemp = Properties.Resources.estado3;
                            imageTemp.Tag = 2;
                        }
                        controlView.Rows.Add(myBom[i].segmentos, imageTemp, myBom[i].trims, myBom[i].itemCode, myBom[i].category, myBom[i].descripcion,
                            myBom[i].color, myBom[i].supplier, myBom[i].cantidad, myBom[i].piece, myBom[i].notas);
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void CargarDatos(DataGridView controlView, string numeroBom, string Nacionalidad)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    List<BOM> myBom = new List<BOM>();
                    String Aux = "";

                    if (numeroBom.Contains("N"))
                    {
                        Aux = numeroBom.Replace("N", "");
                    }
                    if (numeroBom.Contains("E"))
                    {
                        Aux = numeroBom.Replace("E", "");
                    }

                    var _detailBom = db.BomsDetails.Where(x => x.NroBom == Aux && x.nacionalidad == Nacionalidad).Select(x => x).ToList();
                    foreach (var dato in _detailBom)
                    {
                        BOM _temp = new BOM()
                        {
                            segmentos = dato.Segmento,
                            status = dato.Status,
                            trims = dato.Trims,
                            itemCode = dato.ItemCode,
                            category = dato.Category,
                            descripcion = dato.Descripcion,
                            color = dato.Color,
                            cantidad = dato.Cantidad,
                            piece = dato.Piece,
                            supplier = dato.Supplier,
                            costo = dato.Costo,
                            notas = dato.Notas,
                            ntarea = dato.Ntarea
                        };
                        myBom.Add(_temp);
                    }
                    if (controlView.Rows.Count > 0)
                    {
                        controlView.Rows.Clear();
                    }
                    for (int i = 0; i <= myBom.Count - 1; i++)
                    {
                        Image imageTemp = null;
                        if (myBom[i].status == 0)
                        {
                            imageTemp = Properties.Resources.estado0;
                            imageTemp.Tag = 0;
                        }
                        else if (myBom[i].status == 1)
                        {
                            imageTemp = Properties.Resources.estado2;
                            imageTemp.Tag = 1;
                        }
                        else
                        {
                            imageTemp = Properties.Resources.estado3;
                            imageTemp.Tag = 2;
                        }
                        controlView.Rows.Add(myBom[i].segmentos, imageTemp, myBom[i].trims, myBom[i].itemCode, myBom[i].category, myBom[i].descripcion,
                            myBom[i].color, myBom[i].supplier, myBom[i].cantidad, myBom[i].costo, myBom[i].piece, myBom[i].notas);
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool LiberarCerrar()
        {
            using (PLMContext db = new PLMContext())
            {
                var bom = (from x in db.BomsDetails where x.Status != 2 select x).Count();
                try
                {
                    if (bom > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }

        public string CargarDatosPOH(string nom, string noms, MetroTextBox Spo, MetroTextBox PO,String Nota,MetroTextBox hilos)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    
                    
                    var bom = db.Boms.Where(x => x.NroBom == nom && x.Estilo == noms).Select(x => x).ToList().FirstOrDefault();
                    if (bom != null)
                    {
                        Spo.Text = bom.SPO;
                        if(bom.PO != null && bom.PO != string.Empty)
                        {
                            PO.Text = bom.PO;
                        }
                        Nota = bom.Notas;
                        hilos.Text = bom.Hilos;
                        //PO.Text = bom.PO;
                        return bom.PO;
                        
                    }
                    else
                    {
                        Dialogs.Show("Datos usuario no encontrado", DialogsType.Info);
                        return string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return string.Empty;
                }
            }
        }

        public void CargarDatosU(string nom, string noms, MetroTextBox Usuario, MetroTextBox Input, MetroTextBox LastMod, MetroTextBox NroRev)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    if (nom.Contains("E"))
                    {
                        nom = nom.Replace("E", "");
                    }
                    else
                    {
                        nom = nom.Replace("N", "");
                    }
                    var bom = db.Boms.Where(x => x.NroBom == nom && x.CodigoNacional == noms).Select(x => x).ToList().FirstOrDefault();
                    if (bom != null)
                    {
                        Usuario.Text = bom.usuario;
                        Input.Text = bom.FechaCreacion.ToString();
                        LastMod.Text = bom.FUltimaModificacion.ToString();
                        NroRev.Text = bom.NumeroRevisiones.ToString();
                    }
                    else
                    {
                        Dialogs.Show("Datos usuario no encontrado", DialogsType.Info);
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void UpdateRevisiones(string nrobom, string nacionalidad)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var bom = db.Boms.Where(x => x.NroBom == nrobom && x.Estilo == nacionalidad).Select(x => x).ToList().FirstOrDefault();
                    bom.FUltimaModificacion = DateTime.Now;
                    bom.NumeroRevisiones = bom.NumeroRevisiones + 1;
                    db.Entry(bom).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public void UpdateEstadoCierre(string nrobom, string nacionalidad)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var bom = db.Boms.Where(x => x.NroBom == nrobom && x.CodigoNacional == nacionalidad).Select(x => x).ToList().FirstOrDefault();
                    bom.Etapa = 1;
                    bom.Estado = 1;
                    db.Entry(bom).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public bool GuardarBom( Boms bom)
        {
            using (PLMContext db = new PLMContext())
            {

                
                try
                {
                    var vBom = from adBomm in db.Boms where adBomm.Id == bom.Id select adBomm;

                    if (vBom.Count() == 0)
                    db.Boms.Add(bom);

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    //Dialogs.Show(ex.Message, DialogsType.Error);
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddDetailBom(DataGridView dtDatos, MetroTextBox NroBom)
        {
            BomsDetails tempDetailBom;
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    for (int i = 0; i <= dtDatos.Rows.Count - 1; i++)
                    {
                        string bom = NroBom.Text;
                        string nacionalidad = string.Empty;
                        var imagen = dtDatos.Rows[i].Cells[1].Value;
                        Image _imagen = (Image)imagen;
                        int _statusImage = (int)_imagen.Tag;
                        if (bom.Contains("E"))
                        {
                            nacionalidad = "E";
                            bom = bom.Replace("E", "");
                        }
                        else
                        {
                            nacionalidad = "N";
                            bom = bom.Replace("N", "");
                        }
                        tempDetailBom = new BomsDetails
                        {
                            NroBom = bom,
                            nacionalidad = nacionalidad,
                            Segmento = dtDatos.Rows[i].Cells[0].Value.ToString(),
                            Status = _statusImage,
                            Trims = dtDatos.Rows[i].Cells[2].Value.ToString(),
                            ItemCode = dtDatos.Rows[i].Cells[3].Value.ToString(),
                            Category = dtDatos.Rows[i].Cells[4].Value.ToString(),
                            Descripcion = dtDatos.Rows[i].Cells[5].Value.ToString(),
                            Color = dtDatos.Rows[i].Cells[6].Value.ToString(),
                            Cantidad = double.Parse(dtDatos.Rows[i].Cells[8].Value.ToString()),
                            Piece = dtDatos.Rows[i].Cells[10].Value.ToString(),
                            Supplier = dtDatos.Rows[i].Cells[7].Value.ToString(),
                            Costo = double.Parse(dtDatos.Rows[i].Cells[9].Value.ToString()),
                            Notas = dtDatos.Rows[i].Cells[11].Value.ToString(),
                            Ntarea = "",
                        };
                        db.BomsDetails.Add(tempDetailBom);
                        db.SaveChanges();
                    }
                    Dialogs.Show("Bom guardado exitosamente", DialogsType.Info);
                    return true;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }


        public bool UpdateDetailBom(DataGridView dtDatos, MetroTextBox NroBom)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    for (int i = 0; i <= dtDatos.Rows.Count - 1; i++)
                    {
                        string bom = NroBom.Text;
                        string Nacionalidad = string.Empty;
                        var imagen = dtDatos.Rows[i].Cells[1].Value;
                        Image _imagen = (Image)imagen;
                        int _statusImage = (int)_imagen.Tag;

                        if (bom.Contains("E"))
                        {
                            Nacionalidad = "E";
                            bom = bom.Replace("E", "");
                        }
                        else
                        {
                            Nacionalidad = "N";
                            bom = bom.Replace("N", "");
                        }

                        string _trimTemp = dtDatos.Rows[i].Cells[2].Value.ToString();
                        var boms = db.BomsDetails.Where(x => x.NroBom == bom && x.nacionalidad == Nacionalidad && x.Trims == _trimTemp).Select(x => x).ToList().FirstOrDefault();
                        boms.NroBom = bom;
                        boms.nacionalidad = Nacionalidad;
                        boms.Segmento = dtDatos.Rows[i].Cells[0].Value.ToString();
                        boms.Status = _statusImage;
                        boms.Trims = dtDatos.Rows[i].Cells[2].Value.ToString();
                        boms.ItemCode = dtDatos.Rows[i].Cells[3].Value.ToString();
                        boms.Category = dtDatos.Rows[i].Cells[4].Value.ToString();
                        boms.Descripcion = dtDatos.Rows[i].Cells[5].Value.ToString();
                        boms.Color = dtDatos.Rows[i].Cells[6].Value.ToString();
                        boms.Cantidad = double.Parse(dtDatos.Rows[i].Cells[8].Value.ToString());
                        boms.Piece = dtDatos.Rows[i].Cells[10].Value.ToString();
                        boms.Supplier = dtDatos.Rows[i].Cells[7].Value.ToString();
                        boms.Costo = double.Parse(dtDatos.Rows[i].Cells[9].Value.ToString());
                        boms.Notas = dtDatos.Rows[i].Cells[11].Value.ToString();
                        db.Entry(boms).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    Dialogs.Show("Bom editado exitosamente", DialogsType.Info);
                    return true;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                    return false;
                }
            }
        }
        public void MostrarHilosDetails(DataGridView controlView, string codigo)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    List<mostrarHilos> myHilos = new List<mostrarHilos>();

                    var _hilos = db.HilosDetails.Where(x => x.CodigoHilos == codigo).Select(x => x).OrderBy(x => x.posicion).ToList();
                    foreach (var _dato in _hilos)
                    {
                        mostrarHilos _temp = new mostrarHilos()
                        {
                            Vista = _dato.Vista,
                            mtsvista = _dato.MetrajeVista,
                            Interior = _dato.Interior,
                            mtsinterior = _dato.MetrajeInteiores,
                            total = _dato.Total,
                            notas = _dato.Notas,

                        };
                        myHilos.Add(_temp);

                    }
                    if (controlView.Rows.Count > 0)
                    {
                        controlView.Rows.Clear();
                    }
                    for (int i = 0; i <= myHilos.Count - 1; i++)
                    {

                        controlView.Rows.Add(myHilos[i].Vista, myHilos[i].mtsvista, myHilos[i].Interior, myHilos[i].mtsinterior,
                            myHilos[i].total, myHilos[i].notas);
                    }
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }
        public bool UpdateHilosDetail(DataGridView controlView, string codigo)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    for (int i = 0; i <= controlView.Rows.Count - 1; i++)
                    {
                        var hilos = db.HilosDetails.Where(x => x.CodigoHilos == codigo && x.posicion == i).Select(x => x).ToList().FirstOrDefault();
                        hilos.CodigoHilos = codigo;
                        hilos.Vista = controlView.Rows[i].Cells[0].Value.ToString();
                        hilos.MetrajeVista = float.Parse(controlView.Rows[i].Cells[1].Value.ToString());
                        hilos.Interior = controlView.Rows[i].Cells[2].Value.ToString();
                        hilos.MetrajeInteiores = float.Parse(controlView.Rows[i].Cells[3].Value.ToString());
                        hilos.Total = float.Parse(controlView.Rows[i].Cells[4].Value.ToString());
                        hilos.Notas = controlView.Rows[i].Cells[5].Value.ToString();
                        db.Entry(hilos).State = EntityState.Modified;
                        db.SaveChanges();
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
        public void EstadoNotificacion(string nrotarea)
        {
            using (PLMContext db = new PLMContext())
            {
                var dato = db.Notificacion.Where(x => x.NroTarea == nrotarea && x.EstadoTarea == 0).Select(x => x).ToList().FirstOrDefault();
                dato.EstadoTarea = 1;
                db.Entry(dato).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool UpdateDetailBom(DataGridView dtDatos, MetroTextBox NroBom, int flag)
        {
            using (PLMContext db = new PLMContext())
            {
                if (flag == 1)
                {
                    for (int i = 0; i <= dtDatos.Rows.Count - 1; i++)
                    {
                        string nrotarea;
                        string bom = NroBom.Text;
                        string Nacionalidad = string.Empty;
                        var imagen = dtDatos.Rows[i].Cells[1].Value;
                        Image _imagen = (Image)imagen;
                        _imagen = null;
                        _imagen = Properties.Resources.estado3;
                        _imagen.Tag = 2;
                        int _statusImage = (int)_imagen.Tag;
                        dtDatos.Rows[i].Cells[1].Value = _imagen;
                        if (bom.Contains("E"))
                        {
                            Nacionalidad = "E";
                            bom = bom.Replace("E", "");
                        }
                        else
                        {
                            Nacionalidad = "N";
                            bom = bom.Replace("N", "");
                        }
                        string _trimTemp = dtDatos.Rows[i].Cells[2].Value.ToString();
                        var boms = db.BomsDetails.Where(x => x.NroBom == bom && x.nacionalidad == Nacionalidad && x.Trims == _trimTemp).Select(x => x).ToList().FirstOrDefault();
                        boms.NroBom = bom;
                        boms.nacionalidad = Nacionalidad;
                        boms.Segmento = dtDatos.Rows[i].Cells[0].Value.ToString();
                        boms.Status = _statusImage;
                        boms.Trims = dtDatos.Rows[i].Cells[2].Value.ToString();
                        boms.Cantidad = double.Parse(dtDatos.Rows[i].Cells[8].Value.ToString());
                        boms.Notas = dtDatos.Rows[i].Cells[11].Value.ToString();
                        nrotarea = db.BomsDetails.Where(x => x.NroBom == bom && x.nacionalidad == Nacionalidad && x.Trims == _trimTemp).Select(x => x.Ntarea).ToString();
                        DateTime fecharesta;
                        var bomsr = db.Tareas.Where(x => x.Ref == nrotarea).Select(x => x).ToList().FirstOrDefault();
                        bomsr.FechaRespuesta = DateTime.Now;
                        bomsr.DepartamentoRespuesta = GLOBALS.DEPARTAMENTO;
                        fecharesta = bomsr.FechaTarea;
                        if (fecharesta.Hour > 10 && fecharesta.Day != 5)
                        {
                            int Hora = int.Parse((DateTime.Now - fecharesta).TotalHours.ToString());
                            int resultHora = Hora - 23;
                            bomsr.Dif = bomsr.TiempoRespuesta - resultHora;



                        }
                        else if (fecharesta.Hour < 10 && DateTime.Now.Day == 5)
                        {
                            int Hora = int.Parse((DateTime.Now - fecharesta).TotalHours.ToString());
                            int resultHora = Hora - 48;
                        }
                        db.Entry(boms).State = EntityState.Modified;


                        db.SaveChanges();
                    }
                    Dialogs.Show("Bom editado exitosamente", DialogsType.Info);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Itemcode(string dato, DataGridView controlView)
        {
            var datos1 = dbd.Inventario(dato).Select(x => new { x.IdEstilos, x.Category, x.Descripcion, x.Lavado, x.Supplier, x.Costo, x.Piece }).ToList();
            if (datos1 != null)
            {
                float _tempCosto = 0;
                foreach (var item in datos1)
                {
                    if(item.Costo > 0)
                    {
                        _tempCosto = item.Costo;
                        break;
                    }
                }
                controlView.CurrentRow.Cells[4].Value = datos1[0].Category.ToString();
                controlView.CurrentRow.Cells[5].Value = datos1[0].Descripcion.ToString();
                controlView.CurrentRow.Cells[6].Value = datos1[0].Lavado.ToString();
                if (!string.IsNullOrEmpty(datos1[0].Supplier.ToString()))
                {
                    controlView.CurrentRow.Cells[7].Value = datos1[0].Supplier.ToString();
                }
                else
                {
                    controlView.CurrentRow.Cells[7].Value = "";
                }
                controlView.CurrentRow.Cells[9].Value = _tempCosto.ToString();
                controlView.CurrentRow.Cells[10].Value = datos1[0].Piece.ToString();             
            }
        }

        public bool ActualizarEstadoHilos(string nb, string es, string na, int estado)
        {
            using (PLMContext db = new PLMContext())
            {
                string codigohilos;
                codigohilos = na + nb + es;
                var hilo = db.Hilos.Where(x => x.CodigoHilos == codigohilos).Select(x => x).ToList().FirstOrDefault();
                if (hilo != null)
                {
                    hilo.Estado = estado;
                    db.Entry(hilo).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ActualizarEstadoHilos(string nb, int estado)
        {
            using (PLMContext db = new PLMContext())
            {
                string codigohilos;
                codigohilos = nb;
                var hilo = db.Hilos.Where(x => x.CodigoHilos == codigohilos).Select(x => x).ToList().FirstOrDefault();
                if (hilo != null)
                {
                    hilo.Estado = estado;
                    db.Entry(hilo).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int VerificarEstadoHilos(string nb, string es, string na)
        {
            using (PLMContext db = new PLMContext())
            {
                int estado;
                string codigohilos;
                codigohilos = na + nb + es;
                var hilo = db.Hilos.Where(x => x.CodigoHilos == codigohilos).Select(x => x).ToList().FirstOrDefault();
                if (hilo != null)
                {
                    estado = hilo.Estado;

                    return estado;
                }
                else
                {
                    return 0;
                }
            }
        }
        public bool GuardarHilosDetails(DataGridView controlView, string nb, string es, string na, int estado)
        {
            using (PLMContext db = new PLMContext())
            {
                var hilos = new HilosDetails();
                for (int i = 0; i <= controlView.Rows.Count - 1; i++)
                {
                    hilos.CodigoHilos = na + nb + es;
                    hilos.Vista = controlView.Rows[i].Cells[0].Value.ToString();
                    hilos.MetrajeVista = float.Parse(controlView.Rows[i].Cells[1].Value.ToString());
                    hilos.Interior = controlView.Rows[i].Cells[2].Value.ToString();
                    hilos.MetrajeInteiores = float.Parse(controlView.Rows[i].Cells[3].Value.ToString());
                    hilos.Total = float.Parse(controlView.Rows[i].Cells[4].Value.ToString());
                    hilos.Notas = controlView.Rows[i].Cells[5].Value.ToString();
                    hilos.posicion = i;
                }
                try
                {
                    db.HilosDetails.Add(hilos);
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

        public bool GuardarHilos(string nb, string es, string na, int estado)
        {
            using (PLMContext db = new PLMContext())
            {
                var hilos = new Hilos();
                hilos.CodigoHilos = na + nb + es;
                hilos.NroBom = nb;
                hilos.Estilos = es;
                hilos.Nacionaliad = na;
                hilos.Estado = estado;
                try
                {

                    db.Hilos.Add(hilos);
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

        public void TareasM(DataGridView controlView)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = (from x in db.Notificacion where (x.DepartamentoResp == GLOBALS.DEPARTAMENTO && x.EstadoTarea == 0) select x).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].Visible = false;
                    controlView.Columns[1].HeaderText = "USUARIO";
                    controlView.Columns[2].HeaderText = "NRO TAREA";
                    controlView.Columns[3].HeaderText = "DEPARTAMENTO RESPUESTA";
                    controlView.Columns[4].HeaderText = "DESCRIPCION ";
                    controlView.Columns[4].Width = 400;
                    controlView.Columns[5].Visible = false;
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
        }

        public DataTable[] ExportarDatosCosteado(DataGridView controlView, string nroBom, string idEstilo)
        {
            Modelo.Reportes.DetalleBom objetoTemporal;
            Modelo.Reportes.EncabezadoEstilo objetoTemporalEst;
            Modelo.Reportes.HilosDetalle objetoTemporalH;
            Modelo.Reportes.DetalleUsuario objetoTemporalU;

            DataTable dtTemporal, dtEstilo, dtThread, dtUsu;
            DataTable[] datosDevuelto = new DataTable[4];
            dtTemporal = new DataTable();
            dtEstilo = new DataTable();
            dtThread = new DataTable();
            dtUsu = new DataTable();
            // Columnas de detail bom
            dtTemporal.Columns.Add("Segmento", typeof(System.String));
            dtTemporal.Columns.Add("Trims", typeof(System.String));
            dtTemporal.Columns.Add("ItemCode", typeof(System.String));
            dtTemporal.Columns.Add("Category", typeof(System.String));
            dtTemporal.Columns.Add("Descripcion", typeof(System.String));
            dtTemporal.Columns.Add("Color", typeof(System.String));
            dtTemporal.Columns.Add("Cantidad", typeof(System.Double));
            dtTemporal.Columns.Add("Costo", typeof(System.Double));
            dtTemporal.Columns.Add("Piece", typeof(System.String));
            dtTemporal.Columns.Add("Supplier", typeof(System.String));
            // Columnas de estilo
            dtEstilo.Columns.Add("Style", typeof(System.String));
            dtEstilo.Columns.Add("Category", typeof(System.String));
            dtEstilo.Columns.Add("Division", typeof(System.String));
            dtEstilo.Columns.Add("Season", typeof(System.String));
            dtEstilo.Columns.Add("Customer", typeof(System.String));
            dtEstilo.Columns.Add("Brand", typeof(System.String));
            dtEstilo.Columns.Add("Description", typeof(System.String));
            dtEstilo.Columns.Add("Fit", typeof(System.String));
            dtEstilo.Columns.Add("Body", typeof(System.String));
            dtEstilo.Columns.Add("Wash", typeof(System.String));
            dtEstilo.Columns.Add("Category2", typeof(System.String));
            dtEstilo.Columns.Add("Inseam", typeof(System.String));
            dtEstilo.Columns.Add("Espec", typeof(System.String));
            dtEstilo.Columns.Add("Empaque", typeof(String));
            // Columnas de Hilos
            dtThread.Columns.Add("Vista", typeof(System.String));
            dtThread.Columns.Add("MtsV", typeof(System.Double));
            dtThread.Columns.Add("Interior", typeof(System.String));
            dtThread.Columns.Add("MtsI", typeof(System.Double));
            dtThread.Columns.Add("Total", typeof(System.Double));
            // Columnas de Usuario
            dtUsu.Columns.Add("usuario", typeof(System.String));
            dtUsu.Columns.Add("FechaCreacion", typeof(System.DateTime));
            dtUsu.Columns.Add("FUltimaModificacion", typeof(System.DateTime));
            dtUsu.Columns.Add("NumeroRevisiones", typeof(System.Int32));
            try
            {
                // Busqueda de los datos del Bom /

                for (int i = 0; i <= controlView.Rows.Count - 1; i++)
                {
                    objetoTemporal = new Modelo.Reportes.DetalleBom
                    {
                        Segmento = controlView.Rows[i].Cells[0].Value.ToString(),
                        Trims = controlView.Rows[i].Cells[2].Value.ToString(),
                        ItemCode = controlView.Rows[i].Cells[3].Value.ToString(),
                        Category = controlView.Rows[i].Cells[4].Value.ToString(),
                        Descripcion = controlView.Rows[i].Cells[5].Value.ToString(),
                        Color = controlView.Rows[i].Cells[6].Value.ToString(),
                        Cantidad = double.Parse(controlView.Rows[i].Cells[8].Value.ToString()),
                        Costo = double.Parse(controlView.Rows[i].Cells[9].Value.ToString()),
                        Piece = controlView.Rows[i].Cells[10].Value.ToString(),
                        Supplier = controlView.Rows[i].Cells[7].Value.ToString()
                    };

                    DataRow fila = dtTemporal.NewRow();
                    fila["Segmento"] = objetoTemporal.Segmento;
                    fila["Trims"] = objetoTemporal.Trims;
                    fila["ItemCode"] = objetoTemporal.ItemCode;
                    fila["Category"] = objetoTemporal.Category;
                    fila["Descripcion"] = objetoTemporal.Descripcion;
                    fila["Color"] = objetoTemporal.Color;
                    fila["Cantidad"] = objetoTemporal.Cantidad;
                    fila["Costo"] = objetoTemporal.Costo;
                    fila["Piece"] = objetoTemporal.Piece;
                    fila["Supplier"] = objetoTemporal.Supplier;
                    dtTemporal.Rows.Add(fila);
                }

                // Hasta aqui se llena el detalle
                //Busqueda de los datos del estilo

                using (PLMContext db = new PLMContext())
                {
                    var EstilosdeProduccion = db.EstilosProduccion.Where(x => x.IdEstilo == idEstilo).Select(x => x).FirstOrDefault();
                    objetoTemporalEst = new Modelo.Reportes.EncabezadoEstilo
                    {

                        Style = EstilosdeProduccion.IdEstilo,
                        Category = EstilosdeProduccion.Categoria,
                        Division = EstilosdeProduccion.Division,
                        Season = EstilosdeProduccion.Estacion,
                        Customer = EstilosdeProduccion.Cliente,
                        Brand = EstilosdeProduccion.Marca,
                        Description = EstilosdeProduccion.Descripcion,
                        Fit = EstilosdeProduccion.Fit,
                        Body = EstilosdeProduccion.Body,
                        Wash = EstilosdeProduccion.Lavado,
                        Category2 = EstilosdeProduccion.Category2,
                        Inseam = EstilosdeProduccion.Inseam,
                        Espec = EstilosdeProduccion.Espec,
                        Empaque = EstilosdeProduccion.Empaque,
                    };
                    DataRow fila = dtEstilo.NewRow();
                    fila["Style"] = objetoTemporalEst.Style;
                    fila["Category"] = objetoTemporalEst.Category;
                    fila["Division"] = objetoTemporalEst.Division;
                    fila["Season"] = objetoTemporalEst.Season;
                    fila["Customer"] = objetoTemporalEst.Customer;
                    fila["Brand"] = objetoTemporalEst.Brand;
                    fila["Description"] = objetoTemporalEst.Description;
                    fila["Fit"] = objetoTemporalEst.Fit;
                    fila["Body"] = objetoTemporalEst.Body;
                    fila["Wash"] = objetoTemporalEst.Wash;
                    fila["Category2"] = objetoTemporalEst.Category2;
                    fila["Inseam"] = objetoTemporalEst.Inseam;
                    fila["Espec"] = objetoTemporalEst.Espec;
                    fila["Empaque"] = objetoTemporalEst.Empaque;
                    dtEstilo.Rows.Add(fila);
                }

                // Busqueda de datos de Hilos                   
                using (PLMContext db = new PLMContext())
                {
                    string id;
                    id = nroBom + idEstilo;
                    if (BuscarCurr(idEstilo))
                    {
                        id = "N" + nroBom + idEstilo;
                    }
                    else
                    {
                        id = "E" + nroBom + idEstilo;
                    }
                    var Hilos = db.HilosDetails.Where(x => x.CodigoHilos == id).Select(x => x).ToList();
                    foreach (var item in Hilos)
                    {
                        objetoTemporalH = new Modelo.Reportes.HilosDetalle
                        {
                            Vista = item.Vista,
                            MtsV = item.MetrajeVista,
                            Interior = item.Interior,
                            MtsI = item.MetrajeInteiores,
                            Total = item.Total,
                        };
                        DataRow fila = dtThread.NewRow();
                        fila["Vista"] = objetoTemporalH.Vista;
                        fila["MtsV"] = objetoTemporalH.MtsV;
                        fila["Interior"] = objetoTemporalH.Interior;
                        fila["MtsI"] = objetoTemporalH.MtsI;
                        fila["Total"] = objetoTemporalH.Total;
                        dtThread.Rows.Add(fila);
                    }
                }

                // Busqueda de datos de Hilos     
                string nacionalidad, bom;
                using (PLMContext db = new PLMContext())
                {
                    if (nroBom.Contains("E"))
                    {
                        nacionalidad = "E";
                        bom = nroBom.Replace("E", "");
                    }
                    else
                    {
                        nacionalidad = "N";
                        bom = nroBom.Replace("N", "");
                    }
                    var Usu = db.Boms.Where(x => x.NroBom == bom && x.CodigoNacional == nacionalidad).Select(x => x).FirstOrDefault();
                    objetoTemporalU = new Modelo.Reportes.DetalleUsuario
                    {
                        usuario = Usu.usuario,
                        FechaCreacion = Usu.FechaCreacion,
                        FUltimaModificacion = Usu.FUltimaModificacion,
                        NumeroRevisiones = Usu.NumeroRevisiones,
                    };
                    DataRow fila = dtUsu.NewRow();
                    fila["usuario"] = objetoTemporalU.usuario;
                    fila["FechaCreacion"] = objetoTemporalU.FechaCreacion;
                    fila["FUltimaModificacion"] = objetoTemporalU.FUltimaModificacion;
                    fila["NumeroRevisiones"] = objetoTemporalU.NumeroRevisiones;
                    dtUsu.Rows.Add(fila);
                }
                datosDevuelto[0] = dtTemporal;
                datosDevuelto[1] = dtEstilo;
                datosDevuelto[2] = dtThread;
                datosDevuelto[3] = dtUsu;
                return datosDevuelto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable[] ExportarDatos(DataGridView controlView, string nroBom, string idEstilo)
        {
            Modelo.Reportes.DetalleBom objetoTemporal;
            Modelo.Reportes.EncabezadoEstilo objetoTemporalEst;
            Modelo.Reportes.HilosDetalle objetoTemporalH;
            Modelo.Reportes.DetalleUsuario objetoTemporalU;

            DataTable dtTemporal, dtEstilo, dtThread, dtUsu;
            DataTable[] datosDevuelto = new DataTable[4]; 
            dtTemporal = new DataTable();
            dtEstilo = new DataTable();
            dtThread = new DataTable();
            dtUsu = new DataTable();
            // Columnas de detail bom
            dtTemporal.Columns.Add("Segmento", typeof(System.String));
            dtTemporal.Columns.Add("Trims", typeof(System.String));
            dtTemporal.Columns.Add("ItemCode", typeof(System.String));
            dtTemporal.Columns.Add("Category", typeof(System.String));
            dtTemporal.Columns.Add("Descripcion", typeof(System.String));
            dtTemporal.Columns.Add("Color", typeof(System.String));
            dtTemporal.Columns.Add("Cantidad", typeof(System.Double));
            dtTemporal.Columns.Add("Costo", typeof(System.Double));
            dtTemporal.Columns.Add("Piece", typeof(System.String));
            dtTemporal.Columns.Add("Supplier", typeof(System.String));
            // Columnas de estilo
            dtEstilo.Columns.Add("Style", typeof(System.String));
            dtEstilo.Columns.Add("Category", typeof(System.String));
            dtEstilo.Columns.Add("Division", typeof(System.String));
            dtEstilo.Columns.Add("Season", typeof(System.String));
            dtEstilo.Columns.Add("Customer", typeof(System.String));
            dtEstilo.Columns.Add("Brand", typeof(System.String));
            dtEstilo.Columns.Add("Description", typeof(System.String));
            dtEstilo.Columns.Add("Fit", typeof(System.String));
            dtEstilo.Columns.Add("Body", typeof(System.String));
            dtEstilo.Columns.Add("Wash", typeof(System.String));
            dtEstilo.Columns.Add("Category2", typeof(System.String));
            dtEstilo.Columns.Add("Inseam", typeof(System.String));
            dtEstilo.Columns.Add("Espec", typeof(System.String));
            dtEstilo.Columns.Add("Empaque", typeof(String));
            // Columnas de Hilos
            dtThread.Columns.Add("Vista", typeof(System.String));
            dtThread.Columns.Add("MtsV", typeof(System.Double));
            dtThread.Columns.Add("Interior", typeof(System.String));
            dtThread.Columns.Add("MtsI", typeof(System.Double));
            dtThread.Columns.Add("Total", typeof(System.Double));
            // Columnas de Usuario
            dtUsu.Columns.Add("usuario", typeof(System.String));
            dtUsu.Columns.Add("FechaCreacion", typeof(System.DateTime));
            dtUsu.Columns.Add("FUltimaModificacion", typeof(System.DateTime));
            dtUsu.Columns.Add("NumeroRevisiones", typeof(System.Int32));
            try
            {
                // Busqueda de los datos del Bom

                for (int i = 0; i <= controlView.Rows.Count - 1; i++)
                {
                    objetoTemporal = new Modelo.Reportes.DetalleBom
                    {
                        Segmento = controlView.Rows[i].Cells[0].Value.ToString(),
                        Trims = controlView.Rows[i].Cells[2].Value.ToString(),
                        ItemCode = controlView.Rows[i].Cells[3].Value.ToString(),
                        Category = controlView.Rows[i].Cells[4].Value.ToString(),
                        Descripcion = controlView.Rows[i].Cells[5].Value.ToString(),
                        Color = controlView.Rows[i].Cells[6].Value.ToString(),
                        Cantidad = double.Parse(controlView.Rows[i].Cells[8].Value.ToString()),
                        Costo = 0,
                        Piece = controlView.Rows[i].Cells[9].Value.ToString(),
                        Supplier = controlView.Rows[i].Cells[7].Value.ToString()
                    };

                    DataRow fila = dtTemporal.NewRow();
                    fila["Segmento"] = objetoTemporal.Segmento;
                    fila["Trims"] = objetoTemporal.Trims;
                    fila["ItemCode"] = objetoTemporal.ItemCode;
                    fila["Category"] = objetoTemporal.Category;
                    fila["Descripcion"] = objetoTemporal.Descripcion;
                    fila["Color"] = objetoTemporal.Color;
                    fila["Cantidad"] = objetoTemporal.Cantidad;                    
                    fila["Costo"] = objetoTemporal.Costo;
                    fila["Piece"] = objetoTemporal.Piece;
                    fila["Supplier"] = objetoTemporal.Supplier;
                    dtTemporal.Rows.Add(fila);
                }

                // Hasta aqui se llena el detalle
                //Busqueda de los datos del estilo

                using (PLMContext db = new PLMContext())
                {
                    var EstilosdeProduccion = db.EstilosProduccion.Where(x => x.IdEstilo == idEstilo).Select(x => x).FirstOrDefault();
                    objetoTemporalEst = new Modelo.Reportes.EncabezadoEstilo
                    {

                        Style = EstilosdeProduccion.IdEstilo,
                        Category = EstilosdeProduccion.Categoria,
                        Division = EstilosdeProduccion.Division,
                        Season = EstilosdeProduccion.Estacion,
                        Customer = EstilosdeProduccion.Cliente,
                        Brand = EstilosdeProduccion.Marca,
                        Description = EstilosdeProduccion.Descripcion,
                        Fit = EstilosdeProduccion.Fit,
                        Body = EstilosdeProduccion.Body,
                        Wash = EstilosdeProduccion.Lavado,
                        Category2 = EstilosdeProduccion.Category2,
                        Inseam = EstilosdeProduccion.Inseam,
                        Espec = EstilosdeProduccion.Espec,
                        Empaque = EstilosdeProduccion.Empaque,
                    };
                    DataRow fila = dtEstilo.NewRow();
                    fila["Style"] = objetoTemporalEst.Style;
                    fila["Category"] = objetoTemporalEst.Category;
                    fila["Division"] = objetoTemporalEst.Division;
                    fila["Season"] = objetoTemporalEst.Season;
                    fila["Customer"] = objetoTemporalEst.Customer;
                    fila["Brand"] = objetoTemporalEst.Brand;
                    fila["Description"] = objetoTemporalEst.Description;
                    fila["Fit"] = objetoTemporalEst.Fit;
                    fila["Body"] = objetoTemporalEst.Body;
                    fila["Wash"] = objetoTemporalEst.Wash;
                    fila["Category2"] = objetoTemporalEst.Category2;
                    fila["Inseam"] = objetoTemporalEst.Inseam;
                    fila["Espec"] = objetoTemporalEst.Espec;
                    fila["Empaque"] = objetoTemporalEst.Empaque;
                    dtEstilo.Rows.Add(fila);
                }

                // Busqueda de datos de Hilos                   
                using (PLMContext db = new PLMContext())
                {
                    string id;
                    id = nroBom + idEstilo;
                    if (BuscarCurr(idEstilo))
                    {
                        id = "N" + nroBom + idEstilo;
                    }
                    else
                    {
                        id = "E" + nroBom + idEstilo;
                    }
                    var Hilos = db.HilosDetails.Where(x => x.CodigoHilos == id).Select(x => x).ToList();
                    foreach (var item in Hilos)
                    {
                        objetoTemporalH = new Modelo.Reportes.HilosDetalle
                        {
                            Vista = item.Vista,
                            MtsV = item.MetrajeVista,
                            Interior = item.Interior,
                            MtsI = item.MetrajeInteiores,
                            Total = item.Total,
                        };
                        DataRow fila = dtThread.NewRow();
                        fila["Vista"] = objetoTemporalH.Vista;
                        fila["MtsV"] = objetoTemporalH.MtsV;
                        fila["Interior"] = objetoTemporalH.Interior;
                        fila["MtsI"] = objetoTemporalH.MtsI;
                        fila["Total"] = objetoTemporalH.Total;
                        dtThread.Rows.Add(fila);
                    }                                      
                }

                // Busqueda de datos de Hilos     
                string nacionalidad, bom;
                using (PLMContext db = new PLMContext())
                {
                    if (nroBom.Contains("E"))
                    {
                        nacionalidad = "E";
                        bom = nroBom.Replace("E", "");
                    }
                    else
                    {
                        nacionalidad = "N";
                        bom = nroBom.Replace("N", "");
                    }
                    var Usu = db.Boms.Where(x => x.NroBom == bom && x.CodigoNacional == nacionalidad).Select(x => x).FirstOrDefault();
                    objetoTemporalU = new Modelo.Reportes.DetalleUsuario
                    {
                        usuario = Usu.usuario,
                        FechaCreacion = Usu.FechaCreacion,
                        FUltimaModificacion = Usu.FUltimaModificacion,
                        NumeroRevisiones = Usu.NumeroRevisiones,
                    };
                    DataRow fila = dtUsu.NewRow();
                    fila["usuario"] = objetoTemporalU.usuario;
                    fila["FechaCreacion"] = objetoTemporalU.FechaCreacion;
                    fila["FUltimaModificacion"] = objetoTemporalU.FUltimaModificacion;
                    fila["NumeroRevisiones"] = objetoTemporalU.NumeroRevisiones;
                    dtUsu.Rows.Add(fila);
                }
                datosDevuelto[0] = dtTemporal;
                datosDevuelto[1] = dtEstilo;
                datosDevuelto[2] = dtThread;
                datosDevuelto[3] = dtUsu;
                return datosDevuelto;
            }
            catch(Exception ex)
            {
                return null;
            }            
        }



       
    }
}
