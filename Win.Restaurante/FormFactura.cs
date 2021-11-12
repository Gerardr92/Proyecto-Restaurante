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
    public partial class FormFactura : Form
    {
        OrdenesBL _OrdenesBL;
        FacturaBL _FacturaBL;

        public FormFactura()
        {
            InitializeComponent();

            _OrdenesBL = new OrdenesBL();
            ordenBindingSource.DataSource = _OrdenesBL.ObtenerOrdenes();

            _FacturaBL = new FacturaBL();
            listafacturaBindingSource.DataSource = _FacturaBL.Obtenerfacturas();
        }

        private void listafacturaBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            
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
            toolStripButtonCancelar.Visible = !valor;
        }

        private void listafacturaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listafacturaBindingSource.EndEdit();

            var Factura = (factura)listafacturaBindingSource.Current;

            var Resultado = _FacturaBL.Guardarfactura(Factura);
            if(Resultado.Exitoso == true)
            {
                listafacturaBindingSource.ResetBindings(false);
                habilitardeshabilitarbotones(true);
                MessageBox.Show("Factura Guardada");
            }
            else
            {
                MessageBox.Show(Resultado.Mensaje);
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            habilitardeshabilitarbotones(true);
            _FacturaBL.Cancelarcambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Factura = (factura)listafacturaBindingSource.Current;
            var facturadetalle = (Facturadetalle)facturadetalleBindingSource.Current;

            _FacturaBL.Removerfacturadetalle(Factura, facturadetalle);
            habilitardeshabilitarbotones(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Factura = (factura)listafacturaBindingSource.Current;
            _FacturaBL.Agregarfacturadetalle(Factura);
            habilitardeshabilitarbotones(false);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _FacturaBL.Agregarfactura();
            listafacturaBindingSource.MoveLast();

            habilitardeshabilitarbotones(false);

        }

        private void facturadetalleDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void facturadetalleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void facturadetalleDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Factura = (factura)listafacturaBindingSource.Current;
            _FacturaBL.Calcularfactura(Factura);

            listafacturaBindingSource.ResetBindings(false);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var Resultado = MessageBox.Show("Desea Eliminar esta factura?", "Anular", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                {
                    var Id = Convert.ToInt32(idTextBox.Text);
                    Anular(Id);
                }
            }
        }

        private void Anular(int Id)
        {
            var Resultado = _FacturaBL.Anularfactura(Id);
            if(Resultado == true)
            {
                listafacturaBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error anulando la factura");
            }
        }

        private void listafacturaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var Factura = (factura)listafacturaBindingSource.Current;
            if(Factura != null && Factura.Id != 0 && Factura.Activo == false)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }

        }
    }
}
