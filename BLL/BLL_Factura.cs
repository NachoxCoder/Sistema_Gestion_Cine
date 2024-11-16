using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mappers;
using Interfaces;

namespace BLL
{
    public class BLL_Factura : IAbmc<BE_Factura>
    {
        private readonly MapperFactura mapperFactura;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Factura()
        {
            mapperFactura = new MapperFactura();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Factura oFactura)
        {
            //Las Facturas no pueden ser borradas por motivos fiscales
            return false;
        }

        public bool Guardar(BE_Factura oFactura)
        {
            try
            {
                ValidarFactura(oFactura);

                if (oFactura.ID == 0)
                {
                    oFactura.FechaEmision = DateTime.Now;
                    CalcularTotales(oFactura);
                }

                return mapperFactura.Guardar(oFactura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Factura> Consultar()
        {
            return mapperFactura.Consultar();
        }

        public void ValidarFactura(BE_Factura oFactura)
        {
            if (oFactura.IdCliente == 0)
            {
                throw new Exception("Se debe especificar un cliente.");
            }

            if (!oFactura.Detalles.Any())
            {
                throw new Exception("La factura no tiene items.");
            }

            if(string.IsNullOrEmpty(oFactura.MetodoPago))
            {
                throw new Exception("Se debe especificar un método de pago.");
            }
        }

        private void CalcularTotales(BE_Factura oFactura)
        {
            oFactura.Subtotal = oFactura.Detalles.Sum(x => x.Subtotal);
            oFactura.IVA = oFactura.Subtotal * 0.21m;
            oFactura.Total = oFactura.Subtotal + oFactura.IVA;
        }
    }
}
