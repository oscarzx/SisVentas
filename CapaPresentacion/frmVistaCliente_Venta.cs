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
    public partial class frmVistaCliente_Venta : Form
    {
        public frmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {

            this.listadoDataGridView.Columns[0].Visible = false;
            this.listadoDataGridView.Columns[1].Visible = false;
        }

        //Método mostrar
        private void Mostrar()
        {
            this.listadoDataGridView.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarApellido
        private void BuscarApellido()
        {
            this.listadoDataGridView.DataSource = NCliente.BuscarApellido(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarCliente_Documento
        private void BuscarCliente_Documento()
        {
            this.listadoDataGridView.DataSource = NCliente.BuscarCliente_Documento(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (buscarComboBox.SelectedIndex == -1) return;

            if (buscarComboBox.Text.Equals("Apellido"))
            {
                this.BuscarApellido();
            }
            else if (buscarComboBox.Text.Equals("Documento"))
            {
                this.BuscarCliente_Documento();
            }
            PersonalizarGrilla();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmVenta miForm = frmVenta.GetInstance();
            string par1, par2;
            par1 = this.listadoDataGridView.CurrentRow.Cells["IdCliente"].Value.ToString();
            par2 = this.listadoDataGridView.CurrentRow.Cells["Apellido_cliente"].Value.ToString() + " " +
                this.listadoDataGridView.CurrentRow.Cells["Nombre_cliente"].Value.ToString();

            miForm.SetCliente(par1, par2);
            this.Hide();
        }

        private void frmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            this.listadoDataGridView.Columns[0].Visible = false;
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["IdCliente"].HeaderText = "Id";
            listadoDataGridView.Columns["IdCliente"].Width = 50;
            listadoDataGridView.Columns["IdCliente"].ReadOnly = false;

            listadoDataGridView.Columns["Nombre_cliente"].HeaderText = "Nombre";
            listadoDataGridView.Columns["Nombre_cliente"].Width = 150;
            listadoDataGridView.Columns["Nombre_cliente"].ReadOnly = false;

            listadoDataGridView.Columns["Apellido_cliente"].HeaderText = "Apellido";
            listadoDataGridView.Columns["Apellido_cliente"].Width = 150;
            listadoDataGridView.Columns["Apellido_cliente"].ReadOnly = false;

            listadoDataGridView.Columns["Genero"].HeaderText = "Género";
            listadoDataGridView.Columns["Genero"].Width = 50;
            listadoDataGridView.Columns["Genero"].DefaultCellStyle.Alignment = 
                DataGridViewContentAlignment.MiddleCenter;
            listadoDataGridView.Columns["Genero"].ReadOnly = false;

            listadoDataGridView.Columns["Tipo_documento"].HeaderText = "Tipo Documento";
            listadoDataGridView.Columns["Tipo_documento"].Width = 80;
            listadoDataGridView.Columns["Tipo_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Numero_documento"].HeaderText = "N. Documento";
            listadoDataGridView.Columns["Numero_documento"].Width = 80;
            listadoDataGridView.Columns["Numero_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Direccion"].HeaderText = "Dirección";
            listadoDataGridView.Columns["Direccion"].Width = 100;
            listadoDataGridView.Columns["Direccion"].ReadOnly = false;

            listadoDataGridView.Columns["Telefono"].HeaderText = "Teléfono";
            listadoDataGridView.Columns["Telefono"].Width = 80;
            listadoDataGridView.Columns["Telefono"].ReadOnly = false;

            listadoDataGridView.Columns["Email"].HeaderText = "Email";
            listadoDataGridView.Columns["Email"].Width = 80;
            listadoDataGridView.Columns["Email"].ReadOnly = false;

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
