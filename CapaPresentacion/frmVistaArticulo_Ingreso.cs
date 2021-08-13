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
    public partial class frmVistaArticulo_Ingreso : Form
    {
        public frmVistaArticulo_Ingreso()
        {
            InitializeComponent();
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

        private void frmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso miForm = frmIngreso.GetInstance();
            string par1, par2;
            par1 = this.listadoDataGridView.CurrentRow.Cells["IdArticulo"].Value.ToString();
            par2 = this.listadoDataGridView.CurrentRow.Cells["NombreArticulo"].Value.ToString();
            miForm.SetArticulo(par1, par2);
            this.Hide();
        }
    }
}
