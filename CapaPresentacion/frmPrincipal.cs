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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;

        public string IdEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Acceso { get; set; }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo miForm = frmArticulo.GetInstancia();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria miForm = new frmCategoria();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion miForm = new frmPresentacion();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor miForm = new frmProveedor();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente miForm = new frmCliente();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado miForm = new frmEmpleado();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            helpMenu.Visible = false;
            windowsMenu.Visible = false;
            herramientasMenu.Visible = false;
            toolStrip.Visible = false;
            GestionPermisoUsuario();
        }

        private void GestionPermisoUsuario()
        {
            if (Acceso == "Administrador")
            {
                archivoMenu.Enabled = true;
                almacenMenu.Enabled = true;
                comprasMenu.Enabled = true;
                ventasMenu.Enabled = true;
                verMenu.Enabled = true;
                mantenimientoMenu.Enabled = true;
                consultasMenu.Enabled = true;
                herramientasMenu.Enabled = true;
            }

            else if (Acceso == "Vendedor")
            {
                archivoMenu.Enabled = true;
                almacenMenu.Enabled = false;
                comprasMenu.Enabled = false;
                ventasMenu.Enabled = true;
                verMenu.Enabled = true;
                mantenimientoMenu.Enabled = false;
                consultasMenu.Enabled = true;
                herramientasMenu.Enabled = false;
            }

            else if (Acceso == "Bodeguero")
            {
                archivoMenu.Enabled = true;
                almacenMenu.Enabled = false;
                comprasMenu.Enabled = false;
                ventasMenu.Enabled = false;
                verMenu.Enabled = true;
                mantenimientoMenu.Enabled = false;
                consultasMenu.Enabled = true;
                herramientasMenu.Enabled = false;
            }

            else
            {
                archivoMenu.Enabled = false;
                almacenMenu.Enabled = false;
                comprasMenu.Enabled = false;
                ventasMenu.Enabled = false;
                verMenu.Enabled = false;
                mantenimientoMenu.Enabled = false;
                consultasMenu.Enabled = false;
                herramientasMenu.Enabled = false;
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso miForm = frmIngreso.GetInstance();
            miForm.MdiParent = this;
            miForm.Show();
            miForm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta miForm = frmVenta.GetInstance();
            miForm.MdiParent = this;
            miForm.Show();
            miForm.IdEmpleado = Convert.ToInt32(this.IdEmpleado);
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.frmConsulta_Stock_Articulos miForm = new Consultas.frmConsulta_Stock_Articulos();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaja miForm = new frmCaja();
            miForm.MdiParent = this;
            miForm.Show();
        }
    }
}
