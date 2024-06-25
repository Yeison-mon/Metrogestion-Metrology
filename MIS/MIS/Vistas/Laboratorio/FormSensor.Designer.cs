namespace MIS.Vistas.Laboratorio
{
    partial class FormSensor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSensor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            labelDescripcion = new System.Windows.Forms.Label();
            tcGeneral = new System.Windows.Forms.TabControl();
            tpRegistro = new System.Windows.Forms.TabPage();
            panelRecepcion = new System.Windows.Forms.Panel();
            Grafica = new OxyPlot.WindowsForms.PlotView();
            tablaSensor = new System.Windows.Forms.DataGridView();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            txtObservacion = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanelContainer2 = new System.Windows.Forms.TableLayoutPanel();
            labelCliente = new System.Windows.Forms.Label();
            txtMin = new System.Windows.Forms.TextBox();
            txtMax = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            cbSensores = new System.Windows.Forms.ComboBox();
            btnComenzar = new System.Windows.Forms.Button();
            btnDetener = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            txtTiempo = new System.Windows.Forms.TextBox();
            tableLayoutPanelContenedorPrincipar = new System.Windows.Forms.TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            btnLimpiar = new System.Windows.Forms.Button();
            btnImprimir = new System.Windows.Forms.Button();
            btnGuardar = new System.Windows.Forms.Button();
            tpConsultar = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            tablaConsulta = new System.Windows.Forms.DataGridView();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            txtFiltro = new System.Windows.Forms.TextBox();
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            txtCInspeccion = new System.Windows.Forms.TextBox();
            dtpCHasta = new System.Windows.Forms.DateTimePicker();
            dtpCDesde = new System.Windows.Forms.DateTimePicker();
            txtCNro = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            btnConsultar = new System.Windows.Forms.Button();
            tcGeneral.SuspendLayout();
            tpRegistro.SuspendLayout();
            panelRecepcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaSensor).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanelContainer2.SuspendLayout();
            panel2.SuspendLayout();
            tpConsultar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tablaConsulta).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // labelDescripcion
            // 
            labelDescripcion.BackColor = System.Drawing.Color.FromArgb(78, 233, 15);
            labelDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            labelDescripcion.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelDescripcion.ForeColor = System.Drawing.Color.Black;
            labelDescripcion.Location = new System.Drawing.Point(0, 0);
            labelDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new System.Drawing.Size(1088, 74);
            labelDescripcion.TabIndex = 1;
            labelDescripcion.Text = "PRUEBA HIDROSTATICA";
            labelDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcGeneral
            // 
            tcGeneral.Controls.Add(tpRegistro);
            tcGeneral.Controls.Add(tpConsultar);
            tcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            tcGeneral.Font = new System.Drawing.Font("Calibri", 12F);
            tcGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tcGeneral.Location = new System.Drawing.Point(0, 74);
            tcGeneral.Margin = new System.Windows.Forms.Padding(0);
            tcGeneral.Name = "tcGeneral";
            tcGeneral.Padding = new System.Drawing.Point(5, 3);
            tcGeneral.SelectedIndex = 0;
            tcGeneral.Size = new System.Drawing.Size(1088, 675);
            tcGeneral.TabIndex = 3;
            tcGeneral.TabStop = false;
            // 
            // tpRegistro
            // 
            tpRegistro.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tpRegistro.Controls.Add(panelRecepcion);
            tpRegistro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            tpRegistro.ForeColor = System.Drawing.Color.White;
            tpRegistro.Location = new System.Drawing.Point(4, 28);
            tpRegistro.Margin = new System.Windows.Forms.Padding(0);
            tpRegistro.Name = "tpRegistro";
            tpRegistro.Size = new System.Drawing.Size(1080, 643);
            tpRegistro.TabIndex = 0;
            tpRegistro.Text = "Registro";
            // 
            // panelRecepcion
            // 
            panelRecepcion.AutoScroll = true;
            panelRecepcion.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            panelRecepcion.Controls.Add(Grafica);
            panelRecepcion.Controls.Add(tablaSensor);
            panelRecepcion.Controls.Add(tableLayoutPanel3);
            panelRecepcion.Controls.Add(tableLayoutPanelContainer2);
            panelRecepcion.Controls.Add(tableLayoutPanelContenedorPrincipar);
            panelRecepcion.Controls.Add(panel2);
            panelRecepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            panelRecepcion.Location = new System.Drawing.Point(0, 0);
            panelRecepcion.Margin = new System.Windows.Forms.Padding(0);
            panelRecepcion.Name = "panelRecepcion";
            panelRecepcion.Padding = new System.Windows.Forms.Padding(12);
            panelRecepcion.Size = new System.Drawing.Size(1080, 643);
            panelRecepcion.TabIndex = 2;
            // 
            // Grafica
            // 
            Grafica.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Grafica.Location = new System.Drawing.Point(338, 132);
            Grafica.Name = "Grafica";
            Grafica.PanCursor = System.Windows.Forms.Cursors.Hand;
            Grafica.Size = new System.Drawing.Size(718, 287);
            Grafica.TabIndex = 15;
            Grafica.Text = "plotView1";
            Grafica.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            Grafica.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            Grafica.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tablaSensor
            // 
            tablaSensor.AllowUserToAddRows = false;
            tablaSensor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            tablaSensor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            tablaSensor.BackgroundColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tablaSensor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tablaSensor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(240, 243, 249);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(240, 243, 249);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tablaSensor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tablaSensor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(60, 120, 216);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            tablaSensor.DefaultCellStyle = dataGridViewCellStyle2;
            tablaSensor.Dock = System.Windows.Forms.DockStyle.Left;
            tablaSensor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            tablaSensor.EnableHeadersVisualStyles = false;
            tablaSensor.GridColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tablaSensor.Location = new System.Drawing.Point(12, 132);
            tablaSensor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tablaSensor.MultiSelect = false;
            tablaSensor.Name = "tablaSensor";
            tablaSensor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tablaSensor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tablaSensor.RowHeadersVisible = false;
            tablaSensor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            tablaSensor.Size = new System.Drawing.Size(328, 275);
            tablaSensor.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel3.Controls.Add(txtObservacion, 0, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanel3.Location = new System.Drawing.Point(12, 407);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.05042F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.94958F));
            tableLayoutPanel3.Size = new System.Drawing.Size(1056, 137);
            tableLayoutPanel3.TabIndex = 13;
            // 
            // txtObservacion
            // 
            txtObservacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            txtObservacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            txtObservacion.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtObservacion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtObservacion.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtObservacion.Location = new System.Drawing.Point(0, 35);
            txtObservacion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtObservacion.Multiline = true;
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new System.Drawing.Size(959, 89);
            txtObservacion.TabIndex = 15;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(1044, 23);
            label1.TabIndex = 14;
            label1.Text = "Observación";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelContainer2
            // 
            tableLayoutPanelContainer2.AutoSize = true;
            tableLayoutPanelContainer2.ColumnCount = 6;
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            tableLayoutPanelContainer2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 890F));
            tableLayoutPanelContainer2.Controls.Add(labelCliente, 0, 0);
            tableLayoutPanelContainer2.Controls.Add(txtMin, 1, 0);
            tableLayoutPanelContainer2.Controls.Add(txtMax, 3, 0);
            tableLayoutPanelContainer2.Controls.Add(label2, 2, 0);
            tableLayoutPanelContainer2.Controls.Add(label8, 0, 1);
            tableLayoutPanelContainer2.Controls.Add(cbSensores, 1, 1);
            tableLayoutPanelContainer2.Controls.Add(btnComenzar, 0, 2);
            tableLayoutPanelContainer2.Controls.Add(btnDetener, 2, 2);
            tableLayoutPanelContainer2.Controls.Add(label5, 4, 0);
            tableLayoutPanelContainer2.Controls.Add(txtTiempo, 5, 0);
            tableLayoutPanelContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanelContainer2.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanelContainer2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelContainer2.Name = "tableLayoutPanelContainer2";
            tableLayoutPanelContainer2.RowCount = 3;
            tableLayoutPanelContainer2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelContainer2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelContainer2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanelContainer2.Size = new System.Drawing.Size(1056, 120);
            tableLayoutPanelContainer2.TabIndex = 7;
            // 
            // labelCliente
            // 
            labelCliente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelCliente.BackColor = System.Drawing.Color.Transparent;
            labelCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelCliente.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            labelCliente.Location = new System.Drawing.Point(0, 0);
            labelCliente.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new System.Drawing.Size(99, 28);
            labelCliente.TabIndex = 14;
            labelCliente.Text = "Min";
            labelCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMin
            // 
            txtMin.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtMin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMin.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtMin.Location = new System.Drawing.Point(111, 0);
            txtMin.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtMin.Name = "txtMin";
            txtMin.Size = new System.Drawing.Size(85, 27);
            txtMin.TabIndex = 19;
            txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMax
            // 
            txtMax.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtMax.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtMax.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtMax.Location = new System.Drawing.Point(292, 0);
            txtMax.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtMax.Name = "txtMax";
            txtMax.Size = new System.Drawing.Size(97, 27);
            txtMax.TabIndex = 3;
            txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label2.Location = new System.Drawing.Point(208, 0);
            label2.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 28);
            label2.TabIndex = 20;
            label2.Text = "Max";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label8.Location = new System.Drawing.Point(0, 40);
            label8.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(99, 28);
            label8.TabIndex = 21;
            label8.Text = "Sensor";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSensores
            // 
            cbSensores.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSensores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cbSensores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cbSensores.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            tableLayoutPanelContainer2.SetColumnSpan(cbSensores, 3);
            cbSensores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSensores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cbSensores.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbSensores.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            cbSensores.FormattingEnabled = true;
            cbSensores.Location = new System.Drawing.Point(111, 40);
            cbSensores.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            cbSensores.Name = "cbSensores";
            cbSensores.Size = new System.Drawing.Size(278, 27);
            cbSensores.TabIndex = 26;
            // 
            // btnComenzar
            // 
            btnComenzar.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            btnComenzar.FlatAppearance.BorderSize = 0;
            btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnComenzar.ForeColor = System.Drawing.Color.Black;
            btnComenzar.Location = new System.Drawing.Point(0, 80);
            btnComenzar.Margin = new System.Windows.Forms.Padding(0);
            btnComenzar.Name = "btnComenzar";
            btnComenzar.Size = new System.Drawing.Size(111, 37);
            btnComenzar.TabIndex = 24;
            btnComenzar.Text = "Comenzar";
            btnComenzar.UseVisualStyleBackColor = false;
            btnComenzar.Click += btnComenzar_Click;
            // 
            // btnDetener
            // 
            btnDetener.BackColor = System.Drawing.Color.Salmon;
            btnDetener.FlatAppearance.BorderSize = 0;
            btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDetener.ForeColor = System.Drawing.Color.Black;
            btnDetener.Location = new System.Drawing.Point(208, 80);
            btnDetener.Margin = new System.Windows.Forms.Padding(0);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new System.Drawing.Size(84, 37);
            btnDetener.TabIndex = 25;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = false;
            btnDetener.Click += btnDetener_Click;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label5.Location = new System.Drawing.Point(401, 0);
            label5.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(202, 28);
            label5.TabIndex = 27;
            label5.Text = "Tiempo de lectura (s)";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTiempo
            // 
            txtTiempo.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtTiempo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtTiempo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtTiempo.Location = new System.Drawing.Point(615, 0);
            txtTiempo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtTiempo.Name = "txtTiempo";
            txtTiempo.Size = new System.Drawing.Size(33, 27);
            txtTiempo.TabIndex = 28;
            txtTiempo.Text = "1";
            txtTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtTiempo.TextChanged += txtTiempo_TextChanged;
            // 
            // tableLayoutPanelContenedorPrincipar
            // 
            tableLayoutPanelContenedorPrincipar.AutoSize = true;
            tableLayoutPanelContenedorPrincipar.ColumnCount = 2;
            tableLayoutPanelContenedorPrincipar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelContenedorPrincipar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelContenedorPrincipar.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanelContenedorPrincipar.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanelContenedorPrincipar.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelContenedorPrincipar.Name = "tableLayoutPanelContenedorPrincipar";
            tableLayoutPanelContenedorPrincipar.RowCount = 1;
            tableLayoutPanelContenedorPrincipar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelContenedorPrincipar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            tableLayoutPanelContenedorPrincipar.Size = new System.Drawing.Size(1056, 0);
            tableLayoutPanelContenedorPrincipar.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            panel2.Controls.Add(btnLimpiar);
            panel2.Controls.Add(btnImprimir);
            panel2.Controls.Add(btnGuardar);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(12, 544);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1056, 87);
            panel2.TabIndex = 11;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Image = Properties.Resources.limpiar64;
            btnLimpiar.Location = new System.Drawing.Point(178, 6);
            btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(79, 78);
            btnLimpiar.TabIndex = 16;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnImprimir.Image = (System.Drawing.Image)resources.GetObject("btnImprimir.Image");
            btnImprimir.Location = new System.Drawing.Point(91, 6);
            btnImprimir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new System.Drawing.Size(79, 78);
            btnImprimir.TabIndex = 13;
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Image = (System.Drawing.Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.Location = new System.Drawing.Point(4, 6);
            btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(79, 78);
            btnGuardar.TabIndex = 11;
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // tpConsultar
            // 
            tpConsultar.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tpConsultar.Controls.Add(panel1);
            tpConsultar.ForeColor = System.Drawing.Color.White;
            tpConsultar.Location = new System.Drawing.Point(4, 28);
            tpConsultar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tpConsultar.Name = "tpConsultar";
            tpConsultar.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tpConsultar.Size = new System.Drawing.Size(1080, 643);
            tpConsultar.TabIndex = 1;
            tpConsultar.Text = "Consultar";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            panel1.Controls.Add(tablaConsulta);
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Controls.Add(tableLayoutPanel5);
            panel1.Controls.Add(tableLayoutPanel8);
            panel1.Controls.Add(panel3);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(4, 3);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(12);
            panel1.Size = new System.Drawing.Size(1072, 637);
            panel1.TabIndex = 3;
            // 
            // tablaConsulta
            // 
            tablaConsulta.AllowUserToAddRows = false;
            tablaConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            tablaConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            tablaConsulta.BackgroundColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tablaConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tablaConsulta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            tablaConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(240, 243, 249);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(240, 243, 249);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tablaConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            tablaConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(60, 120, 216);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            tablaConsulta.DefaultCellStyle = dataGridViewCellStyle5;
            tablaConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            tablaConsulta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            tablaConsulta.EnableHeadersVisualStyles = false;
            tablaConsulta.GridColor = System.Drawing.Color.FromArgb(230, 233, 239);
            tablaConsulta.Location = new System.Drawing.Point(12, 158);
            tablaConsulta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tablaConsulta.MultiSelect = false;
            tablaConsulta.Name = "tablaConsulta";
            tablaConsulta.ReadOnly = true;
            tablaConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tablaConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            tablaConsulta.RowHeadersVisible = false;
            tablaConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            tablaConsulta.Size = new System.Drawing.Size(1048, 380);
            tablaConsulta.TabIndex = 12;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.919F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.84735F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.93347F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.17048F));
            tableLayoutPanel4.Controls.Add(label3, 2, 1);
            tableLayoutPanel4.Controls.Add(txtFiltro, 3, 1);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel4.Location = new System.Drawing.Point(12, 85);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.20635F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.79365F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel4.Size = new System.Drawing.Size(1048, 73);
            tableLayoutPanel4.TabIndex = 13;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label3.Location = new System.Drawing.Point(521, 35);
            label3.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(218, 24);
            label3.TabIndex = 7;
            label3.Text = "Filtro";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFiltro
            // 
            txtFiltro.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtFiltro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtFiltro.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtFiltro.Location = new System.Drawing.Point(751, 35);
            txtFiltro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new System.Drawing.Size(259, 27);
            txtFiltro.TabIndex = 9;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.AutoSize = true;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel5.Location = new System.Drawing.Point(12, 85);
            tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new System.Drawing.Size(1048, 0);
            tableLayoutPanel5.TabIndex = 7;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 4;
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08411F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.87539F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.99377F));
            tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.89096F));
            tableLayoutPanel8.Controls.Add(txtCInspeccion, 1, 1);
            tableLayoutPanel8.Controls.Add(dtpCHasta, 3, 1);
            tableLayoutPanel8.Controls.Add(dtpCDesde, 2, 1);
            tableLayoutPanel8.Controls.Add(txtCNro, 0, 1);
            tableLayoutPanel8.Controls.Add(label7, 3, 0);
            tableLayoutPanel8.Controls.Add(label6, 2, 0);
            tableLayoutPanel8.Controls.Add(label4, 0, 0);
            tableLayoutPanel8.Controls.Add(label9, 1, 0);
            tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel8.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.20635F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.79365F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel8.Size = new System.Drawing.Size(1048, 73);
            tableLayoutPanel8.TabIndex = 6;
            // 
            // txtCInspeccion
            // 
            txtCInspeccion.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtCInspeccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtCInspeccion.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtCInspeccion.Location = new System.Drawing.Point(137, 35);
            txtCInspeccion.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtCInspeccion.Name = "txtCInspeccion";
            txtCInspeccion.Size = new System.Drawing.Size(132, 27);
            txtCInspeccion.TabIndex = 11;
            // 
            // dtpCHasta
            // 
            dtpCHasta.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtpCHasta.CalendarForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            dtpCHasta.CalendarMonthBackground = System.Drawing.Color.FromArgb(120, 120, 120);
            dtpCHasta.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtpCHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpCHasta.Location = new System.Drawing.Point(418, 35);
            dtpCHasta.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            dtpCHasta.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            dtpCHasta.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpCHasta.Name = "dtpCHasta";
            dtpCHasta.Size = new System.Drawing.Size(116, 24);
            dtpCHasta.TabIndex = 12;
            // 
            // dtpCDesde
            // 
            dtpCDesde.CalendarFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtpCDesde.CalendarForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            dtpCDesde.CalendarMonthBackground = System.Drawing.Color.FromArgb(120, 120, 120);
            dtpCDesde.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dtpCDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpCDesde.Location = new System.Drawing.Point(293, 35);
            dtpCDesde.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            dtpCDesde.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            dtpCDesde.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpCDesde.Name = "dtpCDesde";
            dtpCDesde.Size = new System.Drawing.Size(100, 24);
            dtpCDesde.TabIndex = 11;
            // 
            // txtCNro
            // 
            txtCNro.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            txtCNro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtCNro.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            txtCNro.Location = new System.Drawing.Point(0, 35);
            txtCNro.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            txtCNro.Name = "txtCNro";
            txtCNro.Size = new System.Drawing.Size(125, 27);
            txtCNro.TabIndex = 8;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label7.Location = new System.Drawing.Point(418, 0);
            label7.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(618, 23);
            label7.TabIndex = 7;
            label7.Text = "Hasta";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label6.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label6.Location = new System.Drawing.Point(293, 0);
            label6.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(113, 23);
            label6.TabIndex = 6;
            label6.Text = "Desde";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label4.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label4.Location = new System.Drawing.Point(0, 0);
            label4.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(125, 23);
            label4.TabIndex = 4;
            label4.Text = "Recepcion";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label9.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            label9.Location = new System.Drawing.Point(137, 0);
            label9.Margin = new System.Windows.Forms.Padding(0, 0, 12, 12);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(144, 23);
            label9.TabIndex = 13;
            label9.Text = "Inspeccion";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(230, 233, 239);
            panel3.Controls.Add(btnConsultar);
            panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel3.Location = new System.Drawing.Point(12, 538);
            panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(1048, 87);
            panel3.TabIndex = 11;
            // 
            // btnConsultar
            // 
            btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConsultar.Image = (System.Drawing.Image)resources.GetObject("btnConsultar.Image");
            btnConsultar.Location = new System.Drawing.Point(5, -8);
            btnConsultar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new System.Drawing.Size(79, 78);
            btnConsultar.TabIndex = 10;
            btnConsultar.UseVisualStyleBackColor = true;
            // 
            // FormSensor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1088, 749);
            Controls.Add(tcGeneral);
            Controls.Add(labelDescripcion);
            Name = "FormSensor";
            Text = "FormSensor";
            tcGeneral.ResumeLayout(false);
            tpRegistro.ResumeLayout(false);
            panelRecepcion.ResumeLayout(false);
            panelRecepcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablaSensor).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanelContainer2.ResumeLayout(false);
            tableLayoutPanelContainer2.PerformLayout();
            panel2.ResumeLayout(false);
            tpConsultar.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tablaConsulta).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TabControl tcGeneral;
        private System.Windows.Forms.TabPage tpRegistro;
        private System.Windows.Forms.Panel panelRecepcion;
        private System.Windows.Forms.DataGridView tablaSensor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContainer2;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelContenedorPrincipar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabPage tpConsultar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tablaConsulta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox txtCInspeccion;
        private System.Windows.Forms.DateTimePicker dtpCHasta;
        private System.Windows.Forms.DateTimePicker dtpCDesde;
        private System.Windows.Forms.TextBox txtCNro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.ComboBox cbSensores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTiempo;
        private OxyPlot.WindowsForms.PlotView Grafica;
    }
}