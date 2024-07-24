using MIS.Modelos;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO.Compression;
using System.Net.Http;

namespace MIS.Helpers
{
    public static class FG
    {
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string Ip { get; set; }
        public static string Mac { get; set; }
        public static string Url { get; set; }
        public static async Task CargarCombos(ComboBox comboBox, string tipo, string condicion, int seleccionado)
        {
            CombosRepository combos = new CombosRepository();
            DataTable data = await combos.CargarCombos(tipo, condicion);
            if (data != null)
            {

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
                if (image != null)
                {
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }else
                {
                    return string.Empty;
                }
                
            }
        }

        public static string FileToBase64(string filePath)
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes);
        }

        public static void ShowMsg(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowAlert(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void EnviarCorreo(string correos, string correoenvio, string clavecorreo, string nombreusuario, string archivosBase64, string tipo, string imagenBase64)
        {
            string tempPath = string.Empty;
            string imagePath = string.Empty;
            string zipPath = string.Empty;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.tuservidor.com");
                mail.From = new MailAddress(correoenvio);

                // Añadir destinatarios separados por coma
                string[] listaCorreos = correos.Split(';');
                foreach (string correo in listaCorreos)
                {
                    mail.To.Add(correo.Trim());
                }

                mail.Subject = "Certificados";

                string cuerpoHtml = @"
                    <p>Buen día,</p>
                    <p>Reciba un cordial saludo de METROLOGY INTEGRATION SAS</p>
                    <p>Adjunto Certificados</p>
                    <p>Remito esta información para su conocimiento y trámite correspondiente, quedo atento a cualquier inquietud o sugerencia</p>
                    <p>Cordialmente,</p>
                    <img src='cid:imagen' alt='Imagen'>";

                // Decodificar y guardar la imagen embebida
                byte[] imageBytes = Convert.FromBase64String(imagenBase64);
                imagePath = Path.Combine(Path.GetTempPath(), "imagen.jpg");
                File.WriteAllBytes(imagePath, imageBytes);
                LinkedResource imagen = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg)
                {
                    ContentId = "imagen"
                };

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(cuerpoHtml, null, MediaTypeNames.Text.Html);
                htmlView.LinkedResources.Add(imagen);
                mail.AlternateViews.Add(htmlView);

                // Decodificar y guardar los archivos
                string[] archivos = archivosBase64.Split(';');
                tempPath = Path.Combine(Path.GetTempPath(), "ArchivosCertificados");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }

                foreach (string archivoBase64 in archivos)
                {
                    byte[] archivoBytes = Convert.FromBase64String(archivoBase64);
                    string archivoPath = Path.Combine(tempPath, $"archivo_{Guid.NewGuid()}.pdf"); // Asumiendo que son PDFs, ajusta según sea necesario
                    File.WriteAllBytes(archivoPath, archivoBytes);
                }

                // Comprimir los archivos en un archivo ZIP
                zipPath = Path.Combine(Path.GetTempPath(), "Certificados.zip");
                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                }
                ZipFile.CreateFromDirectory(tempPath, zipPath);

                // Adjuntar el archivo ZIP al correo
                Attachment zipAttachment = new Attachment(zipPath, MediaTypeNames.Application.Zip);
                mail.Attachments.Add(zipAttachment);

                // Configuración del servidor SMTP
                smtpServer.Port = 587; // El puerto SMTP, generalmente es 587 para TLS
                smtpServer.Credentials = new NetworkCredential(correoenvio, clavecorreo);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);

                MessageBox.Show("Correos enviados exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar los correos: " + ex.Message);
            }
            finally
            {
                // Limpiar archivos temporales
                try
                {
                    Directory.Delete(tempPath, true);
                    if (File.Exists(imagePath)) File.Delete(imagePath);
                    if (File.Exists(zipPath)) File.Delete(zipPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al limpiar archivos temporales: " + ex.Message);
                }
            }
        }
        public static async Task EnviarMensajeTelegram(string mensaje)
        {
            string token = "7002907696:AAFRueTPvPj_hfUpAZzja-vWP7HQ8Jq5LTU";
            string chatId = "5421759554"; // Reemplaza con tu Chat ID
            string urlString = $"https://api.telegram.org/bot{token}/sendMessage?chat_id={chatId}&text={Uri.EscapeDataString(mensaje)}";

            using (HttpClient client = new HttpClient())
            {
                await client.GetAsync(urlString);
            }
        }

    }
}
