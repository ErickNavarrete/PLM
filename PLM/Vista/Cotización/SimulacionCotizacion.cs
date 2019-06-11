using ArcangelDialogs;
using DevComponents.DotNetBar.Metro;
using PLM.Controlador;
using PLM.Modelo;
using PLM.Vista.Cotización;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM.Vista
{
    public partial class SimulacionCotizacion : MetroForm
    {
        int pantalla = 1;
        public string nacionalidad;
        CotizacionController cotizacion = new CotizacionController();

        #region FUNCIONES
        private void hide_show_cu(UserControl cu)
        {
            cotizacion1.Visible = false;
            cotizacion2.Visible = false;
            cotizacion3.Visible = false;
            cotizacion4.Visible = false;
            cotizacion5.Visible = false;
            cotizacion6.Visible = false;

            cu.Visible = true;
        }
        private void control_uc(int pantalla)
        {
            switch (pantalla)
            {
                case 1:
                    hide_show_cu(cotizacion1);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = false;
                    break;
                case 2:
                    hide_show_cu(cotizacion2);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 3:
                    hide_show_cu(cotizacion3);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 4:
                    hide_show_cu(cotizacion4);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 5:
                    hide_show_cu(cotizacion5);
                    btnSiguiente.Visible = true;
                    btnAnterior.Visible = true;
                    break;
                case 6:
                    hide_show_cu(cotizacion6);
                    btnSiguiente.Visible = false;
                    btnAnterior.Visible = true;
                    break;
            }
        }
        #endregion

        public SimulacionCotizacion()
        {
            InitializeComponent();
            hide_show_cu(cotizacion1);
            nacionalidad = string.Empty;
            pantalla = 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            pantalla += 1;
            control_uc(pantalla);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            pantalla -= 1;
            control_uc(pantalla);
        }

        private void tbCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                cotizacion1.cliente = false;

                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(41);
                frmBusqueda.ShowDialog();
                if(frmBusqueda.dato != "")
                {
                    //CLIENTE CONTROL USER
                    cotizacion1.cliente = true;
                    cotizacion2.cliente = true;
                    cotizacion3.cliente = true;
                    cotizacion4.cliente = true;

                    Segundas segundas = new Segundas(); 
                    tbCliente.Text = frmBusqueda.dato;
                    tbTienda.Text = frmBusqueda.dato1;
                    nacionalidad = frmBusqueda.dato2;
                    segundas = cotizacion.GetSegundas(tbCliente.Text);
                    //NACIONALIDAD CONTROL USER
                    cotizacion1.nacionalidad = nacionalidad.Trim();                    
                    cotizacion2.nacionalidad = nacionalidad.Trim();
                    cotizacion3.nacionalidad = nacionalidad.Trim();
                    cotizacion4.nacionalidad = nacionalidad.Trim();
                    if (segundas != null)
                    {
                        tbTela.Text = segundas.Tela;
                        tbConf.Text = segundas.Conf;
                        tbLav.Text = segundas.Lavado;
                        tbPres.Text = segundas.proc;
                        tbAvios.Text = segundas.avios;
                        tbFalt.Text = segundas.faltantes;
                        tbTotal.Text = segundas.total;

                        //PORCENTAJE
                        cotizacion1.porcentaje_tela = Convert.ToDecimal(segundas.Tela.Replace("%", "")) / 100;
                        cotizacion2.porcentaje_tela = Convert.ToDecimal(segundas.Tela.Replace("%", "")) / 100;
                        cotizacion3.porcentaje_tela = Convert.ToDecimal(segundas.Tela.Replace("%", "")) / 100;
                        cotizacion4.porcentaje_tela = Convert.ToDecimal(segundas.Tela.Replace("%", "")) / 100;
                    }
                    else
                    {
                        Dialogs.Show("Cliente no existente en el catálogo", DialogsType.Warning);
                        tbTela.Text = "0";
                        tbConf.Text = "0";
                        tbLav.Text = "0";
                        tbPres.Text = "0";
                        tbAvios.Text = "0";
                        tbFalt.Text = "0";
                        tbTotal.Text = "0";

                        cotizacion1.porcentaje_tela = 0;
                    }
                }
                else
                {
                    tbCliente.Text = "";
                    tbTienda.Text = "";
                    tbTela.Text = "";
                    tbConf.Text = "";
                    tbLav.Text = "";
                    tbPres.Text = "";
                    tbAvios.Text = "";
                    tbFalt.Text = "";
                    tbTotal.Text = "";

                    //CLIENTE CONTROL USER
                    cotizacion1.cliente = false;
                    cotizacion2.cliente = false;
                    cotizacion3.cliente = false;
                    cotizacion4.cliente = false;
                }
            }
        }

        private void tbEstilo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                Busqueda.Busqueda frmBusqueda = new Busqueda.Busqueda(42);
                frmBusqueda.ShowDialog();
                if(frmBusqueda.articulosPT != null)
                {
                    tbEstilo.Text = frmBusqueda.articulosPT.Estilo;
                    tbLinea.Text = frmBusqueda.articulosPT.Linea;
                    tbDescripcion.Text = frmBusqueda.articulosPT.Descr;
                    tbCategoria.Text = frmBusqueda.articulosPT.Categoria;
                    tbMarca.Text = frmBusqueda.articulosPT.Marca;
                }
            }
        }

        private void tbTipoCambio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cotizacion1.tipo_cambio = Convert.ToDecimal(tbTipoCambio.Text);
                cotizacion2.tipo_cambio = Convert.ToDecimal(tbTipoCambio.Text);
                cotizacion3.tipo_cambio = Convert.ToDecimal(tbTipoCambio.Text);
                cotizacion4.tipo_cambio = Convert.ToDecimal(tbTipoCambio.Text);

                cotizacion1.t_cambio = true;
                cotizacion2.t_cambio = true;
                cotizacion3.t_cambio = true;
                cotizacion4.t_cambio = true;
            }
            catch (Exception)
            {
                cotizacion1.t_cambio = false;
                cotizacion2.t_cambio = false;
                cotizacion3.t_cambio = false;
                cotizacion4.t_cambio = false;
            }            
        }
    }
}
