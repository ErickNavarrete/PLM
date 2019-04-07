using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ArcangelDialogs;
 
namespace PLM.Vista
{
    public partial class DiasAnticipacion : MetroForm
    {
        Controlador.DiasAnticipacionController DiasA;

        public DiasAnticipacion() 
        {
            InitializeComponent();
            DiasA = new Controlador.DiasAnticipacionController();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           string DiasAnt,DiasM;
           if (txtDiasAnticipacion.Text != string.Empty && txtDiasMargen.Text != string.Empty)
           {
               int Id;
               Id = DiasA.Id();
               DiasAnt = txtDiasAnticipacion.Text;
               DiasM = txtDiasMargen.Text;
               if (Id > 0)
               {
                   DiasA.UpdateDiasA(DiasAnt, DiasM, Id);
                   Dialogs.Show("Los dias han sido guardados", DialogsType.Info);
               }
               else
               {
                   DiasA.AddDiasA(DiasAnt, DiasM);
                   Dialogs.Show("Los dias han sido guardados", DialogsType.Info);
               }

           }
           else 
           {
               Dialogs.Show("Existen campos vacios vuelva a intentar", DialogsType.Error);
           }
        }

        private void txtDiasAnticipacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) )
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDiasMargen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void DiasAnticipacion_Load(object sender, EventArgs e)
        {
            DiasA.MostarDiasA(txtDiasAnticipacion, txtDiasMargen);
        }       
    }
}
