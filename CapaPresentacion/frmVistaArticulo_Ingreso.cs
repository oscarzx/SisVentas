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
    public partial class frmVistaArticulo_Ingreso : Form
    {
        public frmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.listadoDataGridView.Columns[0].Visible = false;
            this.listadoDataGridView.Columns[1].Visible = false;
            //this.listadoDataGridView.Columns[2].Visible = false;
            this.listadoDataGridView.Columns[6].Visible = false;
            this.listadoDataGridView.Columns[7].Visible = false;
            this.listadoDataGridView.Columns[8].Visible = false;
            this.listadoDataGridView.Columns[10].Visible = false;
        }

        //Método mostrar
        private void Mostrar()
        {
            this.listadoDataGridView.DataSource = null;
            this.listadoDataGridView.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.listadoDataGridView.DataSource = null;
            this.listadoDataGridView.DataSource = NArticulo.BuscarNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            PersonalizarGrillaProducto();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
            PersonalizarGrillaProducto();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso miForm = frmIngreso.GetInstance();
            string par1, par2;
            par1 = this.listadoDataGridView.CurrentRow.Cells["IdArticulo"].Value.ToString();
            par2 = this.listadoDataGridView.CurrentRow.Cells["NombreArticulo"].Value.ToString();
            miForm.SetArticulo(par1, par2);
            this.Hide();
        }

        private void PersonalizarGrillaProducto()
        {
            listadoDataGridView.Columns["CodigoArticulo"].HeaderText = "Código";
            listadoDataGridView.Columns["CodigoArticulo"].Width = 80;
            listadoDataGridView.Columns["CodigoArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["NombreArticulo"].HeaderText = "Nombre Artículo";
            listadoDataGridView.Columns["NombreArticulo"].Width = 250;
            listadoDataGridView.Columns["NombreArticulo"].ReadOnly = false;

            listadoDataGridView.Columns["Referencia"].HeaderText = "Referencia";
            listadoDataGridView.Columns["Referencia"].Width = 100;
            listadoDataGridView.Columns["Referencia"].ReadOnly = false;

            listadoDataGridView.Columns["Talla"].HeaderText = "Talla";
            listadoDataGridView.Columns["Talla"].Width = 80;
            listadoDataGridView.Columns["Talla"].ReadOnly = false;

            listadoDataGridView.Columns["Categoria"].HeaderText = "Categoría";
            listadoDataGridView.Columns["Categoria"].Width = 100;
            listadoDataGridView.Columns["Categoria"].ReadOnly = false;

            listadoDataGridView.Columns["Presentacion"].HeaderText = "Presentación";
            listadoDataGridView.Columns["Presentacion"].Width = 100;
            listadoDataGridView.Columns["Presentacion"].ReadOnly = false;

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
