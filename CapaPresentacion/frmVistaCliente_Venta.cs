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
            if (buscarComboBox.Text.Equals("Apellido"))
            {
                this.BuscarApellido();
            }
            else if (buscarComboBox.Text.Equals("Documento"))
            {
                this.BuscarCliente_Documento();
            }
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
    }
}
