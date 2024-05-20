﻿using MIS.Modelos;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MIS.Helpers
{
    public static class FG
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string Ip { get; set; }
        public static string Mac { get; set; }
        public static async Task CargarCombos(ComboBox comboBox, string tipo, string condicion, int seleccionado)
        {
            CombosRepository combos = new CombosRepository();
            DataTable data = await combos.CargarCombos(tipo, condicion);
            if (data != null)
            {
                DataTable datosOriginales = data.Copy();

                DataRow newRow = data.NewRow();
                newRow["id"] = 0;
                newRow["descripcion"] = "--SELECCIONE--";
                data.Rows.InsertAt(newRow, 0);
                comboBox.DisplayMember = "descripcion";
                comboBox.ValueMember = "id";
                comboBox.DataSource = data;
                if (seleccionado > 0)
                {
                    comboBox.SelectedValue = seleccionado;
                }
            }
        }

        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
