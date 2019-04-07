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

namespace PLM.Vista.BOM
{
    public partial class BomTarea : MetroForm
    { 
        private Controlador.EstilosdeProduccionController Estilos;
        private Controlador.BOMController Bom;
        string snotas;
        private int flag;
        string i, ii, iii, iv, v;

        public BomTarea(string _i, string _ii, string _iii,string _iv, string _v)
        {
            InitializeComponent();
            Estilos = new Controlador.EstilosdeProduccionController();
            Bom = new Controlador.BOMController();
            flag = 0; 
            i = _i ;
            ii = _ii ;
            iii = _iii;
            iv = _iv;
            v = _v;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            flag = 0;
            this.Dispose();   
        }

        private void BomTarea_Load(object sender, EventArgs e)
        {
            txtNroBom.Text = i + ii;
            txtEstilo.Text = iv;
            Bom.VerificarEstadoCierre(txtNroBom.Text, txtEstilo.Text, lblStatus, lblEtapa);                                 
            Bom.CargarDatosPOH(txtNroBom.Text, txtEstilo.Text, txtHilos, txtPO,snotas,txtHilos);
            Bom.CargarDatosTarea(DtBOM, ii, i, iii);                                   
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtEstilo.Text == string.Empty)
            {
                Dialogs.Show("Debe realizar la busqueda de un estilo ya existente (F2)", DialogsType.Info);
            }
            else
            {
                string estiloI = txtEstilo.Text;
                DetailBomVista frm = new DetailBomVista(estiloI);
                frm.ShowDialog();
            }
        }

        private void btnDetalleUsu_Click(object sender, EventArgs e)
        {
            {
                if (txtNroBom.Text != string.Empty)
                {
                    BomNotas frm = new BomNotas(snotas);
                    frm.ShowDialog();
                }
                else
                {
                    Dialogs.Show("Debe crear el Bom para observar el detalle de usuario", DialogsType.Error);
                }
            }
        }

        private void DtBOM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            int Ncolumna = 0;
            Ncolumna = e.ColumnIndex;
            if (Ncolumna == 8)
            {
                if (DtBOM.Rows.Count > 0)
                {
                    string dato2;
                    dato2 = DtBOM.CurrentRow.Cells[8].Value.ToString();
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum, dato2);
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                    if (frm.dato != "" || frm.dato != null)
                    {
                        flag = 1;
                    }                
                }
                else
                {
                    int sum;
                    sum = Ncolumna + 20;
                    Busqueda.Input frm = new Busqueda.Input(sum, "0");
                    frm.ShowDialog();
                    DtBOM.CurrentCell.Value = frm.dato;
                    if (frm.dato != "" || frm.dato != null)
                    {
                        flag = 1;
                    }
                }
            }
            if (Ncolumna == 11)
            {
                if (DtBOM.Rows.Count > 0)
                {
                    string dato2;
                    if (DtBOM.CurrentRow.Cells[11].Value != null)
                    {
                        dato2 = DtBOM.CurrentRow.Cells[11].Value.ToString();
                        int sum;
                        sum = Ncolumna + 20;
                        Busqueda.Input frm = new Busqueda.Input(sum, dato2);
                        frm.ShowDialog();
                        DtBOM.CurrentCell.Value = frm.dato;
                    }
                    else
                    {
                        int sum;
                        sum = Ncolumna + 20;
                        Busqueda.Input frm = new Busqueda.Input(sum, "");
                        frm.ShowDialog();
                        DtBOM.CurrentCell.Value = frm.dato;
                    }
                }                
            }
        }

        private void DtBOM_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {           
            Bom.UpdateDetailBom(DtBOM, txtNroBom, flag);
            Bom.EstadoNotificacion(v);
            flag = 0;
            this.Dispose();
        }               
    }
}
