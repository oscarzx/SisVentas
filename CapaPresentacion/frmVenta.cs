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

namespace CapaPresentacion
{
    public partial class frmVenta : Form
    {
        public int IdEmpleado { get; set; }
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private static frmVenta _instancia;

        public static frmVenta GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        public void SetCliente(string idcliente, string nombre)
        {
            this.idClienteTextBox.Text = idcliente;
            this.clienteTextBox.Text = nombre;
        }

        public void SetArticulo(string iddetalle_ingreso, string nombre,
            decimal precio_compra, decimal precio_venta, int stock, DateTime fecha_vencimiento)
        {
            this.idArticuloTextBox.Text = iddetalle_ingreso;
            this.articuloTextBox.Text = nombre;
            this.precioCompraTextBox.Text = precio_compra.ToString();
            this.precioVentaTextBox.Text = precio_venta.ToString();
            this.stockActualTextBox.Text = stock.ToString();
            this.fechaVencimientoDateTimePicker.Value = fecha_vencimiento;

            this.idClienteTextBox.Visible = false;
            this.idArticuloTextBox.Visible = false;
            this.clienteTextBox.ReadOnly = true;
            this.articuloTextBox.ReadOnly = true;
            this.fechaVencimientoDateTimePicker.Enabled = false;
            this.precioCompraTextBox.ReadOnly = true;
            this.stockActualTextBox.ReadOnly = true;

        }

        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.clienteTextBox, "Seleccione un cliente");
            this.ttMensaje.SetToolTip(this.serieTextBox, "Ingrese una serie del comprobante");
            this.ttMensaje.SetToolTip(this.correlativoTextBox, "Ingrese un número de comprobante");
            this.ttMensaje.SetToolTip(this.cantidadTextBox, "Ingrese la cantidad del producto a vender");
            this.ttMensaje.SetToolTip(this.articuloTextBox, "Seleccione un artículo");
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void buscarClienteButton_Click(object sender, EventArgs e)
        {
            frmVistaCliente_Venta miForm = new frmVistaCliente_Venta();
            miForm.ShowDialog();
        }

        private void buscarArticuloButton_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Venta miForm = new frmVistaArticulo_Venta();
            miForm.ShowDialog();
        }
    }
}
