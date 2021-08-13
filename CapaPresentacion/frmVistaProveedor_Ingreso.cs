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
    }
}
