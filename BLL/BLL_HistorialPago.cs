using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using Mappers;

namespace BLL
{
    public class BLL_HistorialPago : IAbmc<BE_HistorialPago>
    {
        private readonly MappperHistorialPago mapperHistorialPago;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_HistorialPago()
        {
            mapperHistorialPago = new MappperHistorialPago();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_HistorialPago oPago)
        {
            //Los Pagos no se pueden borrar
            return false;
        }

        public bool Guardar(BE_HistorialPago oPago)
        {
            try
            {
                ValidarPago(oPago);

                if (oPago.ID == 0)
                {
                    oPago.FechaPago = DateTime.Now;
                    oPago.NumeroTransaccion = GenerarNumeroTransaccion();
                }

                return mapperHistorialPago.Guardar(oPago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_HistorialPago> Consultar()
        {
            return mapperHistorialPago.Consultar();
        }

        public void ValidarPago(BE_HistorialPago oPago)
        {
            if (oPago.IdFactura == 0)
            {
                throw new Exception("Se debe especificar una factura.");
            }

            if (oPago.Monto <= 0)
            {
                throw new Exception("El monto debe ser mayor a 0.");
            }

            if (string.IsNullOrEmpty(oPago.MetodoPago))
            {
                throw new Exception("Se debe especificar un medio de pago.");
            }
        }

        public List<BE_HistorialPago> ListarPagosPorPeriodo(DateTime desde, DateTime hasta)
        {
            return Consultar().Where(x => x.FechaPago.Date >= desde.Date && x.FechaPago.Date <= hasta.Date)
                   .OrderByDescending(x => x.FechaPago).ToList();
        }

        public decimal ObtenerTotalPagosPorPeriodo(DateTime desde, DateTime hasta)
        {
            return ListarPagosPorPeriodo(desde, hasta).Where(x => x.Estado == "Completado").Sum(x => x.Monto);
        }

        private string GenerarNumeroTransaccion()
        {
            return $"TR{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000,9999)}";
        }
    }
}
