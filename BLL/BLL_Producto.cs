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
    public class BLL_Producto : IAbmc<BE_Producto>
    {
        private readonly MapperProducto mapperProducto;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Producto()
        {
            mapperProducto = new MapperProducto();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Producto oProducto)
        {
            try
            {
                //Verificar que el producto no esté asociado a una orden de compra
                var mapperOrdenCompra = new MapperOrdenCompra();
                var productoEnUso = mapperOrdenCompra.Consultar()
                                    .Any(x => x.Productos.Any(y => y.ID == oProducto.ID));

                if (productoEnUso)
                {
                    throw new Exception("No se puede eliminar un producto si esta incluido en Ordenes de Compra");
                }

                return mapperProducto.Borrar(oProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Producto oProducto)
        {
            try
            {
                ValidarProducto(oProducto);
                return mapperProducto.Guardar(oProducto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BE_Producto> Consultar()
        { return mapperProducto.Consultar(); }

        private void ValidarProducto(BE_Producto oProducto)
        {
            if (string.IsNullOrEmpty(oProducto.NombreProducto))
            {
                throw new Exception("El nombre del producto es requerido");
            }

            if (oProducto.PrecioProducto <= 0)
            {
                throw new Exception("El precio del producto debe ser mayor a 0");
            }

            if (string.IsNullOrEmpty(oProducto.DescripcionProducto))
            {
                throw new Exception("La descripcion del producto es requerida");
            }

            //Verificar que no exista otro producto con el mismo nombre
            var productoExistente = Consultar()
                                    .FirstOrDefault(x => x.NombreProducto.ToLower() == 
                                    oProducto.NombreProducto.ToLower() && x.ID != oProducto.ID);
            if (productoExistente != null)
            {
                throw new Exception("Ya existe un producto con el mismo nombre");
            }
        }

        public List<BE_Producto> ListarProductosBajoStock()
        {
            return Consultar().Where(x => x.Stock <= 10).OrderBy(x => x.Stock).ToList();
        }

        public bool ActualizarStockProducto(BE_Producto oProducto, int cantidad)
        {
            try
            {
                if (oProducto.Stock + cantidad < 0)
                {
                    throw new Exception("Stock insuficiente");
                }

                oProducto.Stock += cantidad;
                return mapperProducto.Guardar(oProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
