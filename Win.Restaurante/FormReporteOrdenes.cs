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
    public partial class FormReporteOrdenes : Form
    {
        public FormReporteOrdenes()
        {
            InitializeComponent();

            var _OrdenBL = new OrdenesBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _OrdenBL.ObtenerOrdenes();

            var Reporte = new ReporteOrdenes();
            Reporte.SetDataSource(bindingSource);

            crystalReportViewer1.ReportSource = Reporte;
            crystalReportViewer1.RefreshReport();

        }
    }
}
