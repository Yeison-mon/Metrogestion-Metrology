using MIS.Helpers;
using MIS.Modelos.Comercial;
using MIS.Reportes.Recepcion;
using MIS.Vistas.Modales;
using System;
using System.Data;
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
            btnImportar.Visible = false;
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
            using (FormRecepciones form = new FormRecepciones())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    recepcion = form.recepcion;
                    //Buscar(recepcion, 0);
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
                    btnImportar.Visible = true;
                    //TablaDetalle(idcliente, idcotizacion);
                }
            }
        }        
    }
}
