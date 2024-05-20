namespace MIS.Vistas.Modales
{
    partial class FormReportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            this.recepcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRecepcion = new MIS.Reportes.Recepcion.dsRecepcion();
            this.recepciondetalleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.recepcionEncabezadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recepcionDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvRecepcion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsRecepcionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvInspeccion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsInspeccion = new MIS.Reportes.Recepcion.dsInspeccion();
            this.inspeccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inspecciondetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.recepcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepciondetalleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionEncabezadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInspeccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspecciondetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // recepcionesBindingSource
            // 
            this.recepcionesBindingSource.DataMember = "recepciones";
            this.recepcionesBindingSource.DataSource = this.dsRecepcion;
            // 
            // dsRecepcion
            // 
            this.dsRecepcion.DataSetName = "dsRecepcion";
            this.dsRecepcion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recepciondetalleBindingSource1
            // 
            this.recepciondetalleBindingSource1.DataMember = "recepcion_detalle";
            this.recepciondetalleBindingSource1.DataSource = this.dsRecepcion;
            // 
            // rvRecepcion
            // 
            this.rvRecepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "recepciones";
            reportDataSource1.Value = this.recepcionesBindingSource;
            reportDataSource2.Name = "recepcion_detalle";
            reportDataSource2.Value = this.recepciondetalleBindingSource1;
            this.rvRecepcion.LocalReport.DataSources.Add(reportDataSource1);
            this.rvRecepcion.LocalReport.DataSources.Add(reportDataSource2);
            this.rvRecepcion.LocalReport.ReportEmbeddedResource = "MIS.Reportes.Recepcion.rpRecepcion.rdlc";
            this.rvRecepcion.Location = new System.Drawing.Point(0, 0);
            this.rvRecepcion.Name = "rvRecepcion";
            this.rvRecepcion.ServerReport.BearerToken = null;
            this.rvRecepcion.Size = new System.Drawing.Size(730, 745);
            this.rvRecepcion.TabIndex = 0;
            // 
            // dsRecepcionBindingSource
            // 
            this.dsRecepcionBindingSource.DataSource = this.dsRecepcion;
            this.dsRecepcionBindingSource.Position = 0;
            // 
            // rvInspeccion
            // 
            this.rvInspeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "encabezado";
            reportDataSource3.Value = this.inspeccionesBindingSource;
            reportDataSource4.Name = "detalle";
            reportDataSource4.Value = this.inspecciondetalleBindingSource;
            this.rvInspeccion.LocalReport.DataSources.Add(reportDataSource3);
            this.rvInspeccion.LocalReport.DataSources.Add(reportDataSource4);
            this.rvInspeccion.LocalReport.ReportEmbeddedResource = "MIS.Reportes.Recepcion.rpInspeccion.rdlc";
            this.rvInspeccion.Location = new System.Drawing.Point(0, 0);
            this.rvInspeccion.Name = "rvInspeccion";
            this.rvInspeccion.ServerReport.BearerToken = null;
            this.rvInspeccion.Size = new System.Drawing.Size(730, 745);
            this.rvInspeccion.TabIndex = 1;
            // 
            // dsInspeccion
            // 
            this.dsInspeccion.DataSetName = "dsInspeccion";
            this.dsInspeccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inspeccionesBindingSource
            // 
            this.inspeccionesBindingSource.DataMember = "inspecciones";
            this.inspeccionesBindingSource.DataSource = this.dsInspeccion;
            // 
            // inspecciondetalleBindingSource
            // 
            this.inspecciondetalleBindingSource.DataMember = "inspeccion_detalle";
            this.inspecciondetalleBindingSource.DataSource = this.dsInspeccion;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 745);
            this.Controls.Add(this.rvInspeccion);
            this.Controls.Add(this.rvRecepcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recepcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepciondetalleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionEncabezadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInspeccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspecciondetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource recepcionEncabezadoBindingSource;
        private System.Windows.Forms.BindingSource recepcionDetalleBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rvRecepcion;
        private System.Windows.Forms.BindingSource recepcionesBindingSource;
        private Reportes.Recepcion.dsRecepcion dsRecepcion;
        private System.Windows.Forms.BindingSource recepciondetalleBindingSource1;
        private System.Windows.Forms.BindingSource dsRecepcionBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rvInspeccion;
        private System.Windows.Forms.BindingSource inspeccionesBindingSource;
        private Reportes.Recepcion.dsInspeccion dsInspeccion;
        private System.Windows.Forms.BindingSource inspecciondetalleBindingSource;
    }
}