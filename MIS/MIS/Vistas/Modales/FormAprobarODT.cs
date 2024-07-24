using MIS.Helpers;
using MIS.Modelos.Laboratorio;
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
    public partial class FormAprobarODT : Form
    {
        private int id = 0;
        public FormAprobarODT(int idodt)
        {
            id = idodt;
            InitializeComponent();
            limpiar();
        }

        private async void limpiar()
        {
            cbUsuRevisado.DataSource = null;
            cbUsuRevisado.Items.Clear();
            cbUsuSellado.DataSource = null;
            cbUsuSellado.Items.Clear();
            cbUsuAprobado.DataSource = null;
            cbUsuAprobado.Items.Clear();
            dtFechaRevisado.Value = DateTime.Now;
            dtFechaSellado.Value = DateTime.Now;
            dtFechaAprobado.Value = DateTime.Now;
            await FG.CargarCombos(cbUsuRevisado, "metrologo", "", 0);
            await FG.CargarCombos(cbUsuSellado, "metrologo", "", 0);
            await FG.CargarCombos(cbUsuAprobado, "metrologo", "", 0);
        }

        private async void btnRevisar_Click(object sender, EventArgs e)
        {
            int idrevisa = 0;
            if ((int)cbUsuRevisado.SelectedValue > 0)
            {
                idrevisa = (int)cbUsuRevisado.SelectedValue;
            }
            DateTime fecha = dtFechaRevisado.Value.Date;
            string fecharevisdo = fecha.ToString("dd-MM-yyyy");
            OrdenTrabajoRepository estado = new OrdenTrabajoRepository();
            int revisada = await estado.EstadosODT(id, idrevisa, fecharevisdo, 1);
            if (revisada == 1) 
            {
                FG.ShowMsg("Revisada con éxito", "Éxito");
            }
        }

        private async void btnSellado_Click(object sender, EventArgs e)
        {
            int idsellado = 0;
            if ((int)cbUsuSellado.SelectedValue > 0)
            {
                idsellado = (int)cbUsuSellado.SelectedValue;
            }
            DateTime fecha = dtFechaSellado.Value.Date;
            string fechasellado = fecha.ToString("dd-MM-yyyy");
            OrdenTrabajoRepository estado = new OrdenTrabajoRepository();
            int sellado = await estado.EstadosODT(id, idsellado, fechasellado, 2);
            if (sellado == 1)
            {
                FG.ShowMsg("Sellado con éxito", "Éxito");
            }
        }

        private async void btnAprobado_Click(object sender, EventArgs e)
        {
            int idaprobado = 0;
            if ((int)cbUsuAprobado.SelectedValue > 0)
            {
                idaprobado = (int)cbUsuAprobado.SelectedValue;
            }
            DateTime fecha = dtFechaAprobado.Value.Date;
            string fechaaprobado = fecha.ToString("dd-MM-yyyy");
            OrdenTrabajoRepository estado = new OrdenTrabajoRepository();
            int aprobado = await estado.EstadosODT(id, idaprobado, fechaaprobado, 3);
            if (aprobado == 1)
            {
                FG.ShowMsg("Aprobado con éxito", "Éxito");
            }
        }
    }
}
