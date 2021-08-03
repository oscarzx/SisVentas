using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmArticulo : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static frmArticulo _Instancia;

        public static frmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }

        public void SetCategoria(string idCategoria, string nombre)
        {
            this.idCategoriaTextBox.Text = idCategoria;
            this.categoriaTextBox.Text = nombre;
        }

        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.nombreTextBox, "Ingrese el nombre del artículo");
            this.ttMensaje.SetToolTip(this.imagenPictureBox, "Seleccione la imagen del artículo");
            this.ttMensaje.SetToolTip(this.categoriaTextBox, "Seleccione la categoría del artículo");
            this.ttMensaje.SetToolTip(this.presentacionComboBox, "seleccione la presentación del artículo");

            this.idCategoriaTextBox.Visible = false;
            this.categoriaTextBox.ReadOnly = true;
            this.LlenarComboBoxPresentacion();
                
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
            this.idArticuloTextBox.Text = string.Empty;
            this.codigoTextBox.Text = string.Empty;
            this.categoriaTextBox.Text = string.Empty;
            this.imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imagenPictureBox.Image = global::CapaPresentacion.Properties.Resources.ImagenBlanco;
        }


        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.codigoTextBox.ReadOnly = !valor;
            this.nombreTextBox.ReadOnly = !valor;
            this.descripcionTextBox.ReadOnly = !valor;
            this.buscarCategoriaButton.Enabled = valor;
            this.presentacionComboBox.Enabled = valor;
            this.cargarButton.Enabled = valor;
            this.limpiarImagenButton.Enabled = valor;
            this.presentacionComboBox.SelectedIndex = -1;
            this.idArticuloTextBox.ReadOnly = !valor;
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
            this.listadoDataGridView.Columns[6].Visible = false;
            this.listadoDataGridView.Columns[8].Visible = false;
        }

        //Método mostrar
        private void Mostrar()
        {
            this.listadoDataGridView.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.listadoDataGridView.DataSource = NArticulo.BuscarNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void LlenarComboBoxPresentacion()
        {
            presentacionComboBox.DataSource = NPresentacion.Mostrar();
            presentacionComboBox.ValueMember = "idPresentacion";
            presentacionComboBox.DisplayMember = "nombre";
        }

        private void cargarButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                this.imagenPictureBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void limpiarImagenButton_Click(object sender, EventArgs e)
        {
            this.imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.imagenPictureBox.Image = global::CapaPresentacion.Properties.Resources.ImagenBlanco;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
            this.codigoTextBox.Focus();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (nombreTextBox.Text == string.Empty || 
                    idCategoriaTextBox.Text == string.Empty || 
                    codigoTextBox.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProvider1.SetError(nombreTextBox, "Ingrese un valor");
                    errorProvider1.SetError(idCategoriaTextBox, "Ingrese un valor");
                    errorProvider1.SetError(codigoTextBox, "Ingrese un valor");
                }
                else
                {
                    MemoryStream memoryStream = new MemoryStream();
                    this.imagenPictureBox.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = memoryStream.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(codigoTextBox.Text.Trim(), nombreTextBox.Text.Trim().ToUpper(), 
                            descripcionTextBox.Text.Trim(), imagen, Convert.ToInt32(idCategoriaTextBox.Text), 
                            Convert.ToInt32(presentacionComboBox.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(idArticuloTextBox.Text), 
                            codigoTextBox.Text.Trim(), nombreTextBox.Text.Trim().ToUpper(),
                            descripcionTextBox.Text.Trim(), imagen, Convert.ToInt32(idCategoriaTextBox.Text),
                            Convert.ToInt32(presentacionComboBox.SelectedValue));
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

            if (!this.idArticuloTextBox.Text.Equals(""))
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
            idArticuloTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdArticulo"].Value.ToString();
            codigoTextBox.Text = listadoDataGridView.CurrentRow.Cells["CodigoArticulo"].Value.ToString();
            nombreTextBox.Text = listadoDataGridView.CurrentRow.Cells["NombreArticulo"].Value.ToString();
            descripcionTextBox.Text = listadoDataGridView.CurrentRow.Cells["DescripcionArticulo"].Value.ToString();

            byte[] imagenBuffer = (byte[])this.listadoDataGridView.CurrentRow.Cells["ImagenArticulo"].Value;
            MemoryStream memoryStream = new MemoryStream(imagenBuffer);

            this.imagenPictureBox.Image = Image.FromStream(memoryStream);
            this.imagenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            idCategoriaTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdCategoria"].Value.ToString();
            categoriaTextBox.Text = listadoDataGridView.CurrentRow.Cells["Categoria"].Value.ToString();
            presentacionComboBox.SelectedValue = listadoDataGridView.CurrentRow.Cells["IdPresentacion"].Value.ToString();
            idCategoriaTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdCategoria"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
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
                            rpta = NArticulo.Eliminar(Convert.ToInt32(codigo));

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

        private void buscarCategoriaButton_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_articulo form = new frmVistaCategoria_articulo();
            form.ShowDialog();
        }
    }
}
