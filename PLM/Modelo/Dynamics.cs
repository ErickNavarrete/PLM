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
			conexion = new SqlConnection(@"Data Source=" + ConfigIni.HostDynamic + ";Initial Catalog=" + ConfigIni.BdDynamic + ";User Id=" + ConfigIni.IdDynamic + ";Password=" + ConfigIni.PasswordDynamic + ";");
			//conexion = new SqlConnection(@"Data Source= DESKTOP-JBDH3N9; Initial Catalog=RIOSULPRUEBAS9 ;Integrated Security=True;");
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

		public List<RepResurtimiento> Reporte1(string fecha1, string fecha2, string cliente)
		{
			SqlCommand comando = new SqlCommand(@"SELECT        TOP (100) PERCENT A.InvtID, B.Descr AS DescrArt, A.QtyWOReqd AS CantOrd, A.WONbr, dbo.InventoryADG.ProdLineID AS MaterialType, dbo.ItemSite.QtyOnHand AS Existencia, B.DfltPOUnit AS UnidadCompra, 
						 dbo.SOHeader.OrdNbr AS OrdenVenta, dbo.SOHeader.CustOrdNbr AS Po, dbo.InventoryADG.User6 AS PorAdicional, dbo.ItemSite.QtyOnPO AS CantidadOrdenesVta, dbo.ItemXRef.AlternateID AS CodProv, 
						 dbo.ItemXRef.Descr AS DescProv, B.Supplr1 AS Proveedor, B.LeadTime AS TempoEntregaCompras, dbo.SOHeader.User9 AS FechaEmbarque, dbo.SOHeader.CustID
FROM            dbo.SOHeader INNER JOIN
						 dbo.WOMatlReq AS A INNER JOIN
						 dbo.Inventory AS B ON A.InvtID = B.InvtID INNER JOIN
						 dbo.INUnit AS C ON B.StkUnit = C.ToUnit AND B.DfltPOUnit = C.FromUnit INNER JOIN
						 dbo.WOHeader AS D ON A.WONbr = D.WONbr INNER JOIN
						 dbo.ProductClass AS F ON F.ClassID = B.ClassID INNER JOIN
						 dbo.RsVw_1265001A AS G ON G.Wonbr = D.WONbr INNER JOIN
						 dbo.RsTb_Plantas AS E ON E.Planta = D.User5 ON dbo.SOHeader.OrdNbr = D.User9 LEFT OUTER JOIN
						 dbo.ItemXRef ON B.InvtID = dbo.ItemXRef.InvtID LEFT OUTER JOIN
						 dbo.ItemSite INNER JOIN
						 dbo.InventoryADG ON dbo.ItemSite.InvtID = dbo.InventoryADG.InvtID RIGHT OUTER JOIN
						 dbo.INDfltSites ON dbo.ItemSite.DfltPickBin = dbo.INDfltSites.DfltPickBin AND dbo.ItemSite.InvtID = dbo.INDfltSites.InvtID AND dbo.ItemSite.SiteID = dbo.INDfltSites.DfltSiteID ON 
						 B.InvtID = dbo.INDfltSites.InvtID
						WHERE        (D.ProcStage IN ('P', 'F', 'R')) AND (A.SiteID <> 'prod. term') 
						AND SOHeader.User9 >= '" + fecha1 + "' AND SOHeader.User9 <= '" + fecha2 + "' " + cliente, conexion);
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

	}
}
