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

        private void ordenBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            ordenBindingSource.EndEdit();
            var orden = (Orden)ordenBindingSource.Current;

            var Resultado = _Ordenes.GuardarOrden(orden);

            if (Resultado.Exitoso == true)
            {
                ordenBindingSource.ResetBindings(false);
                habilitardeshabilitarbotones(true);

            }
            else
            {
                MessageBox.Show(Resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _Ordenes.agregarOrden();
            ordenBindingSource.MoveLast();

            habilitardeshabilitarbotones(false);
            

        }

        private void habilitardeshabilitarbotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = ! valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
           
            if(idTextBox.Text != "")
            {
                var Resultado = MessageBox.Show("Desea Eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }

            }   
        }

        private void Eliminar(int id)
        {
            
            var resultado = _Ordenes.eliminarOrden(id);

            if (resultado == true)
            {
                ordenBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar la orden");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            habilitardeshabilitarbotones(true);
            Eliminar(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
