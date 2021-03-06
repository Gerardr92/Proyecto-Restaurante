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
    public partial class MenuPrinc : Form
    {
        public MenuPrinc()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormAgregarP = new FormAgregarP();
            FormAgregarP.Show();
        }

        private void MenuPrinc_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var FormLogin = new FormLogin();
            FormLogin.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormAgregar = new FormAgregarO();
            FormAgregar.Show();
        }


        private void estatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormEstado = new FormEstadoO();
            FormEstado.Show();
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FormEliminarP = new FormEliminarP();
            FormEliminarP.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FormAgregar = new FormAgregarO();
            FormAgregar.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.Show();
        }

        private void reporteOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formreporteordenes = new FormReporteOrdenes();
            formreporteordenes.Show();
        }

        private void reporteFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formreportefacturas = new FormReporteFactura();
            formreportefacturas.Show();
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formreporteventas = new FormReporteVentas();
            formreporteventas.Show();
        }
    }
}
