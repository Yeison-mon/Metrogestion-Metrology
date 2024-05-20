using MIS.Modelos.Registros;
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
    public partial class FormRecepciones : Form
    {

        public int recepcion { get; private set; }
        public FormRecepciones()
        {
            InitializeComponent();
            cbEstados.SelectedIndex = 0;
            TablaRecepciones();
        }

        private async void TablaRecepciones()
        {
            tablaRecepcion.DataSource = null;
            tablaRecepcion.Rows.Clear();
            RecepcionRepository recepciones = new RecepcionRepository();
            string estado = cbEstados.SelectedItem.ToString();
            DataTable tabla = await recepciones.ModalRecepciones(estado);

            if (tabla != null)
            {
                tablaRecepcion.DataSource = tabla;
                tablaRecepcion.Visible = false;
                if (tablaRecepcion.Rows.Count > 0)
                {
                    tablaRecepcion.Visible = true;
                    tablaRecepcion.CurrentCell = null;
                    tablaRecepcion.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
                    tablaRecepcion.Font = new Font("Calibri", 12F, FontStyle.Bold);
                    tablaRecepcion.Columns["id"].Visible = false;
                    tablaRecepcion.Columns["nro_recepcion"].Visible = false;
                    tablaRecepcion.Columns["fila"].HeaderText = "#";
                    tablaRecepcion.Columns["anio"].HeaderText = "Año";
                    tablaRecepcion.Columns["recepcion"].HeaderText = "Recepción";
                    tablaRecepcion.Columns["estado"].HeaderText = "Estado";
                    tablaRecepcion.Columns["cliente"].HeaderText = "Cliente";
                    tablaRecepcion.Columns["magnitud"].HeaderText = "Magnitudes";
                    tablaRecepcion.Columns["cantidad"].HeaderText = "Cantidad de Ingresos";
                    tablaRecepcion.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    tablaRecepcion.Columns["cantidad"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    tablaRecepcion.Columns["fecha"].HeaderText = "Fecha";
                    tablaRecepcion.Columns["registrado_por"].HeaderText = "Registrado por";
                    tablaRecepcion.Columns["registrado_por"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    tablaRecepcion.Columns["observacion"].HeaderText = "Observación";
                    tablaRecepcion.Columns["observacion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    tablaRecepcion.AllowUserToOrderColumns = false;
                }
            }
        }



        private void txtRecepcion_TextChanged(object sender, EventArgs e)
        {
            if (tablaRecepcion.DataSource != null)
            {
                (tablaRecepcion.DataSource as DataTable).DefaultView.RowFilter = string.Format("recepcion like '%{0}%'", txtRecepcion.Text);
            }
        }

        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            TablaRecepciones();
        }

        private void tablaRecepcion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = e.RowIndex;
            if (filaSeleccionada >= 0)
            {
                DataGridViewRow fila = tablaRecepcion.Rows[filaSeleccionada];
                recepcion = Convert.ToInt32(fila.Cells["nro_recepcion"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
