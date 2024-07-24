using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using MIS.Helpers;
using MIS.Modelos;
using System.Text.RegularExpressions;
using System.Net;

namespace MIS.Vistas.Modales
{
    public partial class FormCorreos : Form
    {
        private int id = 0;
        public FormCorreos(int idcliente, int iddevolucion)
        {
            InitializeComponent();
            id = idcliente;
            combo();
        }
        private async void combo()
        {
            await FG.CargarCombos(cbCorreos, "correos_cliente", $"{id}", 0);
        }

        private async void lbCorreo_Click(object sender, EventArgs e)
        {
            using (FormAgregarDescripciones form = new FormAgregarDescripciones())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string texto = form.TextoIngresado;
                    if (EsCorreoValido(texto))
                    {
                        CombosRepository combosRepository = new CombosRepository();
                        bool guardadoExitoso = await combosRepository.GuardarNuevoValor("correos_cliente", texto, $"{id}");
                        if (guardadoExitoso)
                        {
                            await FG.CargarCombos(cbCorreos, "correos_cliente", $"{id}", 0);
                            cbCorreos.SelectedItem = texto;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El correo ingresado no es válido. Por favor, ingrese un correo electrónico válido.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private bool EsCorreoValido(string correo)
        {
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patronCorreo);
        }

        private void cbCorreos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = this.cbCorreos.GetItemText(this.cbCorreos.SelectedItem);
            if (valor != "--SELECCIONE--")
            {
                string texto = txtCorreos.Text;
                if (texto != "")
                {
                    string[] palabras = texto.Split(';');
                    if (!palabras.Contains(valor))
                    {
                        txtCorreos.Text += "; " + valor;
                    }
                }
                else
                {
                    txtCorreos.Text = valor;
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtCorreos.Text.Trim().Length > 0) 
            {
                var result = MessageBox.Show("Seguro que desea enviar los certificados a los correos: " + txtCorreos.Text, "Confirmar Envío", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    
                }
            }
        }
        
    }
}
