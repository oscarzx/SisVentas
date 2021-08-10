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

        private void eliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("realmente desea eliminar los registros?", "Sistem de Ventas",
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
                            rpta = NCliente.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                                this.MensajeOk("Se eliminó correctamente el registro");
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

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            idClienteTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdCliente"].Value.ToString();
            nombreTextBox.Text = listadoDataGridView.CurrentRow.Cells["Nombre_cliente"].Value.ToString();
            apellidosTextBox.Text = listadoDataGridView.CurrentRow.Cells["Apellido_cliente"].Value.ToString();
            generoComboBox.Text = listadoDataGridView.CurrentRow.Cells["Genero"].Value.ToString();
            fechaDateTimePicker.Value = Convert.ToDateTime(listadoDataGridView.CurrentRow.Cells["Fecha_nacimiento"].Value);
            tipoDocumentoComboBox.Text = listadoDataGridView.CurrentRow.Cells["Tipo_documento"].Value.ToString();
            numeroDocumentoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Numero_documento"].Value.ToString();
            direccionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
            telefonoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
            emailTextBox.Text = listadoDataGridView.CurrentRow.Cells["Email"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.nombreTextBox.Focus();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (nombreTextBox.Text == string.Empty ||
                    apellidosTextBox.Text==string.Empty ||
                    numeroDocumentoTextBox.Text == string.Empty ||
                    direccionTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(nombreTextBox, "Ingrese un valor");
                    errorProvider1.SetError(apellidosTextBox, "Ingrese un valor");
                    errorProvider1.SetError(numeroDocumentoTextBox, "Ingrese un valor");
                    errorProvider1.SetError(direccionTextBox, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(nombreTextBox.Text.Trim().ToUpper(),
                            apellidosTextBox.Text.Trim().ToUpper(),
                            generoComboBox.Text,
                            fechaDateTimePicker.Value,
                            tipoDocumentoComboBox.Text,
                            numeroDocumentoTextBox.Text.Trim(),
                            direccionTextBox.Text.Trim(),
                            telefonoTextBox.Text.Trim(),
                            emailTextBox.Text.Trim());
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(idClienteTextBox.Text),
                            nombreTextBox.Text.Trim().ToUpper(),
                            apellidosTextBox.Text.Trim().ToUpper(),
                            generoComboBox.Text,
                            fechaDateTimePicker.Value,
                            tipoDocumentoComboBox.Text,
                            numeroDocumentoTextBox.Text.Trim(),
                            direccionTextBox.Text.Trim(),
                            telefonoTextBox.Text.Trim(),
                            emailTextBox.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            if (!this.idClienteTextBox.Text.Equals(""))
            {
                //this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.idClienteTextBox.Text = string.Empty;
        }
    }
}
