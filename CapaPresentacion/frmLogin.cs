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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            horaLabel.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            horaLabel.Text = DateTime.Now.ToString();
        }

        private void salirButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = NEmpleado.Login(usuarioTextBox.Text, passwordTextBox.Text);

            if (dataTable.Rows.Count == 0)
                MessageBox.Show("Usuario o contraseña incorrectos", "Sistema de Ventas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                frmPrincipal miForm = new frmPrincipal();
                miForm.IdEmpleado = dataTable.Rows[0][0].ToString();
                miForm.Apellido = dataTable.Rows[0][1].ToString();
                miForm.Nombre= dataTable.Rows[0][2].ToString();
                miForm.Acceso = dataTable.Rows[0][3].ToString();

                miForm.Show();
                this.Hide();
            }
        }
    }
}
