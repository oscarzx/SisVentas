using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmVistaArticulo_Venta : Form
    {
        public frmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {

            this.listadoDataGridView.Columns[0].Visible = false;
            this.listadoDataGridView.Columns[1].Visible = false;
        }

        
        private void MostrarArticulo_Venta_Nombre()
        {
            this.listadoDataGridView.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void MostrarArticulo_Venta_Codigo()
        {
            this.listadoDataGridView.DataSource = NVenta.MostrarArticulo_Venta_Codigo(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //private void NGetArticuloByNombreArticulo()
        //{
        //    this.listadoDataGridView.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.buscarTextBox.Text);
        //    this.OcultarColumnas();
        //    totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        //}

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (buscarComboBox.Text.Equals("Codigo"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (buscarComboBox.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmVenta miForm = frmVenta.GetInstance();
            string par1, par2;
            decimal par3, par4;
            int par5;
            DateTime par6;

            par1 = listadoDataGridView.CurrentRow.Cells["IdDetalle_ingreso"].Value.ToString();
            par2 = listadoDataGridView.CurrentRow.Cells["NombreArticulo"].Value.ToString();
            par3 = Convert.ToDecimal(listadoDataGridView.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(listadoDataGridView.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(listadoDataGridView.CurrentRow.Cells["Stock_actual"].Value);
            par6 = Convert.ToDateTime(listadoDataGridView.CurrentRow.Cells["Fecha_vencimiento"].Value);

            miForm.SetArticulo(par1, par2, par3, par4, par5, par6);
            this.Hide();
        }
    }
}
