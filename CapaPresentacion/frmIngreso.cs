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
    public partial class frmIngreso : Form
    {
        public int IdEmpleado { get; set; }
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado;


        private static frmIngreso _instancia;

        public static frmIngreso GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }

        public void SetProveedor(string idProveedor, string nombre)
        {
            this.idProveedorTextBox.Text = idProveedor;
            this.proveedorTextBox.Text = nombre;
        }

        public void SetArticulo(string idArticulo, string nombre)
        {
            this.idArticuloTextBox.Text = idArticulo;
            this.articuloTextBox.Text = nombre;
        }

        public frmIngreso()
        {
            InitializeComponent();
            //this.ttMensaje.SetToolTip(this.proveedorTextBox, "Seleccione el proveedor");
            //this.ttMensaje.SetToolTip(this.serieTextBox, "Ingrese la serie del comprobante");
            //this.ttMensaje.SetToolTip(this.serieTextBox, "Ingrese el número del comprobante");
            //this.ttMensaje.SetToolTip(this.stockInicialTextBox, "Ingrese la cantidad de compra");
            //this.ttMensaje.SetToolTip(this.articuloTextBox, "Seleccione el artículo de compra");
            this.idProveedorTextBox.Visible = false;
            this.idArticuloTextBox.Visible = false;
            this.proveedorTextBox.ReadOnly = true;
            this.articuloTextBox.ReadOnly = true;

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
            this.ingresoTextBox.Text = string.Empty;
            this.idProveedorTextBox.Text = string.Empty;
            this.proveedorTextBox.Text = string.Empty;
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
            this.stockInicialTextBox.Text = string.Empty;
            this.precioCompraTextBox.Text = string.Empty;
            this.precioVentaTextBox.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.ingresoTextBox.ReadOnly = true;
            this.serieTextBox.ReadOnly = !valor;
            this.correlativoTextBox.ReadOnly = !valor;
            this.ivaTextBox.ReadOnly = !valor;
            this.fechaIngresodateTimePicker.Enabled = valor;
            this.comprobanteComboBox.Enabled = valor;
            this.comprobanteComboBox.SelectedIndex = -1;
            this.stockInicialTextBox.ReadOnly = !valor;
            this.precioCompraTextBox.ReadOnly = !valor;
            this.precioVentaTextBox.ReadOnly = !valor;
            this.fechaProduccionDateTimePicker.Enabled = valor;
            this.fechaVencimientoDateTimePicker.Enabled = valor;

            this.buscarArticuloButton.Enabled = valor;
            this.buscarProveedorButton.Enabled = valor;
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
            this.listadoDataGridView.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            totalRegistrosLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.listadoDataGridView.DataSource = 
                NIngreso.BuscarFechas(this.fechaInicioDateTimePicker.Value.ToString("yyyy/MM/dd"),
                this.fechaFinalDateTimePicker.Value.ToString("yyyy/MM/dd"));
            this.OcultarColumnas();
            totalRegistrosLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void MostrarDetalle()
        {
            this.listadoDetalleDataGridView.DataSource = NIngreso.MostrarDetalle(this.ingresoTextBox.Text);
        }


        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
            this.Mostrar();
            this.PersonalizarGrillaListado();
        }

        private void buscarProveedorButton_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso miForm = new frmVistaProveedor_Ingreso();
            miForm.ShowDialog();
        }

        private void buscarArticuloButton_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Ingreso miForm = new frmVistaArticulo_Ingreso();
            miForm.ShowDialog();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            BuscarFechas();
            PersonalizarGrillaListado();
        }

        private void anularButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("realmente desea anular los registros?", "Sistema de Ventas",
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
                            rpta = NIngreso.Anular(Convert.ToInt32(codigo));

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

        private void anularCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (anularCheckBox.Checked)
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


        private void CrearTabla()
        {
            //Crea el detalle de la venta
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar nuestro Datagrid con nuestro Datatable
            this.listadoDataGridView.DataSource = null;
            this.listadoDetalleDataGridView.DataSource = dtDetalle;
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
            string rpta = "";

            try
            {
                if (this.IsNuevo)
                {
                    rpta = NIngreso.Insertar(IdEmpleado, Convert.ToInt32(idProveedorTextBox.Text.Trim()),
                        fechaIngresodateTimePicker.Value, comprobanteComboBox.Text,
                        serieTextBox.Text, correlativoTextBox.Text, Convert.ToDecimal(ivaTextBox.Text),
                        "ACTIVO", dtDetalle);
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
                this.PersonalizarGrillaListado();
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

            if (string.IsNullOrEmpty(proveedorTextBox.Text))
            {
                errorProvider1.SetError(proveedorTextBox, "Debe seleccionar un proveedor");
                proveedorTextBox.Focus();
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
                
            return true;
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.comprobanteComboBox.Focus();
            this.LimpiarDetalle();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string rpta = "";
                if (idArticuloTextBox.Text == string.Empty ||
                    stockInicialTextBox.Text == string.Empty ||
                    precioCompraTextBox.Text == string.Empty ||
                    precioVentaTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(idArticuloTextBox, "Ingrese un valor");
                    errorProvider1.SetError(stockInicialTextBox, "Ingrese un valor");
                    errorProvider1.SetError(precioCompraTextBox, "Ingrese un valor");
                    errorProvider1.SetError(precioVentaTextBox, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    //Comprueba si el artículo está en la lista del ingreso
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if(Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.idArticuloTextBox.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra agregado el artículo");
                        }
                    }

                    if (registrar)
                    {
                        decimal subTotal = 
                            Convert.ToInt32(this.stockInicialTextBox.Text) * Convert.ToInt32(this.precioCompraTextBox.Text);
                        totalPagado = totalPagado + subTotal;
                        this.totalPagadoLabel.Text = totalPagado.ToString("#0.00#");

                        //Agregar detalle al ListadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.idArticuloTextBox.Text);
                        row["articulo"] = this.articuloTextBox.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.precioCompraTextBox.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.precioVentaTextBox.Text);
                        row["stock_inicial"] = Convert.ToDouble(this.stockInicialTextBox.Text);
                        row["fecha_produccion"] = fechaProduccionDateTimePicker.Value;
                        row["fecha_vencimiento"] = fechaVencimientoDateTimePicker.Value;
                        row["subtotal"] = subTotal;

                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();
                    }
                }

                this.PersonalizarGrillaProducto();
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

            this.PersonalizarGrillaProducto();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            //Columnas del [spmostrar_ingreso]
            this.ingresoTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["IdIngreso"].Value.ToString();
            this.fechaIngresodateTimePicker.Value = 
                Convert.ToDateTime(this.listadoDataGridView.CurrentRow.Cells["Fecha"].Value);
            this.comprobanteComboBox.Text = this.listadoDataGridView.CurrentRow.Cells["Tipo_comprobante"].Value.ToString();
            this.proveedorTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Proveedor"].Value.ToString();
            this.serieTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Serie"].Value.ToString();
            this.correlativoTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Correlativo"].Value.ToString();
            this.ivaTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Impuesto"].Value.ToString();
            this.totalRegistrosLabel.Text = this.listadoDataGridView.CurrentRow.Cells["Total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
            PersonalizarGrillaListado();
        }

        private void PersonalizarGrillaListado()
        {
            //listadoDataGridView.Columns["Imprimir"].ReadOnly = false;

            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["IdIngreso"].HeaderText = "Id";
            listadoDataGridView.Columns["IdIngreso"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDataGridView.Columns["IdIngreso"].Width = 80;
            listadoDataGridView.Columns["IdIngreso"].ReadOnly = true;

            listadoDataGridView.Columns["Empleado"].HeaderText = "Empleado";
            listadoDataGridView.Columns["Empleado"].Width = 150;
            listadoDataGridView.Columns["Empleado"].ReadOnly = false;

            listadoDataGridView.Columns["Fecha"].HeaderText = "Fecha";
            listadoDataGridView.Columns["Fecha"].Width = 80;
            listadoDataGridView.Columns["Fecha"].ReadOnly = false;

            listadoDataGridView.Columns["Tipo_comprobante"].HeaderText = "Tipo Comprobante";
            listadoDataGridView.Columns["Tipo_comprobante"].Width = 100;
            listadoDataGridView.Columns["Tipo_comprobante"].ReadOnly = false;

            listadoDataGridView.Columns["Proveedor"].HeaderText = "Proveedor";
            listadoDataGridView.Columns["Proveedor"].Width = 150;
            listadoDataGridView.Columns["Proveedor"].ReadOnly = false;

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

        private void PersonalizarGrillaProducto()
        {
            listadoDetalleDataGridView.Columns["idarticulo"].HeaderText = "Id Artículo";
            listadoDetalleDataGridView.Columns["idarticulo"].Width = 60;
            listadoDetalleDataGridView.Columns["idarticulo"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["articulo"].HeaderText = "Artículo";
            listadoDetalleDataGridView.Columns["articulo"].Width = 150;
            listadoDetalleDataGridView.Columns["articulo"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["precio_compra"].HeaderText = "Precio Compra";
            listadoDetalleDataGridView.Columns["precio_compra"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["precio_compra"].DefaultCellStyle.Format = "C2";
            listadoDetalleDataGridView.Columns["precio_compra"].Width = 100;
            listadoDetalleDataGridView.Columns["precio_compra"].ReadOnly = true;

            listadoDetalleDataGridView.Columns["precio_venta"].HeaderText = "Precio Venta";
            listadoDetalleDataGridView.Columns["precio_venta"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["precio_venta"].DefaultCellStyle.Format = "C2";
            listadoDetalleDataGridView.Columns["precio_venta"].Width = 100;
            listadoDetalleDataGridView.Columns["precio_venta"].ReadOnly = true;

            listadoDetalleDataGridView.Columns["stock_inicial"].HeaderText = "Stock Inicial";
            listadoDetalleDataGridView.Columns["stock_inicial"].Width = 80;
            listadoDetalleDataGridView.Columns["stock_inicial"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            listadoDetalleDataGridView.Columns["stock_inicial"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["fecha_produccion"].HeaderText = "Fecha Producción";
            listadoDetalleDataGridView.Columns["fecha_produccion"].Width = 150;
            listadoDetalleDataGridView.Columns["fecha_produccion"].ReadOnly = false;

            listadoDetalleDataGridView.Columns["fecha_vencimiento"].HeaderText = "Fecha Vencimiento";
            listadoDetalleDataGridView.Columns["fecha_vencimiento"].Width = 150;
            listadoDetalleDataGridView.Columns["fecha_vencimiento"].ReadOnly = false;

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
