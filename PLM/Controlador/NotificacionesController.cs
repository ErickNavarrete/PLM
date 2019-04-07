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
    public class NotificacionesController
    {
        public NotificacionesController()
        {

        }

        public bool BuscarNotificacion()
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {                                    
                    var respuesta = db.Notificacion.Where(x => x.DepartamentoResp == GLOBALS.DEPARTAMENTO && x.EstadoTarea == 0).Select(x => x).ToList().FirstOrDefault();
                    if(respuesta != null)
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
    }
}
