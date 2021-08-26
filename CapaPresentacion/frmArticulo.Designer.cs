
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulo));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listadoDataGridView = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.totalLabel = new System.Windows.Forms.Label();
            this.eliminarCheckBox = new System.Windows.Forms.CheckBox();
            this.buscarTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.presentacionComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.categoriaTextBox = new System.Windows.Forms.TextBox();
            this.codigoTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.idCategoriaTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.tallaTextBox = new System.Windows.Forms.TextBox();
            this.referenciaTextBox = new System.Windows.Forms.TextBox();
            this.idArticuloTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tituloPanel = new System.Windows.Forms.Panel();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.eliminarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarImagenButton = new System.Windows.Forms.Button();
            this.buscarCategoriaButton = new System.Windows.Forms.Button();
            this.cargarButton = new System.Windows.Forms.Button();
            this.imagenPictureBox = new System.Windows.Forms.PictureBox();
            this.nuevoButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.editarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tituloPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 288);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
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
            this.tabPage1.Size = new System.Drawing.Size(797, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listadoDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.listadoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listadoDataGridView.Size = new System.Drawing.Size(785, 162);
            this.listadoDataGridView.TabIndex = 7;
            this.listadoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoDataGridView_CellContentClick);
            this.listadoDataGridView.DoubleClick += new System.EventHandler(this.listadoDataGridView_DoubleClick);
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
            this.totalLabel.Location = new System.Drawing.Point(689, 72);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(35, 13);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "label3";
            // 
            // eliminarCheckBox
            // 
            this.eliminarCheckBox.AutoSize = true;
            this.eliminarCheckBox.Location = new System.Drawing.Point(6, 71);
            this.eliminarCheckBox.Name = "eliminarCheckBox";
            this.eliminarCheckBox.Size = new System.Drawing.Size(62, 17);
            this.eliminarCheckBox.TabIndex = 5;
            this.eliminarCheckBox.Text = "Eliminar";
            this.eliminarCheckBox.UseVisualStyleBackColor = true;
            this.eliminarCheckBox.CheckedChanged += new System.EventHandler(this.eliminarCheckBox_CheckedChanged);
            // 
            // buscarTextBox
            // 
            this.buscarTextBox.Location = new System.Drawing.Point(70, 19);
            this.buscarTextBox.Name = "buscarTextBox";
            this.buscarTextBox.Size = new System.Drawing.Size(109, 20);
            this.buscarTextBox.TabIndex = 1;
            this.buscarTextBox.TextChanged += new System.EventHandler(this.buscarTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.nuevoButton);
            this.tabPage2.Controls.Add(this.guardarButton);
            this.tabPage2.Controls.Add(this.editarButton);
            this.tabPage2.Controls.Add(this.cancelarButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(797, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.presentacionComboBox);
            this.groupBox1.Controls.Add(this.limpiarImagenButton);
            this.groupBox1.Controls.Add(this.buscarCategoriaButton);
            this.groupBox1.Controls.Add(this.cargarButton);
            this.groupBox1.Controls.Add(this.imagenPictureBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.categoriaTextBox);
            this.groupBox1.Controls.Add(this.codigoTextBox);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Controls.Add(this.idCategoriaTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.tallaTextBox);
            this.groupBox1.Controls.Add(this.referenciaTextBox);
            this.groupBox1.Controls.Add(this.idArticuloTextBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artículo";
            // 
            // presentacionComboBox
            // 
            this.presentacionComboBox.FormattingEnabled = true;
            this.presentacionComboBox.Location = new System.Drawing.Point(398, 101);
            this.presentacionComboBox.Name = "presentacionComboBox";
            this.presentacionComboBox.Size = new System.Drawing.Size(124, 21);
            this.presentacionComboBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Presentación";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Categoría";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Barras";
            // 
            // categoriaTextBox
            // 
            this.categoriaTextBox.BackColor = System.Drawing.Color.White;
            this.categoriaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoriaTextBox.Location = new System.Drawing.Point(398, 76);
            this.categoriaTextBox.Name = "categoriaTextBox";
            this.categoriaTextBox.Size = new System.Drawing.Size(124, 20);
            this.categoriaTextBox.TabIndex = 13;
            // 
            // codigoTextBox
            // 
            this.codigoTextBox.BackColor = System.Drawing.Color.White;
            this.codigoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codigoTextBox.Location = new System.Drawing.Point(398, 50);
            this.codigoTextBox.Name = "codigoTextBox";
            this.codigoTextBox.Size = new System.Drawing.Size(124, 20);
            this.codigoTextBox.TabIndex = 7;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.BackColor = System.Drawing.Color.White;
            this.descripcionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descripcionTextBox.Location = new System.Drawing.Point(82, 102);
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descripcionTextBox.Size = new System.Drawing.Size(230, 99);
            this.descripcionTextBox.TabIndex = 16;
            // 
            // idCategoriaTextBox
            // 
            this.idCategoriaTextBox.BackColor = System.Drawing.Color.White;
            this.idCategoriaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idCategoriaTextBox.Location = new System.Drawing.Point(398, 26);
            this.idCategoriaTextBox.Name = "idCategoriaTextBox";
            this.idCategoriaTextBox.Size = new System.Drawing.Size(100, 20);
            this.idCategoriaTextBox.TabIndex = 3;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.BackColor = System.Drawing.Color.White;
            this.nombreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombreTextBox.Location = new System.Drawing.Point(82, 50);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(230, 20);
            this.nombreTextBox.TabIndex = 5;
            // 
            // tallaTextBox
            // 
            this.tallaTextBox.BackColor = System.Drawing.Color.White;
            this.tallaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tallaTextBox.Location = new System.Drawing.Point(252, 76);
            this.tallaTextBox.Name = "tallaTextBox";
            this.tallaTextBox.Size = new System.Drawing.Size(60, 20);
            this.tallaTextBox.TabIndex = 11;
            // 
            // referenciaTextBox
            // 
            this.referenciaTextBox.BackColor = System.Drawing.Color.White;
            this.referenciaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.referenciaTextBox.Location = new System.Drawing.Point(82, 76);
            this.referenciaTextBox.Name = "referenciaTextBox";
            this.referenciaTextBox.Size = new System.Drawing.Size(128, 20);
            this.referenciaTextBox.TabIndex = 9;
            // 
            // idArticuloTextBox
            // 
            this.idArticuloTextBox.BackColor = System.Drawing.Color.White;
            this.idArticuloTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idArticuloTextBox.Location = new System.Drawing.Point(82, 24);
            this.idArticuloTextBox.Name = "idArticuloTextBox";
            this.idArticuloTextBox.Size = new System.Drawing.Size(51, 20);
            this.idArticuloTextBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Talla";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Decripción";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Referencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Id";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(702, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 0;
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
            // tituloPanel
            // 
            this.tituloPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.tituloPanel.Controls.Add(this.label1);
            this.tituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tituloPanel.Location = new System.Drawing.Point(0, 0);
            this.tituloPanel.Name = "tituloPanel";
            this.tituloPanel.Size = new System.Drawing.Size(828, 40);
            this.tituloPanel.TabIndex = 2;
            // 
            // imprimirButton
            // 
            this.imprimirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.imprimirButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.printer_;
            this.imprimirButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imprimirButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.imprimirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imprimirButton.ForeColor = System.Drawing.Color.Black;
            this.imprimirButton.Location = new System.Drawing.Point(283, 16);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(43, 23);
            this.imprimirButton.TabIndex = 4;
            this.ttMensaje.SetToolTip(this.imprimirButton, "Listado Artículos");
            this.imprimirButton.UseVisualStyleBackColor = false;
            this.imprimirButton.Click += new System.EventHandler(this.imprimirButton_Click);
            // 
            // eliminarButton
            // 
            this.eliminarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.eliminarButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.Delete1;
            this.eliminarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eliminarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.eliminarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminarButton.Location = new System.Drawing.Point(234, 16);
            this.eliminarButton.Name = "eliminarButton";
            this.eliminarButton.Size = new System.Drawing.Size(43, 23);
            this.eliminarButton.TabIndex = 3;
            this.ttMensaje.SetToolTip(this.eliminarButton, "Eliminar Artículo");
            this.eliminarButton.UseVisualStyleBackColor = false;
            this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.buscarButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.buscarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buscarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.buscarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarButton.ForeColor = System.Drawing.Color.Black;
            this.buscarButton.Location = new System.Drawing.Point(185, 16);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(43, 23);
            this.buscarButton.TabIndex = 2;
            this.ttMensaje.SetToolTip(this.buscarButton, "Buscar Artículo");
            this.buscarButton.UseVisualStyleBackColor = false;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // limpiarImagenButton
            // 
            this.limpiarImagenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.limpiarImagenButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.x_mark_2_48;
            this.limpiarImagenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.limpiarImagenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.limpiarImagenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiarImagenButton.Location = new System.Drawing.Point(528, 157);
            this.limpiarImagenButton.Name = "limpiarImagenButton";
            this.limpiarImagenButton.Size = new System.Drawing.Size(43, 23);
            this.limpiarImagenButton.TabIndex = 20;
            this.ttMensaje.SetToolTip(this.limpiarImagenButton, "Limpiar Imagen");
            this.limpiarImagenButton.UseVisualStyleBackColor = false;
            this.limpiarImagenButton.Click += new System.EventHandler(this.limpiarImagenButton_Click);
            // 
            // buscarCategoriaButton
            // 
            this.buscarCategoriaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.buscarCategoriaButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.buscarCategoriaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buscarCategoriaButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.buscarCategoriaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarCategoriaButton.Location = new System.Drawing.Point(528, 74);
            this.buscarCategoriaButton.Name = "buscarCategoriaButton";
            this.buscarCategoriaButton.Size = new System.Drawing.Size(43, 23);
            this.buscarCategoriaButton.TabIndex = 14;
            this.ttMensaje.SetToolTip(this.buscarCategoriaButton, "Buscar Categoría");
            this.buscarCategoriaButton.UseVisualStyleBackColor = false;
            this.buscarCategoriaButton.Click += new System.EventHandler(this.buscarCategoriaButton_Click);
            // 
            // cargarButton
            // 
            this.cargarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.cargarButton.BackgroundImage = global::CapaPresentacion.Properties.Resources.Buscar;
            this.cargarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cargarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cargarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargarButton.Location = new System.Drawing.Point(528, 128);
            this.cargarButton.Name = "cargarButton";
            this.cargarButton.Size = new System.Drawing.Size(43, 23);
            this.cargarButton.TabIndex = 19;
            this.ttMensaje.SetToolTip(this.cargarButton, "Buscar Imagen");
            this.cargarButton.UseVisualStyleBackColor = false;
            this.cargarButton.Click += new System.EventHandler(this.cargarButton_Click);
            // 
            // imagenPictureBox
            // 
            this.imagenPictureBox.BackColor = System.Drawing.Color.White;
            this.imagenPictureBox.BackgroundImage = global::CapaPresentacion.Properties.Resources.ImagenBlanco;
            this.imagenPictureBox.Location = new System.Drawing.Point(398, 128);
            this.imagenPictureBox.Name = "imagenPictureBox";
            this.imagenPictureBox.Size = new System.Drawing.Size(124, 73);
            this.imagenPictureBox.TabIndex = 12;
            this.imagenPictureBox.TabStop = false;
            // 
            // nuevoButton
            // 
            this.nuevoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.nuevoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.nuevoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.nuevoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nuevoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoButton.ForeColor = System.Drawing.Color.White;
            this.nuevoButton.Image = global::CapaPresentacion.Properties.Resources.nuevo1;
            this.nuevoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nuevoButton.Location = new System.Drawing.Point(636, 13);
            this.nuevoButton.Name = "nuevoButton";
            this.nuevoButton.Size = new System.Drawing.Size(98, 39);
            this.nuevoButton.TabIndex = 21;
            this.nuevoButton.Text = "Nuevo";
            this.nuevoButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nuevoButton.UseVisualStyleBackColor = false;
            this.nuevoButton.Click += new System.EventHandler(this.nuevoButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.guardarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guardarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.guardarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarButton.ForeColor = System.Drawing.Color.White;
            this.guardarButton.Image = global::CapaPresentacion.Properties.Resources.Guardar1;
            this.guardarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guardarButton.Location = new System.Drawing.Point(636, 58);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(98, 39);
            this.guardarButton.TabIndex = 22;
            this.guardarButton.Text = "&Guardar";
            this.guardarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.guardarButton.UseVisualStyleBackColor = false;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // editarButton
            // 
            this.editarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.editarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.editarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editarButton.ForeColor = System.Drawing.Color.White;
            this.editarButton.Image = global::CapaPresentacion.Properties.Resources.Edit1;
            this.editarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editarButton.Location = new System.Drawing.Point(636, 103);
            this.editarButton.Name = "editarButton";
            this.editarButton.Size = new System.Drawing.Size(98, 39);
            this.editarButton.TabIndex = 23;
            this.editarButton.Text = "E&ditar";
            this.editarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editarButton.UseVisualStyleBackColor = false;
            this.editarButton.Click += new System.EventHandler(this.editarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(127)))));
            this.cancelarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.Image = global::CapaPresentacion.Properties.Resources.Cancel1;
            this.cancelarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelarButton.Location = new System.Drawing.Point(636, 147);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(98, 39);
            this.cancelarButton.TabIndex = 0;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // frmArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(828, 344);
            this.Controls.Add(this.tituloPanel);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArticulo";
            this.Text = "Articulos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArticulo_FormClosing);
            this.Load += new System.EventHandler(this.frmArticulo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tituloPanel.ResumeLayout(false);
            this.tituloPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenPictureBox)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button limpiarImagenButton;
        private System.Windows.Forms.Button buscarCategoriaButton;
        private System.Windows.Forms.Button cargarButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox categoriaTextBox;
        private System.Windows.Forms.TextBox idCategoriaTextBox;
        private System.Windows.Forms.TextBox tallaTextBox;
        private System.Windows.Forms.TextBox referenciaTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel tituloPanel;
    }
}