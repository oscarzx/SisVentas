
namespace CapaPresentacion
{
    partial class frmReporteArticulos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.principalDataSet = new CapaPresentacion.principalDataSet();
            this.spmostrar_articuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spmostrar_articuloTableAdapter = new CapaPresentacion.principalDataSetTableAdapters.spmostrar_articuloTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.principalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_articuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spmostrar_articuloBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.rptArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // principalDataSet
            // 
            this.principalDataSet.DataSetName = "principalDataSet";
            this.principalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spmostrar_articuloBindingSource
            // 
            this.spmostrar_articuloBindingSource.DataMember = "spmostrar_articulo";
            this.spmostrar_articuloBindingSource.DataSource = this.principalDataSet;
            // 
            // spmostrar_articuloTableAdapter
            // 
            this.spmostrar_articuloTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteArticulos";
            this.Text = "Reporte de Productos";
            this.Load += new System.EventHandler(this.frmReporteArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.principalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrar_articuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spmostrar_articuloBindingSource;
        private principalDataSet principalDataSet;
        private principalDataSetTableAdapters.spmostrar_articuloTableAdapter spmostrar_articuloTableAdapter;
    }
}