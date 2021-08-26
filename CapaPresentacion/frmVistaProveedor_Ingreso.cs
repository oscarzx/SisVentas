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
    public partial class frmVistaProveedor_Ingreso : Form
    {
        public frmVistaProveedor_Ingreso()
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
            this.listadoDataGridView.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.listadoDataGridView.DataSource = NProveedor.BuscarRazon_Social(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.listadoDataGridView.DataSource = NProveedor.BuscarNum_Documento(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            PersonalizarGrilla();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (buscarComboBox.Text.Equals("Razón Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (buscarComboBox.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
            PersonalizarGrilla();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso miForm = frmIngreso.GetInstance();
            string par1, par2;
            par1 = listadoDataGridView.CurrentRow.Cells["IdProveedor"].Value.ToString();
            par2 = listadoDataGridView.CurrentRow.Cells["Razon_social"].Value.ToString();

            miForm.SetProveedor(par1, par2);
            this.Hide();
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["Razon_social"].HeaderText = "Razón Social";
            listadoDataGridView.Columns["Razon_social"].Width = 150;
            listadoDataGridView.Columns["Razon_social"].ReadOnly = false;

            listadoDataGridView.Columns["Sector_comercial"].HeaderText = "Sector Comercial";
            listadoDataGridView.Columns["Sector_comercial"].Width = 80;
            listadoDataGridView.Columns["Sector_comercial"].ReadOnly = false;

            listadoDataGridView.Columns["Tipo_documento"].HeaderText = "Tipo Documento";
            listadoDataGridView.Columns["Tipo_documento"].Width = 80;
            listadoDataGridView.Columns["Tipo_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Num_documento"].HeaderText = "N. Documento";
            listadoDataGridView.Columns["Num_documento"].Width = 100;
            listadoDataGridView.Columns["Num_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Direccion_proveedor"].HeaderText = "Dirección";
            listadoDataGridView.Columns["Direccion_proveedor"].Width = 200;
            listadoDataGridView.Columns["Direccion_proveedor"].ReadOnly = false;

            listadoDataGridView.Columns["Telefono"].HeaderText = "Teléfono";
            listadoDataGridView.Columns["Telefono"].Width = 100;
            listadoDataGridView.Columns["Telefono"].ReadOnly = false;

            listadoDataGridView.Columns["Email"].HeaderText = "Email";
            listadoDataGridView.Columns["Email"].Width = 100;
            listadoDataGridView.Columns["Email"].ReadOnly = false;

            listadoDataGridView.Columns["Url"].HeaderText = "Url";
            listadoDataGridView.Columns["Url"].Width = 100;
            listadoDataGridView.Columns["Url"].ReadOnly = false;

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
