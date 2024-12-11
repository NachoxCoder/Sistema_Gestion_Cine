using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using BLL;
using Timer = System.Windows.Forms.Timer;

namespace UI
{
    public partial class Fr_Dashboard : Form
    {
        private readonly BLL_Dashboard gestorDashboard;
        private readonly BE_Empleado usuarioActual;
        private readonly BLL_Producto gestorProducto;
        private DateTime fechaDesde;
        private DateTime fechaHasta;

        public Fr_Dashboard(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorDashboard = new BLL_Dashboard();
            gestorProducto = new BLL_Producto();
            usuarioActual = usuario;
            fechaDesde = DateTime.Today.AddMonths(-1);
            fechaHasta = DateTime.Today;
        }

        private void Fr_Dashboard_Load(object sender, EventArgs e)
        {
            ConfigurarControlesFecha();
            ConfigurarGraficos();
            ActualizarDashboard();
            ConfigurarTimer();
        }

        private void ConfigurarControlesFecha()
        {
            dtpDesde.Value = fechaDesde;
            dtpHasta.Value = fechaHasta;
            dtpDesde.ValueChanged += (s, e) => ActualizarDashboard();
            dtpHasta.ValueChanged += (s, e) => ActualizarDashboard();
        }

        private void ConfigurarGraficos()
        {
            chartVentasMensuales.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartVentasMensuales.ChartAreas[0].AxisX.Interval = 1;
            chartVentasMensuales.Series["Ventas"].ChartType = SeriesChartType.Column;

            chartPeliculas.Series["Peliculas"].ChartType = SeriesChartType.Pie;
            chartPeliculas.Series["Peliculas"].Label = "#PERCENT{P1}";

            chartOcupacion.Series["Ocupacion"].ChartType = SeriesChartType.Pie;
            chartOcupacion.Series["Ocupacion"].Label = "#VALX\n#PERCENT{P1}";
            chartOcupacion.Titles.Clear();
            chartOcupacion.Titles.Add("Ocupación por Sala");
        }

            private void ActualizarDashboard()
        {
            try
            {
                var metricas = gestorDashboard.ObtenerMetricas();
                ActualizarMetricas(metricas);
                ConfiguarGrilla();
                ActualizarGraficos();
                ActualizarProdcutosBajoStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el Dashboard: {ex.Message}");
            }
        }

        private void ActualizarMetricas(Dictionary<string, object> metricas)
        {
            lblTotalClientes.Text = metricas["TotalClientes"].ToString();
            lblMembresiasActivas.Text = metricas["MembresiasActivas"].ToString();
            lblVentasDiaria.Text = $"$ {metricas["VentasHoy"]:N2}";
            lblVentasPeriodo.Text = $"$ {metricas["VentasMes"]:N2}";
        }

        private void ActualizarGraficos()
        {
            var metricasPorPeriodo = gestorDashboard.ObtenerMetricasPorPeriodo(fechaDesde, fechaHasta);
            var peliculasMasVistas = gestorDashboard.ObtenerEstadisticasOcupacion();
            var ocupacion = gestorDashboard.ObtenerEstadisticasOcupacion();

            chartVentasMensuales.Series["Ventas"].Points.Clear();
            foreach (var item in metricasPorPeriodo)
            {
                chartVentasMensuales.Series["Ventas"].Points.AddXY(item.Key, item.Value);
            }

            chartPeliculas.Series["Peliculas"].Points.Clear();
            foreach (var item in peliculasMasVistas)
            {
                var punto = chartPeliculas.Series["Peliculas"].Points.Add(item.Value);
                punto.LegendText = item.Key;
                punto.Label = $"{item.Value}";
            }

            chartOcupacion.Series["Ocupacion"].Points.Clear();
            foreach (var item in ocupacion)
            {
                int pointIndex = chartOcupacion.Series["Ocupacion"].Points.AddXY(item.Key, item.Value);
                chartOcupacion.Series["Ocupacion"].Points[pointIndex].Label = $"{item.Value:N1}%";
                chartOcupacion.Series["Ocupacion"].Points[pointIndex].LegendText = item.Key;
            }
        }

        private void ConfiguarGrilla()
        {
            dgvLowStock.AutoGenerateColumns = false;
            dgvLowStock.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Producto", DataPropertyName = "NombreProducto", HeaderText = "Producto", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Stock", DataPropertyName = "Stock", HeaderText = "Stock Actual", Width = 100 }
            );

            dgvLowStock.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void ActualizarProdcutosBajoStock()
        {
            try
            {
                var productosBajoStock = gestorProducto.ListarProductosBajoStock()
                    .Select(x => new { x.NombreProducto, x.Stock }).ToList();

                dgvLowStock.DataSource = productosBajoStock;

                lblAlertaLowStock.Text = productosBajoStock.Any()
                    ? $"!ATENCION¡ Hay: {productosBajoStock.Count} productos con bajo Stock" 
                    : "No hay productos con stock bajo";
                lblAlertaLowStock.ForeColor = productosBajoStock.Any() ? Color.Red : Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += (s, e) => ActualizarDashboard();
            timer.Start();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveDialog.DefaultExt = "pdf";
                    saveDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        gestorDashboard.ExportarReporte(saveDialog.FileName, fechaDesde, fechaHasta);
                        MessageBox.Show("Reporte exportado correctamente");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
