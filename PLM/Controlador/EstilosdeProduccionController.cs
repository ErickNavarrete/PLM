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
using System.IO;
using System.Data.SqlClient;
using DevComponents.DotNetBar;

namespace PLM.Controlador
{

    public class EstilosTemp 
    {        
        public string IdEstilos { get; set; }
    }

    public class EstilosdeProduccionController 
    {
         private Dynamics DbD;

         public EstilosdeProduccionController()
         {
             DbD = new Dynamics(); 
         }
        private string valida(string texto,string d)
         {
             if (texto == "" || texto.Length == 0)
             {
                 return d;
             }
             else
                 return texto;
         }
         
        public bool AddEstilosdeProduccion(string Descripcion, string Categoria, string Division, string Estacion, string Cliente, string Marca, string Category2, string Espec, string IdEstilosdeProduccion , string Fit ,string Body ,string Lavado , string Inseam , string Empaque)
        {
            using (PLMContext db = new PLMContext())
            {
                
                var EstilosdeProduccion = new EstilosProduccions();
                EstilosdeProduccion.IdEstilo = IdEstilosdeProduccion;
                EstilosdeProduccion.Descripcion =valida(Descripcion,"-");
                EstilosdeProduccion.Categoria = valida(Categoria,"-");
                EstilosdeProduccion.Division = valida(Division,"-");
                EstilosdeProduccion.Estacion = valida(Estacion,"-");
                EstilosdeProduccion.Cliente = valida(Cliente,"-");
                EstilosdeProduccion.Marca = valida(Marca,"-");
                EstilosdeProduccion.Category2 = valida(Category2,"-");
                EstilosdeProduccion.Espec =valida(Espec,"-");
                EstilosdeProduccion.Fit = valida(Fit,"-");
                EstilosdeProduccion.Body = valida(Body,"-");
                EstilosdeProduccion.Lavado = valida(Lavado,"-");
                EstilosdeProduccion.Inseam = valida(Inseam,"-") ;
                EstilosdeProduccion.Empaque = valida(Empaque,"-");
                
                try
                {
                    db.EstilosProduccion.Add(EstilosdeProduccion);
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

        public bool UpdateEstilosdeProduccion(string Descripcion, string Categoria, string Division, string Estacion, string Cliente, string Marca, string Category2, string Espec, string IdEstilosdeProduccion, string Fit, string Body, string Lavado, string Inseam, string Empaque)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    string base64 = string.Empty;
                    FileStream fs = new FileStream(Espec, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] codificado = new byte[(int)fs.Length];
                    try
                    {
                        br.Read(codificado, 0, codificado.Length);
                        base64 = Convert.ToBase64String(codificado);
                    }
                    catch (Exception ex)
                    { }
                    var EstilosdeProduccion = db.EstilosProduccion.Where(x => x.IdEstilo == IdEstilosdeProduccion).Select(x => x).FirstOrDefault();
                    EstilosdeProduccion.IdEstilo = IdEstilosdeProduccion;
                    EstilosdeProduccion.Descripcion = Descripcion;
                    EstilosdeProduccion.Categoria = Categoria;
                    EstilosdeProduccion.Division = Division;
                    EstilosdeProduccion.Estacion = Estacion;
                    EstilosdeProduccion.Cliente = Cliente;
                    EstilosdeProduccion.Marca = Marca;
                    EstilosdeProduccion.Category2 = Category2;
                    EstilosdeProduccion.Espec = base64;
                    EstilosdeProduccion.Fit = Fit;
                    EstilosdeProduccion.Body = Body;
                    EstilosdeProduccion.Lavado = Lavado;
                    EstilosdeProduccion.Inseam = Inseam;
                    EstilosdeProduccion.Empaque = Empaque;
                    fs.Close();
                    fs = null;
                    br = null;
                    codificado = null;
                    db.Entry(EstilosdeProduccion).State = EntityState.Modified;
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

        public bool DeleteEstilosdeProduccion(string id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                { 
                    var EstilosdeProduccion = (from x in db.EstilosProduccion where x.IdEstilo == id select x).FirstOrDefault();
                    db.EstilosProduccion.Remove(EstilosdeProduccion);
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
       
        public void Mostrar(MetroTextBox IdEstilos, MetroComboBox Descrip, MetroComboBox Categoria, MetroComboBox Marca,  MetroComboBox Lavado,MetroComboBox Division, string estilo,int id)
        {
            using (PLMContext db = new PLMContext())
            {
                if (estilo != null && id==2 )
                {
                    var EstilosdeProduccion = DbD.Inventario(estilo).Select(x => new { x.IdEstilos, x.Category, x.Descripcion, x.Lavado, x.Supplier, x.Costo, x.Piece,x.Marca,x.Categoria,x.Division }).ToList().FirstOrDefault();
                    var EstilosdeProduccionn = DbD.Inventario1(estilo).Select(x => new { x.Division, x.Espec }).ToList().FirstOrDefault();
                    IdEstilos.Text = (EstilosdeProduccion.IdEstilos).Replace(" ", "");
                    Descrip.Items.Add(EstilosdeProduccion.Descripcion);
                    Descrip.SelectedIndex = 0;
                    Categoria.Items.Add(EstilosdeProduccion.Categoria);
                    Categoria.SelectedIndex = 0;
                    Marca.Items.Add(EstilosdeProduccion.Marca);
                    Marca.SelectedIndex = 0;
                    Lavado.Items.Add(EstilosdeProduccion.Lavado);
                    Lavado.SelectedIndex = 0;
                    Division.Items.Add(EstilosdeProduccionn.Division);
                    Division.SelectedIndex = 0; 
                }
            }
        }

      
      
        public void MostrarPLM(MetroTextBox IdEstilos, MetroComboBox Descrip, MetroComboBox Categoria, MetroComboBox Division, MetroComboBox Estacion, MetroComboBox Cliente, MetroComboBox Marca, MetroComboBox Category2, MetroTextBox Espec, MetroComboBox Fit, MetroComboBox Body, MetroComboBox Lavado, MetroComboBox Inseam, MetroComboBox Empaque, string estilo, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                if (estilo != string.Empty && id == 1)
                {
                    var EstilosdeProduccion = db.EstilosProduccion.Where(x => x.IdEstilo == estilo).Select(x => x).FirstOrDefault();
                    IdEstilos.Text = EstilosdeProduccion.IdEstilo;
                    IdEstilos.Enabled = false;
                    Descrip.Items.Add(EstilosdeProduccion.Descripcion);
                    Descrip.SelectedIndex = 0;
                    Categoria.Items.Add(EstilosdeProduccion.Categoria);
                    Categoria.SelectedIndex = 0;
                    Division.Items.Add(EstilosdeProduccion.Division);
                    Division.SelectedIndex = 0;
                    Estacion.Items.Add(EstilosdeProduccion.Estacion);
                    Estacion.SelectedIndex = 0;
                    Cliente.Items.Add(EstilosdeProduccion.Cliente);
                    Cliente.SelectedIndex = 0;
                    Marca.Items.Add(EstilosdeProduccion.Marca);
                    Marca.SelectedIndex = 0;
                    Category2.Items.Add(EstilosdeProduccion.Category2);
                    Category2.SelectedIndex = 0;
                    Espec.Text= (EstilosdeProduccion.Espec.ToString());
                    Fit.Items.Add(EstilosdeProduccion.Fit);
                    Fit.SelectedIndex = 0;
                    Body.Items.Add(EstilosdeProduccion.Body);
                    Body.SelectedIndex = 0;
                    Lavado.Items.Add(EstilosdeProduccion.Lavado);
                    Lavado.SelectedIndex = 0;
                    Inseam.Items.Add(EstilosdeProduccion.Inseam);
                    Inseam.SelectedIndex = 0;
                    Empaque.Items.Add(EstilosdeProduccion.Empaque);
                    Empaque.SelectedIndex = 0;
                }
            }
        }
        public void MostrarPLML(MetroTextBox IdEstilos, MetroLabel Descrip, MetroLabel Categoria, MetroLabel Division, MetroLabel Estacion, MetroLabel Cliente, MetroLabel Marca, MetroLabel Category2, MetroTextBox Espec, MetroLabel Fit, MetroLabel Body, MetroLabel Lavado, MetroLabel Inseam, MetroTextBox Empaque, string estilo, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                if (estilo != string.Empty && id == 1)
                {
                    var EstilosdeProduccion = db.EstilosProduccion.Where(x => x.IdEstilo == estilo).Select(x => x).FirstOrDefault();
                    IdEstilos.Text = EstilosdeProduccion.IdEstilo;
                    IdEstilos.Enabled = false;
                    Descrip.Text=EstilosdeProduccion.Descripcion;
                    
                    Categoria.Text=EstilosdeProduccion.Categoria;
                    
                    Division.Text=EstilosdeProduccion.Division;
                    
                    Estacion.Text=EstilosdeProduccion.Estacion;
                    
                    Cliente.Text=EstilosdeProduccion.Cliente;
                    
                    Marca.Text=EstilosdeProduccion.Marca;
                  
                    Category2.Text=EstilosdeProduccion.Category2;
                    
                    Espec.Text = (EstilosdeProduccion.Espec.ToString());
                    Fit.Text=EstilosdeProduccion.Fit;
                    
                    Body.Text=EstilosdeProduccion.Body;
                    
                    Lavado.Text=EstilosdeProduccion.Lavado;
                    
                    Inseam.Text=EstilosdeProduccion.Inseam;
                    
                    Empaque.Text=EstilosdeProduccion.Empaque;
                    
                }
            }
        }

        public void DatosDynamics(MetroComboBox descrip, MetroComboBox marca,MetroComboBox Categoria, MetroComboBox Lavado,MetroComboBox Espec, MetroComboBox Division, MetroComboBox Cliente)
        {
            var datos = DbD.Inventario();
            var datos1 = DbD.Inventario1();
            var datos2 = DbD.Inventario2();
            var datodescrip = datos.Select(x => x.Descripcion).ToList();
            var datomarca = datos.Select(x => x.Marca).ToList();
            var datoCategoria = datos.Select(x => x.Categoria).ToList();
            var datoLavado = datos.Select(x => x.Lavado).ToList();
            var datoIdEstilos = datos.Select(x => x.IdEstilos).ToList();
            var datoEspec = datos1.Select(x => x.Espec).ToList();
            var datoDivision = datos1.Select(x => x.Division).ToList();
            var datoCliente = datos2.Select(x => new {x.IdCliente,x.Cliente }).ToList();
            descrip.Items.Clear();
            descrip.ValueMember = "Descripcion";
            descrip.DisplayMember = "Descripcion";
            descrip.DataSource = datodescrip;
            marca.Items.Clear();
            marca.ValueMember = "Marca";
            marca.DisplayMember = "Marca";
            marca.DataSource = datomarca;
            Categoria.Items.Clear();
            Categoria.ValueMember = "Categoria";
            Categoria.DisplayMember = "Categoria";
            Categoria.DataSource = datoCategoria;
            Lavado.Items.Clear();
            Lavado.ValueMember = "Lavado";
            Lavado.DisplayMember = "Lavado";
            Lavado.DataSource = datoLavado;
            Espec.Items.Clear();
            Espec.ValueMember = "Espec";
            Espec.DisplayMember = "Espec";
            Espec.DataSource = datoEspec;
            Division.Items.Clear();
            Division.ValueMember = "Division";
            Division.DisplayMember = "Division";
            Division.DataSource = datoDivision;
            Cliente.Items.Clear();
            Cliente.ValueMember = "IdCLiente";
            Cliente.DisplayMember = "Cliente";
            Cliente.DataSource = datoCliente;
            if (descrip.Items.Count > 0)
            {
                

            }
        }

        public void DatosDynamics(DataGridView dtDatos, int idFuncion)
        {
            try {
                Cursor.Current = Cursors.WaitCursor;
            switch (idFuncion)
            {                 
                case 0:
                    var datos = DbD.Inventario().Select(x => new { x.Descripcion }).ToList();
                    List<Inventory> temp = new List<Inventory>();
                    foreach(var dato in datos)
                    {
                        if (temp.Where(x => x.Descripcion == dato.Descripcion).Select(x => x.Descripcion).FirstOrDefault() == null)
                        {
                            temp.Add(new Inventory { Descripcion = dato.Descripcion });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos = temp.Select(x => new { x.Descripcion }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos;                    
                    dtDatos.Columns[0].Width = 500; 
                    break;
                case 2:
                    var datos1 = DbD.Inventario().Select(x => new { x.Categoria }).ToList();
                    List<Inventory> temp1 = new List<Inventory>();
                    foreach(var dato in datos1)
                    {
                        if (temp1.Where(x => x.Categoria == dato.Categoria).Select(x => x.Categoria).FirstOrDefault() == null)
                        {
                            temp1.Add(new Inventory { Categoria = dato.Categoria });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos1 = temp1.Select(x => new { x.Categoria }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos1;
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 6:
                    var datos2 = DbD.Inventario1().Select(x => new { x.Division }).ToList();
                    List<Inventory> temp2 = new List<Inventory>();
                    foreach(var dato in datos2)
                    {
                        if (temp2.Where(x => x.Division == dato.Division).Select(x => x.Division).FirstOrDefault() == null)
                        {
                            temp2.Add(new Inventory { Division = dato.Division });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos2 = temp2.Select(x => new { x.Division }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos2; 
                    dtDatos.Columns[0].Width = 500; 
                    break;
                case 7:
                    var datos3 = DbD.Inventario2().Select(x => new { x.Cliente }).ToList();
                    List<Inventory> temp3 = new List<Inventory>();
                    foreach(var dato in datos3)
                    {
                        if (temp3.Where(x => x.Cliente == dato.Cliente).Select(x => x.Cliente).FirstOrDefault() == null)
                        {
                            temp3.Add(new Inventory { Cliente = dato.Cliente });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos3 = temp3.Select(x => new { x.Cliente }).ToList();     dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos3;
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 1:
                    var datos4 = DbD.Inventario().Select(x => new { x.Marca }).ToList();
                    List<Inventory> temp4 = new List<Inventory>();
                    foreach(var dato in datos4)
                    {
                        if (temp4.Where(x => x.Marca == dato.Marca).Select(x => x.Marca).FirstOrDefault() == null)
                        {
                            temp4.Add(new Inventory { Marca = dato.Marca });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos4 = temp4.Select(x => new { x.Marca }).ToList();     dtDatos.Columns.Clear();  dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos4;                        
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 5:
                   var datos5 = DbD.Inventario1().Select(x => new { x.Espec }).ToList();
                   List<Inventory> temp5 = new List<Inventory>();
                   foreach(var dato in datos5)
                   {
                        if (temp5.Where(x => x.Espec == dato.Espec).Select(x => x.Espec).FirstOrDefault() == null)
                        {
                            temp5.Add(new Inventory { Espec = dato.Espec });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos5 = temp5.Select(x => new { x.Espec }).ToList();     dtDatos.Columns.Clear();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos5;                       
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 30:
                    var datos15 = DbD.Inventario().Select(x => new { x.Piece }).ToList();
                    List<Inventory> temp15 = new List<Inventory>();
                    foreach (var dato in datos15)
                    {
                        if (temp15.Where(x => x.Piece == dato.Piece).Select(x => x.Piece).FirstOrDefault() == null)
                        {
                            temp15.Add(new Inventory { Piece = dato.Piece });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos15 = temp15.Select(x => new { x.Piece }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos15;
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 24:
                    var datos16 = DbD.Inventario().Select(x => new { x.Category }).ToList();
                    List<Inventory> temp16 = new List<Inventory>();
                    foreach (var dato in datos16)
                    {
                        if (temp16.Where(x => x.Category == dato.Category).Select(x => x.Category).FirstOrDefault() == null)
                        {
                            temp16.Add(new Inventory { Category = dato.Category });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos16 = temp16.Select(x => new { x.Category }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos16;
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 3:
                    var datos6 = DbD.Inventario().Select(x => new { x.Lavado }).ToList();
                    List<Inventory> temp6 = new List<Inventory>();
                    foreach(var dato in datos6)
                    {
                        if (temp6.Where(x => x.Lavado == dato.Lavado).Select(x => x.Lavado).FirstOrDefault() == null)
                        {
                            temp6.Add(new Inventory { Lavado = dato.Lavado });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos6 = temp6.Select(x => new { x.Lavado }).ToList();     dtDatos.Columns.Clear();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos6;                   
                    dtDatos.Columns[0].Width = 500;
                    break;
                default:
                    datos = null;
                    break;
                case 27:
                    var datos17 = DbD.Inventario().Select(x => new { x.Supplier }).ToList();
                    var datosP = DbD.Reporte2().ToList();
                    string nombre = "";    
                    
                    List<Proveedores> temp17 = new List<Proveedores>();
                    foreach (var dato in datos17)
                    {
                        if (temp17.Where(x => x.Clave == dato.Supplier).Select(x => x.Clave).FirstOrDefault() == null)
                        {
                            nombre = datosP.Where(x => x.Clave == dato.Supplier).Select(x => x.Nombre).FirstOrDefault();
                            temp17.Add(new Proveedores { Clave = dato.Supplier, Nombre = nombre });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    //datos17 = temp17.Select(x => new { x.Supplier }).ToList();
                    dtDatos.Columns.Clear();
                    dtDatos.DataSource = temp17;
                    dtDatos.Columns[0].Width = 100;
                    dtDatos.Columns[1].Width = 500;
                    break;
                case 17:
                    var datos27 = DbD.Inventario().Select(x => new { x.Marca }).ToList();
                    List<Inventory> temp27 = new List<Inventory>();
                    foreach (var dato in datos27)
                    {
                        if (temp27.Where(x => x.Marca == dato.Marca).Select(x => x.Marca).FirstOrDefault() == null)
                        {
                            temp27.Add(new Inventory { Marca = dato.Marca });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos27 = temp27.Select(x => new { x.Marca }).ToList(); dtDatos.Columns.Clear(); dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos27;
                    dtDatos.Columns[0].Width = 500;
                    break;
                case 16:
                    var datos26 = DbD.Inventario().Select(x => new { x.Marca }).ToList();
                    List<Inventory> temp26 = new List<Inventory>();
                    foreach (var dato in datos26)
                    {
                        if (temp26.Where(x => x.Marca == dato.Marca).Select(x => x.Marca).FirstOrDefault() == null)
                        {
                            temp26.Add(new Inventory { Marca = dato.Marca });
                        }
                        else
                        {
                            continue;
                        }
                    }
                    datos26 = temp26.Select(x => new { x.Marca }).ToList(); dtDatos.Columns.Clear(); dtDatos.Columns.Clear();
                    dtDatos.DataSource = datos26;
                    dtDatos.Columns[0].Width = 500;
                    break;               
                case 18:
                    using (PLMContext db = new PLMContext())
                    {
                        var datos18 = db.Boms.Select(x => x).ToList();
                        dtDatos.Columns.Clear();
                        dtDatos.DataSource = datos18;                                       
                    }
                  break;
                case 31:
                  var datos31 = DbD.Inventario4().Select(x => new { x.Thread, x.EstilosThread }).ToList();
                  List<Inventory> temp31= new List<Inventory>();
                  foreach (var dato in datos31)
                  {
                      if (temp31.Where(x => x.Thread == dato.Thread).Select(x => x.Thread).FirstOrDefault() == null)
                      {
                          temp31.Add(new Inventory { Thread = dato.Thread, EstilosThread = dato.EstilosThread });
                      }
                      else
                      {
                          continue;
                      }
                  }
                  datos31 = temp31.Select(x => new { x.Thread, x.EstilosThread }).ToList(); dtDatos.Columns.Clear(); dtDatos.Columns.Clear();
                  dtDatos.DataSource = datos31;
                 
                  dtDatos.Columns[0].Width = 500;
                  break; 
            }
            Cursor.Current = Cursors.Default;
                }
            catch (SqlException ex)
            {
                MessageBoxEx.Show("Error al conectarse a la base de datos: "+ ex.ErrorCode.ToString() +" " + ex.Message, "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                Cursor.Current = Cursors.Default;
            }
        }
        
        public void EstilosDynamics(DataGridView dtDatos)
        {
            var datos3 = DbD.Inventario().Select(x => new { x.IdEstilos }).ToList();
            dtDatos.Columns.Clear();
            dtDatos.DataSource = datos3;          
            dtDatos.Columns[0].Width = 400;
            dtDatos.Columns[0].HeaderText = "ESTILOS DE PRODUCCION DYNAMICS";                    
        }
        public bool Existe(string estilo)
        {
            using (PLMContext db = new PLMContext())
            {
                var Estilo = (from x in db.EstilosProduccion where x.IdEstilo == estilo select x).Count();
                if (Estilo == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void EstilosDynamicsBom(DataGridView dtDatos)
        {

            Cursor.Current = Cursors.WaitCursor;
            var datos4 = DbD.Inventario().Select(x => new { x.IdEstilos }).ToList();
            List<EstilosTemp>EstilosTemp = new List<EstilosTemp>();
            foreach (var dato in datos4)
            {
                string estilo;
                string[] temp;
                temp = dato.IdEstilos.Split(' ');
                estilo = temp[0];                                                  
                if (EstilosTemp.Where(x => x.IdEstilos == estilo).FirstOrDefault() == null)
                {
                    EstilosTemp.Add(new EstilosTemp { IdEstilos = estilo });
                }
                else 
                {
                    continue;
                }                
            }
            dtDatos.Columns.Clear();
            dtDatos.DataSource = EstilosTemp;
            dtDatos.Columns[0].Width = 400;
            dtDatos.Columns[0].HeaderText = "ESTILOS DE PRODUCCION DYNAMICS";
            Cursor.Current = Cursors.Default;
        }

        public void EstilosdeProduccion(DataGridView controlView)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.EstilosProduccion.Select(x => new { x.IdEstilo }).ToList();
                    controlView.DataSource = datos;
                    controlView.Columns[0].HeaderText = "ESTILOS DE PRODUCCION PLM";
                    controlView.Columns[0].Width = 400;                   
                }
                catch (Exception ex)
                {
                    Dialogs.Show(ex.Message, DialogsType.Error);
                }
            }
            Cursor.Current = Cursors.Default;
        }     
    }
}
