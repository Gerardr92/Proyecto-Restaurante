using BL.Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Restaurante
{
    public partial class FormReporteFactura : Form
    {
        public FormReporteFactura()
        {
            InitializeComponent();

            var _FacturasBL = new FacturaBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _FacturasBL.Obtenerfacturas();

            var Reporte = new ReporteFacturas();
            Reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = Reporte;
            crystalReportViewer1.RefreshReport();

        }
    }
}
