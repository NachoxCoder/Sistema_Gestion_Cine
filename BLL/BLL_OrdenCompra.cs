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
    public class BLL_OrdenCompra : IAbmc<BE_OrdenCompra>
    {
        private readonly MapperOrdenCompra mapperOrdenCompra;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_OrdenCompra()
        {
            mapperOrdenCompra = new MapperOrdenCompra();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_OrdenCompra oOrdenCompra)
        {
            try
            {
                //No se puede borrar una orden de compra que ya fue procesada
                if (oOrdenCompra.EstadoOrdenCompra != "Pendiente")
                {
                    throw new Exception("Solo se pueden eliminar ordenes en estado Pendiente");
                }
                return mapperOrdenCompra.Borrar(oOrdenCompra);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al borrar orden de compra: {ex.Message}");
            }
        }

        public bool Guardar(BE_OrdenCompra oOrdenCompra)
        {
            try
            {
                ValidarOrdenCompra(oOrdenCompra);
                return mapperOrdenCompra.Guardar(oOrdenCompra);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar orden de compra: {ex.Message}");
            }
        }

        public List<BE_OrdenCompra> Consultar()
        {
            return mapperOrdenCompra.Consultar();
        }

        public List<BE_DetalleOrdenCompra> ObtenerDetallesOrden(int idOrden)
        {
            var mapperDetalle = new MapperDetalleOrdenCompra();
            return mapperDetalle.ConsultarPorOrden(idOrden);
        }

        private void ValidarOrdenCompra(BE_OrdenCompra oOrdenCompra)
        {
            if (oOrdenCompra.IdProveedor == 0)
            {
                throw new Exception("Debe seleccionar un proveedor");
            }

            if (!oOrdenCompra.Detalles.Any())
            {
                throw new Exception("La orden de compra no tiene productos.");
            }

            foreach (var producto in oOrdenCompra.Detalles)
            {
                if (producto.Cantidad <= 0)
                {
                    throw new Exception($"La cantidad del producto debe ser mayor a 0.");
                }

                if (producto.PrecioUnitario <= 0)
                {
                    throw new Exception($"El precio del producto debe ser mayor a 0.");
                }
            }

        }

        public bool ProcesarOrdenCompra(BE_OrdenCompra oOrdenCompra, BE_Empleado usuario)
        {
            try
            {
               if (oOrdenCompra.EstadoOrdenCompra != "Pendiente")
                {
                    throw new Exception("La orden ya fue procesada");
                }

                oOrdenCompra.EstadoOrdenCompra = "Procesada";
                var result = mapperOrdenCompra.Guardar(oOrdenCompra);

                if (result)
                {
                    bllBitacora.Log(usuario, $"Se procesó la orden de compra: #{oOrdenCompra.ID}");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar orden de compra: {ex.Message}");
            }
        }
    }
}
