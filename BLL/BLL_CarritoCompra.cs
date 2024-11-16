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
    public class BLL_CarritoCompra : IAbmc<BE_CarritoCompra>
    {
        private readonly MapperCarritoCompra mapperCarritoCompra;
        private readonly BLL_Bitacora bLL_Bitacora;

        public BLL_CarritoCompra()
        {
            mapperCarritoCompra = new MapperCarritoCompra();
            bLL_Bitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_CarritoCompra oCarritoCompra)
        {
            try
            {
                return mapperCarritoCompra.Borrar(oCarritoCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_CarritoCompra oCarritoCompra)
        {
            try
            {
                ValidarCarrito(oCarritoCompra);
                CalcularTotal(oCarritoCompra);
                return mapperCarritoCompra.Guardar(oCarritoCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_CarritoCompra> Consultar()
        {
            return mapperCarritoCompra.Consultar();
        }

        public BE_CarritoCompra ObtenerCarritoActivo (int idCliente)
        {
            return Consultar().FirstOrDefault(x => x.IdCliente == idCliente && x.Items.Any());
        }

        private void ValidarCarrito(BE_CarritoCompra oCarritoCompra)
        {
            if(oCarritoCompra.IdCliente == 0)
            {
                throw new Exception("El carrito no tiene un cliente asignado");
            }

            if (!oCarritoCompra.Items.Any())
            {
                throw new Exception("El carrito esta vacio");
            }
        }

        private void CalcularTotal(BE_CarritoCompra oCarritoCompra)
        {
            oCarritoCompra.Total = oCarritoCompra.Items.Sum(x => x.Subtotal);
        }

        public bool ProcesarCompra(BE_CarritoCompra oCarritoCompra, string metodoPago)
        {
            try
            {
                var factura = new BE_Factura
                {
                    Cliente = oCarritoCompra.Cliente,
                    IdCliente = oCarritoCompra.IdCliente,
                    TipoFactura = "A",
                    FechaEmision = DateTime.Now,
                    MetodoPago = metodoPago,
                    Total = oCarritoCompra.Total
                };

                foreach (var item in oCarritoCompra.Items)
                {
                    var detalle = new BE_DetalleFactura
                    {
                        Descripcion = $"Boleto - {item.Boleto.Funcion.PeliculaTitulo()}",
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.PrecioUnitario,
                        Subtotal = item.Subtotal
                    };
                    factura.Detalles.Add(detalle);
                }

                var bllFactura = new BLL_Factura();
                if(!bllFactura.Guardar(factura))
                {
                    throw new Exception("Error al generar la factura");
                }
                var historialPago = new BE_HistorialPago
                {
                    IdFactura = factura.ID,
                    FechaPago = DateTime.Now,
                    Monto = factura.Total,
                    MetodoPago = metodoPago,
                    Estado = "Aprobado"
                };

                var bllHistorialPago = new BLL_HistorialPago();
                if (!bllHistorialPago.Guardar(historialPago))
                {
                    throw new Exception("Error al registrar el pago");
                }

                return Borrar(oCarritoCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
