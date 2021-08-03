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
    public partial class frmVistaCategoria_articulo : Form
    {
        public frmVistaCategoria_articulo()
        {
            InitializeComponent();
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
            this.listadoDataGridView.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.listadoDataGridView.DataSource = NCategoria.BuscarNombre(this.buscarTextBox.Text);
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void buscarTextBox_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void frmVista_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void listadoDataGridView_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();
            string par1, par2;

            par1 = this.listadoDataGridView.CurrentRow.Cells["IdCategoria"].Value.ToString();
            par2 = this.listadoDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            form.SetCategoria(par1, par2);
            this.Hide();
        }
    }
}
