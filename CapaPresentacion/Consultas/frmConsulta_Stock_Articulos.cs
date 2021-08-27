using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Consultas
{
    public partial class frmConsulta_Stock_Articulos : Form
    {
        public frmConsulta_Stock_Articulos()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.listadoDataGridView.Columns[0].Visible = false;
            this.listadoDataGridView.Columns[4].Visible = false;
            this.listadoDataGridView.Columns[6].Visible = false;

        }

        private void StockArticuloNombre()
        {
            this.listadoDataGridView.DataSource = NArticulo.StockArticuloNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método mostrar
        private void Mostrar()
        {
            this.listadoDataGridView.DataSource = NArticulo.StockArticulos();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmConsulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            Mostrar();
            PersonalizarGrilla();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (buscarComboBox.SelectedIndex == -1) return;

            if (buscarComboBox.Text.Equals("Nombre"))
            {
                this.StockArticuloNombre();
                
            }
            else if (buscarComboBox.Text.Equals("Codigo"))
            {
                //Falta crear procedimiento almacenado
                //this.MostrarArticulo_Venta_Codigo();
            }
            PersonalizarGrilla();
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["CodigoArticulo"].HeaderText = "Código";
            listadoDataGridView.Columns["CodigoArticulo"].Width = 100;
            listadoDataGridView.Columns["CodigoArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["NombreArticulo"].HeaderText = "Nombre Artículo";
            listadoDataGridView.Columns["NombreArticulo"].Width = 250;
            listadoDataGridView.Columns["NombreArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["Categoria"].HeaderText = "Categoría";
            listadoDataGridView.Columns["Categoria"].Width = 100;
            listadoDataGridView.Columns["Categoria"].ReadOnly = false;

            listadoDataGridView.Columns["Cantidad_Stock"].HeaderText = "Stock";
            listadoDataGridView.Columns["Cantidad_Stock"].Width = 80;
            listadoDataGridView.Columns["Cantidad_Stock"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Cantidad_Stock"].ReadOnly = false;

            listadoDataGridView.EnableHeadersVisualStyles = false;
            listadoDataGridView.RowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            listadoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(listadoDataGridView.Font, FontStyle.Bold);
            listadoDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }
    }
}
