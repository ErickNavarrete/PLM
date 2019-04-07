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
    public partial class Hilo : MetroForm
    {
        public bool flag;
        private int imagen;
        private string nb, es, na;
        private Controlador.BOMController Bom;
        private string codigoHilos;               

        public Hilo(string _nb, string _es, string _na, int _imagen)
        {
            InitializeComponent();
            imagen = _imagen;
            nb = _nb;
            es = _es;
            na = _na;            
            Bom = new Controlador.BOMController();
            codigoHilos = na + nb + es;
        }

        private void dtDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Ncolumna = 0;
            Ncolumna = e.ColumnIndex;                         
            if (Ncolumna == 0 && imagen < 1)
            {
                int sum;
                sum = Ncolumna + 31;               
                Busqueda frmBusqueda = new Busqueda(sum);
                frmBusqueda.ShowDialog();
                if (!string.IsNullOrEmpty(frmBusqueda.dato))
                {
                    string tempDescrip = Bom.BuscarThread(frmBusqueda.dato);
                    dtDatos.CurrentRow.Cells[0].Value = tempDescrip;
                    dtDatos.CurrentRow.Cells[2].Value = tempDescrip; 

                }              
            }           
            if (Ncolumna == 1 && imagen < 1 )
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
            if (Ncolumna == 3 && imagen < 1)
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
            if (Ncolumna == 5 && imagen < 1)
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

        private void Hilo_Load(object sender, EventArgs e)
        {
            if (Bom.ExisteHilos(codigoHilos)&& imagen < 1 )
            {
                Bom.MostrarHilosDetails(dtDatos, codigoHilos);
                btnAgregaFila.Enabled = true;
                btnGuardar.Enabled = true;
                
            }
            else if (Bom.ExisteHilos(codigoHilos) && imagen >= 1)
            {
                Bom.MostrarHilosDetails(dtDatos, codigoHilos);
                btnAgregaFila.Enabled = false;
                btnGuardar.Enabled = false;
                
            } 

           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string codigo;
            bool respuesta;
            codigo = na + nb + es;
            if (Bom.ExisteHilos(codigo) == false && dtDatos.CurrentRow.Cells[0].Value != null && dtDatos.CurrentRow.Cells[1].Value != null && dtDatos.CurrentRow.Cells[2].Value != null && dtDatos.CurrentRow.Cells[3].Value != null && dtDatos.CurrentRow.Cells[3].Value != null && dtDatos.CurrentRow.Cells[4].Value != null && dtDatos.CurrentRow.Cells[5].Value != null && imagen == 0)
            {
                if (dtDatos.Rows.Count > 0) 
                {
                    respuesta = Bom.GuardarHilos(nb, es, na, imagen);
                    if(respuesta)
                    {
                        respuesta = Bom.GuardarHilosDetails(dtDatos, nb, es, na, imagen);                       
                        if(respuesta)
                        {
                            Dialogs.Show("Los hilos han sido guardados exitosamente", DialogsType.Info);
                            flag = true;
                        }
                        else
                        {
                            Dialogs.Show("Ocurrio un error registrando hilos", DialogsType.Error);
                            flag = false;
                        }
                    }
                    else
                    {
                        Dialogs.Show("Ocurrio un error registrando hilos", DialogsType.Error);
                        flag = false;
                    }
                    this.Close();
                }               
            }
            else if(Bom.ExisteHilos(codigo) == true && dtDatos.CurrentRow.Cells[0].Value != null && dtDatos.CurrentRow.Cells[1].Value != null && dtDatos.CurrentRow.Cells[2].Value != null && dtDatos.CurrentRow.Cells[3].Value != null && dtDatos.CurrentRow.Cells[3].Value != null && dtDatos.CurrentRow.Cells[4].Value != null && dtDatos.CurrentRow.Cells[5].Value != null ) 
            {
               respuesta = Bom.UpdateHilosDetail(dtDatos, codigo);
               if (respuesta)
               {
                  // Dialogs.Show("Los hilos han sido guardados exitosamente", DialogsType.Info);
                   flag = true;
               }
               else 
               {
                 //  Dialogs.Show("Ocurrio un error registrando hilos", DialogsType.Error);
                   flag = false;
               }
               this.Close();                
            }
        }

        private void btnAgregaFila_Click(object sender, EventArgs e)
        {
            dtDatos.Rows.Add(); 
        }                          
    }
}
      


    

