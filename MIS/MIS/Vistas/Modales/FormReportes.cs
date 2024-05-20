using Microsoft.Reporting.WinForms;
using MIS.Modelos.Recepcion;
using MIS.Modelos.Registros;
using MIS.Reportes.Recepcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS.Vistas.Modales
{
    public partial class FormReportes : Form
    {
        private int documento {  get; set; }
        private string tipo {  get; set; }
        private List<ReportViewer> reportViewers = new List<ReportViewer>();
        public FormReportes(int nro_documento, string tipo_documento)
        {
            InitializeComponent();
            documento= nro_documento;
            tipo = tipo_documento;
            reportViewers.Add(rvRecepcion);
            reportViewers.Add(rvInspeccion);
        }

        private async void FormReportes_Load(object sender, EventArgs e)
        {
            foreach (ReportViewer viewer in reportViewers)
            {
                ConfigurePageAndView(viewer);
            }
            switch (tipo)
            {
                case "Recepcion":
                    ShowReportViewer(rvRecepcion);
                    await LoadRecepcionReport();
                    break;
                case "Inspeccion":
                    ShowReportViewer(rvInspeccion);
                    await LoadInspeccionReport();
                    break;
            }
        }

        private void ConfigurePageAndView(ReportViewer viewer)
        {
            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
            pg.Landscape = false;
            pg.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            viewer.SetPageSettings(pg);
            viewer.SetDisplayMode(DisplayMode.PrintLayout);
            viewer.ZoomMode = ZoomMode.PageWidth;
        }

        private void ShowReportViewer(ReportViewer viewerToShow)
        {
            // Ocultar todos los ReportViewers excepto el que se va a mostrar
            foreach (ReportViewer viewer in reportViewers)
            {
                viewer.Visible = (viewer == viewerToShow);
            }
        }

        private async Task LoadRecepcionReport()
        {
            RecepcionRepository recepcion = new RecepcionRepository();
            DataTable te = await recepcion.GetEncabezadoRecepcion(documento);
            ReportDataSource rdsEncabezado = new ReportDataSource("recepciones", te);
            DataTable td = await recepcion.GetDetalleRecepcion(documento);
            ReportDataSource rdsDetalle = new ReportDataSource("recepcion_detalle", td);
            rvRecepcion.LocalReport.DataSources.Clear();
            rvRecepcion.LocalReport.DataSources.Add(rdsEncabezado);
            rvRecepcion.LocalReport.DataSources.Add(rdsDetalle);
            rvRecepcion.LocalReport.Refresh();
            rvRecepcion.RefreshReport();
        }
        private async Task LoadInspeccionReport()
        {
            InspeccionRepository inspeccion = new InspeccionRepository();
            DataTable te = await inspeccion.GetEncabezadoInspeccion(documento);
            ReportDataSource rdsEncabezado = new ReportDataSource("inspecciones", te);
            DataTable td = await inspeccion.GetDetalleInspecccion(documento);
            ReportDataSource rdsDetalle = new ReportDataSource("inspeccion_detalle", td);
            rvInspeccion.LocalReport.DataSources.Clear();
            rvInspeccion.LocalReport.DataSources.Add(rdsEncabezado);
            rvInspeccion.LocalReport.DataSources.Add(rdsDetalle);
            rvInspeccion.LocalReport.Refresh();
            rvInspeccion.RefreshReport();
        }
    }
}
