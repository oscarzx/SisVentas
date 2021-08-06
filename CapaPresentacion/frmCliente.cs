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
    public partial class frmCliente : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(nombreTextBox, "Ingrese el nombre del cliente");
            this.ttMensaje.SetToolTip(apellidosTextBox, "Ingrese el apellido del cliente");
            this.ttMensaje.SetToolTip(direccionTextBox, "Ingrese la dirección del cliente");
            this.ttMensaje.SetToolTip(numeroDocumentoTextBox, "Ingrese el número de documento del cliente");
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
            this.idClienteTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidosTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.numeroDocumentoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.generoComboBox.Text = string.Empty;
            this.tipoDocumentoComboBox.Text = string.Empty;

            generoComboBox.SelectedIndex = -1;
            tipoDocumentoComboBox.SelectedIndex = -1;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.idClienteTextBox.ReadOnly = !valor;
            this.nombreTextBox.ReadOnly = !valor;
            this.apellidosTextBox.ReadOnly = !valor;
            this.direccionTextBox.ReadOnly = !valor;
            this.numeroDocumentoTextBox.ReadOnly = !valor;
            this.telefonoTextBox.ReadOnly = !valor;
            this.emailTextBox.ReadOnly = !valor;

            generoComboBox.Enabled = valor;
            tipoDocumentoComboBox.Enabled = valor;
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

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
    }
}
