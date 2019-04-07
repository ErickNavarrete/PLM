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
  public  class TareaController
    {

      public void MostrarTareas(DataGridView controlView)
      {
          using (PLMContext db = new PLMContext())
          {
              try
              {
                  var datos = db.Tareas.Select(x => new { x.Ref, x.Nacionalidad, x.IdBOM, x.Segmento, x.TiempoRespuesta,x.Trim,x.UsuarioEnvio, x.FechaTarea, x.DepartamentoRespuesta, x.FechaRespuesta,x.Dif }).ToList();
                  controlView.DataSource = datos;
                  controlView.Columns[0].HeaderText = "REF";
                  controlView.Columns[1].HeaderText = "NACIONALIDAD";
                  controlView.Columns[2].HeaderText = "#BOM";
                  controlView.Columns[3].HeaderText = "SEGMENTO";
                  controlView.Columns[4].HeaderText = "T/RESP";
                  controlView.Columns[5].HeaderText = "TRIM";
                  controlView.Columns[6].HeaderText = "USUARIO ENVIO";
                  controlView.Columns[7].HeaderText = "FECHA ENVIO";
                  controlView.Columns[8].HeaderText = "DEPARTAMENTO RESPUESTA";
                  controlView.Columns[9].HeaderText = "FECHA RESPUESTA";
                  controlView.Columns[10].HeaderText = "DIF";
              }
              catch (Exception ex)
              {
                  Dialogs.Show(ex.Message, DialogsType.Error);
              }
          } 
      }
            public void BuscarTareaF(string  usuario, DateTime fecha, DataGridView controlView)
       {
           DateTime _fechaInicio = new DateTime(fecha.Year,fecha.Month,fecha.Day,0,0,0);
           DateTime _fechaTope = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var tarea = (from x in db.Tareas where (x.UsuarioEnvio == usuario && x.FechaTarea >= _fechaInicio && x.FechaTarea <= _fechaTope) select new { x.Ref, x.Nacionalidad, x.IdBOM, x.Segmento, x.TiempoRespuesta, x.Trim, x.UsuarioEnvio, x.FechaTarea, x.DepartamentoRespuesta, x.FechaRespuesta, x.Dif }).ToList();
                   if (tarea != null)
                   {
                       if (tarea.Count > 0)
                       {
                           controlView.DataSource = tarea;
                           controlView.Columns[0].HeaderText = "REF";
                           controlView.Columns[1].HeaderText = "NACIONALIDAD";
                           controlView.Columns[2].HeaderText = "#BOM";
                           controlView.Columns[3].HeaderText = "SEGMENTO";
                           controlView.Columns[4].HeaderText = "T/RESP";
                           controlView.Columns[5].HeaderText = "TRIM";
                           controlView.Columns[6].HeaderText = "USUARIO ENVIO";
                           controlView.Columns[7].HeaderText = "FECHA ENVIO";
                           controlView.Columns[8].HeaderText = "DEPARTAMENTO RESPUESTA";
                           controlView.Columns[9].HeaderText = "FECHA RESPUESTA";
                           controlView.Columns[10].HeaderText = "DIF";
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
       public void BuscarTareaU(string usuario, DataGridView controlView)
       {
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var tarea = (from x in db.Tareas where (x.UsuarioEnvio == usuario) select new { x.Ref, x.Nacionalidad, x.IdBOM, x.Segmento, x.TiempoRespuesta, x.Trim, x.UsuarioEnvio, x.FechaTarea, x.DepartamentoRespuesta, x.FechaRespuesta, x.Dif }).ToList();
                   if (tarea != null)
                   {
                       if (tarea.Count > 0)
                       {
                           controlView.DataSource = tarea;
                           controlView.Columns[0].HeaderText = "REF";
                           controlView.Columns[1].HeaderText = "NACIONALIDAD";
                           controlView.Columns[2].HeaderText = "#BOM";
                           controlView.Columns[3].HeaderText = "SEGMENTO";
                           controlView.Columns[4].HeaderText = "T/RESP";
                           controlView.Columns[5].HeaderText = "TRIM";
                           controlView.Columns[6].HeaderText = "USUARIO ENVIO";
                           controlView.Columns[7].HeaderText = "FECHA ENVIO";
                           controlView.Columns[8].HeaderText = "DEPARTAMENTO RESPUESTA";
                           controlView.Columns[9].HeaderText = "FECHA RESPUESTA";
                           controlView.Columns[10].HeaderText = "DIF";
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
       public void BuscarTareafiltro(DataGridView controlView)
       {
           using (PLMContext db = new PLMContext())
           {
               try
               {
                   var Tarea = (from x in db.Tareas select x).ToList();
                   if (Tarea != null)
                   {
                       if (Tarea.Count > 0)
                       {
                           List<Tareas> Tareas = new List<Tareas>();
                           foreach (var tarea in Tarea)
                           {
                               if (Tareas.Where(x => x.Usuario == tarea.UsuarioEnvio).FirstOrDefault() == null)
                               {
                                   Tareas.Add(new Tareas { Usuario = tarea.UsuarioEnvio });
                               }
                               else
                               {
                                   continue;
                               }
                           }
                           controlView.DataSource = Tareas;
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

       private class Tareas
       {
           public string Usuario { get; set; }
       }
      }
    }

