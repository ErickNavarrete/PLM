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
using Microsoft.Reporting.WinForms;
using System.IO;
using ArcangelDialogs;
using System.Data;


namespace PLM.Vista.Reporte
{
    public partial class vistaReporte : MetroForm
    {
        public DataTable[] datos;
        public string[] datosConsultaBOM;
        public int tipoReporte;

        public vistaReporte(int _tipoReporte)
        {
            InitializeComponent();
            tipoReporte = _tipoReporte;
        }

        private void vistaReporte_Load(object sender, EventArgs e)
        {
            ReportDataSource dataSet;
            switch(tipoReporte)
            {
                case 1:
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "PLM.Informes.ReporteBom.rdlc";                                       
                    reportViewer1.LocalReport.DataSources.Clear();
                    dataSet = new ReportDataSource("DataSetBom", datos[0]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetEstilo", datos[1]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetThread", datos[2]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetUsu", datos[3]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("NROBOM", datosConsultaBOM[0]));
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("ETAPA", datosConsultaBOM[1]));
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("STATUS", datosConsultaBOM[2]));
                    this.reportViewer1.RefreshReport();
                    break;
                case 2:
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "PLM.Informes.ReporteBomCosteado.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    dataSet = new ReportDataSource("DataSetBom", datos[0]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetEstilo", datos[1]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetThread", datos[2]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    dataSet = new ReportDataSource("DataSetUsu", datos[3]);
                    reportViewer1.LocalReport.DataSources.Add(dataSet);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("NROBOM", datosConsultaBOM[0]));
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("ETAPA", datosConsultaBOM[1]));
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("STATUS", datosConsultaBOM[2]));
                    this.reportViewer1.RefreshReport();
                    break;
                default:
                    Dialogs.Show("No se encuentra reporte a consultar", DialogsType.Info);
                    break;
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
