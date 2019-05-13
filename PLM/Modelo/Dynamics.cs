using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PLM.Modelo;
using ArcangelDialogs;
using PLM.Clases;
using PLM.Modelo.Reportes;

namespace PLM.Modelo
{
	public class Dynamics
	{
		SqlConnection conexion;

		public Dynamics()
		{
			//"Data Source=OMARTUAPC;Initial Catalog=RIOSULAPP;User Id=sa;Password=********;"            
			//conexion = new SqlConnection(@"Data Source=" + ConfigIni.HostDynamic + ";Initial Catalog=" + ConfigIni.BdDynamic + ";User Id=" + ConfigIni.IdDynamic + ";Password=" + ConfigIni.PasswordDynamic + "; Integrated Security=False;");
			//conexion = new SqlConnection(@"Data Source=DESKTOP-5EQKCQB; Initial Catalog=RIOSULPRUEBAS9 ;Integrated Security=True;");
			conexion = new SqlConnection(@"Data Source=DESKTOP-JBDH3N9; Initial Catalog=RIOSULPRUEBAS9 ;Integrated Security=True;");
		}

		// recorda que quitamos el LeadTime
		public List<Inventory> Inventario()
		{
			SqlCommand comando = new SqlCommand("SELECT descr,classid,InvtID,Size,color,materialtype,stkunit,supplr1,LastCost,MaxOnHand,DfltPOUnit FROM Inventory", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory>miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							Descripcion = miDt.Rows[i][0].ToString(),
							Marca = miDt.Rows[i][1].ToString(),
							Categoria = miDt.Rows[i][3].ToString(), 
							Lavado = miDt.Rows[i][4].ToString(), 
							IdEstilos= miDt.Rows[i][2].ToString(),
							Category = miDt.Rows[i][5].ToString(),
							Piece = miDt.Rows[i][6].ToString(),
							Supplier = miDt.Rows[i][7].ToString(),
							Costo = float.Parse(miDt.Rows[i][8].ToString()),
							//MaximoEnExistencia = float.Parse(miDt.Rows[i][9].ToString()),
							//UMCompra = float.Parse(miDt.Rows[i][10].ToString()),
							//FechaEntProv = DateTime.Parse(miDt.Rows[i][11].ToString())
							//FechaEntProv = float.Parse(miDt.Rows[i][11].ToString())
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> hojaCotizacion()
		{
			SqlCommand comando = new SqlCommand("SELECT AltIDType FROM ItemxRef", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							HDescripcion = miDt.Rows[i][0].ToString(),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> hojacotizacion1()
		{
			SqlCommand comando = new SqlCommand("SELECT CustOrdNbr, CustID FROM SOHeader", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							NroOrdenCompra = miDt.Rows[i][0].ToString(),
						   IdClienteO = miDt.Rows[i][1].ToString(),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> hojacotizacion3()
		{
			SqlCommand comando = new SqlCommand("SELECT QtyWOReqd FROM WOMatlReq", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							CantidadFabricar = float.Parse(miDt.Rows[i][0].ToString()),
							
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> hojacotizacion2()
		{
			SqlCommand comando = new SqlCommand("SELECT User9,QtyOrig,ProcStage,PlanStart FROM SOHeader", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							OrdenVenta = miDt.Rows[i][0].ToString(),
							CantidadFabricar= float.Parse(miDt.Rows[i][1].ToString()),
							EtapaProceso = miDt.Rows[i][2].ToString(),
							PlanInicio = DateTime.Parse(miDt.Rows[i][3].ToString()),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario(string dato)
		{
			SqlCommand comando = new SqlCommand("SELECT descr,classid,InvtID,Size,color,materialtype,stkunit,supplr1,LastCost FROM Inventory WHERE InvtID LIKE @dato " , conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				comando.Parameters.AddWithValue("@dato",  "%" + dato + "%");
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							Descripcion = miDt.Rows[i][0].ToString(),
							Marca = miDt.Rows[i][1].ToString(),
							Categoria = miDt.Rows[i][3].ToString(),
							Lavado = miDt.Rows[i][4].ToString(),
							IdEstilos = miDt.Rows[i][2].ToString(),
							Category = miDt.Rows[i][5].ToString(),
							Piece = miDt.Rows[i][6].ToString(),
							Supplier = miDt.Rows[i][7].ToString(),
							Costo = float.Parse(miDt.Rows[i][8].ToString())
						};
						miLista.Add(objetoInv);
						
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario1()
		{
			SqlCommand comando = new SqlCommand("SELECT  Style FROM InventoryADG", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory();
						if(string.IsNullOrEmpty(miDt.Rows[i][0].ToString()))
						{
							objetoInv.Division = "";
						}
						else
						{
							objetoInv.Division = miDt.Rows[i][0].ToString();
						}
													  
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Hojacotizacion5()
		{
			SqlCommand comando = new SqlCommand("SELECT  Weight, User8, Gauge FROM InventoryADG", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory();
					  
						if (string.IsNullOrEmpty(miDt.Rows[i][0].ToString()))
						{
							objetoInv.Peso = 0;
						}
						else
						{
							objetoInv.Peso = float.Parse(miDt.Rows[i][0].ToString());
						}
						if (miDt.Rows[i][1]== null)
						{
							objetoInv.Ancho = 0;
						}
						else
						{
							objetoInv.Ancho = float.Parse(miDt.Rows[i][1].ToString());
						}

						if (string.IsNullOrEmpty(miDt.Rows[i][2].ToString()))
						{
							objetoInv.Calibre = 0;
						}
						else
						{
							objetoInv.Calibre = float.Parse(miDt.Rows[i][2].ToString());
						}
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario1(string dato)
		{
			SqlCommand comando = new SqlCommand("SELECT user1, Style FROM InventoryADG WHERE InvtID = @dato", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				comando.Parameters.AddWithValue("@dato", dato);
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							Espec = miDt.Rows[i][0].ToString(),
							Division = miDt.Rows[i][1].ToString(),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario3()
		{
			SqlCommand comando = new SqlCommand("SELECT vendid, Style FROM vendor", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							IdProvedor = miDt.Rows[i][0].ToString(),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario4()
		{
			SqlCommand comando = new SqlCommand("SELECT AlternateId,InvtId FROM ItemXRef", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							Thread = miDt.Rows[i][0].ToString(),
							EstilosThread = miDt.Rows[i][1].ToString(), 
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Inventory> Inventario2()
		{
			SqlCommand comando = new SqlCommand("SELECT custid, name,curyid FROM customer order by name", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Inventory> miLista = new List<Inventory>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Inventory objetoInv = new Inventory
						{
							Cliente = miDt.Rows[i][1].ToString(),
							IdCliente = miDt.Rows[i][0].ToString(), 
							ClienteC = miDt.Rows[i][2].ToString(),
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<RepResurtimiento> Reporte1(string fecha1, string fecha2, string cliente, string Wonbr)
		{
			SqlCommand comando = new SqlCommand(@"SELECT        TOP (100) PERCENT A.InvtID, B.Descr AS DescrArt, A.QtyWOReqd AS CantOrd, A.WONbr, dbo.InventoryADG.ProdLineID AS MaterialType, dbo.ItemSite.QtyOnHand AS Existencia, B.DfltPOUnit AS UnidadCompra, 
						 dbo.SOHeader.OrdNbr AS OrdenVenta, dbo.SOHeader.CustOrdNbr AS Po, dbo.InventoryADG.User6 AS PorAdicional, dbo.ItemSite.QtyOnPO AS CantidadOrdenesVta, dbo.ItemXRef.AlternateID AS CodProv, 
						 dbo.ItemXRef.Descr AS DescProv, B.Supplr1 AS Proveedor, B.LeadTime AS TempoEntregaCompras, dbo.SOHeader.User9 AS FechaEmbarque, dbo.SOHeader.CustID, D.QtyOrig AS CantFabric
FROM            dbo.SOHeader INNER JOIN
						 dbo.WOMatlReq AS A INNER JOIN
						 dbo.Inventory AS B ON A.InvtID = B.InvtID INNER JOIN
						 dbo.INUnit AS C ON B.StkUnit = C.ToUnit AND B.DfltPOUnit = C.FromUnit INNER JOIN
						 dbo.WOHeader AS D ON A.WONbr = D.WONbr INNER JOIN
						 dbo.ProductClass AS F ON F.ClassID = B.ClassID INNER JOIN
						 dbo.RsVw_1265001A AS G ON G.Wonbr = D.WONbr ON dbo.SOHeader.OrdNbr = D.User9 LEFT OUTER JOIN
						 dbo.ItemXRef ON B.InvtID = dbo.ItemXRef.InvtID LEFT OUTER JOIN
						 dbo.ItemSite INNER JOIN
						 dbo.InventoryADG ON dbo.ItemSite.InvtID = dbo.InventoryADG.InvtID RIGHT OUTER JOIN
						 dbo.INDfltSites ON dbo.ItemSite.DfltPickBin = dbo.INDfltSites.DfltPickBin AND dbo.ItemSite.InvtID = dbo.INDfltSites.InvtID AND dbo.ItemSite.SiteID = dbo.INDfltSites.DfltSiteID ON 
						 B.InvtID = dbo.INDfltSites.InvtID
WHERE        (D.ProcStage IN ('P', 'F', 'R')) AND (A.SiteID <> 'prod. term')
						AND SOHeader.User9 >= '" + fecha1 + "' AND SOHeader.User9 <= '" + fecha2 + "' " + cliente + Wonbr, conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<RepResurtimiento> miLista = new List<RepResurtimiento>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						RepResurtimiento objetoInv = new RepResurtimiento
						{
							clave = miDt.Rows[i][0].ToString().Trim(),
							descripcion = miDt.Rows[i][1].ToString().Trim(),
							cant_ord = miDt.Rows[i][2].ToString().Trim() ?? "0",
							ot = miDt.Rows[i][3].ToString().Trim(),
							tipo_material = miDt.Rows[i][4].ToString().Trim(),
							existencia = miDt.Rows[i][5].ToString().Trim() ?? "0",
							unidad_compra = miDt.Rows[i][6].ToString().Trim(),
							orden_venta = miDt.Rows[i][7].ToString().Trim(),
							po = miDt.Rows[i][8].ToString().Trim(),
							adicional = miDt.Rows[i][9].ToString().Trim() ?? "0",
							cantidad_ordenes_venta = miDt.Rows[i][10].ToString().Trim() ?? "0",
							cod_proveedor = miDt.Rows[i][11].ToString().Trim(),
							desc_proveedor = miDt.Rows[i][12].ToString().Trim(),
							proveedor = miDt.Rows[i][13].ToString().Trim(),
							tiempo_entrega = miDt.Rows[i][14].ToString().Trim(),
							fecha_embarque = miDt.Rows[i][15].ToString().Trim(),
							cliente_id = miDt.Rows[i][16].ToString().Trim(),
							cant_fabr = miDt.Rows[i][17].ToString().Trim()
						};
						miLista.Add(objetoInv);
					}
				

					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Proveedores> Reporte2()
		{
			SqlCommand comando = new SqlCommand("select VendId,Name from Vendor", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Proveedores> miLista = new List<Proveedores>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Proveedores proveedores = new Proveedores()
						{
							Clave = miDt.Rows[i][0].ToString(),
							Nombre = miDt.Rows[i][1].ToString()
						};
						miLista.Add(proveedores);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<string> GetWonbr()
		{
			SqlCommand comando = new SqlCommand("select distinct(WONbr) from WOMatlReq", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<string> miLista = new List<string>();
			string Clave = "";
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Clave = miDt.Rows[i][0].ToString().Trim();
						miLista.Add(Clave);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public string BuscarThreadDescripcion(string InvtID)
		{
			SqlCommand comando = new SqlCommand("SELECT descr FROM Inventory WHERE InvtId = @id", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			string temp = string.Empty;
			try
			{
				comando.Parameters.AddWithValue("@id", InvtID);
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					temp = miDt.Rows[0][0].ToString();
					return temp;
				}
				else
				{
					return string.Empty;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return string.Empty;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public string PURORDDET(string WONbr)
		{
			SqlCommand comando = new SqlCommand("select PONbr From PURORDDET where projectid = @id", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			string temp = string.Empty;
			try
			{
				comando.Parameters.AddWithValue("@id", WONbr);
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					temp = miDt.Rows[0][0].ToString();
					return temp;
				}
				else
				{
					return string.Empty;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return string.Empty;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public string PURCHORD(string PONbr)
		{
			SqlCommand comando = new SqlCommand("select Status From PURCHORD where ponbr = @id", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			string temp = string.Empty;
			try
			{
				comando.Parameters.AddWithValue("@id", PONbr);
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					temp = miDt.Rows[0][0].ToString();
					return temp;
				}
				else
				{
					return string.Empty;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return string.Empty;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public string CuryRate(string Fecha)
		{
			SqlCommand comando = new SqlCommand("Select Rate From CuryRate where EffDate = @id", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			string temp = string.Empty;
			try
			{
				comando.Parameters.AddWithValue("@id", Fecha);
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					temp = miDt.Rows[0][0].ToString();
					return temp;
				}
				else
				{
					return string.Empty;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return string.Empty;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<WOMatlReq> wOMatlReqs()
		{
			SqlCommand comando = new SqlCommand("select InvtID,QtyWOReqd,SiteID, WONbr from WOMatlReq", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<WOMatlReq> miLista = new List<WOMatlReq>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						WOMatlReq proveedores = new WOMatlReq()
						{
							InvtID = miDt.Rows[i][0].ToString().Trim(),
							QtyWOReqd = miDt.Rows[i][1].ToString().Trim(),
							SiteID = miDt.Rows[i][2].ToString().Trim(),
							WONbr = miDt.Rows[i][3].ToString().Trim()
						};
						miLista.Add(proveedores);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<InventoryOT> Inventario5()
		{
			SqlCommand comando = new SqlCommand("select InvtID,Supplr1,user3,LastCost,ReordQty,ReordPt,StkUnit,DfltPOUnit,Descr,MaterialType From Inventory", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<InventoryOT> miLista = new List<InventoryOT>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						InventoryOT objetoInv = new InventoryOT
						{
							InvtID = miDt.Rows[i][0].ToString(),
							Supplr1 = miDt.Rows[i][1].ToString(),
							user3 = miDt.Rows[i][2].ToString(),
							LastCost = miDt.Rows[i][3].ToString(),
							ReordQty = miDt.Rows[i][4].ToString(),
							ReordPt = miDt.Rows[i][5].ToString(),
							StkUnit = miDt.Rows[i][6].ToString(),
							DfltPOUnit = miDt.Rows[i][7].ToString(),
							Descr = miDt.Rows[i][8].ToString(),
							MaterialType = miDt.Rows[i][9].ToString()
						};
						miLista.Add(objetoInv);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Truncate_Rstb_GeneraOC()
		{
			SqlCommand comando = new SqlCommand("Truncate table Rstb_GeneraOC", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Truncate_RsTb_Vendid()
		{
			SqlCommand comando = new SqlCommand("Truncate table RsTb_Vendid", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Insert_Rstb_GeneraOC(string InvtId, decimal Qty, string VendId, string WonBr, string User1, decimal User5, decimal User6)
		{
			SqlCommand comando = new SqlCommand(@"Insert into RsTb_GeneraOC (InvtId,Qty,Vendid,WoNbr,User1,User5,User6,User2,User3,User4,User7,User8) 
												  values ('"+ InvtId + "','" + Qty + "','" + VendId + "','" + WonBr + "','" + User1 + "','" + User5 + "','" + User6 + "','','','','','')", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<RsTb_GeneraOC> RsTb_GeneraOC()
		{
			SqlCommand comando = new SqlCommand("select InvtId,Qty,Vendid,WoNbr,User1,User5,User6 from RsTb_GeneraOC", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<RsTb_GeneraOC> miLista = new List<RsTb_GeneraOC>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						RsTb_GeneraOC oc = new RsTb_GeneraOC()
						{
							InvtId = miDt.Rows[i][0].ToString().Trim(),
							Qty = Convert.ToDecimal(miDt.Rows[i][1].ToString()),
							VendId = miDt.Rows[i][2].ToString().Trim(),
							WonBr = miDt.Rows[i][3].ToString().Trim(),
							User1 = miDt.Rows[i][4].ToString().Trim(),
							User5 = Convert.ToDecimal(miDt.Rows[i][5].ToString()),
							User6 = Convert.ToDecimal(miDt.Rows[i][6].ToString())
						};
						miLista.Add(oc);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool delete_Rstb_GeneraOC(string InvtID)
		{
			SqlCommand comando = new SqlCommand("Delete from Rstb_generaOC where invtid = " + InvtID + "", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<string> Rstb_Vendid()
		{
			SqlCommand comando = new SqlCommand("Select vendid From Rstb_Vendid", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<string> miLista = new List<string>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						miLista.Add(miDt.Rows[i][0].ToString().Trim());
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<Vendor> Vendor()
		{
			SqlCommand comando = new SqlCommand(@"select CuryId, TaxId00, TaxId01, TaxId02, TaxId03, Terms,Addr1,Addr2,Fax,Phone,Name,EMailAddr,Attn,City,Country,State,Zip,VendId 
													from Vendor", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<Vendor> miLista = new List<Vendor>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						Vendor v = new Vendor()
						{
							CuryId = miDt.Rows[i][0].ToString().Trim(),
							TaxId00 = miDt.Rows[i][1].ToString().Trim(),
							TaxId01 = miDt.Rows[i][2].ToString().Trim(),
							TaxId02 = miDt.Rows[i][3].ToString().Trim(),
							TaxId03 = miDt.Rows[i][4].ToString().Trim(),
							Terms = miDt.Rows[i][5].ToString().Trim(),
							Addr1 = miDt.Rows[i][6].ToString().Trim(),
							Addr2 = miDt.Rows[i][7].ToString().Trim(),
							Fax = miDt.Rows[i][8].ToString().Trim(),
							Phone = miDt.Rows[i][9].ToString().Trim(),
							Name = miDt.Rows[i][10].ToString().Trim(),
							EMailAddr = miDt.Rows[i][11].ToString().Trim(),
							Attn = miDt.Rows[i][12].ToString().Trim(),
							City = miDt.Rows[i][13].ToString().Trim(),
							Country = miDt.Rows[i][14].ToString().Trim(),
							State = miDt.Rows[i][15].ToString().Trim(),
							Zip = miDt.Rows[i][16].ToString().Trim(),
							VendId = miDt.Rows[i][17].ToString().Trim(),
						};
						miLista.Add(v);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public POSetup PoSetup()
		{
			SqlCommand comando = new SqlCommand(@"select ShipAddr1,ShipAddr2,ShipCity,ShipState,ShipAttn,ShipEmail,ShipFax,ShipName,ShipPhone,ShipZip,ShipCountry,LastPONbr
													from POSetup", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			POSetup PO = new POSetup();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						PO.ShipAddr1 = miDt.Rows[i][0].ToString().Trim();
						PO.ShipAddr2 = miDt.Rows[i][1].ToString().Trim();
						PO.ShipCity = miDt.Rows[i][2].ToString().Trim();
						PO.ShipState = miDt.Rows[i][3].ToString().Trim();
						PO.ShipAttn = miDt.Rows[i][4].ToString().Trim();
						PO.ShipEmail = miDt.Rows[i][5].ToString().Trim();
						PO.ShipFax = miDt.Rows[i][6].ToString().Trim();
						PO.ShipName = miDt.Rows[i][7].ToString().Trim();
						PO.ShipPhone = miDt.Rows[i][8].ToString().Trim();
						PO.ShipZip = miDt.Rows[i][9].ToString().Trim();
						PO.ShipCountry = miDt.Rows[i][10].ToString().Trim();
						PO.LastPONbr = miDt.Rows[i][11].ToString().Trim();
					}
					return PO;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public decimal InUnit(string factalmac, string factcomp)
		{
			SqlCommand comando = new SqlCommand("select CnvFact From InUnit where tounit = " + factalmac + " and fromUnit = " + factcomp + "", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			decimal temp = 0;
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					temp = Convert.ToDecimal(miDt.Rows[0][0].ToString());
					return temp;
				}
				else
				{
					return 0;
				}
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return 0;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public List<POREQDET> POREQDET()
		{
			SqlCommand comando = new SqlCommand("select ReqNbr,ExtCost,CuryExtCost From POREQDET", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			List<POREQDET> miLista = new List<POREQDET>();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				miDt = miDs.Tables[0];
				if (miDt.Rows.Count > 0)
				{
					for (int i = 0; i <= miDt.Rows.Count - 1; i++)
					{
						POREQDET v = new POREQDET()
						{
							ReqNbr = miDt.Rows[i][0].ToString().Trim(),
							ExtCost = Convert.ToDecimal(miDt.Rows[i][1].ToString()),
							CuryCuryExtCost = Convert.ToDecimal(miDt.Rows[i][2].ToString())
						};
						miLista.Add(v);
					}
					return miLista;
				}
				else
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return null;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Insert_PURORDDET(decimal factor, decimal Qty, string Fecha, string UserId, decimal CuryExtCost, string CuryID,
									decimal TC, decimal CuryUnitCost, decimal ExtCost, string InvtID, int Num, string LineRef, string OC, string WONbr, string factcomp,
									decimal cantidadcomp, string FechaProm, string SiteID, string tax1, string tax2, string tax3, string tax4, string Descr, string User6)
		{
			SqlCommand comando = new SqlCommand(@"INSERT INTO PURORDDET values(0,0,'','',0,'','','" + factor + "',0,0,0,''," + Fecha + ",'04250','" + UserId +
												"',0,0,0,'" + CuryExtCost + "','" + CuryID + "','M','" + TC + "',0,0,0,0,0,0,0,0,'" + CuryUnitCost + "','" + 
												ExtCost + "',0,0,0,'" + InvtID + "',1,0,'','" + Num + "','" + Num + "','" + LineRef + "','" + Fecha + "','04250','" + UserId +
												"',0,1,1,'Y','',0,'" + OC +
												 "','OR','" + WONbr + "','','1130010','GI','" + factcomp + "','000000000','" + cantidadcomp + "',0,0,0,'W','105','100'," +
												 "'N','','" + FechaProm + "','','','',0,0,0,0,'','',0,0,'','','',0,'','','','','','','','','','" + SiteID + "','','','',0,'',0," +
												 "'',0,0,0,0,'','GRAVABLE','" + tax1 + "','" + tax2 + "','" + tax3 + "','" + tax4 + "','','" 
												 + Descr + "',0,0,0,0,'" + User6 + "','M',0,'','',0,0,'','','','','N',0,'','',0,NULL)", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Insert_POREQDET(decimal factor, string Fecha, string UserId, decimal CuryExtCost, string CuryID,
									decimal TC, decimal CuryUnitCost, decimal ExtCost, string InvtID, int Num, string LineRef, string OC, string factcomp,
									decimal cantidadcomp, string FechaProm, string SiteID, string tax1, string tax2, string tax3, string tax4, string Descr, string User6, string tipomaterial)
		{
			SqlCommand comando = new SqlCommand(@"INSERT INTO POREQDET VALUES('1130010',0,'','','LO','LO','N','','','" + factor + "','" + ExtCost + "','" + Fecha + "', '04250','" + UserId + "','" 
									+ CuryExtCost + "', '" + CuryExtCost + "', '" + CuryID + "', 'M', '" + TC + "', 0, 0, 0, 0, 0, 0, 0, 0, '" + CuryUnitCost + "', 0, '', '" + Descr + "', '" +
									ExtCost + "', 0, '" + InvtID + "', 0, '', '', 0, '', '" + Num + "', '" + Num + "', '" + LineRef + "', '" + Fecha + "', '04250', '" + 
									UserId + "', '" + tipomaterial + "', 0, 'N', 'Y', '', 0, 'LO', 'LO', '', '', '" + Fecha + "', 'GI', '" + cantidadcomp + "', 'W', 105, 100, 0, '" + OC + "','" 
									+ FechaProm + "', '', '', 0, 0, 0, 0, '', '', 0, 0, '', '', '" + LineRef + "', '', '', '" + SiteID + "', '', 'CR', '000000000','',0,0,0,0,'','GRAVABLE','" +
									tax1 + "','" + tax2 + "','" + tax3 + "','" + tax4 + "','','N',0,0,0,0,'" + factcomp + "','" + User6 + "', 'M', 0, '', '', 0, 0, '', '', '', '', NULL)", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
		public bool Insert_PurchOrd(string Fecha, string UserId, string CuryID,string CpnyID, decimal sumcuryextcost, string WONbr, string periodo, decimal sumextcost, string email,
									decimal TC, int Num, string OC, string tax1, string tax2, string tax3, string tax4, string Addr1, string Addr2, string Attn, string City, string Country,
									string Fax, string NameR, string Phone, string State, string Zip, string Terms, string va, string va2, string va1, string vci, string vc, string vf,
									string ve, string VendID, string vn, string vp, string vs, string vz)
		{
			SqlCommand comando = new SqlCommand(@"insert PurchOrd values ('','','','','','','HG','','','" + CpnyID + "','" + Fecha + "','4250','" + UserId + "','','" + Fecha + "','','" + CuryID + "','M','" + sumcuryextcost + "','" + TC + "'," +
				"'DOF','','','','','','','','','','','','','" + Num + "','" + Fecha + "','4250','" + UserId + "','','','','','','','" + periodo + "','" + sumextcost + "','" + Fecha + "','','OC','OR','WONbr','','','N','','','','','','','','','','','','','',''," +
				"'','" + Addr1 + "','" + Addr2 + "','','" + Attn + "','" + City + "','" + Country + "',''," +
				"'"+ email + "','" +Fax + "','" + NameR + "','" + Phone + "','','" + State + "','','P','','','','" + Zip + "','P','','','','','" + tax1 + "','" + tax2 + "','" + tax3 + "'," +
				"'"+ tax4 + "','','','','','" + Terms + "','','','','','','','','','','','','','" + va1+ "','" + va2 + "','DEFAULT'," +
				"'" + va + "','" + vci + "','" + vc + "','" + ve + "','" + vf + "','" + VendID + "','" + vn + "','" + vp + "','" + vs + "','" + vz + "','N','',NULL)", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}

		public bool Insert_PoReqHdr(string Fecha, string UserId, string CuryID, string CpnyID, decimal sumcuryextcost, string WONbr, string periodo, decimal sumextcost, string email,
									decimal TC, int Num, string OC, string tax1, string tax2, string tax3, string tax4, string Addr1, string Addr2, string Attn, string City, string Country,
									string Fax, string NameR, string Phone, string State, string Zip, string Terms, string va, string va2, string va1, string vci, string vc, string vf,
									string ve, string VendID, string vn, string vp, string vs, string vz)
		{
			SqlCommand comando = new SqlCommand(@"Insert into PoReqHdr values('" + va1 + "','" + va2 + "','','','','','" + va + "', '" + Addr1 + "','" 
				+ Addr2 + "','" + Attn + "','" + City + "','" + Country + "','" + email + "','" + Fax + "','" + NameR + "', '" + Phone 
				+ "','" + State + "','" + Zip + "', '','','HG',0,'" + vci + "', '',0,'" + vc + "','" + CpnyID + "', '','" + Fecha + "','04250','" 
				+ UserId + "','" + Fecha + "', 0,'" + CuryID + "', 'M',0,'" + TC + "','DOF','" + sumcuryextcost + "','','','','','','','','','','','CP','',''," 
				+ vf + "','',0,1,'" + Fecha + "','04250','" + UserId + "','" + vn + "', 0,'N','N','N','','" + periodo + "','" + vp + "', '" + Fecha +
				"', '','','" + OC + "',0,'OR',0,'" + WONbr + "','',0,'" + OC + "', '" + sumextcost + "','SR','" + UserId + "','','','','',0,0,0,0,'','',0,0,'','','" 
				+ Addr1 + "', '" + Addr2 + "', 'DEFAULT','" + Attn + "','" + City + "', '" + Country + "', '" + email + "','" + Fax + "','" 
				+ NameR + "', '" + Phone + "', '" + State + "', '','" + Zip + "', '" + vs + "', 'CR',0,0,0,0,'" + tax1 + "','" + tax2 + "','" 
				+ tax3 + "','" + tax4 + "',0,0,0,0,'" + Terms + "', 0,'',0,0,0,0,'','',0,0,'','','','','DEFAULT','" + VendID + "', '" + vz + "' ,NULL)", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}

		public bool RsSp_InsertVendid()
		{
			SqlCommand comando = new SqlCommand("RsSp_InsertVendid", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;

			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}

		public bool Update_PoSetUp(string OC)
		{
			SqlCommand comando = new SqlCommand(@"Update PoSetUp set LastPONbr = '" + OC + "'", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}   
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}

		public bool Update_WoHeader(string wonbr)
		{
			SqlCommand comando = new SqlCommand(@"Update WoHeader set user2 = 1 where wonbr = '" + wonbr + "'", conexion);
			SqlDataAdapter miDa = new SqlDataAdapter();
			DataSet miDs = new DataSet();
			DataTable miDt = new DataTable();
			try
			{
				conexion.Open();
				miDa.SelectCommand = comando;
				miDa.Fill(miDs);
				return true;
			}
			catch (SqlException ex)
			{
				Dialogs.Show(ex.Message, DialogsType.Error);
				return false;
			}
			finally
			{
				conexion.Close();
				miDa.Dispose();
				miDs.Dispose();
				miDt.Dispose();
			}
		}
	}
}
