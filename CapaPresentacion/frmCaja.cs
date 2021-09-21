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
    public partial class frmCaja : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCaja()
        {
            InitializeComponent();
        }

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
            this.descripcionTextBox.Text = string.Empty;
            this.serialTextBox.Text = string.Empty;
            this.idCajaTextBox.Text = string.Empty;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.descripcionTextBox.ReadOnly = !valor;
            this.serialTextBox.ReadOnly = !valor;
            this.idCajaTextBox.ReadOnly = !valor;
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
            this.listadoDataGridView.DataSource = NCaja.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.listadoDataGridView.DataSource = NCaja.BuscarCajaNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            PersonalizarGrilla();
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void PersonalizarGrilla()
        {
            listadoDataGridView.Columns["Eliminar"].HeaderText = "Eliminar";
            listadoDataGridView.Columns["Eliminar"].Width = 60;
            listadoDataGridView.Columns["Eliminar"].ReadOnly = false;

            listadoDataGridView.Columns["Nombre"].HeaderText = "Nombre Categoría";
            listadoDataGridView.Columns["Nombre"].Width = 150;
            listadoDataGridView.Columns["Nombre"].ReadOnly = false;

            listadoDataGridView.Columns["Descripcion"].HeaderText = "Descripción";
            listadoDataGridView.Columns["Descripcion"].Width = 300;
            listadoDataGridView.Columns["Descripcion"].ReadOnly = false;

            listadoDataGridView.EnableHeadersVisualStyles = false;
            listadoDataGridView.RowsDefaultCellStyle.BackColor = Color.CornflowerBlue;
            listadoDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
            listadoDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(listadoDataGridView.Font, FontStyle.Bold);
            listadoDataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.descripcionTextBox.Focus();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                string rpta = "";

                if (this.IsNuevo)
                {
                    rpta = NCaja.Insertar(descripcionTextBox.Text.Trim().ToUpper(),
                        serialTextBox.Text.Trim(), impresoraPosTextBox.Text.Trim(), 
                        impresoraReporteTextBox.Text.Trim());
                }
                else
                {
                    rpta = NCaja.Editar(Convert.ToInt32(idCajaTextBox.Text),
                        descripcionTextBox.Text.Trim().ToUpper(), serialTextBox.Text.Trim(),
                        impresoraPosTextBox.Text.Trim(), impresoraReporteTextBox.Text.Trim()1);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(descripcionTextBox.Text))
            {
                errorProvider1.SetError(descripcionTextBox, "Debe ingresar un nombre de caja");
                descripcionTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(serialTextBox.Text))
            {
                errorProvider1.SetError(serialTextBox, "Debe ingresar el serial del PC");
                serialTextBox.Focus();
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        private void listadoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idCajaTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdCaja"].Value.ToString();
            descripcionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
            //descripcionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
