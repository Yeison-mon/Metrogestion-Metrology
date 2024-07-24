using MIS.Helpers;
using MIS.Modelos.Laboratorio;
using MIS.Vistas.Modales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MIS.Vistas.Laboratorio
{

    public partial class FormProcesoFinal : Form
    {
        private int odt = 0;
        private int ipf = 0;
        private int idrecepcion = 0;
        private int idipf = 0;
        public FormProcesoFinal()
        {
            InitializeComponent();
            limpiar();
        }

        private void limpiar()
        {
            txtCliente.Text = string.Empty;
            txtNroODT.Text = string.Empty;
            txtEstado.Text = "Temporal";
            txtObservacion.Text = string.Empty;
            txtNroIPF.Text = string.Empty;
            dtFechaIPF.Value = DateTime.Now;
            dtFechaODT.Value = DateTime.Now;
            btnGuardar.Visible = false;
            btnImprimir.Visible = false;
            btnCulminar.Visible = false;
            btnLimpiar.Visible = false;
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
            idipf = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FormRecepciones form = new FormRecepciones(0, "IPF"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    idrecepcion = form.idrecepcion;
                    Buscar(idrecepcion, 0, 0);
                }
            }
        }

        private async void Buscar(int idrecepcion, int odt, int ipf)
        {
            ProcesoFinalRepository buscar = new ProcesoFinalRepository();
            DataTable tabla = await buscar.Buscar(idrecepcion, odt, ipf);
            if (tabla != null && tabla.Rows.Count > 0)
            {
                txtCliente.Text = tabla.Rows[0]["cliente"].ToString();
                txtEstado.Text = tabla.Rows[0]["estado"].ToString() != "" ? tabla.Rows[0]["estado"].ToString() : "Temporal";
                this.odt = (int)tabla.Rows[0]["ordentrabajo"];
                txtNroODT.Text = tabla.Rows[0]["ordentrabajo"].ToString();
                txtNroIPF.Text = tabla.Rows[0]["procesofinal"].ToString() != "0" ? tabla.Rows[0]["procesofinal"].ToString() : "";
                dtFechaODT.Value = (DateTime)tabla.Rows[0]["fecha_orden"];
                dtFechaIPF.Value = tabla.Rows[0]["fecha"].ToString() != "" ? (DateTime)tabla.Rows[0]["fecha"] : DateTime.Now;
                int id = (int)tabla.Rows[0]["id"];
                idipf = (int)tabla.Rows[0]["idipf"];
                Detalle(id);
                if (txtNroIPF.Text != "")
                {
                    btnImprimir.Visible = true;
                    btnCulminar.Visible = true;
                }
                if (txtEstado.Text == "Culminado")
                {
                    btnCulminar.Visible = false;
                    btnGuardar.Enabled = false;
                }
            }
        }

        private async void Detalle(int id)
        {
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
            tablaDetalle.Columns.Clear();
            ProcesoFinalRepository ingresos = new ProcesoFinalRepository();
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
                tablaDetalle.Columns["lavado"].Visible = false;
                tablaDetalle.Columns["componentes"].Visible = false;
                tablaDetalle.Columns["desarme"].Visible = false;
                tablaDetalle.Columns["ensamblaje"].Visible = false;
                tablaDetalle.Columns["certificado"].Visible = false;
                tablaDetalle.Columns["fecha_certificado"].Visible = false;
                tablaDetalle.Columns["tipo"].Visible = false;
                tablaDetalle.Columns["observacion"].Visible = false;

                // Crear y configurar las columnas ComboBox
                DataGridViewComboBoxColumn columnaLavado = new DataGridViewComboBoxColumn
                {
                    Name = "ColumnaLavado",
                    HeaderText = "Lavado",
                    Items = { "NO", "SI" },
                    DisplayIndex = 4,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                tablaDetalle.Columns.Add(columnaLavado);

                ComboBox comboBoxComponentesData = new ComboBox();
                await FG.CargarCombos(comboBoxComponentesData, "componentes", "", 0);
                DataGridViewComboBoxColumn columnaComponentes = new DataGridViewComboBoxColumn
                {
                    Name = "ColumnaComponentes",
                    HeaderText = "Componentes",
                    DisplayIndex = 5,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), WrapMode = DataGridViewTriState.True },
                    ValueMember = "Value",
                    DisplayMember = "Text"
                };
                tablaDetalle.Columns.Add(columnaComponentes);

                DataTable dataComponentes = comboBoxComponentesData.DataSource as DataTable;
                if (dataComponentes != null)
                {
                    foreach (DataRow row in dataComponentes.Rows)
                    {
                        columnaComponentes.Items.Add(new ComboBoxItem { Value = row["id"].ToString(), Text = row["descripcion"].ToString() });
                    }
                }

                DataGridViewComboBoxColumn columnaDesarme = new DataGridViewComboBoxColumn
                {
                    Name = "ColumnaDesarme",
                    HeaderText = "Desarme",
                    Items = { "NO", "SI" },
                    DisplayIndex = 6,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                tablaDetalle.Columns.Add(columnaDesarme);

                DataGridViewComboBoxColumn columnaEnsamblaje = new DataGridViewComboBoxColumn
                {
                    Name = "ColumnaEnsamblaje",
                    HeaderText = "Ensamblaje",
                    Items = { "NO", "SI" },
                    DisplayIndex = 7,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                tablaDetalle.Columns.Add(columnaEnsamblaje);

                DataGridViewTextBoxColumn columnaCertificado = new DataGridViewTextBoxColumn
                {
                    Name = "ColumnaCertificado",
                    HeaderText = "Certificado",
                    DisplayIndex = 9,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), WrapMode = DataGridViewTriState.True }
                };
                tablaDetalle.Columns.Add(columnaCertificado);

                DataGridViewTextBoxColumn columnaFechaCertificado = new DataGridViewTextBoxColumn
                {
                    Name = "ColumnaFechaCertificado",
                    HeaderText = "Fecha Certificado",
                    DisplayIndex = 10,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), WrapMode = DataGridViewTriState.True }
                };
                tablaDetalle.Columns.Add(columnaFechaCertificado);

                ComboBox comboBoxData = new ComboBox();
                await FG.CargarCombos(comboBoxData, "tipo_acreditacion", "", 0);
                DataGridViewComboBoxColumn columnaTipo = new DataGridViewComboBoxColumn
                {
                    Name = "ColumnaTipo",
                    HeaderText = "Tipo servicio",
                    DisplayIndex = 11,
                    DefaultCellStyle = { BackColor = Color.FromArgb(250, 250, 250), Alignment = DataGridViewContentAlignment.MiddleCenter },
                    ValueMember = "Value",
                    DisplayMember = "Text"
                };

                DataTable dataTable = comboBoxData.DataSource as DataTable;
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnaTipo.Items.Add(new ComboBoxItem { Value = row["id"].ToString(), Text = row["descripcion"].ToString() });
                    }
                }
                tablaDetalle.Columns.Add(columnaTipo);

                // Asignar valores a las celdas basados en los datos de la tabla
                foreach (DataRow fila in tabla.Rows)
                {
                    foreach (DataGridViewRow dgvRow in tablaDetalle.Rows)
                    {
                        if (dgvRow.Cells["id"].Value != null && dgvRow.Cells["id"].Value.ToString() == fila["id"].ToString())
                        {
                            dgvRow.Cells["ColumnaLavado"].Value = string.IsNullOrWhiteSpace(fila["lavado"].ToString()) ? "NO" : fila["lavado"].ToString();
                            dgvRow.Cells["ColumnaComponentes"].Value = fila["componentes"].ToString();
                            dgvRow.Cells["ColumnaDesarme"].Value = string.IsNullOrWhiteSpace(fila["desarme"].ToString()) ? "NO" : fila["desarme"].ToString();
                            dgvRow.Cells["ColumnaEnsamblaje"].Value = string.IsNullOrWhiteSpace(fila["ensamblaje"].ToString()) ? "NO" : fila["ensamblaje"].ToString();
                            dgvRow.Cells["columnaCertificado"].Value = fila["certificado"];
                            dgvRow.Cells["columnaFechaCertificado"].Value = string.IsNullOrWhiteSpace(fila["fecha_certificado"].ToString()) ? DateTime.Now.ToString("yyyy-MM-dd") : Convert.ToDateTime(fila["fecha_certificado"]).ToString("yyyy-MM-dd");
                            dgvRow.Cells["ColumnaTipo"].Value = fila["tipo"].ToString();
                            break;
                        }
                    }
                }
            }
        }

        private void tablaDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (
                columnIndex == tablaDetalle.Columns["ColumnaLavado"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaComponentes"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaDesarme"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaEnsamblaje"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaCertificado"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaFechaCertificado"].Index ||
                columnIndex == tablaDetalle.Columns["ColumnaTipo"].Index
                )
            {
                tablaDetalle.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            else
            {
                tablaDetalle.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }
        private void txtNroODT_TextChanged(object sender, EventArgs e)
        {
            if (txtNroODT.Text.Length == 0)
                btnLimpiar_Click(null, null);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void txtNroIPF_TextChanged(object sender, EventArgs e)
        {
            if (txtNroIPF.Text.Length == 0)
                btnLimpiar_Click(null, null);
        }
        private void txtNroODT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int odt;
                if (int.TryParse(txtNroODT.Text, out odt))
                {
                    Buscar(0, odt, 0);
                }
                else
                {
                    txtNroODT.Text = "";
                }
            }
        }
        private void txtNroIPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                int ipf;
                if (int.TryParse(txtNroIPF.Text, out ipf))
                {
                    Buscar(0, 0, ipf);
                }
                else
                {
                    txtNroIPF.Text = "";
                }
            }
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<string> lavados = new List<string>();
            List<string> componentes = new List<string>();
            List<string> desarmes = new List<string>();
            List<string> ensambles = new List<string>();
            List<int> certificados = new List<int>();
            List<string> fechas = new List<string>();
            List<int> tipos = new List<int>();
            HashSet<int> certificadosUnicos = new HashSet<int>();
            string formatoFecha = "yyyy-MM-dd";

            for (int i = 0; i < tablaDetalle.Rows.Count; i++)
            {
                DataGridViewRow row = tablaDetalle.Rows[i];

                int id = Convert.ToInt32(row.Cells["id"].Value);
                string lavado = row.Cells["ColumnaLavado"].Value?.ToString() ?? "";
                string componente = row.Cells["ColumnaComponentes"].Value?.ToString() == "0" ? row.Cells["ColumnaComponentes"].Value?.ToString() : "1";
                string desarme = row.Cells["ColumnaDesarme"].Value?.ToString() ?? "";
                string ensamble = row.Cells["ColumnaEnsamblaje"].Value?.ToString() ?? "";
                int certificado = Convert.ToInt32(row.Cells["ColumnaCertificado"].Value);
                string fecha = row.Cells["ColumnaFechaCertificado"].Value?.ToString() ?? "";
                int tipo = Convert.ToInt32(row.Cells["ColumnaTipo"].Value);
                DateTime fechaValidada;
                if (!DateTime.TryParseExact(fecha, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaValidada))
                {
                    int numeroFila = i + 1;
                    FG.ShowAlert($"Rectificar la fecha en la fila {numeroFila}: {fecha}. Formato esperado: yyyy-MM-dd", "Tabla");
                    return;
                }
                if (!certificadosUnicos.Add(certificado))
                {
                    int numeroFila = i + 1;
                    FG.ShowAlert($"El número de certificado {certificado} está duplicado en la fila {numeroFila}.", "Error");
                    return;
                }

                ids.Add(id);
                lavados.Add(lavado);
                componentes.Add(componente);
                desarmes.Add(desarme);
                ensambles.Add(ensamble);
                certificados.Add(certificado);
                fechas.Add(fecha);
                tipos.Add(tipo);
            }
            ProcesoFinalRepository guardar = new ProcesoFinalRepository();
            this.ipf = await guardar.GuardarProcesoFinal(ids, lavados, componentes, desarmes, ensambles, certificados, fechas, tipos, ipf, txtObservacion.Text);
            btnImprimir.Visible = true;
            btnCulminar.Visible = true;
            if (ipf > 0)
            {
                Buscar(0,0,ipf);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        private async void imprimir()
        {

            string tipo = "ProcesoFinal";
            if (idipf > 0)
            {
                ReportService reportService = new ReportService();
                await reportService.OpenReportInBrowserAsync(idipf, tipo);
            }
            else
            {
                MessageBox.Show("No se ha cargado el número de documento");
            }
        }

        private void btnCulminar_Click(object sender, EventArgs e)
        {
            ProcesoFinalRepository culminar = new ProcesoFinalRepository();
            if (idipf > 0 && txtEstado.Text != "Culminado")
            {
                int culminado = culminar.Culminar(idipf);
                Buscar(0, 0, ipf);
            }
            else
                FG.ShowAlert("No se ha cargado la información", "");

        }
    }
}
