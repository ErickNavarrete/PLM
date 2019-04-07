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

namespace PLM.Vista.BOM
{
    public partial class DetailBomVista : MetroForm
    {
        private string identity;     
        public Controlador.EstilosdeProduccionController Estilo;

        public DetailBomVista(string _identiy)
        {
            InitializeComponent();
            identity = _identiy;           
            Estilo = new Controlador.EstilosdeProduccionController(); 
        }

        private void DetailBomVista_Load(object sender, EventArgs e)
        {
            Estilo.MostrarPLM(txtIdEstilos, cmbDescrip, cmbCategoria, cmbDivision, cmbEstacion, cmbCliente, cmbMarca, cmbCategory2, txtEspec, cmbFit, cmbBody, cmbLavado, cmbInseam, cmbEmpaque, identity, 1);         
        }
    }
}
