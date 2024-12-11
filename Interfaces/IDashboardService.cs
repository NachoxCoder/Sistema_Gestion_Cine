using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDashboardService
    {
        Dictionary<string, object> ObtenerMetricas();
        Dictionary<string, decimal> ObtenerMetricasPorPeriodo(DateTime desde, DateTime hasta);
        Dictionary<string, int> ObtenerEstadisticasOcupacion();
        void ExportarReporte(string rutaArchivo, DateTime desde, DateTime hasta);
    }
}
