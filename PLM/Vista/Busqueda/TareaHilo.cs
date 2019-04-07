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
using MetroFramework;
using ArcangelDialogs;

namespace PLM.Vista.Busqueda
{
    public partial class TareaHilo : MetroForm
    {
        Controlador.BOMController Bom; 
        string hilo;
        public TareaHilo(string _hilo) 
        {
            InitializeComponent(); 
            hilo = _hilo;
            Bom = new Controlador.BOMController();
        }

        private void TareaHilo_Load(object sender, EventArgs e)
        {
            Bom.MostrarHilosDetails(dtDatos,hilo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Bom.UpdateHilosDetail(dtDatos, hilo);
            Bom.ActualizarEstadoHilos(hilo, 2);
            Bom.EstadoNotificacion(hilo);
            this.Dispose();

        }

        private void dtDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Ncolumna;
            Ncolumna = e.ColumnIndex;
            if (Ncolumna == 1 )
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int sum;
                    sum = Ncolumna + 40;
                    Input frm = new Input(sum, "");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                    if (!string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[1].Value.ToString()) && dtDatos.CurrentRow.Cells[3].Value != null)
                    {
                        dtDatos.CurrentRow.Cells[4].Value = float.Parse((dtDatos.CurrentRow.Cells[1].Value.ToString())) + float.Parse((dtDatos.CurrentRow.Cells[3].Value.ToString()));
                    }
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 40;
                    Input frm = new Input(sum, "0");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                    if (!string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[1].Value.ToString()) && !string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[3].Value.ToString()))
                    {
                        dtDatos.CurrentRow.Cells[4].Value = float.Parse(dtDatos.CurrentRow.Cells[1].Value.ToString()) + float.Parse(dtDatos.CurrentRow.Cells[1].Value.ToString());
                    }
                }
            }
            if (Ncolumna == 3 )
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int sum;
                    sum = Ncolumna + 40;
                    Input frm = new Input(sum, "");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                    if (!string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[3].Value.ToString()) && dtDatos.CurrentRow.Cells[1].Value != null)
                    {
                        dtDatos.CurrentRow.Cells[4].Value = float.Parse((dtDatos.CurrentRow.Cells[1].Value.ToString())) + float.Parse((dtDatos.CurrentRow.Cells[3].Value.ToString()));
                    }
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 40;
                    Input frm = new Input(sum, "0");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                    if (!string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[1].Value.ToString()) && !string.IsNullOrEmpty(dtDatos.CurrentRow.Cells[3].Value.ToString()))
                    {
                        dtDatos.CurrentRow.Cells[4].Value = float.Parse(dtDatos.CurrentRow.Cells[1].Value.ToString()) + float.Parse(dtDatos.CurrentRow.Cells[1].Value.ToString());
                    }
                }
            }
            if (Ncolumna == 5 )
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int sum;
                    sum = Ncolumna + 20;
                    Input frm = new Input(sum, "");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 20;
                    Input frm = new Input(sum, "");
                    frm.ShowDialog();
                    dtDatos.CurrentCell.Value = frm.dato;
                }
            }
        }
    }
}
