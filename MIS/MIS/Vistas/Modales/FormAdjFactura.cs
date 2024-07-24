using MIS.Helpers;
using MIS.Modelos.Comercial;
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
    public partial class FormAdjFactura : Form
    {
        private int id = 0;
        public FormAdjFactura(int idcotizacion)
        {
            id = idcotizacion;
            InitializeComponent();
            limpiar();
        }

        private void limpiar()
        {
            dtFechaCotizacion.Value = DateTime.Now;
            dtFechaFactura.Value = DateTime.Now;
        }
        private async void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF|*.pdf";
            openFileDialog.Title = "Seleccionar archivo PDF";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string base64String = FG.FileToBase64(filePath);
                    CotizacionRepository adjuntar = new CotizacionRepository();
                    await adjuntar.AdjuntarArchivo(id, base64String, "COTIZACION FACTURA");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCotizacion.Text == "") 
            {
                FG.ShowAlert("Agregue el numero de la cotización", "Alerta");
                return;
            }
            if (txtFactura.Text == "")
            {
                FG.ShowAlert("Agregue el numero de la factura", "Alerta");
                return;
            }
            DateTime fecha = dtFechaCotizacion.Value.Date;
            string fechacoti = fecha.ToString("dd-MM-yyyy");
            DateTime fecha2 = dtFechaFactura.Value.Date;
            string fechafactura = fecha2.ToString("dd-MM-yyyy");
            CotizacionRepository guardar = new CotizacionRepository();
            bool guardado = guardar.FacturaExterna(id, Convert.ToInt32(txtCotizacion.Text), Convert.ToInt32(txtFactura.Text), fechafactura, fechacoti);
            if (guardado) 
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
