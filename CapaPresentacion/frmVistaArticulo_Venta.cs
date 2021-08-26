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
            this.listadoDataGridView.Columns[9].Visible = false;
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
            if (buscarComboBox.SelectedIndex == -1) return;

            if (buscarComboBox.Text.Equals("Codigo"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (buscarComboBox.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
            PersonalizarGrilla();
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

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["IdDetalle_ingreso"].HeaderText = "Id D.Ingreso";
            listadoDataGridView.Columns["IdDetalle_ingreso"].Width = 70;
            listadoDataGridView.Columns["IdDetalle_ingreso"].ReadOnly = false;

            listadoDataGridView.Columns["CodigoArticulo"].HeaderText = "Código";
            listadoDataGridView.Columns["CodigoArticulo"].Width = 80;
            listadoDataGridView.Columns["CodigoArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["NombreArticulo"].HeaderText = "Nombre Artículo";
            listadoDataGridView.Columns["NombreArticulo"].Width = 200;
            listadoDataGridView.Columns["NombreArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["Referencia"].HeaderText = "Referencia";
            listadoDataGridView.Columns["Referencia"].Width = 70;
            listadoDataGridView.Columns["Referencia"].ReadOnly = false;

            listadoDataGridView.Columns["Talla"].HeaderText = "Talla";
            listadoDataGridView.Columns["Talla"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            listadoDataGridView.Columns["Talla"].Width = 40;
            listadoDataGridView.Columns["Talla"].ReadOnly = false;

            listadoDataGridView.Columns["Categoria"].HeaderText = "Categoría";
            listadoDataGridView.Columns["Categoria"].Width = 70;
            listadoDataGridView.Columns["Categoria"].ReadOnly = false;

            listadoDataGridView.Columns["Presentacion"].HeaderText = "Presentación";
            listadoDataGridView.Columns["Presentacion"].Width = 90;
            listadoDataGridView.Columns["Presentacion"].ReadOnly = false;

            listadoDataGridView.Columns["Stock_actual"].HeaderText = "Stock";
            listadoDataGridView.Columns["Stock_actual"].Width = 50;
            listadoDataGridView.Columns["Stock_actual"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Stock_actual"].ReadOnly = false;

            listadoDataGridView.Columns["Precio_compra"].HeaderText = "Precio Compra";
            listadoDataGridView.Columns["Precio_compra"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Precio_compra"].DefaultCellStyle.Format = "C2";
            listadoDataGridView.Columns["Precio_compra"].Width = 100;
            listadoDataGridView.Columns["Precio_compra"].ReadOnly = true;

            listadoDataGridView.Columns["Precio_venta"].HeaderText = "Precio Venta";
            listadoDataGridView.Columns["Precio_venta"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Precio_venta"].DefaultCellStyle.Format = "C2";
            listadoDataGridView.Columns["Precio_venta"].Width = 80;
            listadoDataGridView.Columns["Precio_venta"].ReadOnly = true;

            listadoDataGridView.Columns["Fecha_vencimiento"].HeaderText = "F. Vencimiento";
            listadoDataGridView.Columns["Fecha_vencimiento"].Width = 100;
            listadoDataGridView.Columns["Fecha_vencimiento"].ReadOnly = false;

            listadoDataGridView.EnableHeadersVisualStyles = false;
            listadoDataGridView.RowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            listadoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(listadoDataGridView.Font, FontStyle.Bold);
            listadoDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private void frmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            //PersonalizarGrilla();
        }
    }
}
