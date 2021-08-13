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
    public partial class frmIngreso : Form
    {
        public int IdEmpleado { get; set; }

        private static frmIngreso _instancia;

        public static frmIngreso GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }

        public void SetProveedor(string idProveedor, string nombre)
        {
            this.idProveedorTextBox.Text = idProveedor;
            this.proveedorTextBox.Text = nombre;
        }

        public void SetArticulo(string idArticulo, string nombre)
        {
            this.idArticuloTextBox.Text = idArticulo;
            this.articuloTextBox.Text = nombre;
        }

        public frmIngreso()
        {
            InitializeComponent();
        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {

        }

        private void buscarProveedorButton_Click(object sender, EventArgs e)
        {
            frmVistaProveedor_Ingreso miForm = new frmVistaProveedor_Ingreso();
            miForm.ShowDialog();
        }

        private void buscarArticuloButton_Click(object sender, EventArgs e)
        {
            frmVistaArticulo_Ingreso miForm = new frmVistaArticulo_Ingreso();
            miForm.ShowDialog();
        }
    }
}
