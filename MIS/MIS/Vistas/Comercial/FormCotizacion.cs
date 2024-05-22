using MIS.Helpers;
using MIS.Modelos.Comercial;
using MIS.Reportes.Recepcion;
using MIS.Vistas.Modales;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MIS.Vistas.Comercial
{
    public partial class FormCotizacion : Form
    {
        public FormCotizacion()
        {
            InitializeComponent();
            limpiar();
        }
        private int idcliente = 0;
        private int idcotizacion = 0;
        private int recepcion = 0;

        private void labelSede_Click(object sender, EventArgs e)
        {
            if (idcliente == 0)
            {
                MessageBox.Show("Debe de seleccionar el cliente", "Sugerencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                using (FormSedes form = new FormSedes(idcliente, txtCliente.Text))
                {
                    form.SedeGuardada += async (eventSender, args) => await FG.CargarCombos(cbSedes, "sedes", $"{idcliente}", 0);
                    DialogResult result = form.ShowDialog();
                }
            }
        }

        private void labelContacto_Click(object sender, EventArgs e)
        {
            if (idcliente == 0)
            {
                MessageBox.Show("Debe de seleccionar el cliente", "Sugerencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (cbContactos.DataSource == null || (int)cbContactos.SelectedValue == 0)
            {
                MessageBox.Show("Debe de seleccionar la sede del cliente", "Sugerencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                using (FormContactos form = new FormContactos(idcliente, (int)cbContactos.SelectedValue, txtCliente.Text))
                {
                    form.ContactoGuardado += async (eventSender, args) => await FG.CargarCombos(cbContactos, "contactos", $"{idcliente}", 0);
                    DialogResult result = form.ShowDialog();
                }
            }
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void limpiar()
        {
            btnGuardar.Visible = false;
            btnAgregarItems.Visible = false;
            btnLimpiar.Visible = false;
            btnImprimir.Visible = false;
            idcliente = 0;
            idcotizacion = 0;
            txtDocumento.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtAnio.Text = DateTime.Now.Year.ToString();
            txtEstado.Text = "Temporal";
            tablaDetalle.DataSource = null;
            tablaDetalle.Rows.Clear();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FormBuscarCliente form = new FormBuscarCliente())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    limpiar();
                    idcliente = form.idcliente;
                    BuscarCliente(idcliente, "", 0, 0);
                }
            }
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (FormRecepciones form = new FormRecepciones(idcliente))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    recepcion = form.recepcion;
                    int id = form.idrecepcion;
                    if (idcliente == 0)
                    {
                        BuscarCliente(form.idcliente, "", 0, 0);
                    }
                    ImportarRecepcion(id);
                }
            }
        }
        private async void BuscarCliente(int id, string documento, int idsede, int idcontacto)
        {
            CotizacionRepository cliente = new CotizacionRepository();
            DataTable tabla = await cliente.BuscarCliente(id, documento);
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    txtDocumento.Text = tabla.Rows[0]["documento"].ToString();
                    txtCliente.Text = tabla.Rows[0]["nombrecompleto"].ToString();
                    idcliente = (int)tabla.Rows[0]["id"];
                    btnAgregarItems.Enabled = true;
                    await FG.CargarCombos(cbSedes, "sedes", $"{idcliente}", idsede);
                    await FG.CargarCombos(cbContactos, "contactos", $"{idcliente}", idcontacto);
                    btnLimpiar.Enabled = true;
                    TablaDetalle();
                }
            }
        }
        private async void ImportarRecepcion(int id) 
        {
            CotizacionRepository importar = new CotizacionRepository();
            bool importado = await importar.ImportarRecepcion(id);
            if (importado)
            {
                MessageBox.Show("Importado con éxito");
                TablaDetalle();
            }
        }

        private async void TablaDetalle()
        {
            CotizacionRepository detalle = new CotizacionRepository();
            DataTable tabla = await detalle.Detalle(idcliente, idcotizacion);
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    tablaDetalle.Rows.Clear();
                    int numeroFila = 1;
                    foreach (DataRow row in tabla.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        string ingreso = row["ingreso"].ToString();
                        string descripcion = row["descripcion"].ToString();
                        string moneda = row["moneda"].ToString();
                        decimal precio = Convert.ToDecimal(row["precio"]);
                        int cantidad = Convert.ToInt32(row["precio"]);
                        int iva = Convert.ToInt32(row["iva"]);
                        int descuento = Convert.ToInt32(row["descuento"]);
                        decimal subtotal = (precio * cantidad) - (precio*cantidad*descuento/100);
                        tablaDetalle.CurrentCell = null;
                        tablaDetalle.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
                        tablaDetalle.Columns["ColumnDescripcion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        tablaDetalle.Columns["ColumnCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tablaDetalle.Columns["ColumnPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tablaDetalle.Columns["ColumnDescuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tablaDetalle.Columns["ColumnIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tablaDetalle.Columns["ColumnPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        tablaDetalle.Rows.Add(id, numeroFila, ingreso, descripcion, "", moneda, cantidad, precio, descuento, iva, subtotal);
                        numeroFila++;
                    }
                }
            }
        }
    }
}
