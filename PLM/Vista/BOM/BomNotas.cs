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

namespace PLM.Vista.BOM
{
    public partial class BomNotas : MetroForm
    {
        public String strNota;
        public BomNotas(string nota)
        {
            InitializeComponent();
            strNota = nota;
            txtNota.Text = nota;
        }

        private void DetalleUsuario_Load(object sender, EventArgs e)
        {            
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            strNota = this.txtNota.Text;
            this.Hide();

        }
    }
}
