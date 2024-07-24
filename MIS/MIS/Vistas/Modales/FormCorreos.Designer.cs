namespace MIS.Vistas.Modales
{
    partial class FormCorreos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCorreos));
            dtFecha = new System.Windows.Forms.DateTimePicker();
            labelCliente = new System.Windows.Forms.Label();
            txtCorreos = new System.Windows.Forms.TextBox();
            lbCorreo = new System.Windows.Forms.Label();
            cbCorreos = new System.Windows.Forms.ComboBox();
            btnEnviar = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            SuspendLayout();
            // 
            // dtFecha
            // 
            dtFecha.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtFecha.CalendarForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            dtFecha.CalendarMonthBackground = System.Drawing.Color.FromArgb(120, 120, 120);
            dtFecha.Enabled = false;
            dtFecha.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtFecha.Location = new System.Drawing.Point(90, 19);
            dtFecha.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            dtFecha.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            dtFecha.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtFecha.Name = "dtFecha";
            dtFecha.Size = new System.Drawing.Size(93, 24);
            dtFecha.TabIndex = 8;
            toolTip1.SetToolTip(dtFecha, "Fecha de Envio de Correo");
            // 
            // labelCliente
            // 
            labelCliente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelCliente.BackColor = System.Drawing.Color.Transparent;
            labelCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelCliente.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            labelCliente.Location = new System.Drawing.Point(9, 18);
            labelCliente.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new System.Drawing.Size(69, 28);
            labelCliente.TabIndex = 15;
            labelCliente.Text = "Cliente";
            labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCorreos
            // 
            txtCorreos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            txtCorreos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            txtCorreos.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtCorreos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtCorreos.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtCorreos.Location = new System.Drawing.Point(9, 103);
            txtCorreos.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtCorreos.Multiline = true;
            txtCorreos.Name = "txtCorreos";
            txtCorreos.Size = new System.Drawing.Size(689, 102);
            txtCorreos.TabIndex = 16;
            // 
            // lbCorreo
            // 
            lbCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbCorreo.BackColor = System.Drawing.Color.Transparent;
            lbCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            lbCorreo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbCorreo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            lbCorreo.Location = new System.Drawing.Point(9, 63);
            lbCorreo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            lbCorreo.Name = "lbCorreo";
            lbCorreo.Size = new System.Drawing.Size(98, 28);
            lbCorreo.TabIndex = 17;
            lbCorreo.Text = "Correos (+)";
            lbCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            toolTip1.SetToolTip(lbCorreo, "Agregar Correos");
            lbCorreo.Click += lbCorreo_Click;
            // 
            // cbCorreos
            // 
            cbCorreos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cbCorreos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cbCorreos.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            cbCorreos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCorreos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbCorreos.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            cbCorreos.FormattingEnabled = true;
            cbCorreos.Location = new System.Drawing.Point(107, 65);
            cbCorreos.Margin = new System.Windows.Forms.Padding(7, 0, 12, 0);
            cbCorreos.Name = "cbCorreos";
            cbCorreos.Size = new System.Drawing.Size(352, 27);
            cbCorreos.TabIndex = 18;
            toolTip1.SetToolTip(cbCorreos, "Lista de Correos");
            cbCorreos.SelectedIndexChanged += cbCorreos_SelectedIndexChanged;
            // 
            // btnEnviar
            // 
            btnEnviar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEnviar.FlatAppearance.BorderSize = 0;
            btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEnviar.Image = Properties.Resources.correo64;
            btnEnviar.Location = new System.Drawing.Point(617, 214);
            btnEnviar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new System.Drawing.Size(75, 79);
            btnEnviar.TabIndex = 19;
            toolTip1.SetToolTip(btnEnviar, "Enviar");
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // FormCorreos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            ClientSize = new System.Drawing.Size(702, 294);
            Controls.Add(btnEnviar);
            Controls.Add(cbCorreos);
            Controls.Add(lbCorreo);
            Controls.Add(txtCorreos);
            Controls.Add(labelCliente);
            Controls.Add(dtFecha);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCorreos";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Envio de Correos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox txtCorreos;
        private System.Windows.Forms.Label lbCorreo;
        private System.Windows.Forms.ComboBox cbCorreos;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}