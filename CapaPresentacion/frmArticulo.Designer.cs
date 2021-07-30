
namespace CapaPresentacion
{
    partial class frmArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listadoDataGridView = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.totalLabel = new System.Windows.Forms.Label();
            this.eliminarCheckBox = new System.Windows.Forms.CheckBox();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.buscarTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.editarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.nuevoButton = new System.Windows.Forms.Button();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.idArticuloTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imagenPictureBox = new System.Windows.Forms.PictureBox();
            this.cargarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.idCategoriaTextBox = new System.Windows.Forms.TextBox();
            this.categoriaTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buscarCategoriaButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.presentacionComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 481);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listadoDataGridView);
            this.tabPage1.Controls.Add(this.totalLabel);
            this.tabPage1.Controls.Add(this.eliminarCheckBox);
            this.tabPage1.Controls.Add(this.imprimirButton);
            this.tabPage1.Controls.Add(this.eliminarButton);
            this.tabPage1.Controls.Add(this.buscarButton);
            this.tabPage1.Controls.Add(this.buscarTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1007, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listadoDataGridView
            // 
            this.listadoDataGridView.AllowUserToAddRows = false;
            this.listadoDataGridView.AllowUserToDeleteRows = false;
            this.listadoDataGridView.AllowUserToOrderColumns = true;
            this.listadoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listadoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.listadoDataGridView.Location = new System.Drawing.Point(6, 94);
            this.listadoDataGridView.MultiSelect = false;
            this.listadoDataGridView.Name = "listadoDataGridView";
            this.listadoDataGridView.ReadOnly = true;
            this.listadoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoDataGridView.Size = new System.Drawing.Size(995, 355);
            this.listadoDataGridView.TabIndex = 7;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(481, 75);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(35, 13);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "label3";
            // 
            // eliminarCheckBox
            // 
            this.eliminarCheckBox.AutoSize = true;
            this.eliminarCheckBox.Location = new System.Drawing.Point(35, 71);
            this.eliminarCheckBox.Name = "eliminarCheckBox";
            this.eliminarCheckBox.Size = new System.Drawing.Size(62, 17);
            this.eliminarCheckBox.TabIndex = 5;
            this.eliminarCheckBox.Text = "Eliminar";
            this.eliminarCheckBox.UseVisualStyleBackColor = true;
            // 
            // imprimirButton
            // 
            this.imprimirButton.Location = new System.Drawing.Point(353, 31);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(75, 23);
            this.imprimirButton.TabIndex = 4;
            this.imprimirButton.Text = "&Imprimir";
            this.imprimirButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            this.eliminarButton.Location = new System.Drawing.Point(272, 31);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(75, 23);
            this.eliminarButton.TabIndex = 3;
            this.eliminarButton.Text = "&Eliminar";
            this.eliminarButton.UseVisualStyleBackColor = true;
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(191, 31);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 2;
            this.buscarButton.Text = "&Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // buscarTextBox
            // 
            this.buscarTextBox.Location = new System.Drawing.Point(85, 33);
            this.buscarTextBox.Name = "buscarTextBox";
            this.buscarTextBox.Size = new System.Drawing.Size(100, 20);
            this.buscarTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.presentacionComboBox);
            this.groupBox1.Controls.Add(this.limpiarButton);
            this.groupBox1.Controls.Add(this.buscarCategoriaButton);
            this.groupBox1.Controls.Add(this.cargarButton);
            this.groupBox1.Controls.Add(this.imagenPictureBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.categoriaTextBox);
            this.groupBox1.Controls.Add(this.codigoTextBox);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.editarButton);
            this.groupBox1.Controls.Add(this.guardarButton);
            this.groupBox1.Controls.Add(this.nuevoButton);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Controls.Add(this.idCategoriaTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.idArticuloTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artículo";
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(356, 213);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 9;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // editarButton
            // 
            this.editarButton.Location = new System.Drawing.Point(265, 213);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(75, 23);
            this.editarButton.TabIndex = 8;
            this.editarButton.Text = "E&ditar";
            this.editarButton.UseVisualStyleBackColor = true;
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(169, 213);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 7;
            this.guardarButton.Text = "&Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // nuevoButton
            // 
            this.nuevoButton.Location = new System.Drawing.Point(77, 213);
            this.nuevoButton.Name = "nuevoButton";
            this.nuevoButton.Size = new System.Drawing.Size(75, 23);
            this.nuevoButton.TabIndex = 6;
            this.nuevoButton.Text = "&Nuevo";
            this.nuevoButton.UseVisualStyleBackColor = true;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.descripcionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descripcionTextBox.Location = new System.Drawing.Point(82, 124);
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descripcionTextBox.Size = new System.Drawing.Size(230, 83);
            this.descripcionTextBox.TabIndex = 5;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.nombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreTextBox.Location = new System.Drawing.Point(82, 91);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(230, 20);
            this.nombreTextBox.TabIndex = 4;
            // 
            // idArticuloTextBox
            // 
            this.idArticuloTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.idArticuloTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idArticuloTextBox.Location = new System.Drawing.Point(82, 24);
            this.idArticuloTextBox.Name = "idArticuloTextBox";
            this.idArticuloTextBox.Size = new System.Drawing.Size(100, 20);
            this.idArticuloTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Decripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Artículos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.codigoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoTextBox.Location = new System.Drawing.Point(82, 57);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.Size = new System.Drawing.Size(230, 20);
            this.codigoTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Barras";
            // 
            // imagenPictureBox
            // 
            this.imagenPictureBox.Location = new System.Drawing.Point(318, 124);
            this.imagenPictureBox.Name = "imagenPictureBox";
            this.imagenPictureBox.Size = new System.Drawing.Size(135, 83);
            this.imagenPictureBox.TabIndex = 12;
            this.imagenPictureBox.TabStop = false;
            // 
            // cargarButton
            // 
            this.cargarButton.Location = new System.Drawing.Point(459, 124);
            this.cargarButton.Name = "cargarButton";
            this.cargarButton.Size = new System.Drawing.Size(75, 23);
            this.cargarButton.TabIndex = 13;
            this.cargarButton.Text = "Cargar";
            this.cargarButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(459, 153);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 14;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // idCategoriaTextBox
            // 
            this.idCategoriaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.idCategoriaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idCategoriaTextBox.Location = new System.Drawing.Point(410, 28);
            this.idCategoriaTextBox.Name = "idCategoriaTextBox";
            this.idCategoriaTextBox.Size = new System.Drawing.Size(100, 20);
            this.idCategoriaTextBox.TabIndex = 3;
            // 
            // categoriaTextBox
            // 
            this.categoriaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.categoriaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoriaTextBox.Location = new System.Drawing.Point(410, 61);
            this.categoriaTextBox.Name = "categoriaTextBox";
            this.categoriaTextBox.Size = new System.Drawing.Size(230, 20);
            this.categoriaTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Categoría";
            // 
            // buscarCategoriaButton
            // 
            this.buscarCategoriaButton.Location = new System.Drawing.Point(660, 61);
            this.buscarCategoriaButton.Name = "buscarCategoriaButton";
            this.buscarCategoriaButton.Size = new System.Drawing.Size(75, 23);
            this.buscarCategoriaButton.TabIndex = 13;
            this.buscarCategoriaButton.Text = "Buscar";
            this.buscarCategoriaButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Presentación";
            // 
            // presentacionComboBox
            // 
            this.presentacionComboBox.FormattingEnabled = true;
            this.presentacionComboBox.Location = new System.Drawing.Point(410, 91);
            this.presentacionComboBox.Name = "presentacionComboBox";
            this.presentacionComboBox.Size = new System.Drawing.Size(124, 21);
            this.presentacionComboBox.TabIndex = 15;
            // 
            // frmArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmArticulo";
            this.Text = "Articulos";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView listadoDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.CheckBox eliminarCheckBox;
        private System.Windows.Forms.Button imprimirButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.TextBox buscarTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button editarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button nuevoButton;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox idArticuloTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox codigoTextBox;
        private System.Windows.Forms.PictureBox imagenPictureBox;
        private System.Windows.Forms.ComboBox presentacionComboBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarCategoriaButton;
        private System.Windows.Forms.Button cargarButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox categoriaTextBox;
        private System.Windows.Forms.TextBox idCategoriaTextBox;
    }
}