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

namespace PLM.Controlador
{
    public class DiasAnticipacionController
    {
        public bool AddDiasA(string DiasAnt, string DiasM)
        {
            using (PLMContext db = new PLMContext())
            {
                var DiasA = new DiasAnticipacion();
                DiasA.DiasA= int.Parse(DiasAnt);
                DiasA.DiasdeMargen = int.Parse(DiasM);
                try
                {
                    db.DiasAnticipacion.Add(DiasA);
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

        public int Id()
        {
            using (PLMContext db = new PLMContext())
            {
                int id = 0;
                var DiasA = db.DiasAnticipacion.Select(x => x).ToList();
                if (DiasA != null)
                {
                    return DiasA.Count;
                }
                else
                {
                    return id;                    
                }                
            }
        }

        public bool MostarDiasA(MetroTextBox DiasAnt, MetroTextBox DiasM)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var datos = db.DiasAnticipacion.Select(x => x).ToList().FirstOrDefault();
                    if (datos != null)
                    {
                        DiasAnt.Text = datos.DiasA.ToString();
                        DiasM.Text = datos.DiasdeMargen.ToString();
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
 
        public bool UpdateDiasA(string DiasAnt, string DiasM, int id)
        {
            using (PLMContext db = new PLMContext())
            {
                try
                {
                    var DiasA = db.DiasAnticipacion.Where(x => x.id == id).Select(x => x).FirstOrDefault();
                    DiasA.DiasA = int.Parse(DiasAnt);
                    DiasA.DiasdeMargen = int.Parse(DiasM);
                    db.Entry(DiasA).State= EntityState.Modified;
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
