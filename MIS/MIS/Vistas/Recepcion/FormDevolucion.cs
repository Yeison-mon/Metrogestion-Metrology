using MIS.Helpers;
using MIS.Modelos.Laboratorio;
using MIS.Modelos.Recepcion;
using MIS.Vistas.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MIS.Vistas.Recepcion
{
    public partial class FormDevolucion : Form
    {
        private int idrecepcion = 0;
        private int iddevolucion = 0;
        private int devolucion = 0;
        private int idcliente = 0;
        public FormDevolucion()
        {
            InitializeComponent();
            limpiar();
        }
        private void limpiar()
        {
            idrecepcion = 0;
            iddevolucion = 0;
            devolucion = 0;
            idcliente = 0;
            txtCliente.Text = string.Empty;
            txtNR.Text = string.Empty;
            txtDevolucion.Text = string.Empty;
            txtEstado.Text = string.Empty;
            dtFechaNE.Value = DateTime.Now;
            dtFechaNR.Value = DateTime.Now;
            txtObservacion.Text = string.Empty;
            btnGuardar.Visible = false;
            btnImprimir.Visible = false;
            btnLimpiar.Visible = false;
            btnCorreo.Visible = false;
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FormRecepciones form = new FormRecepciones(0, "Devolucion"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    idrecepcion = form.idrecepcion;
                    Buscar(idrecepcion, 0, 0);
                }
            }
        }

        private async void Buscar(int idrecepcion, int devolucion, int recepcion)
        {
            DevolucionRepository buscar = new DevolucionRepository();
            DataTable tabla = await buscar.Buscar(idrecepcion, devolucion, recepcion);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                txtCliente.Text = tabla.Rows[0]["cliente"].ToString();
                txtEstado.Text = tabla.Rows[0]["estado"].ToString() != "" ? tabla.Rows[0]["estado"].ToString() : "Temporal";
                this.idrecepcion = (int)tabla.Rows[0]["id"];
                this.idcliente = (int)tabla.Rows[0]["idcliente"];
                this.devolucion = (int)tabla.Rows[0]["devolucion"];
                txtNR.Text = tabla.Rows[0]["recepcion"].ToString();
                txtDevolucion.Text = tabla.Rows[0]["devolucion"].ToString() != "0" ? tabla.Rows[0]["devolucion"].ToString() : "";
                dtFechaNR.Value = (DateTime)tabla.Rows[0]["fecha_recepcion"];
                dtFechaNE.Value = tabla.Rows[0]["fecha"].ToString() != "" ? (DateTime)tabla.Rows[0]["fecha"] : DateTime.Now;
                int id = (int)tabla.Rows[0]["id"];
                iddevolucion = (int)tabla.Rows[0]["iddevolucion"];
                Detalle(id);
                if (txtDevolucion.Text != "")
                {
                    btnImprimir.Visible = true;
                    btnCorreo.Visible = true;
                }
                btnLimpiar.Visible = true;
            }
        }
        private async void Detalle(int id)
        {
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
            DevolucionRepository ingresos = new DevolucionRepository();
            DataTable tabla = await ingresos.Detalle(id);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                btnGuardar.Visible = true;
                btnLimpiar.Visible = true;
                tablaDetalle.DataSource = tabla;
                tablaDetalle.CurrentCell = null;
                tablaDetalle.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
                tablaDetalle.Columns["id"].Visible = false;
                tablaDetalle.Columns["id"].DisplayIndex = 0;
                tablaDetalle.Columns["renglon"].HeaderText = "Renglon";
                tablaDetalle.Columns["renglon"].DisplayIndex = 1;
                tablaDetalle.Columns["ingreso"].HeaderText = "Ingreso";
                tablaDetalle.Columns["ingreso"].DisplayIndex = 2;
                tablaDetalle.Columns["descripcion"].HeaderText = "Descripción";
                tablaDetalle.Columns["descripcion"].DisplayIndex = 3;
                tablaDetalle.Columns["descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                tablaDetalle.Columns["certificado"].HeaderText = "Certificado";
                tablaDetalle.Columns["certificado"].DisplayIndex = 4;

            }
        }

        private void txtNR_TextChanged(object sender, EventArgs e)
        {
            if (txtNR.Text.Length == 0)
                btnLimpiar_Click(null, null);
        }

        private void txtNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int recepcion;
                if (int.TryParse(txtNR.Text, out recepcion))
                {
                    Buscar(0, 0, recepcion);
                }
                else
                {
                    txtNR.Text = "";
                }
            }
        }

        private void txtDevolucion_TextChanged(object sender, EventArgs e)
        {
            if (txtDevolucion.Text.Length == 0)
                btnLimpiar_Click(null, null);
        }

        private void txtDevolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int devolucion;
                if (int.TryParse(txtDevolucion.Text, out devolucion))
                {
                    Buscar(0, devolucion, 0);
                }
                else
                {
                    txtDevolucion.Text = "";
                    this.devolucion = 0;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            for (int i = 0; i < tablaDetalle.Rows.Count; i++)
            {
                DataGridViewRow row = tablaDetalle.Rows[i];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                ids.Add(id);
            }
            DevolucionRepository guardar = new DevolucionRepository();
            int guardado = await guardar.Guardar(ids, devolucion, txtObservacion.Text);
            txtDevolucion.Text = guardado.ToString();
            devolucion = guardado;
            Buscar(0, devolucion, 0);
            btnImprimir.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        private async void imprimir()
        {

            string tipo = "Devolucion";
            if (devolucion > 0)
            {
                ReportService reportService = new ReportService();
                await reportService.OpenReportInBrowserAsync(devolucion, tipo);
            }
            else
            {
                MessageBox.Show("No se ha cargado el número de documento");
            }
        }

        private void btnCorreo_Click(object sender, EventArgs e)
        {
            if (idcliente > 0) 
            {
                using (FormCorreos form = new FormCorreos(idcliente, iddevolucion)) 
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        
                        FG.ShowMsg("Correo Enviado", "Exito");
                    }
                }
            }  
        }
    }
}
