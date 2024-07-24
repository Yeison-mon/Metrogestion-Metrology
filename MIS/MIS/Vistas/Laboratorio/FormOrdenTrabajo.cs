using MIS.Helpers;
using MIS.Modelos.Comercial;
using MIS.Modelos.Laboratorio;
using MIS.Vistas.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS.Vistas.Laboratorio
{
    public partial class FormOrdenTrabajo : Form
    {
        private int idcliente = 0;
        private int inspeccion = 0;
        private int ordentrabajo = 0;
        private int idodt = 0;
        public FormOrdenTrabajo()
        {
            InitializeComponent();
            limpiar();
        }
        private async void limpiar()
        {
            txtCliente.Text = "";
            txtEstado.Text = "Temporal";
            txtODT.Text = "";
            idodt = 0;
            ordentrabajo = 0;
            idcliente = 0;
            inspeccion = 0;
            txtInspeccion.Text = "";
            dtFecha.Value = DateTime.Now;
            btnLimpiar.Visible = false;
            btnImportar.Visible = false;
            btnGuardar.Visible = false;
            btnImprimir.Visible = false;
            btnAgregarItems.Visible = false;
            btnAprobar.Visible = false;
            idcliente = 0;
            cbMetrologo.DataSource = null;
            cbMetrologo.Items.Clear();
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
            await FG.CargarCombos(cbMetrologo, "metrologo", "", 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FormRecepciones form = new FormRecepciones(idcliente, "ODT"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    inspeccion = form.inspeccion;
                    int id = form.idrecepcion;
                    if (idcliente == 0)
                    {
                        BuscarCliente(form.idcliente);
                        Buscar(inspeccion, 0);
                    }
                    Detalle(id);

                }
            }
        }

        private async void BuscarCliente(int id)
        {
            
            CotizacionRepository cliente = new CotizacionRepository();
            DataTable tabla = await cliente.BuscarCliente(id, "");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {

                    txtCliente.Text = tabla.Rows[0]["nombrecompleto"].ToString();
                    idcliente = (int)tabla.Rows[0]["id"];
                    btnAgregarItems.Enabled = true;
                    btnLimpiar.Visible = true;
                }
            }
        }

        private async void Detalle(int id)
        {
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
            OrdenTrabajoRepository ingresos = new OrdenTrabajoRepository();
            DataTable tabla = await ingresos.Detalle(id);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                btnGuardar.Visible = true;
                btnImportar.Visible = true;
                btnLimpiar.Visible = true;
                tablaDetalle.DataSource = tabla;
                tablaDetalle.CurrentCell = null;
                tablaDetalle.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
                tablaDetalle.Columns["id"].Visible = false;
                tablaDetalle.Columns["renglon"].HeaderText = "Renglon";
                tablaDetalle.Columns["ingreso"].HeaderText = "Ingreso";
                tablaDetalle.Columns["descripcion"].HeaderText = "Descripción";
                tablaDetalle.Columns["descripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                tablaDetalle.Columns["observacion"].HeaderText = "Observación";
                tablaDetalle.Columns["observacion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private async void Buscar(int inspeccion, int ordentrabajo)
        {
            this.ordentrabajo = 0;
            idodt = 0;
            OrdenTrabajoRepository buscar = new OrdenTrabajoRepository();
            DataTable tabla = await buscar.Buscar(inspeccion, ordentrabajo);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                txtCliente.Text = tabla.Rows[0]["cliente"].ToString();
                txtEstado.Text = tabla.Rows[0]["estado"].ToString() != "" ? tabla.Rows[0]["estado"].ToString() : "Temporal";
                txtInspeccion.Text = tabla.Rows[0]["inspeccion"].ToString();
                txtODT.Text = tabla.Rows[0]["ordentrabajo"].ToString() != "0" ? tabla.Rows[0]["ordentrabajo"].ToString() : "";
                string proceso = tabla.Rows[0]["estado_proceso"].ToString() != "" ? tabla.Rows[0]["estado_proceso"].ToString() : "";
                string fechaString = tabla.Rows[0]["fecha"].ToString();
                DateTime fechaLocal = DateTime.Now;
                if (!string.IsNullOrEmpty(fechaString))
                {
                    if (DateTimeOffset.TryParse(fechaString, out DateTimeOffset fechaOffset))
                    {
                        fechaLocal = fechaOffset.ToLocalTime().DateTime;
                    }
                    else
                    {
                        fechaLocal = DateTime.Now;
                    }
                }
                else
                {
                    fechaLocal = DateTime.Now;
                }

                dtFecha.Value = fechaLocal;
                idodt = (int)tabla.Rows[0]["idodt"];
                if (proceso != "")
                {
                    btnAprobar.Visible = true;
                }
                if (txtODT.Text != "")
                {
                    this.ordentrabajo = (int)tabla.Rows[0]["ordentrabajo"];
                    btnImprimir.Visible = true;
                }
                await FG.CargarCombos(cbMetrologo, "metrologo", "", (int)tabla.Rows[0]["idmetrologo"]);
                this.inspeccion = (int)tabla.Rows[0]["inspeccion"];
                int id = (int)tabla.Rows[0]["id"];
                Detalle(id);
            }
        }

        private void txtInspeccion_TextChanged(object sender, EventArgs e)
        {
            if (txtInspeccion.Text.Trim().Length == 0)
                limpiar();
        }

        private void txtODT_TextChanged(object sender, EventArgs e)
        {
            if (txtODT.Text.Trim().Length == 0)
                limpiar();
        }

        private void txtInspeccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int inspeccion;
                if (int.TryParse(txtInspeccion.Text, out inspeccion))
                {
                    Buscar(inspeccion, 0);
                }
                else
                {
                    txtInspeccion.Text = "";
                }
            }
        }

        private void txtODT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int odt;
                if (int.TryParse(txtODT.Text, out odt))
                {
                    Buscar(0, odt);
                }
                else
                {
                    txtODT.Text = "";
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int metrologo = 0;
            if ((int)cbMetrologo.SelectedValue > 0)
            {
                metrologo = (int)cbMetrologo.SelectedValue;
            }
            else
            {
                MessageBox.Show("Es obligatorio la selección del metrólogo");
                return;
            }
            List<int> ids = new List<int>();
            List<string> observaciones = new List<string>();
            DateTime fecha = dtFecha.Value.Date;
            string fechaguardar = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            foreach (DataGridViewRow row in tablaDetalle.Rows)
            {
                int id = Convert.ToInt32(row.Cells["id"].Value);
                string observacion = row.Cells["observacion"].Value?.ToString() ?? "";
                ids.Add(id);
                observaciones.Add(observacion);
            }
            OrdenTrabajoRepository guardar = new OrdenTrabajoRepository();
            ordentrabajo = await guardar.Guardar(ids, observaciones, ordentrabajo, "", metrologo, fechaguardar);
            if (ordentrabajo > 0)
            {
                txtODT.Text = ordentrabajo.ToString();
                btnImprimir.Visible = true;
            }

        }

        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ordentrabajo > 0)
            {
                ReportService reportService = new ReportService();
                await reportService.OpenReportInBrowserAsync(ordentrabajo, "ODT");
            }
            else
            {
                MessageBox.Show("No se ha cargado el número de documento");
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (idodt > 0) 
            {
                using (FormAprobarODT form = new FormAprobarODT(idodt))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Buscar(inspeccion, ordentrabajo);
                    }
                }
            }
        }
    }
}
