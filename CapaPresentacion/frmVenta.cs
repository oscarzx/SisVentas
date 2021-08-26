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
            //Aquí se le está pasando por parametro el IdArticuloa al IdDetalleIngreso
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
            this.idVentaTextBox.Text = string.Empty;
            this.idClienteTextBox.Text = string.Empty;
            this.clienteTextBox.Text = string.Empty;
            this.serieTextBox.Text = string.Empty;
            this.correlativoTextBox.Text = string.Empty;
            this.totalRegistrosLabel.Text = "0,0";
            this.ivaTextBox.Text = "19";
            this.CrearTabla();
        }

        private void LimpiarDetalle()
        {
            this.idArticuloTextBox.Text = string.Empty;
            this.articuloTextBox.Text = string.Empty;
            this.cantidadTextBox.Text = string.Empty;
            this.stockActualTextBox.Text = string.Empty;
            this.precioCompraTextBox.Text = string.Empty;
            this.precioVentaTextBox.Text = string.Empty;
            this.descuentoTextBox.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.idVentaTextBox.ReadOnly = true;
            this.serieTextBox.ReadOnly = !valor;
            this.correlativoTextBox.ReadOnly = !valor;
            this.ivaTextBox.ReadOnly = !valor;
            this.fechaIngresodateTimePicker.Enabled = valor;
            this.comprobanteComboBox.Enabled = valor;
            this.comprobanteComboBox.SelectedIndex = -1;
            this.cantidadTextBox.ReadOnly = !valor;
            this.stockActualTextBox.ReadOnly = !valor;
            this.precioCompraTextBox.ReadOnly = !valor;
            this.precioVentaTextBox.ReadOnly = !valor;
            this.descuentoTextBox.ReadOnly = !valor;
            this.fechaVencimientoDateTimePicker.Enabled = valor;

            this.buscarArticuloButton.Enabled = valor;
            this.buscarClienteButton.Enabled = valor;
            this.agregarButton.Enabled = valor;
            this.borrarButton.Enabled = valor;
        }

        //Habilitar los botones 
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.nuevoButton.Enabled = false;
                this.guardarButton.Enabled = true;
                this.cancelarButton.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.nuevoButton.Enabled = true;
                this.guardarButton.Enabled = false;
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
            this.listadoDataGridView.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            totalRegistrosLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.listadoDataGridView.DataSource =
                NVenta.BuscarFechas(this.fechaInicioDateTimePicker.Value.ToString("dd/MM/yyyy"),
                this.fechaFinalDateTimePicker.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            totalRegistrosLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void MostrarDetalle()
        {
            this.listadoDetalleDataGridView.DataSource = NVenta.MostrarDetalle(this.idVentaTextBox.Text);
        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar nuestro Datagrid con nuestro Datatable
            this.listadoDataGridView.DataSource = null;
            this.listadoDetalleDataGridView.DataSource = this.dtDetalle;
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

        private void frmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            idClienteTextBox.Visible = false;
            idArticuloTextBox.Visible = false;

            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.Mostrar();
            PersonalizarGrillaListado();
        }

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("realmente desea eliminar los registros?", "Sistema de Ventas",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in listadoDataGridView.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = row.Cells[1].Value.ToString();
                            rpta = NVenta.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                                this.MensajeOk("Se anuló correctamente el ingreso");
                            else
                                this.MensajeError(rpta);
                        }
                    }
                    this.Mostrar();
                    PersonalizarGrillaListado();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            //Columnas del [spmostrar_venta]
            this.idVentaTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["IdVenta"].Value.ToString();
            this.clienteTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Cliente"].Value.ToString();
            this.fechaIngresodateTimePicker.Value =
                Convert.ToDateTime(this.listadoDataGridView.CurrentRow.Cells["Fecha"].Value);
            this.comprobanteComboBox.Text = this.listadoDataGridView.CurrentRow.Cells["Tipo_comprobante"].Value.ToString();
            this.serieTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Serie"].Value.ToString();
            this.correlativoTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Correlativo"].Value.ToString();
            this.totalRegistrosLabel.Text = this.listadoDataGridView.CurrentRow.Cells["Total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
            PersonalizarGrillaListado();
        }

        private void eliminarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (eliminarCheckBox.Checked)
            {
                this.listadoDataGridView.Columns[0].Visible = true;
            }
            else
            {
                this.listadoDataGridView.Columns[0].Visible = false;
            }
            PersonalizarGrillaListado();
        }

        private void listadoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == listadoDataGridView.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)listadoDataGridView.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.comprobanteComboBox.Focus();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            Mostrar();
            PersonalizarGrillaListado();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = NVenta.Insertar(Convert.ToInt32(idClienteTextBox.Text.Trim()), IdEmpleado,
                        fechaIngresodateTimePicker.Value, comprobanteComboBox.Text,
                        serieTextBox.Text, correlativoTextBox.Text, Convert.ToDecimal(ivaTextBox.Text), dtDetalle);
                }


                if (rpta.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se insertó de forma correcta el registro");
                    }

                }
                else
                {
                    this.MensajeError(rpta);
                }

                this.IsNuevo = false;
                this.Botones();
                this.Limpiar();
                this.LimpiarDetalle();
                this.Mostrar();
                PersonalizarGrillaListado();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private bool ValidarCampos()
        {
            if (comprobanteComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(comprobanteComboBox, "Debe seleccionar un comprpobante de ingreso");
                comprobanteComboBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(clienteTextBox.Text))
            {
                errorProvider1.SetError(clienteTextBox, "Debe seleccionar un proveedor");
                clienteTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(serieTextBox.Text))
            {
                errorProvider1.SetError(serieTextBox, "Debe ingresar una serie");
                serieTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(correlativoTextBox.Text))
            {
                errorProvider1.SetError(correlativoTextBox, "Debe ingresar un correlativo");
                correlativoTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ivaTextBox.Text))
            {
                errorProvider1.SetError(ivaTextBox, "Debe ingresar un impuesto");
                ivaTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (listadoDetalleDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No ha ingresado artículos");
                articuloTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            return true;
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string rpta = "";
                if (idArticuloTextBox.Text == string.Empty ||
                    cantidadTextBox.Text == string.Empty ||
                    descuentoTextBox.Text == string.Empty ||
                    precioVentaTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(idArticuloTextBox, "Ingrese un valor");
                    errorProvider1.SetError(cantidadTextBox, "Ingrese un valor");
                    errorProvider1.SetError(descuentoTextBox, "Ingrese un valor");
                    errorProvider1.SetError(precioVentaTextBox, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.idArticuloTextBox.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra agregado el artículo");
                        }
                    }

                    if (registrar && Convert.ToInt32(cantidadTextBox.Text) <= Convert.ToInt32(stockActualTextBox.Text))
                    {
                        decimal subTotal =
                            (Convert.ToDecimal(this.cantidadTextBox.Text) * Convert.ToDecimal(this.precioVentaTextBox.Text)) - Convert.ToDecimal(this.descuentoTextBox.Text);
                        totalPagado = totalPagado + subTotal;
                        this.totalPagadoLabel.Text = totalPagado.ToString("#0.00#");

                        //Agregar detalle al ListadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.idArticuloTextBox.Text);
                        row["articulo"] = this.articuloTextBox.Text;
                        row["cantidad"] = Convert.ToDouble(this.cantidadTextBox.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.precioVentaTextBox.Text);
                        row["descuento"] = Convert.ToDecimal(this.descuentoTextBox.Text);
                        row["subtotal"] = subTotal;

                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                    else
                    {
                        MensajeError("No hay Stock suficiente");
                    }
                    PersonalizarGrillaProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void borrarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.listadoDetalleDataGridView.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];

                //Disminuir el total pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.totalRegistrosLabel.Text = totalPagado.ToString("#0.00#");

                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
            PersonalizarGrillaProducto();
        }

        private void comprobanteButton_Click(object sender, EventArgs e)
        {
            if (listadoDataGridView.Rows.Count == 0) return;
            frmReporteFactura miForm = new frmReporteFactura();
            miForm.IdVenta = Convert.ToInt32(listadoDataGridView.CurrentRow.Cells["IdVenta"].Value);
            miForm.ShowDialog();
        }

        private void PersonalizarGrillaListado()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["Empleado"].HeaderText = "Empleado";
            listadoDataGridView.Columns["Empleado"].Width = 150;
            listadoDataGridView.Columns["Empleado"].ReadOnly = false;

            listadoDataGridView.Columns["Cliente"].HeaderText = "Cliente";
            listadoDataGridView.Columns["Cliente"].Width = 150;
            listadoDataGridView.Columns["Cliente"].ReadOnly = false;

            listadoDataGridView.Columns["Fecha"].HeaderText = "Fecha";
            listadoDataGridView.Columns["Fecha"].Width = 80;
            listadoDataGridView.Columns["Fecha"].ReadOnly = false;

            listadoDataGridView.Columns["Tipo_comprobante"].HeaderText = "Tipo Comprobante";
            listadoDataGridView.Columns["Tipo_comprobante"].Width = 100;
            listadoDataGridView.Columns["Tipo_comprobante"].ReadOnly = false;

            listadoDataGridView.Columns["Serie"].HeaderText = "Serie";
            listadoDataGridView.Columns["Serie"].Width = 50;
            listadoDataGridView.Columns["Serie"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Serie"].ReadOnly = false;

            listadoDataGridView.Columns["Correlativo"].HeaderText = "Correlativo";
            listadoDataGridView.Columns["Correlativo"].Width = 80;
            listadoDataGridView.Columns["Correlativo"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Correlativo"].ReadOnly = false;

            listadoDataGridView.Columns["Impuesto"].HeaderText = "Impuesto";
            listadoDataGridView.Columns["Impuesto"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Impuesto"].DefaultCellStyle.Format = "C2";
            listadoDataGridView.Columns["Impuesto"].Width = 80;
            listadoDataGridView.Columns["Impuesto"].ReadOnly = true;

            listadoDataGridView.Columns["Total"].HeaderText = "Total";
            listadoDataGridView.Columns["Total"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["Total"].DefaultCellStyle.Format = "C2";
            listadoDataGridView.Columns["Total"].Width = 100;
            listadoDataGridView.Columns["Total"].ReadOnly = true;

            listadoDataGridView.EnableHeadersVisualStyles = false;
            listadoDataGridView.RowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            listadoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(listadoDataGridView.Font, FontStyle.Bold);
            listadoDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.listadoDataGridView.DataSource =
                NVenta.BuscarFechas(this.fechaInicioDateTimePicker.Value.ToString("yyyy/MM/dd"),
                this.fechaFinalDateTimePicker.Value.ToString("yyyy/MM/dd"));
            this.OcultarColumnas();
            totalRegistrosLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
            PersonalizarGrillaListado();
        }

        private void PersonalizarGrillaProducto()
        {
            listadoDetalleDataGridView.Columns["iddetalle_ingreso"].HeaderText = "Id Ingreso";
            listadoDetalleDataGridView.Columns["iddetalle_ingreso"].Width = 60;
            listadoDetalleDataGridView.Columns["iddetalle_ingreso"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["articulo"].HeaderText = "Artículo";
            listadoDetalleDataGridView.Columns["articulo"].Width = 150;
            listadoDetalleDataGridView.Columns["articulo"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["cantidad"].HeaderText = "Cantidad";
            listadoDetalleDataGridView.Columns["cantidad"].Width = 150;
            listadoDetalleDataGridView.Columns["cantidad"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["cantidad"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["precio_venta"].HeaderText = "Precio Venta";
            listadoDetalleDataGridView.Columns["precio_venta"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["precio_venta"].DefaultCellStyle.Format = "C2";
            listadoDetalleDataGridView.Columns["precio_venta"].Width = 100;
            listadoDetalleDataGridView.Columns["precio_venta"].ReadOnly = true;

            listadoDetalleDataGridView.Columns["descuento"].HeaderText = "% Descuento";
            listadoDetalleDataGridView.Columns["descuento"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["descuento"].DefaultCellStyle.Format = "C2";
            listadoDetalleDataGridView.Columns["descuento"].Width = 100;
            listadoDetalleDataGridView.Columns["descuento"].ReadOnly = true;

            listadoDetalleDataGridView.Columns["subtotal"].HeaderText = "SubTotal";
            listadoDetalleDataGridView.Columns["subtotal"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["subtotal"].DefaultCellStyle.Format = "C2";
            listadoDetalleDataGridView.Columns["subtotal"].Width = 100;
            listadoDetalleDataGridView.Columns["subtotal"].ReadOnly = true;

            listadoDetalleDataGridView.EnableHeadersVisualStyles = false;
            listadoDetalleDataGridView.RowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            listadoDetalleDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            listadoDetalleDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            listadoDetalleDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(listadoDataGridView.Font, FontStyle.Bold);
            listadoDetalleDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }


    }
}
