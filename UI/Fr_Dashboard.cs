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

namespace UI
{
    public partial class Fr_Dashboard: Form
    {
        private readonly BLL_Boleto gestorBoleto;
        private readonly BLL_Funcion gestorFuncion;
        private readonly BLL_Cliente gestorCliente;
        private readonly BLL_Membresia gestorMembresia;
        private readonly BE_Empleado usuarioActual;

        public Fr_Dashboard(BE_Empleado usuario)
        {
            InitializeComponent();
            gestorBoleto = new BLL_Boleto();
            gestorFuncion = new BLL_Funcion();
            gestorCliente = new BLL_Cliente();
            gestorMembresia = new BLL_Membresia();
            usuarioActual = usuario;
        }

        private void Fr_Dashboard_Load(object sender, EventArgs e)
        {
            CargarEstadisticas();
            ConfigurarGraficos();
            ActualizarGraficos();
        }

        private void CargarEstadisticas()
        {
            try
            {
                var ventashoy = gestorBoleto.CalcularVentasDia(DateTime.Today);
                var totalClientes = gestorCliente.Consultar().Count;
                var membresiasActivas = gestorMembresia.ConsultarMembresiasActivas().Count;
                var funcionesActivas = gestorFuncion.ListarFuncionesFuturas().Count;

                lblVentasHoy.Text = $"$ {ventashoy : N2}";
                lblTotalClientes.Text = totalClientes.ToString();
                lblMembresiasActivas.Text = membresiasActivas.ToString();
                lblFuncionesActivas.Text = funcionesActivas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarGraficos()
        {
            chartVentasMensuales.ChartAreas.Clear();
            chartVentasMensuales.Series.Clear();

            var areaVentas = new ChartArea("VentasMensuales");
            chartVentasMensuales.ChartAreas.Add(areaVentas);

            var serieVentas = new Series("VentasMensuales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double,
                XValueMember = "Fecha",
                YValueMembers = "Cantidad"
            };

            chartVentasMensuales.Series.Add(serieVentas);

            chartPeliculas.ChartAreas.Clear();
            chartPeliculas.Series.Clear();

            var areaPeliculas = new ChartArea("Peliculas");
            chartPeliculas.ChartAreas.Add(areaPeliculas);

            var seriePeliculas = new Series("Peliculas")
            {
                ChartType = SeriesChartType.Pie
            };
        }

        private void ActualizarGraficos()
        {
            try
            {
                var ventasMensuales = gestorBoleto.ObtenerVentasMensuales();
                foreach (var venta in ventasMensuales)
                {
                    chartVentasMensuales.Series["VentasMensuales"].Points
                        .AddXY(venta.Mes.ToString("MMM"), venta.Total);
                }

                var peliculasPouplares = gestorBoleto.ObtenerPeliculasPopularses();
                foreach (var pelicula in peliculasPouplares)
                {
                    var punto = chartPeliculas.Series["Peliculas"].Points.Add(pelicula.Cantidad);
                    punto.LegendText = pelicula.Titulo;
                    punto.Label = $"{pelicula.Pocentaje : N1}%";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
