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
    public class BLL_Proveedor : IAbmc<BE_Proveedor>
    {
        private readonly MapperProveedor mapperProveedor;
        private readonly BLL_Bitacora gestorBitacora;

        public BLL_Proveedor()
        {
            mapperProveedor = new MapperProveedor();
            gestorBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Proveedor oProveedor)
        {
            try
            {
                var ordenesActivas = oProveedor.OrdenesCompra
                    .Any(x => x.EstadoOrdenCompra == "Pendiente" || x.EstadoOrdenCompra == "En Proceso");

                if (ordenesActivas)
                {
                    throw new Exception("No se puede eliminar el proveedor porque tiene ordenes de compra activas");
                }

                return mapperProveedor.Borrar(oProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Proveedor oProveedor)
        {
            try
            {
                ValidarProveedor(oProveedor);
                
                if(oProveedor.ID == 0)
                {
                    var existente = mapperProveedor.Consultar().FirstOrDefault(x => x.CUIT == oProveedor.CUIT);
                    if(existente != null)
                    {
                        throw new Exception("Ya existe un proveedor con el CUIT ingresado");
                    }
                }

                return mapperProveedor.Guardar(oProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Proveedor> Consultar()
        {
            return mapperProveedor.Consultar();
        }

        private void ValidarProveedor(BE_Proveedor oProveedor)
        {
            if (string.IsNullOrWhiteSpace(oProveedor.RazonSocial))
            {
                throw new Exception("Debe ingresar la razón social del proveedor");
            }

            if (string.IsNullOrWhiteSpace(oProveedor.CUIT))
            {
                throw new Exception("Debe ingresar el CUIT del proveedor");
            }

            if (string.IsNullOrWhiteSpace(oProveedor.DireccionProveedor))
            {
                throw new Exception("Debe ingresar la dirección del proveedor");
            }

            if (string.IsNullOrWhiteSpace(oProveedor.TelefonoProveedor))
            {
                throw new Exception("Debe ingresar el teléfono del proveedor");
            }

            if (!oProveedor.EmailProveedor.Contains("@"))
            {
                throw new Exception("El email es invalido");
            }
        }

        public List<BE_Proveedor> ListarProveedoresActivos()
        {
            return Consultar().Where(x => x.EstaActivo).ToList();
        }
    }
}
