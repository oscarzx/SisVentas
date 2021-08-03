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
    public partial class frmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.razonSocialTextBox, "Ingrese razón social del proveedor");
            this.ttMensaje.SetToolTip(this.numeroDocumentoTextBox, "Ingrese número de documento del proveedor");
            this.ttMensaje.SetToolTip(this.direccionTextBox, "Ingrese la dirección del proveedor");
        }

        //Mostrar mensaje de confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.idProveedorTextBox.Text = string.Empty;
            this.razonSocialTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.numeroDocumentoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.urlTextBox.Text = string.Empty;

            tipoDocumentoComboBox.SelectedIndex = -1;
            sectorComercialComboBox.SelectedIndex = -1;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.idProveedorTextBox.ReadOnly = !valor;
            this.razonSocialTextBox.ReadOnly = !valor;
            this.direccionTextBox.ReadOnly = !valor;
            this.numeroDocumentoTextBox.ReadOnly = !valor;
            this.telefonoTextBox.ReadOnly = !valor;
            this.emailTextBox.ReadOnly = !valor;
            this.urlTextBox.ReadOnly = !valor;

            tipoDocumentoComboBox.Enabled = valor;
            sectorComercialComboBox.Enabled = valor;
        }

        //Habilitar los botones 
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.nuevoButton.Enabled = false;
                this.guardarButton.Enabled = true;
                this.editarButton.Enabled = false;
                this.cancelarButton.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.nuevoButton.Enabled = true;
                this.guardarButton.Enabled = false;
                this.editarButton.Enabled = true;
                this.cancelarButton.Enabled = false;
            }
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

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if(buscarComboBox.Text.Equals("Razón Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (buscarComboBox.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }
    }
}
