﻿
namespace CapaPresentacion
{
    partial class frmIngreso
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
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buscarProveedorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listadoDetalleDataGridView = new System.Windows.Forms.DataGridView();
            this.fechaIngresodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fechaVencimientoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaProduccionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.precioVentaTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.borrarButton = new System.Windows.Forms.Button();
            this.agregarButton = new System.Windows.Forms.Button();
            this.precioCompraTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.stockInicialTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.articuloTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buscarArticuloButton = new System.Windows.Forms.Button();
            this.idArticuloTextBox = new System.Windows.Forms.TextBox();
            this.comprobanteComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.proveedorTextBox = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.totalPagadoLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.nuevoButton = new System.Windows.Forms.Button();
            this.idProveedorTextBox = new System.Windows.Forms.TextBox();
            this.correlativoTextBox = new System.Windows.Forms.TextBox();
            this.ivaTextBox = new System.Windows.Forms.TextBox();
            this.serieTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ingresoTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fechaFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.listadoDataGridView = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.totalRegistrosLabel = new System.Windows.Forms.Label();
            this.anularCheckBox = new System.Windows.Forms.CheckBox();
            this.imprimirButton = new System.Windows.Forms.Button();
            this.anularButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDetalleDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresos Almacén";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // buscarProveedorButton
            // 
            this.buscarProveedorButton.Location = new System.Drawing.Point(585, 42);
            this.buscarProveedorButton.Name = "buscarProveedorButton";
            this.buscarProveedorButton.Size = new System.Drawing.Size(75, 23);
            this.buscarProveedorButton.TabIndex = 8;
            this.buscarProveedorButton.Text = "Buscar";
            this.buscarProveedorButton.UseVisualStyleBackColor = true;
            this.buscarProveedorButton.Click += new System.EventHandler(this.buscarProveedorButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listadoDetalleDataGridView);
            this.groupBox1.Controls.Add(this.fechaIngresodateTimePicker);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.idArticuloTextBox);
            this.groupBox1.Controls.Add(this.comprobanteComboBox);
            this.groupBox1.Controls.Add(this.buscarProveedorButton);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.proveedorTextBox);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.totalPagadoLabel);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.guardarButton);
            this.groupBox1.Controls.Add(this.nuevoButton);
            this.groupBox1.Controls.Add(this.idProveedorTextBox);
            this.groupBox1.Controls.Add(this.correlativoTextBox);
            this.groupBox1.Controls.Add(this.ivaTextBox);
            this.groupBox1.Controls.Add(this.serieTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ingresoTextBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 542);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresos  Almacén";
            // 
            // listadoDetalleDataGridView
            // 
            this.listadoDetalleDataGridView.AllowUserToAddRows = false;
            this.listadoDetalleDataGridView.AllowUserToDeleteRows = false;
            this.listadoDetalleDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listadoDetalleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoDetalleDataGridView.Location = new System.Drawing.Point(18, 235);
            this.listadoDetalleDataGridView.Name = "listadoDetalleDataGridView";
            this.listadoDetalleDataGridView.Size = new System.Drawing.Size(923, 258);
            this.listadoDetalleDataGridView.TabIndex = 18;
            // 
            // fechaIngresodateTimePicker
            // 
            this.fechaIngresodateTimePicker.Location = new System.Drawing.Point(335, 19);
            this.fechaIngresodateTimePicker.Name = "fechaIngresodateTimePicker";
            this.fechaIngresodateTimePicker.Size = new System.Drawing.Size(146, 20);
            this.fechaIngresodateTimePicker.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fechaVencimientoDateTimePicker);
            this.groupBox2.Controls.Add(this.fechaProduccionDateTimePicker);
            this.groupBox2.Controls.Add(this.precioVentaTextBox);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.borrarButton);
            this.groupBox2.Controls.Add(this.agregarButton);
            this.groupBox2.Controls.Add(this.precioCompraTextBox);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.stockInicialTextBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.articuloTextBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.buscarArticuloButton);
            this.groupBox2.Location = new System.Drawing.Point(18, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(923, 116);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // fechaVencimientoDateTimePicker
            // 
            this.fechaVencimientoDateTimePicker.Location = new System.Drawing.Point(677, 68);
            this.fechaVencimientoDateTimePicker.Name = "fechaVencimientoDateTimePicker";
            this.fechaVencimientoDateTimePicker.Size = new System.Drawing.Size(146, 20);
            this.fechaVencimientoDateTimePicker.TabIndex = 12;
            // 
            // fechaProduccionDateTimePicker
            // 
            this.fechaProduccionDateTimePicker.Location = new System.Drawing.Point(677, 39);
            this.fechaProduccionDateTimePicker.Name = "fechaProduccionDateTimePicker";
            this.fechaProduccionDateTimePicker.Size = new System.Drawing.Size(146, 20);
            this.fechaProduccionDateTimePicker.TabIndex = 10;
            // 
            // precioVentaTextBox
            // 
            this.precioVentaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.precioVentaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.precioVentaTextBox.Location = new System.Drawing.Point(445, 68);
            this.precioVentaTextBox.Name = "precioVentaTextBox";
            this.precioVentaTextBox.Size = new System.Drawing.Size(105, 20);
            this.precioVentaTextBox.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(371, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Precio Venta";
            // 
            // borrarButton
            // 
            this.borrarButton.Location = new System.Drawing.Point(829, 67);
            this.borrarButton.Name = "borrarButton";
            this.borrarButton.Size = new System.Drawing.Size(75, 23);
            this.borrarButton.TabIndex = 14;
            this.borrarButton.Text = "Borrar";
            this.borrarButton.UseVisualStyleBackColor = true;
            this.borrarButton.Click += new System.EventHandler(this.borrarButton_Click);
            // 
            // agregarButton
            // 
            this.agregarButton.Location = new System.Drawing.Point(829, 38);
            this.agregarButton.Name = "agregarButton";
            this.agregarButton.Size = new System.Drawing.Size(75, 23);
            this.agregarButton.TabIndex = 13;
            this.agregarButton.Text = "Agregar";
            this.agregarButton.UseVisualStyleBackColor = true;
            this.agregarButton.Click += new System.EventHandler(this.agregarButton_Click);
            // 
            // precioCompraTextBox
            // 
            this.precioCompraTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.precioCompraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.precioCompraTextBox.Location = new System.Drawing.Point(445, 39);
            this.precioCompraTextBox.Name = "precioCompraTextBox";
            this.precioCompraTextBox.Size = new System.Drawing.Size(105, 20);
            this.precioCompraTextBox.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(573, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Fecha Vencimiento";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(363, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Precio Compra";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(577, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Fecha Producción";
            // 
            // stockInicialTextBox
            // 
            this.stockInicialTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.stockInicialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stockInicialTextBox.Location = new System.Drawing.Point(83, 68);
            this.stockInicialTextBox.Name = "stockInicialTextBox";
            this.stockInicialTextBox.Size = new System.Drawing.Size(105, 20);
            this.stockInicialTextBox.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Stock Inicial";
            // 
            // articuloTextBox
            // 
            this.articuloTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.articuloTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.articuloTextBox.Location = new System.Drawing.Point(83, 39);
            this.articuloTextBox.Name = "articuloTextBox";
            this.articuloTextBox.Size = new System.Drawing.Size(188, 20);
            this.articuloTextBox.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Artículo";
            // 
            // buscarArticuloButton
            // 
            this.buscarArticuloButton.Location = new System.Drawing.Point(277, 38);
            this.buscarArticuloButton.Name = "buscarArticuloButton";
            this.buscarArticuloButton.Size = new System.Drawing.Size(75, 23);
            this.buscarArticuloButton.TabIndex = 2;
            this.buscarArticuloButton.Text = "Buscar";
            this.buscarArticuloButton.UseVisualStyleBackColor = true;
            this.buscarArticuloButton.Click += new System.EventHandler(this.buscarArticuloButton_Click);
            // 
            // idArticuloTextBox
            // 
            this.idArticuloTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.idArticuloTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idArticuloTextBox.Location = new System.Drawing.Point(847, 49);
            this.idArticuloTextBox.Name = "idArticuloTextBox";
            this.idArticuloTextBox.Size = new System.Drawing.Size(60, 20);
            this.idArticuloTextBox.TabIndex = 15;
            // 
            // comprobanteComboBox
            // 
            this.comprobanteComboBox.FormattingEnabled = true;
            this.comprobanteComboBox.Items.AddRange(new object[] {
            "Ticket",
            "Boleta",
            "Factura",
            "Remisión"});
            this.comprobanteComboBox.Location = new System.Drawing.Point(106, 51);
            this.comprobanteComboBox.Name = "comprobanteComboBox";
            this.comprobanteComboBox.Size = new System.Drawing.Size(124, 21);
            this.comprobanteComboBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Fecha Ingreso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Proveedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Comprobante:";
            // 
            // proveedorTextBox
            // 
            this.proveedorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.proveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proveedorTextBox.Location = new System.Drawing.Point(335, 45);
            this.proveedorTextBox.Name = "proveedorTextBox";
            this.proveedorTextBox.Size = new System.Drawing.Size(244, 20);
            this.proveedorTextBox.TabIndex = 7;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.Location = new System.Drawing.Point(866, 499);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 0;
            this.cancelarButton.Text = "&Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // totalPagadoLabel
            // 
            this.totalPagadoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPagadoLabel.AutoSize = true;
            this.totalPagadoLabel.Location = new System.Drawing.Point(104, 504);
            this.totalPagadoLabel.Name = "totalPagadoLabel";
            this.totalPagadoLabel.Size = new System.Drawing.Size(22, 13);
            this.totalPagadoLabel.TabIndex = 20;
            this.totalPagadoLabel.Text = "0.0";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 504);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Total Pagado: $";
            // 
            // guardarButton
            // 
            this.guardarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guardarButton.Location = new System.Drawing.Point(776, 499);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 22;
            this.guardarButton.Text = "&Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // nuevoButton
            // 
            this.nuevoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuevoButton.Location = new System.Drawing.Point(684, 499);
            this.nuevoButton.Name = "nuevoButton";
            this.nuevoButton.Size = new System.Drawing.Size(75, 23);
            this.nuevoButton.TabIndex = 21;
            this.nuevoButton.Text = "&Nuevo";
            this.nuevoButton.UseVisualStyleBackColor = true;
            this.nuevoButton.Click += new System.EventHandler(this.nuevoButton_Click);
            // 
            // idProveedorTextBox
            // 
            this.idProveedorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.idProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idProveedorTextBox.Location = new System.Drawing.Point(847, 25);
            this.idProveedorTextBox.Name = "idProveedorTextBox";
            this.idProveedorTextBox.Size = new System.Drawing.Size(60, 20);
            this.idProveedorTextBox.TabIndex = 14;
            // 
            // correlativoTextBox
            // 
            this.correlativoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.correlativoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.correlativoTextBox.Location = new System.Drawing.Point(388, 70);
            this.correlativoTextBox.Name = "correlativoTextBox";
            this.correlativoTextBox.Size = new System.Drawing.Size(93, 20);
            this.correlativoTextBox.TabIndex = 11;
            // 
            // ivaTextBox
            // 
            this.ivaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ivaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ivaTextBox.Location = new System.Drawing.Point(519, 70);
            this.ivaTextBox.Name = "ivaTextBox";
            this.ivaTextBox.Size = new System.Drawing.Size(60, 20);
            this.ivaTextBox.TabIndex = 13;
            // 
            // serieTextBox
            // 
            this.serieTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.serieTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serieTextBox.Location = new System.Drawing.Point(335, 70);
            this.serieTextBox.Name = "serieTextBox";
            this.serieTextBox.Size = new System.Drawing.Size(47, 20);
            this.serieTextBox.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(489, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "IVA";
            // 
            // ingresoTextBox
            // 
            this.ingresoTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ingresoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ingresoTextBox.Location = new System.Drawing.Point(106, 25);
            this.ingresoTextBox.Name = "ingresoTextBox";
            this.ingresoTextBox.Size = new System.Drawing.Size(77, 20);
            this.ingresoTextBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(285, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Número";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Id Ingreso";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(972, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 586);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fechaFinalDateTimePicker);
            this.tabPage1.Controls.Add(this.fechaInicioDateTimePicker);
            this.tabPage1.Controls.Add(this.listadoDataGridView);
            this.tabPage1.Controls.Add(this.totalRegistrosLabel);
            this.tabPage1.Controls.Add(this.anularCheckBox);
            this.tabPage1.Controls.Add(this.imprimirButton);
            this.tabPage1.Controls.Add(this.anularButton);
            this.tabPage1.Controls.Add(this.buscarButton);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fechaFinalDateTimePicker
            // 
            this.fechaFinalDateTimePicker.Location = new System.Drawing.Point(155, 31);
            this.fechaFinalDateTimePicker.Name = "fechaFinalDateTimePicker";
            this.fechaFinalDateTimePicker.Size = new System.Drawing.Size(113, 20);
            this.fechaFinalDateTimePicker.TabIndex = 3;
            // 
            // fechaInicioDateTimePicker
            // 
            this.fechaInicioDateTimePicker.Location = new System.Drawing.Point(23, 31);
            this.fechaInicioDateTimePicker.Name = "fechaInicioDateTimePicker";
            this.fechaInicioDateTimePicker.Size = new System.Drawing.Size(113, 20);
            this.fechaInicioDateTimePicker.TabIndex = 1;
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
            this.listadoDataGridView.Size = new System.Drawing.Size(960, 460);
            this.listadoDataGridView.TabIndex = 9;
            this.listadoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoDataGridView_CellContentClick);
            this.listadoDataGridView.DoubleClick += new System.EventHandler(this.listadoDataGridView_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // totalRegistrosLabel
            // 
            this.totalRegistrosLabel.AutoSize = true;
            this.totalRegistrosLabel.Location = new System.Drawing.Point(481, 75);
            this.totalRegistrosLabel.Name = "totalRegistrosLabel";
            this.totalRegistrosLabel.Size = new System.Drawing.Size(35, 13);
            this.totalRegistrosLabel.TabIndex = 8;
            this.totalRegistrosLabel.Text = "label3";
            // 
            // anularCheckBox
            // 
            this.anularCheckBox.AutoSize = true;
            this.anularCheckBox.Location = new System.Drawing.Point(23, 71);
            this.anularCheckBox.Name = "anularCheckBox";
            this.anularCheckBox.Size = new System.Drawing.Size(56, 17);
            this.anularCheckBox.TabIndex = 7;
            this.anularCheckBox.Text = "Anular";
            this.anularCheckBox.UseVisualStyleBackColor = true;
            this.anularCheckBox.CheckedChanged += new System.EventHandler(this.anularCheckBox_CheckedChanged);
            // 
            // imprimirButton
            // 
            this.imprimirButton.Location = new System.Drawing.Point(445, 28);
            this.imprimirButton.Name = "imprimirButton";
            this.imprimirButton.Size = new System.Drawing.Size(75, 23);
            this.imprimirButton.TabIndex = 6;
            this.imprimirButton.Text = "&Imprimir";
            this.imprimirButton.UseVisualStyleBackColor = true;
            // 
            // anularButton
            // 
            this.anularButton.Location = new System.Drawing.Point(364, 28);
            this.anularButton.Name = "anularButton";
            this.anularButton.Size = new System.Drawing.Size(75, 23);
            this.anularButton.TabIndex = 5;
            this.anularButton.Text = "&Anular";
            this.anularButton.UseVisualStyleBackColor = true;
            this.anularButton.Click += new System.EventHandler(this.anularButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(283, 28);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 4;
            this.buscarButton.Text = "&Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Fecha Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio:";
            // 
            // frmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1012, 655);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmIngreso";
            this.Text = "Ingreso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIngreso_FormClosing);
            this.Load += new System.EventHandler(this.frmIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDetalleDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker fechaFinalDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaInicioDateTimePicker;
        private System.Windows.Forms.DataGridView listadoDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label totalRegistrosLabel;
        private System.Windows.Forms.CheckBox anularCheckBox;
        private System.Windows.Forms.Button imprimirButton;
        private System.Windows.Forms.Button anularButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comprobanteComboBox;
        private System.Windows.Forms.Button buscarProveedorButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox proveedorTextBox;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button nuevoButton;
        private System.Windows.Forms.TextBox idProveedorTextBox;
        private System.Windows.Forms.TextBox ingresoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox correlativoTextBox;
        private System.Windows.Forms.TextBox ivaTextBox;
        private System.Windows.Forms.TextBox serieTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView listadoDetalleDataGridView;
        private System.Windows.Forms.DateTimePicker fechaIngresodateTimePicker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker fechaVencimientoDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaProduccionDateTimePicker;
        private System.Windows.Forms.TextBox precioVentaTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button borrarButton;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.TextBox precioCompraTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox stockInicialTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox articuloTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buscarArticuloButton;
        private System.Windows.Forms.TextBox idArticuloTextBox;
        private System.Windows.Forms.Label totalPagadoLabel;
        private System.Windows.Forms.Label label19;
    }
}