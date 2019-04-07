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
    public partial class PresupuestosVista : MetroForm
    {
        public Controlador.BitacoradeEventosController Bitacora; 
        private Controlador.PresupuestosController Presupuestos;
        private int flag = 0;

        public PresupuestosVista()
        {
            InitializeComponent();
            Presupuestos = new Controlador.PresupuestosController();
            Bitacora = new Controlador.BitacoradeEventosController(); 
        }
        
        public void clearTxt()
        {
            txtVentas.Text = string.Empty;
            txtPrest.Text = string.Empty;
            txtDiario.Text = string.Empty;
            txtProd.Text = string.Empty;
            txtVarios.Text = string.Empty;
            txtIdPresupuestos.Text = string.Empty;
            txtMO.Text = string.Empty;
            txtAdmon.Text = string.Empty;           
        }

      

        private void btnEliminar_Click(object sender, EventArgs e)
        { 
               DialogsResults respuesta = Dialogs.Show("Esta seguro que desea eliminar el item? ", DialogsType.Question);
            if (respuesta == DialogsResults.Yes)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                    bool resultado = Presupuestos.DeletePresupuestos(id);
                    if (resultado == true)
                    {
                        Dialogs.Show(Properties.Resources.Eliminar + " el Presupuestos", DialogsType.Info);
                        txtDiario.Text = string.Empty;
                        txtMO.Text = string.Empty;
                        txtPrest.Text = string.Empty;
                        txtProd.Text = string.Empty;
                        txtVentas.Text = string.Empty;
                        txtVarios.Text = string.Empty;
                        txtAdmon.Text = string.Empty;
                        Presupuestos.Presupuestos(dtDatos);
                        string idcatalogo2;
                        idcatalogo2 = "Eliminación de un Presupuesto";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo2);
                    }
                }
            }            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    string idPresupuestos, Diario, Mo, Prestaciones, Admon, Prod, Venta, Varios;
                    if (txtIdPresupuestos.Text != string.Empty && txtDiario.Text != string.Empty && txtMO.Text != string.Empty && txtPrest.Text != string.Empty && txtAdmon.Text != string.Empty && txtProd.Text != string.Empty && txtVentas.Text != string.Empty && txtVarios.Text != string.Empty && txtIdPresupuestos.Text != string.Empty)
                    {
                        idPresupuestos = txtIdPresupuestos.Text;
                        Diario = txtDiario.Text;
                        Mo = txtMO.Text;
                        Prestaciones = txtPrest.Text;
                        Admon = txtAdmon.Text;
                        Prod = txtProd.Text;
                        Venta = txtVentas.Text;
                        Varios = txtVarios.Text;
                        Mo = Mo.Replace("MX$", string.Empty);
                        Prestaciones = Prestaciones.Replace("MX$", string.Empty);
                        Admon = Admon.Replace("MX$", string.Empty);
                        Prod = Prod.Replace("MX$", string.Empty);
                        Venta = Venta.Replace("MX$", string.Empty);
                        Varios = Varios.Replace("MX$", string.Empty);
                        bool resultado = Presupuestos.AddPresupuestos(Diario, Mo, Prestaciones, Admon, Prod, Venta, Varios, idPresupuestos);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Agregar + " el Presupuestos", DialogsType.Info);
                            txtDiario.Text = string.Empty;
                            txtMO.Text = string.Empty;
                            txtPrest.Text = string.Empty;
                            txtProd.Text = string.Empty;
                            txtVentas.Text = string.Empty;
                            txtVarios.Text = string.Empty;
                            txtAdmon.Text = string.Empty;
                            dtDatos.Enabled = true;
                            Presupuestos.Presupuestos(dtDatos);
                            string idcatalogo;
                            idcatalogo = "Alta de un Item de Presupuesto";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                            flag = 0; 
                        }
                        else
                        {
                            Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                        }
                    }

                }
            }
            else if (flag == 0)
            {
                DialogsResults respuesta = Dialogs.Show("Esta seguro que desea guardar el item? ", DialogsType.Question);
                if (respuesta == DialogsResults.Yes)
                {
                    int id;
                    string idPresupuestos, Diario, Mo, Prestaciones, Admon, Prod, Venta, Varios;
                    if (txtIdPresupuestos.Text != string.Empty && txtDiario.Text != string.Empty && txtMO.Text != string.Empty && txtPrest.Text != string.Empty && txtAdmon.Text != string.Empty && txtProd.Text != string.Empty && txtVentas.Text != string.Empty && txtVarios.Text != string.Empty && txtIdPresupuestos.Text != string.Empty)
                    {
                        id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                        idPresupuestos = txtIdPresupuestos.Text;
                        Diario = txtDiario.Text;
                        Mo = txtMO.Text;
                        Prestaciones = txtPrest.Text;
                        Admon = txtAdmon.Text;
                        Prod = txtProd.Text;
                        Venta = txtVentas.Text;
                        Varios = txtVarios.Text;
                        Mo = Mo.Replace("MX$", string.Empty);
                        Prestaciones = Prestaciones.Replace("MX$", string.Empty);
                        Admon = Admon.Replace("MX$", string.Empty);
                        Venta = Venta.Replace("MX$", string.Empty);
                        Prod = Prod.Replace("MX$", string.Empty);
                        Varios = Varios.Replace("MX$", string.Empty);
                        Mo = Mo.Replace("$", string.Empty);
                        Prestaciones = Prestaciones.Replace("$", string.Empty);
                        Admon = Admon.Replace("$", string.Empty);
                        Venta = Venta.Replace("$", string.Empty);
                        Prod = Prod.Replace("$", string.Empty);
                        Varios = Varios.Replace("$", string.Empty);
                        bool resultado = Presupuestos.UpdatePresupuestos(Diario, Mo, Prestaciones, Admon, Prod, Venta, Varios, idPresupuestos, id);
                        if (resultado == true)
                        {
                            Dialogs.Show(Properties.Resources.Editar + " el Presupuestos", DialogsType.Info);
                            txtDiario.Text = string.Empty;
                            txtMO.Text = string.Empty;
                            txtPrest.Text = string.Empty;
                            txtProd.Text = string.Empty;
                            txtVentas.Text = string.Empty;
                            txtVarios.Text = string.Empty;
                            dtDatos.Enabled = true;
                            Presupuestos.Presupuestos(dtDatos);
                            string idcatalogo1;
                            idcatalogo1 = "Actualización de un Presupuesto";
                            Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo1);
                            dtDatos.Enabled = true;
                            btnAlta.Enabled = true;
                            btnEliminar.Enabled = true;
                        }
                    }
                    else
                    {
                        Dialogs.Show("Ëxiste campo sin datos o datos erroneos, intente de nuevo", DialogsType.Error);
                    }
                }
            }
        }

        private void dtDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtDatos.Rows.Count > 0)
            {
                int id = int.Parse(dtDatos.CurrentRow.Cells[0].Value.ToString());
                Presupuestos.PresupuestosSelect(txtIdPresupuestos, txtDiario, txtMO, txtPrest, txtAdmon, txtProd, txtVentas, txtVarios, id); 
            }
        }
     
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != string.Empty)
            {
                string descrip = txtBusqueda.Text;

                if (Presupuestos.Existe(descrip))
                {
                    Presupuestos.BuscarPresupuestos(descrip, dtDatos);
                    txtIdPresupuestos.Text = txtBusqueda.Text;
                    string idcatalogo3;
                    idcatalogo3 = "Consulta de un Presupuesto";
                    Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                }
                else 
                {
                    Presupuestos.Presupuestos(dtDatos);
                   
                }
            }
            
        }

        private void txtIdPresupuestos_Leave(object sender, EventArgs e)
        {
            string Exist;
            Exist = txtIdPresupuestos.Text;
            Presupuestos.Existe(Exist);
            if (Presupuestos.Existe(Exist) && txtIdPresupuestos.Text != string.Empty)
            {
                Dialogs.Show("El Presupuesto que intenta crear ya existe Intente de nuevo", DialogsType.Error);
                txtIdPresupuestos.Text = string.Empty;
                txtIdPresupuestos.Focus();
            }
        }

        private void txtDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtMO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPrest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtAdmon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }
        }

       

        private void PresupuestosVista_Load(object sender, EventArgs e)
        {
            panelMenu.Left = Screen.PrimaryScreen.Bounds.Width - (panelMenu.Width + (Screen.PrimaryScreen.Bounds.Width / 2) - 570);
            //GLOBALS.Permisos(btnAlta, btnActualizar, btnEliminar,btnGuardar);
            Presupuestos.Presupuestos(dtDatos);
            dtDatos.Enabled = true;
            btnAlta.Enabled = true;
            btnEliminar.Enabled = true;
        }

      

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            dtDatos.Enabled = false;
            btnAlta.Enabled = false;
            btnEliminar.Enabled = false;
            clearTxt();
            flag = 1;
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBusqueda.Text != string.Empty)
                {
                    string descrip = txtBusqueda.Text;

                    if (Presupuestos.Existe(descrip))
                    {
                        Presupuestos.BuscarPresupuestos(descrip, dtDatos);
                        txtIdPresupuestos.Text = txtBusqueda.Text;
                        string idcatalogo3;
                        idcatalogo3 = "Consulta de un Presupuesto";
                        Bitacora.AddBitacoradeEventos(GLOBALS.USUARIO, GLOBALS.DEPARTAMENTO, DateTime.Now, idcatalogo3);
                    }
                    else
                    {
                        Presupuestos.Presupuestos(dtDatos);

                    }
                }
            
            }
        }
    }
}
