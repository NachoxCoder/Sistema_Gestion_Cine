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
                if (oOrdenCompra.EstadoOrdenCompra == "Procesada")
                {
                    throw new Exception("No se puede eliminar una orden de compra que ya fue procesada.");
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

                if (oOrdenCompra.ID == 0)
                {
                    oOrdenCompra.FechaOrdenCompra = DateTime.Now;
                    CalcularTotalOrdenCompra(oOrdenCompra);

                }
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

            if (!oOrdenCompra.Productos.Any())
            {
                throw new Exception("La orden de compra no tiene productos.");
            }

            foreach (var producto in oOrdenCompra.Productos)
            {
                if (producto.Stock <= 0)
                {
                    throw new Exception($"La cantidad del producto {producto.NombreProducto} debe ser mayor a 0.");
                }

                if (producto.PrecioProducto <= 0)
                {
                    throw new Exception($"El precio del producto {producto.NombreProducto} debe ser mayor a 0.");
                }
            }

        }

        private void CalcularTotalOrdenCompra(BE_OrdenCompra oOrdenCompra)
        {
            oOrdenCompra.TotalOrdenCompra = oOrdenCompra.Productos.Sum(x => x.PrecioProducto * x.Stock);
        }

        public bool ProcesarOrdenCompra(BE_OrdenCompra oOrdenCompra)
        {
            try
            {
                //Actualizar el stock de los productos
                foreach (var producto in oOrdenCompra.Productos)
                {
                    var productoExistente = mapperProducto.ConsultarPorId(producto.ID);

                    if (productoExistente != null)
                    {
                        productoExistente.Stock += producto.Stock;
                        mapperProducto.Guardar(productoExistente);
                    }
                }
                
                oOrdenCompra.EstadoOrdenCompra = "Procesada";
                return mapperOrdenCompra.Guardar(oOrdenCompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
