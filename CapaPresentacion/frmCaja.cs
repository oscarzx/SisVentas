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
using System.Management;

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
            this.idCajaTextBox.ReadOnly = true;
            this.descripcionTextBox.ReadOnly = !valor;
            this.serialTextBox.ReadOnly = !valor;
            //this.idCajaTextBox.ReadOnly = !valor;
            this.impresoraPosTextBox.ReadOnly = !valor;
            this.impresoraReporteTextBox.ReadOnly = !valor;
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
                this.buscarSerialPCButton.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.nuevoButton.Enabled = true;
                this.guardarButton.Enabled = false;
                this.editarButton.Enabled = true;
                this.cancelarButton.Enabled = false;
                this.buscarSerialPCButton.Enabled = false;
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
            this.listadoDataGridView.DataSource = NCaja.MostrarListado();
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

            listadoDataGridView.Columns["Descripcion"].HeaderText = "Descripción";
            listadoDataGridView.Columns["Descripcion"].Width = 150;
            listadoDataGridView.Columns["Descripcion"].ReadOnly = false;

            //listadoDataGridView.Columns["Descripcion"].HeaderText = "Descripción";
            //listadoDataGridView.Columns["Descripcion"].Width = 300;
            //listadoDataGridView.Columns["Descripcion"].ReadOnly = false;

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
                        impresoraPosTextBox.Text.Trim(), impresoraReporteTextBox.Text.Trim());
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
            if (e.ColumnIndex == listadoDataGridView.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)listadoDataGridView.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            if (!this.idCajaTextBox.Text.Equals(""))
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

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            idCajaTextBox.Text = listadoDataGridView.CurrentRow.Cells["IdCaja"].Value.ToString();
            //nombreTextBox.Text = listadoDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            descripcionTextBox.Text = listadoDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
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
                            rpta = NCaja.Eliminar(Convert.ToInt32(codigo));

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

        private void buscarSerialPCButton_Click(object sender, EventArgs e)
        {
            try
            {
                //ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

                //foreach (ManagementObject getSerial in mos.Get())
                //{
                //    serialTextBox.Text = getSerial.GetPropertyValue("Manufacturer").ToString();
                //}

                string modelNo = identifier("Win32_DiskDrive", "Model");
                string manufatureID = identifier("Win32_DiskDrive", "Manufacturer");
                string signature = identifier("Win32_DiskDrive", "Signature");
                string totalHeads = identifier("Win32_DiskDrive", "TotalHeads");
                string serial = identifier("Win32_DiskDrive", "SerialNumber");
                serialTextBox.Text = serial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
    }
}
