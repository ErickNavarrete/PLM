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

namespace PLM.Controlador
{
   public class BitacoradeEventosController
   {
       public void BitacoradeEventos(DataGridView controlView)
       {
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var datos = db.BitacoraDeEventos.Select(x => new {x.id, x.Usuario, x.Departamento, x.Fecha, x.Evento}).ToList();                                                
                   controlView.DataSource = datos;
                   controlView.Columns[0].HeaderText = "ID";
                   controlView.Columns[1].HeaderText = "USUARIO";
                   controlView.Columns[2].HeaderText = "DEPARTAMENTO";
                   controlView.Columns[3].HeaderText = "FECHA";
                   controlView.Columns[4].HeaderText = "DESCRIPCION EVENTO";
               }
               catch (Exception ex)
               {
                   Dialogs.Show(ex.Message, DialogsType.Error);
               }
           } 
       }

       public void BuscarBitacoradeEventossF(string IdBitacoradeEventoss, DateTime fecha, DataGridView controlView)
       {
           DateTime _fechaInicio = new DateTime(fecha.Year,fecha.Month,fecha.Day,0,0,0);
           DateTime _fechaTope = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var BitacoradeEventoss = (from x in db.BitacoraDeEventos where (x.Usuario == IdBitacoradeEventoss && x.Fecha >= _fechaInicio && x.Fecha <= _fechaTope) select x).ToList();
                   if (BitacoradeEventoss != null)
                   {
                       if (BitacoradeEventoss.Count > 0)
                       {
                           controlView.DataSource = BitacoradeEventoss;
                           controlView.Columns[0].HeaderText = "ID";
                           controlView.Columns[1].HeaderText = "USUARIO";
                           controlView.Columns[2].HeaderText = "DEPARTAMENTO";
                           controlView.Columns[3].HeaderText = "FECHA";
                           controlView.Columns[4].HeaderText = "DESCRIPCION EVENTO";
                       }
                       else
                       {
                           controlView.DataSource = null;
                       }
                   }
               }
               catch (Exception ex)
               {
                   Dialogs.Show(ex.Message, DialogsType.Error);
               }
           }
       }

       public void BuscarBitacoradeEventoss(string IdBitacoradeEventoss, DataGridView controlView)
       {
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var BitacoradeEventoss = (from x in db.BitacoraDeEventos where (x.Usuario == IdBitacoradeEventoss) select x).ToList();
                   if (BitacoradeEventoss != null)
                   {
                       if (BitacoradeEventoss.Count > 0)
                       {
                            controlView.DataSource = BitacoradeEventoss;
                            controlView.Columns[0].HeaderText = "ID";
                            controlView.Columns[1].HeaderText = "USUARIO";
                            controlView.Columns[2].HeaderText = "DEPARTAMENTO";
                            controlView.Columns[3].HeaderText = "FECHA";
                            controlView.Columns[4].HeaderText = "DESCRIPCION EVENTO";
                            controlView.Columns[4].Width = 320;
                       }
                       else
                       {
                            controlView.DataSource = null;
                       }
                   }
               }
               catch (Exception ex)
               {
                   Dialogs.Show(ex.Message, DialogsType.Error);
               }
           }
       }

       public void BuscarBitacoradeEventossfiltro(DataGridView controlView)
       {
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var BitacoradeEventoss = (from x in db.BitacoraDeEventos select x).ToList();
                   if (BitacoradeEventoss != null)
                   {
                       if (BitacoradeEventoss.Count > 0)
                       {
                           List<BitacoradeEventossTemp> tempBitacoradeEventos = new List<BitacoradeEventossTemp>();
                           foreach (var BitacoradeEventos in BitacoradeEventoss)
                           {
                               if (tempBitacoradeEventos.Where(x => x.id == BitacoradeEventos.Usuario).FirstOrDefault() == null)
                               {
                                   tempBitacoradeEventos.Add(new BitacoradeEventossTemp { id = BitacoradeEventos.Usuario });
                               }
                               else
                               {
                                   continue;
                               }
                           }
                           controlView.DataSource = tempBitacoradeEventos;
                           controlView.Columns[0].HeaderText = " Usuario";
                       }
                       else
                       {
                           controlView.DataSource = null;
                       }
                   }
               }
               catch (Exception ex)
               {
                   Dialogs.Show(ex.Message, DialogsType.Error);
               }
           }
       }

       private class BitacoradeEventossTemp
       {
           public string id { get; set; }
       }

       public bool AddBitacoradeEventos(string Usuario , string Departamento, DateTime Fecha , string Evento)
       {
           using (PLMContext db = new PLMContext())
           {
               var BitacoradeEventos = new BitacoraDeEventos();
               BitacoradeEventos.Usuario = GLOBALS.USUARIO;
               BitacoradeEventos.Departamento = GLOBALS.DEPARTAMENTO;
               BitacoradeEventos.Fecha = DateTime.Now;
               BitacoradeEventos.Evento = Evento; 
               
               try
               {
                   db.BitacoraDeEventos.Add(BitacoradeEventos);
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
    }
}
