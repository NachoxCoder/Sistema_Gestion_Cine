using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDashboard
    {
        decimal CalcularVentasDia(DateTime fecha);
        IEnumerable<object> ObtenerVentasMensuales();
        IEnumerable<object> ObtenerPeliculasPopulares();
        BLL_Dashboard.MetricasDashboard ObtenerMetricas();
    }
}
