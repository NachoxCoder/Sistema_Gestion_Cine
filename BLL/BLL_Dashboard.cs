using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using BE;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;

namespace BLL
{
    public class BLL_Dashboard : IDashboardService
    {
        private readonly BLL_Boleto gestorBoleto;
        private readonly BLL_Cliente gestorCliente;
        private readonly BLL_Membresia gestorMembresia;
        private readonly BLL_Pelicula gestorPelicula;
        private readonly BLL_Funcion gestorFuncion;

        public BLL_Dashboard()
        {
            gestorBoleto = new BLL_Boleto();
            gestorCliente = new BLL_Cliente();
            gestorMembresia = new BLL_Membresia();
            gestorPelicula = new BLL_Pelicula();
            gestorFuncion = new BLL_Funcion();
        }

        public Dictionary<string, object> ObtenerMetricas()
        {
            return new Dictionary<string, object>
            {
                [ "TotalClientes"] = gestorCliente.Consultar().Count,
                ["MembresiasActivas"] = gestorMembresia.Consultar().Count(x => x.EstaActiva),
                ["VentasHoy"] = CalcularVentasDia(DateTime.Today),
                ["VentasMes"] = CalcularVentasDia(DateTime.Today.AddDays(-30)),
                ["PeliculasMasVistas"] = ObtenerPeliculasMasVistas(5),
                ["OcupacionSalas"] = CalcularOcupacionSalas()
            };
        }

        public Dictionary<string, decimal> ObtenerMetricasPorPeriodo(DateTime desde, DateTime hasta)
        {
            var ventas = gestorBoleto.Consultar()
                .Where(x => x.FechaVenta.Date >= desde.Date && x.FechaVenta.Date <= hasta.Date)
                .GroupBy(x => x.FechaVenta.ToString("yyyy-MM"));

            return new Dictionary<string, decimal>
            {
                ["TotalVentas"] = ventas.Sum(x => x.Sum(y => y.Precio)),
                ["PromedioVentaDiaria"] = ventas.Average(x => x.Sum(y => y.Precio)),
                ["MaximoVentas"] = ventas.Max(x => x.Sum(y => y.Precio)),
                ["MinimoVentas"] = ventas.Min(x => x.Sum(y => y.Precio))
            };
        }

        public Dictionary<string, int> ObtenerEstadisticasOcupacion()
        {
            var funciones = gestorFuncion.Consultar();
            var boletos = gestorBoleto.Consultar();

            return funciones.ToDictionary(x => x.Pelicula.Titulo, x => boletos.Count(y => y.IdFuncion == x.ID));
        }

        public void ExportarReporte(string rutaArchivo, DateTime desde, DateTime hasta)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            using (Document doc = new Document(PageSize.A4, 50,50,25,25))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                doc.Add(new Paragraph($"Reporte de Ventas: {desde:dd/MM/yyy} - {hasta:dd/MM/yyyy}"));
                doc.Add(new Paragraph("\n"));

                var metricas = ObtenerMetricasPorPeriodo(desde, hasta);
                foreach (var metrica in metricas)
                {
                    doc.Add(new Paragraph($"{metrica.Key}: ${metrica.Value:N2}"));
                }
                
                doc.Add(new Paragraph("\nPeliculas mas Vistas"));
                foreach (var pelicula in ObtenerPeliculasMasVistas(5))
                {
                    doc.Add(new Paragraph($"{pelicula.Key}: {pelicula.Value} vistas"));
                }

                doc.Close();
            }
        }

        private Dictionary<string, int> ObtenerPeliculasMasVistas(int top)
        {
            return gestorBoleto.Consultar().GroupBy(x => x.Funcion.Pelicula.Titulo)
                .OrderByDescending(x => x.Count()).Take(top).ToDictionary(x => x.Key, x => x.Count());
        }

        private decimal CalcularVentasDia(DateTime fecha)
        {
            return gestorBoleto.Consultar().Where(x => x.FechaVenta.Date == fecha.Date).Sum(x => x.Precio);
        }

        private decimal CalcularVentasPeriodo(DateTime desde, DateTime hasta)
        {
            return gestorBoleto.Consultar()
                .Where(x => x.FechaVenta.Date >= desde.Date && x.FechaVenta.Date <= hasta.Date).Sum(x => x.Precio);
        }

        private Dictionary<string, decimal> CalcularOcupacionSalas()
        {
            var funciones = gestorFuncion.Consultar();
            var boletos = gestorBoleto.Consultar();

            return funciones.GroupBy(x => x.Sala.Nombre)
                .ToDictionary(x => x.Key, x =>
                {
                    var capacidadTotal = x.Sum(y => y.Sala.Capacidad);
                    var boletosVendidos = boletos.Count(y => x.Select(z => z.ID).Contains(y.IdFuncion));
                    return capacidadTotal > 0 ? (decimal)boletosVendidos / capacidadTotal * 100 : 0;
                }
                
            );
        }
    }
}
