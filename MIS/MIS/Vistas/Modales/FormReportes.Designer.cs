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
            this.dsRecepcion = new MIS.Reportes.Recepcion.dsRecepcion();
            this.dsInspeccion = new MIS.Reportes.Recepcion.dsInspeccion();
            this.rvRecepcion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rvInspeccion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.inspeccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inspecciondetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recepcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recepciondetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInspeccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspecciondetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepciondetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsRecepcion
            // 
            this.dsRecepcion.DataSetName = "dsRecepcion";
            this.dsRecepcion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsInspeccion
            // 
            this.dsInspeccion.DataSetName = "dsInspeccion";
            this.dsInspeccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvRecepcion
            // 
            this.rvRecepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "recepciones";
            reportDataSource1.Value = this.recepcionesBindingSource;
            reportDataSource2.Name = "recepcion_detalle";
            reportDataSource2.Value = this.recepciondetalleBindingSource;
            this.rvRecepcion.LocalReport.DataSources.Add(reportDataSource1);
            this.rvRecepcion.LocalReport.DataSources.Add(reportDataSource2);
            this.rvRecepcion.LocalReport.ReportEmbeddedResource = "MIS.Reportes.Recepcion.rpRecepcion.rdlc";
            this.rvRecepcion.Location = new System.Drawing.Point(0, 0);
            this.rvRecepcion.Name = "rvRecepcion";
            this.rvRecepcion.ServerReport.BearerToken = null;
            this.rvRecepcion.Size = new System.Drawing.Size(730, 745);
            this.rvRecepcion.TabIndex = 0;
            // 
            // rvInspeccion
            // 
            this.rvInspeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "inspecciones";
            reportDataSource3.Value = this.inspeccionesBindingSource;
            reportDataSource4.Name = "inspeccion_detalle";
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
            // recepcionesBindingSource
            // 
            this.recepcionesBindingSource.DataMember = "recepciones";
            this.recepcionesBindingSource.DataSource = this.dsRecepcion;
            // 
            // recepciondetalleBindingSource
            // 
            this.recepciondetalleBindingSource.DataMember = "recepcion_detalle";
            this.recepciondetalleBindingSource.DataSource = this.dsRecepcion;
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
            ((System.ComponentModel.ISupportInitialize)(this.dsRecepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInspeccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspeccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspecciondetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recepciondetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rvRecepcion;
        private Reportes.Recepcion.dsRecepcion dsRecepcion;
        private Microsoft.Reporting.WinForms.ReportViewer rvInspeccion;
        private Reportes.Recepcion.dsInspeccion dsInspeccion;
        private System.Windows.Forms.BindingSource recepcionesBindingSource;
        private System.Windows.Forms.BindingSource recepciondetalleBindingSource;
        private System.Windows.Forms.BindingSource inspeccionesBindingSource;
        private System.Windows.Forms.BindingSource inspecciondetalleBindingSource;
    }
}