using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using PLM.Modelo;

namespace PLM.Vista.Busqueda
{
    public partial class Busqueda : MetroForm
    {
        public Controlador.BOMController Bom;
        public Controlador.DiasFeriadoseInhabiles DiasF;
        public Controlador.BitacoradeEventosController Bitacora;
        public Controlador.BodyController Body;
        public Controlador.CategoryDosController Category2;
        public Controlador.FitController Fit;
        public Controlador.InseamController Inseam;
        public Controlador.EmpaqueController Empaque;
        public Controlador.TemporadasController Temporada;
        Controlador.EstilosdeProduccionController controlador;
        public Controlador.CotizacionController cotizacion;
        public string dato;
        public string dato1;
        public Articulos articulo;
        public ArticulosPT articulosPT;
        int consulta;        

        public Busqueda(int _consulta)
        {
            InitializeComponent();
            Bitacora = new Controlador.BitacoradeEventosController();
            Body = new Controlador.BodyController();
            Category2 = new Controlador.CategoryDosController();
            Fit = new Controlador.FitController();
            Inseam = new Controlador.InseamController();
            Empaque = new Controlador.EmpaqueController();
            Temporada = new Controlador.TemporadasController();
            controlador = new Controlador.EstilosdeProduccionController();
            cotizacion = new Controlador.CotizacionController();
            dato = string.Empty;
            articulo = new Articulos();
            articulosPT = new ArticulosPT();
            DiasF = new Controlador.DiasFeriadoseInhabiles();
            Bom = new Controlador.BOMController();
            consulta = _consulta;
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            Temporada.Temporadase(dtDatos, consulta);
            Body.Bodye(dtDatos, consulta); 
            Category2.Category2e(dtDatos, consulta);
            Empaque.Empaquee(dtDatos, consulta);
            Fit.Fite(dtDatos, consulta);
            Inseam.Inseame(dtDatos, consulta);
            controlador.DatosDynamics(dtDatos, consulta);
            if (consulta == 33)
            {
                DiasF.BuscarProveedoressfiltro(dtDatos);
            }
            if (consulta == 34)
            {
                Bom.TareasM(dtDatos);
            }
            if (consulta == 15) 
            {
                controlador.EstilosdeProduccion(dtDatos); 
            }
            if (consulta == 23)
            {
                controlador.EstilosDynamicsBom(dtDatos);
            }
            if (consulta == 31)
            {
                controlador.DatosDynamics(dtDatos,consulta); 
            }
            if (consulta == 40)
            {
                controlador.getArticulos(dtDatos);
            }
            if (consulta == 41)
            {
                cotizacion.getClientes(dtDatos);
            }
            if (consulta == 42)
            {
                cotizacion.getArticulosPT(dtDatos);
            }
        }

        private void selDato()
        {
            if (consulta == 34)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    if (Bom.ExisteHilos(dtDatos.CurrentRow.Cells[2].Value.ToString()))
                    {
                        TareaHilo frm = new TareaHilo(dtDatos.CurrentRow.Cells[2].Value.ToString());
                        frm.ShowDialog();
                    }
                    else
                    {
                        dato1 = dtDatos.CurrentRow.Cells[2].Value.ToString();
                        Bom.RealizarTarea(dato1);
                    }
                }
                else
                {
                    dato = "";
                    dato1 = "";
                }
            }
            if (consulta == 31)
            {
                if (dtDatos.Rows.Count > 0)
                {

                    dato = dtDatos.CurrentRow.Cells[1].Value.ToString();

                }
                else
                {
                    dato = "";
                    dato1 = "";
                }
            }
            else if (consulta == 18)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    dato = dtDatos.CurrentRow.Cells[1].Value.ToString();
                    dato1 = dtDatos.CurrentRow.Cells[2].Value.ToString();
                }
                else
                {
                    dato = "";
                    dato1 = "";
                }
            }
            else
            {
                if (dtDatos.Rows.Count > 0 && consulta != 31)
                {
                    dato = dtDatos.CurrentRow.Cells[0].Value.ToString();
                }

            }
            if(consulta == 40)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    articulo.Clave = dtDatos.CurrentRow.Cells[0].Value.ToString();
                    articulo.Descr = dtDatos.CurrentRow.Cells[1].Value.ToString();
                    articulo.Material = dtDatos.CurrentRow.Cells[2].Value.ToString();
                    articulo.UnidadMedida = dtDatos.CurrentRow.Cells[3].Value.ToString();
                    articulo.Proveedor = dtDatos.CurrentRow.Cells[4].Value.ToString();
                    articulo.Categoria = dtDatos.CurrentRow.Cells[5].Value.ToString();
                    articulo.Color = dtDatos.CurrentRow.Cells[6].Value.ToString();
                }
            }
            if(consulta == 41)
            {
                dato = dtDatos.CurrentRow.Cells[0].Value.ToString();
                dato1 = dtDatos.CurrentRow.Cells[1].Value.ToString();
            }
            if (consulta == 42)
            {
                if (dtDatos.Rows.Count > 0)
                {
                    articulosPT.Clave = dtDatos.CurrentRow.Cells[0].Value.ToString();
                    articulosPT.Descr = dtDatos.CurrentRow.Cells[1].Value.ToString();
                    articulosPT.Categoria = dtDatos.CurrentRow.Cells[2].Value.ToString();
                    articulosPT.Estilo = dtDatos.CurrentRow.Cells[3].Value.ToString();
                    articulosPT.Linea = dtDatos.CurrentRow.Cells[4].Value.ToString();
                    articulosPT.Marca = dtDatos.CurrentRow.Cells[5].Value.ToString();
                }
            }
            this.Close();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            selDato();  
        }

        private void dtDatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dtDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //seleccionamos el registro
                selDato();

            }
        }
    }
}
