using MIS.Helpers;
using MIS.Modelos.Comercial;
using MIS.Reportes.Recepcion;
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
        private int recepcion = 0;
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
            txtInspeccion.Text = "";
            btnLimpiar.Visible = false;
            btnImportar.Visible = false;
            btnGuardar.Visible = false;
            btnImprimir.Visible = false;
            idcliente = 0;
            cbMetrologo.DataSource = null;
            cbMetrologo.Items.Clear();
            await FG.CargarCombos(cbMetrologo, "metrologo", "", 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (FormRecepciones form = new FormRecepciones(idcliente, "ODT"))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    recepcion = form.recepcion;
                    int id = form.idrecepcion;
                    if (idcliente == 0)
                    {
                        BuscarCliente(form.idcliente);
                    }
                    //ImportarRecepcion(id);
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
                    //await TablaDetalle();
                }
            }
        }

        private void Detalle(int id)
        {

        }
    }
}
