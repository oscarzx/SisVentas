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
    public partial class frmEmpleado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmEmpleado()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(nombreTextBox, "Ingrese el nombre del empleado");
            this.ttMensaje.SetToolTip(apellidosTextBox, "Ingrese el apellido del empleado");
            this.ttMensaje.SetToolTip(direccionTextBox, "Ingrese la dirección del empleado");
            this.ttMensaje.SetToolTip(numeroDocumentoTextBox, "Ingrese el número de documento del empleado");
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
            this.idEmpleadoTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidosTextBox.Text = string.Empty;
            this.generoComboBox.SelectedIndex = -1;
            this.direccionTextBox.Text = string.Empty;
            this.numeroDocumentoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.accesoComboBox.SelectedIndex = -1;
            this.usuarioTextBox.Text = string.Empty;
            this.passwordTextBox.Text = string.Empty;

            generoComboBox.SelectedIndex = -1;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.idEmpleadoTextBox.ReadOnly = true;
            this.nombreTextBox.ReadOnly = !valor;
            this.apellidosTextBox.ReadOnly = !valor;
            this.direccionTextBox.ReadOnly = !valor;
            this.numeroDocumentoTextBox.ReadOnly = !valor;
            this.telefonoTextBox.ReadOnly = !valor;
            this.emailTextBox.ReadOnly = !valor;
            this.usuarioTextBox.ReadOnly = !valor;
            this.passwordTextBox.ReadOnly = !valor;

            generoComboBox.Enabled = valor;
            accesoComboBox.Enabled = valor;
            fechaDateTimePicker.Enabled = valor;
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
            this.listadoDataGridView.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarApellido
        private void BuscarApellido()
        {
            this.listadoDataGridView.DataSource = NEmpleado.BuscarApellido(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarEmpleado_Documento
        private void BuscarEmpleado_Documento()
        {
            this.listadoDataGridView.DataSource = NEmpleado.BuscarEmpleado_Documento(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            PersonalizarGrilla();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (buscarComboBox.SelectedIndex == -1) return;

            if (buscarComboBox.Text.Equals("Documento"))
            {
                BuscarEmpleado_Documento();
            }
            else if (buscarComboBox.Text.Equals("Apellido"))
            {
                BuscarApellido();
            }
            PersonalizarGrilla();
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
                            rpta = NEmpleado.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                                this.MensajeOk("Se eliminó correctamente el registro");
                            else
                                this.MensajeError(rpta);
                        }
                    }
                    this.Mostrar();
                    PersonalizarGrilla();
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
            idEmpleadoTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdEmprelado"].Value.ToString();
            nombreTextBox.Text = listadoDataGridView.CurrentRow.Cells["Nombre_empleado"].Value.ToString();
            apellidosTextBox.Text = listadoDataGridView.CurrentRow.Cells["Apellidos_empleado"].Value.ToString();
            generoComboBox.Text = listadoDataGridView.CurrentRow.Cells["Genero"].Value.ToString();
            fechaDateTimePicker.Value = Convert.ToDateTime(listadoDataGridView.CurrentRow.Cells["Fehca_naciemiento"].Value);
            numeroDocumentoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Numero_documento"].Value.ToString();
            direccionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Direccion"].Value.ToString();
            telefonoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
            emailTextBox.Text = listadoDataGridView.CurrentRow.Cells["Email"].Value.ToString();
            accesoComboBox.Text = listadoDataGridView.CurrentRow.Cells["Acceso"].Value.ToString();
            usuarioTextBox.Text = listadoDataGridView.CurrentRow.Cells["Usuario"].Value.ToString();
            passwordTextBox.Text = listadoDataGridView.CurrentRow.Cells["Password"].Value.ToString();

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
                    apellidosTextBox.Text == string.Empty ||
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
                        rpta = NEmpleado.Insertar(nombreTextBox.Text.Trim().ToUpper(),
                            apellidosTextBox.Text.Trim().ToUpper(),
                            generoComboBox.Text,
                            fechaDateTimePicker.Value,
                            numeroDocumentoTextBox.Text.Trim(),
                            direccionTextBox.Text.Trim(),
                            telefonoTextBox.Text.Trim(),
                            emailTextBox.Text.Trim(), 
                            accesoComboBox.Text, 
                            usuarioTextBox.Text.Trim().ToUpper(), 
                            passwordTextBox.Text.Trim());
                    }
                    else
                    {
                        rpta = NEmpleado.Editar(Convert.ToInt32(idEmpleadoTextBox.Text), 
                            nombreTextBox.Text.Trim().ToUpper(),
                            apellidosTextBox.Text.Trim().ToUpper(),
                            generoComboBox.Text,
                            fechaDateTimePicker.Value,
                            numeroDocumentoTextBox.Text.Trim(),
                            direccionTextBox.Text.Trim(),
                            telefonoTextBox.Text.Trim(),
                            emailTextBox.Text.Trim(),
                            accesoComboBox.Text,
                            usuarioTextBox.Text.Trim().ToUpper(),
                            passwordTextBox.Text.Trim());
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
                    PersonalizarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            if (!this.idEmpleadoTextBox.Text.Equals(""))
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
            PersonalizarGrilla();
            this.idEmpleadoTextBox.Text = string.Empty;
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["IdEmprelado"].HeaderText = "Id";
            listadoDataGridView.Columns["IdEmprelado"].Width = 50;
            listadoDataGridView.Columns["IdEmprelado"].ReadOnly = false;

            listadoDataGridView.Columns["Nombre_empleado"].HeaderText = "Nombre";
            listadoDataGridView.Columns["Nombre_empleado"].Width = 150;
            listadoDataGridView.Columns["Nombre_empleado"].ReadOnly = false;

            listadoDataGridView.Columns["Apellidos_empleado"].HeaderText = "Apellido";
            listadoDataGridView.Columns["Apellidos_empleado"].Width = 150;
            listadoDataGridView.Columns["Apellidos_empleado"].ReadOnly = false;

            listadoDataGridView.Columns["Genero"].HeaderText = "Género";
            listadoDataGridView.Columns["Genero"].Width = 50;
            listadoDataGridView.Columns["Genero"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            listadoDataGridView.Columns["Genero"].ReadOnly = false;

            listadoDataGridView.Columns["Fehca_naciemiento"].HeaderText = "Fecha Nacimiento";
            listadoDataGridView.Columns["Fehca_naciemiento"].Width = 80;
            listadoDataGridView.Columns["Fehca_naciemiento"].ReadOnly = false;

            listadoDataGridView.Columns["Numero_documento"].HeaderText = "N. Documento";
            listadoDataGridView.Columns["Numero_documento"].Width = 80;
            listadoDataGridView.Columns["Numero_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Direccion"].HeaderText = "Dirección";
            listadoDataGridView.Columns["Direccion"].Width = 100;
            listadoDataGridView.Columns["Direccion"].ReadOnly = false;

            listadoDataGridView.Columns["Telefono"].HeaderText = "Teléfono";
            listadoDataGridView.Columns["Telefono"].Width = 80;
            listadoDataGridView.Columns["Telefono"].ReadOnly = false;

            listadoDataGridView.Columns["Email"].HeaderText = "Email";
            listadoDataGridView.Columns["Email"].Width = 80;
            listadoDataGridView.Columns["Email"].ReadOnly = false;

            listadoDataGridView.Columns["Acceso"].HeaderText = "Acceso";
            listadoDataGridView.Columns["Acceso"].Width = 80;
            listadoDataGridView.Columns["Acceso"].ReadOnly = false;

            listadoDataGridView.Columns["Usuario"].HeaderText = "Usuario";
            listadoDataGridView.Columns["Usuario"].Width = 80;
            listadoDataGridView.Columns["Usuario"].ReadOnly = false;

            listadoDataGridView.Columns["Password"].HeaderText = "Password";
            listadoDataGridView.Columns["Password"].Width = 80;
            listadoDataGridView.Columns["Password"].ReadOnly = false;

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
