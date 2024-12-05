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
        private readonly MapperProducto mapperProducto;

        public BLL_OrdenCompra()
        {
            mapperOrdenCompra = new MapperOrdenCompra();
            bllBitacora = new BLL_Bitacora();
            mapperProducto = new MapperProducto();
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
                throw ex;
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
                throw ex;
            }
        }

        public List<BE_OrdenCompra> Consultar()
        {
            return mapperOrdenCompra.Consultar();
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
                    throw new Exception($"La cantidad del producto: {producto.NombreProducto} debe ser mayor a 0.");
                }

                if (producto.PrecioUnitario <= 0)
                {
                    throw new Exception($"El precio del producto: {producto.NombreProducto} debe ser mayor a 0.");
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

                foreach (var item in oOrdenCompra.Detalles)
                {
                    var producto = mapperProducto.ConsultarPorId(item.IdProducto);
                    if (producto == null)
                    {
                        throw new Exception($"El producto {item.IdProducto} no existe");
                    }

                    producto.Stock += item.Cantidad;
                    mapperProducto.Guardar(producto);
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
                throw ex;
            }
        }
    }
}
