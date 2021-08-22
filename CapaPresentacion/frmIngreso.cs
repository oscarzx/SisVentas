﻿using System;
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
            this.ttMensaje.SetToolTip(this.proveedorTextBox, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.serieTextBox, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.serieTextBox, "Ingrese el número del comprobante");
            this.ttMensaje.SetToolTip(this.stockInicialTextBox, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.articuloTextBox, "Seleccione el artículo de compra");
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
            this.ingresoTextBox.ReadOnly = !valor;
            this.serieTextBox.ReadOnly = !valor;
            this.correlativoTextBox.ReadOnly = !valor;
            this.ivaTextBox.ReadOnly = !valor;
            this.fechaIngresodateTimePicker.Enabled = valor;
            this.comprobanteComboBox.Enabled = valor;
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
            //this.listadoDataGridView.Columns[6].Visible = false;
            //this.listadoDataGridView.Columns[8].Visible = false;
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
                NIngreso.BuscarFechas(this.fechaInicioDateTimePicker.Value.ToString("dd/MM/yyyy"),
                this.fechaFinalDateTimePicker.Value.ToString("dd/MM/yyyy"));
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
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (idProveedorTextBox.Text == string.Empty ||
                    serieTextBox.Text == string.Empty ||
                    correlativoTextBox.Text == string.Empty ||
                    ivaTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(idProveedorTextBox, "Ingrese un valor");
                    errorProvider1.SetError(serieTextBox, "Ingrese un valor");
                    errorProvider1.SetError(correlativoTextBox, "Ingrese un valor");
                    errorProvider1.SetError(correlativoTextBox, "Ingrese un valor");
                }
                else
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.serieTextBox.Focus();
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
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            //Columnas del [spmostrar_ingreso]
            this.ingresoTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["IdIngreso"].Value.ToString();
            this.fechaIngresodateTimePicker.Value = 
                Convert.ToDateTime(this.listadoDataGridView.CurrentRow.Cells["Fecha"].Value);
            this.comprobanteComboBox.Text = this.listadoDataGridView.CurrentRow.Cells["Tipo_comprobante"].Value.ToString();
            this.serieTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Serie"].Value.ToString();
            this.correlativoTextBox.Text = this.listadoDataGridView.CurrentRow.Cells["Correlativo"].Value.ToString();
            this.totalRegistrosLabel.Text = this.listadoDataGridView.CurrentRow.Cells["Total"].Value.ToString();
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
