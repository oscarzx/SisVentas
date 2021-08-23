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

namespace CapaPresentacion.Consultas
{
    public partial class frmConsulta_Stock_Articulos : Form
    {
        public frmConsulta_Stock_Articulos()
        {
            InitializeComponent();
        }

        //Ocultar columnas
        private void OcultarColumnas()
        {
            this.listadoDataGridView.Columns[0].Visible = false;
            
        }

        //Método mostrar
        private void Mostrar()
        {
            this.listadoDataGridView.DataSource = NArticulo.StockArticulos();
            this.OcultarColumnas();
            totalLabel.Text = $"Total registros: {Convert.ToString(listadoDataGridView.Rows.Count)}";
        }

        private void frmConsulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
