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
    public class BLL_Cliente : IAbmc<BE_Cliente>
    {
        private readonly MapperCliente mapperCliente;
        private readonly BLL_Bitacora bLL_Bitacora;

        public BLL_Cliente()
        {
            mapperCliente = new MapperCliente();
            bLL_Bitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Cliente oCliente)
        {
            try
            {
                //Verificamos que el cliente no posea boletos comprados ni membresias activas
                var mapperBoleto = new MapperBoleto();
                var poseeBoletos = mapperBoleto.Consultar()
                    .Any(x => x.IdCliente == oCliente.ID);
                var mapperMembresia = new MapperMembresia();
                var poseeMembresia = mapperMembresia.Consultar()
                    .Any(x => x.IdCliente == oCliente.ID && x.EstaActiva);

                if (poseeBoletos || poseeMembresia)
                {
                    throw new Exception("No se puede eliminar el cliente con boletos comprados o membresias activa.");
                }
                return mapperCliente.Borrar(oCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Cliente oCliente)
        {
            try
            {
                ValidarCliente(oCliente);
                ValidarDocumentoUnico(oCliente);
                return mapperCliente.Guardar(oCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Cliente> Consultar()
        {
            return mapperCliente.Consultar();
        }

        private void ValidarCliente(BE_Cliente oCliente)
        {
            if (string.IsNullOrEmpty(oCliente.Nombre) || string.IsNullOrEmpty(oCliente.Apellido))
            {
                throw new Exception("El nombre y apellido del cliente son obligatorios");
            }
            if (string.IsNullOrEmpty(oCliente.DNI))
            {
                throw new Exception("El DNI es obligatorio");
            }
            if (string.IsNullOrEmpty(oCliente.Email))
            {
                throw new Exception("El email del cliente es obligatorio");
            }
            if (!oCliente.Email.Contains("@") || !oCliente.Email.Contains("."))
            {
                throw new Exception("El formato del email es invalido");
            }
            
            if (oCliente.FechaNacimiento > DateTime.Today.AddYears(-16))
            {
                throw new Exception("El cliente debe ser mayor de 16 años");
            }
        }

        private void ValidarDocumentoUnico(BE_Cliente oCliente)
        {
            var clienteExistente = Consultar().FirstOrDefault(x => x.DNI == oCliente.DNI && x.ID != oCliente.ID);

            if (clienteExistente != null)
            {
                throw new Exception("Ya existe un cliente con el mismo DNI");
            }
        }

        public bool Modificar(BE_Cliente pCliente)
        {
            try
            {
                ValidarCliente(pCliente);
                return mapperCliente.Guardar(pCliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar cliente: {ex.Message}");
            }
        }
    }
}
