using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using MIS.Helpers;

namespace MIS.Vistas.Laboratorio
{
    public partial class FormSensor : Form
    {
        private SerialPort _serialPort;
        private DataTable _dataTable;
        private System.Windows.Forms.Timer _timer;
        private int _intervalo;
        private PlotModel _plotModel;
        private LineSeries _lineaTemperatura;
        private LineSeries _lineaVariable;
        private float temperatura;
        private float variable;
        private double minPSI, maxPSI;
        public FormSensor()
        {
            CultureInfo culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
            FillComboBoxWithCOMPorts();
            InicializarGrafica();
            
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Variable", typeof(float));
            _dataTable.Columns.Add("Temperatura", typeof(float));
            
            tablaSensor.DataSource = _dataTable;
            tablaSensor.CurrentCell = null;
            tablaSensor.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            tablaSensor.Columns["Variable"].HeaderText = "PSI";
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Tick;
            _timer.Tick += Datos;
            _intervalo = int.TryParse(txtTiempo.Text, out int result) ? result * 1000 : 1000;
            _timer.Interval = _intervalo;
            this.FormClosing += FormSensor_FormClosing;
            limpiar();
        }

        private void InicializarGrafica()
        {
            _plotModel = new PlotModel { Title = "Datos" };
            _plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "HH:mm:ss",
                Title = "Tiempo",
                IntervalType = DateTimeIntervalType.Seconds,
                MinorIntervalType = DateTimeIntervalType.Seconds,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });
            _plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Temperatura (°C)",
                Minimum = 0,
                Maximum = 100,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });
            _plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Right,
                Title = "Presión (PSI)",
                Minimum = 0,
                Maximum = 10000,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                Key = "PressureAxis" // Añade una clave para este eje
            });
            _lineaTemperatura = new LineSeries
            {
                Title = "Temperatura",
                StrokeThickness = 2,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                Color = OxyColors.Orange
            };
            _lineaVariable = new LineSeries
            {
                Title = "PSI",
                StrokeThickness = 2,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                Color = OxyColors.Blue,
                YAxisKey = "PressureAxis"
            };
            _plotModel.Series.Add(_lineaTemperatura);
            _plotModel.Series.Add(_lineaVariable);
            Grafica.Model = _plotModel;
        }

        private void Datos(object sender, EventArgs e)
        {
            if (_lineaTemperatura != null && _lineaVariable != null)
            {
                float temperatura = this.temperatura;
                float variable = this.variable;
                _lineaTemperatura.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), temperatura));
                _lineaVariable.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), variable));

                // Ajustar el máximo del eje X para desplazarse con el tiempo
                (_plotModel.Axes[0] as DateTimeAxis).Maximum = DateTimeAxis.ToDouble(DateTime.Now);
                (_plotModel.Axes[0] as DateTimeAxis).Minimum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(-30));

                Grafica.InvalidatePlot(true);
            }
            else
            {
                MessageBox.Show("La serie de temperatura no está inicializada correctamente.");
            }
        }
        private void FormSensor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }

            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                string data = _serialPort.ReadLine();
                string[] values = data.Split(',');

                if (values.Length == 2 &&
                    float.TryParse(values[0], out float variable) &&
                    float.TryParse(values[1], out float temperatura))
                {
                    // Insertar datos en el DataTable
                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        double voltage = variable; 
                        double minVoltage = 0.0;
                        double maxVoltage = 5.0;
                        double psi = minPSI + ((voltage - minVoltage) / (maxVoltage - minVoltage)) * (maxPSI - minPSI);
                        DataRow newRow = _dataTable.NewRow();
                        newRow["Variable"] = psi;
                        newRow["Temperatura"] = temperatura;
                        this.variable = (float)psi;
                        this.temperatura = temperatura;
                        _dataTable.Rows.InsertAt(newRow, 0);
                        btnLimpiar.Visible = true;
                        btnGuardar.Visible = true;
                        btnImprimir.Visible = true;
                    }));
                }
            }
        }




        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (cbSensores.SelectedItem != null)
            {
                
                string selectedPort = cbSensores.SelectedItem.ToString();
                
                if (!SerialPort.GetPortNames().Contains(selectedPort))
                {
                    MessageBox.Show($"El puerto {selectedPort} no está disponible o no está conectado.");
                    return;
                }
                try
                {
                    
                    if (!double.TryParse(txtMin.Text, out minPSI))
                    {
                        FG.ShowAlert("Ingrese un valor valido (Valor Mínimo)", "Advertencia");
                        return;
                    }
                    if (!double.TryParse(txtMax.Text, out maxPSI))
                    {
                        FG.ShowAlert("Ingrese un valor valido (Valor Máximo)", "Advertencia");
                        return;
                    }
                    txtMin.Enabled = false;
                    txtMax.Enabled = false;
                    // Ajustar los límites del eje de presión
                    var pressureAxis = _plotModel.Axes.FirstOrDefault(a => a.Key == "PressureAxis") as LinearAxis;
                    if (pressureAxis != null)
                    {
                        pressureAxis.Minimum = minPSI;
                        pressureAxis.Maximum = maxPSI;
                    }
                    tablaSensor.Visible = true;
                    _serialPort = new SerialPort(selectedPort, 9600);
                    _serialPort.Open();
                    int tiempo = int.TryParse(txtTiempo.Text, out int result) ? result : 1;
                    _serialPort.WriteLine(tiempo.ToString());
                    _timer.Start();
                    btnComenzar.Enabled = false;
                    btnDetener.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el puerto {selectedPort}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un puerto COM primero.");
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                txtMin.Enabled = true;
                txtMax.Enabled = true;
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
                _timer.Stop();
                btnComenzar.Enabled = true;
                btnDetener.Enabled = false;
            }
        }

        private void limpiar()
        {
            btnDetener_Click(null, null);
            btnLimpiar.Visible = false;
            btnGuardar.Visible = false;
            btnImprimir.Visible = false;
            
            
            tablaSensor.DataSource = _dataTable;
            tablaSensor.CurrentCell = null;

            if (_lineaTemperatura != null)
            {
                _lineaTemperatura.Points.Clear();
            }
            if (_lineaVariable != null)
            {
                _lineaVariable.Points.Clear();
            }

            Grafica.InvalidatePlot(true);
        }


        private void FillComboBoxWithCOMPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cbSensores.Items.Clear();
            cbSensores.Items.AddRange(ports);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _dataTable.Clear();
            limpiar();
            tablaSensor.Visible = true;
        }

        private void txtTiempo_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTiempo.Text, out int tiempo))
            {
                _intervalo = tiempo * 1000;
                _timer.Interval = _intervalo;
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.WriteLine(tiempo.ToString());
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor válido.");
                txtTiempo.Text = "1";
                _intervalo = 1000;
                _timer.Interval = _intervalo;
            }
        }
    }
}
