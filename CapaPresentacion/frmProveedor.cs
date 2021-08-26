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
            PersonalizarGrilla();
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
                            rpta = NProveedor.Eliminar(Convert.ToInt32(codigo));

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
            PersonalizarGrilla();
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.razonSocialTextBox.Focus();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (razonSocialTextBox.Text == string.Empty ||
                    numeroDocumentoTextBox.Text==string.Empty ||
                    direccionTextBox.Text==string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(razonSocialTextBox, "Ingrese un valor");
                    errorProvider1.SetError(numeroDocumentoTextBox, "Ingrese un valor");
                    errorProvider1.SetError(direccionTextBox, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(razonSocialTextBox.Text.Trim().ToUpper(),
                            sectorComercialComboBox.Text,
                            tipoDocumentoComboBox.Text,
                            numeroDocumentoTextBox.Text.Trim(),
                            direccionTextBox.Text.Trim(),
                            telefonoTextBox.Text.Trim(),
                            emailTextBox.Text.Trim(),
                            urlTextBox.Text.Trim());
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(idProveedorTextBox.Text), 
                            razonSocialTextBox.Text.Trim().ToUpper(),
                           sectorComercialComboBox.Text,
                           tipoDocumentoComboBox.Text,
                           numeroDocumentoTextBox.Text.Trim(),
                           direccionTextBox.Text.Trim(),
                           telefonoTextBox.Text.Trim(),
                           emailTextBox.Text.Trim(),
                           urlTextBox.Text.Trim());
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
            if (!this.idProveedorTextBox.Text.Equals(""))
            {
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
            this.Limpiar();
            this.idProveedorTextBox.Text = string.Empty;
            PersonalizarGrilla();
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
            idProveedorTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdProveedor"].Value.ToString();
            razonSocialTextBox.Text = listadoDataGridView.CurrentRow.Cells["Razon_social"].Value.ToString();
            sectorComercialComboBox.Text= listadoDataGridView.CurrentRow.Cells["Sector_comercial"].Value.ToString();
            tipoDocumentoComboBox.Text = listadoDataGridView.CurrentRow.Cells["Tipo_documento"].Value.ToString();
            numeroDocumentoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Num_documento"].Value.ToString();
            direccionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Direccion_proveedor"].Value.ToString();
            telefonoTextBox.Text = listadoDataGridView.CurrentRow.Cells["Telefono"].Value.ToString();
            emailTextBox.Text = listadoDataGridView.CurrentRow.Cells["Email"].Value.ToString();
            urlTextBox.Text = listadoDataGridView.CurrentRow.Cells["Url"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["Razon_social"].HeaderText = "Razón Social";
            listadoDataGridView.Columns["Razon_social"].Width = 150;
            listadoDataGridView.Columns["Razon_social"].ReadOnly = false;

            listadoDataGridView.Columns["Sector_comercial"].HeaderText = "Sector Comercial";
            listadoDataGridView.Columns["Sector_comercial"].Width = 80;
            listadoDataGridView.Columns["Sector_comercial"].ReadOnly = false;

            listadoDataGridView.Columns["Tipo_documento"].HeaderText = "Tipo Documento";
            listadoDataGridView.Columns["Tipo_documento"].Width = 80;
            listadoDataGridView.Columns["Tipo_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Num_documento"].HeaderText = "N. Documento";
            listadoDataGridView.Columns["Num_documento"].Width = 100;
            listadoDataGridView.Columns["Num_documento"].ReadOnly = false;

            listadoDataGridView.Columns["Direccion_proveedor"].HeaderText = "Dirección";
            listadoDataGridView.Columns["Direccion_proveedor"].Width = 200;
            listadoDataGridView.Columns["Direccion_proveedor"].ReadOnly = false;

            listadoDataGridView.Columns["Telefono"].HeaderText = "Teléfono";
            listadoDataGridView.Columns["Telefono"].Width = 100;
            listadoDataGridView.Columns["Telefono"].ReadOnly = false;

            listadoDataGridView.Columns["Email"].HeaderText = "Email";
            listadoDataGridView.Columns["Email"].Width = 100;
            listadoDataGridView.Columns["Email"].ReadOnly = false;

            listadoDataGridView.Columns["Url"].HeaderText = "Url";
            listadoDataGridView.Columns["Url"].Width = 100;
            listadoDataGridView.Columns["Url"].ReadOnly = false;

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
