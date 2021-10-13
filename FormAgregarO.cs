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
    public partial class FormAgregarO : Form
    {
        AgOrdenesBL _Ordenes;

        public FormAgregarO()
        {
            InitializeComponent();

            _Ordenes = new AgOrdenesBL();
            ordenBindingSource.DataSource = _Ordenes.ObtenerOrdenes();
        }

        private void ordenDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void descripcionLabel_Click(object sender, EventArgs e)
        {

        }

        private void activoLabel_Click(object sender, EventArgs e)
        {

        }

        private void activoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void existenciaLabel_Click(object sender, EventArgs e)
        {

        }

        private void existenciaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void precioLabel_Click(object sender, EventArgs e)
        {

        }

        private void precioTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
