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
    public class BLL_Empleado : IAbmc<BE_Empleado>
    {
        private readonly MapperEmpleado mapperEmpleado;

        public BLL_Empleado()
        {
            mapperEmpleado = new MapperEmpleado();
        }

        public bool Guardar(BE_Empleado oEmpleado)
        {
            try
            {
                ValidarEmpleado(oEmpleado);
                return mapperEmpleado.Guardar(oEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar Empleado: {ex.Message}");
            }
        }

        public bool Borrar(BE_Empleado oEmpleado)
        {
            try
            {
                return mapperEmpleado.Borrar(oEmpleado);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al borrar Empleado: {ex.Message}");
            }
        }

        public List<BE_Empleado> Consultar()
        {
            return mapperEmpleado.Consultar();
        }

       public bool VerificarEmpleado(BE_Empleado oEmpleado)
        {
            try
            {
                var empleado = mapperEmpleado.Consultar()
                    .FirstOrDefault(x => x.Username == oEmpleado.Username);

                if (empleado == null) return false;

                return empleado.Password == oEmpleado.Password;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al verificar datos {ex.Message}");
            }
        }

        private void ValidarEmpleado(BE_Empleado oEmpleado)
        {
            if (string.IsNullOrEmpty(oEmpleado.Nombre))
                throw new Exception("El nombre del empleado no puede estar vacío");

            if (string.IsNullOrEmpty(oEmpleado.Apellido))
                throw new Exception("El apellido del empleado no puede estar vacío");

            if (string.IsNullOrEmpty(oEmpleado.Username))
                throw new Exception("El usuario del empleado no puede estar vacío");

            if (string.IsNullOrEmpty(oEmpleado.Password))
                throw new Exception("La contraseña del empleado no puede estar vacía");

            if (string.IsNullOrEmpty(oEmpleado.Area))
                throw new Exception("El área del empleado no puede estar vacía");

            //Validar usuario unico
            if (oEmpleado.ID == 0)
            {
                var existeUsuario = Consultar()
                    .Any(x => x.Username.ToLower() == oEmpleado.Username.ToLower());

                if (existeUsuario)
                    throw new Exception("Ya existe un empleado con el mismo usuario");
            }
        }
    }
}
