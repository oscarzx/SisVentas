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
    public partial class frmPresentacion : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        public frmPresentacion()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.nombreTextBox, "Ingrese el nombre de la presentación");
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
            this.nombreTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
            this.idPresentacionTextBox.Text = string.Empty;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.nombreTextBox.ReadOnly = !valor;
            this.descripcionTextBox.ReadOnly = !valor;
            this.idPresentacionTextBox.ReadOnly = !valor;
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
            this.listadoDataGridView.DataSource = NPresentacion.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.listadoDataGridView.DataSource = NPresentacion.BuscarNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
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
            this.BuscarNombre();
            PersonalizarGrilla();
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                if (nombreTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(nombreTextBox, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NPresentacion.Insertar(nombreTextBox.Text.Trim().ToUpper(),
                            descripcionTextBox.Text.Trim());
                    }
                    else
                    {
                        rpta = NPresentacion.Editar(Convert.ToInt32(idPresentacionTextBox  .Text),
                            nombreTextBox.Text.Trim().ToUpper(), descripcionTextBox.Text.Trim());
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
            if (!this.idPresentacionTextBox.Text.Equals(""))
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
            this.Habilitar(false);
            PersonalizarGrilla();
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
                            rpta = NPresentacion.Eliminar(Convert.ToInt32(codigo));

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
            idPresentacionTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdPresentacion"].Value.ToString();
            nombreTextBox.Text = listadoDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            descripcionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
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

    }
}
