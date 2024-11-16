using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Mappers;

namespace BLL
{
    public class BLL_Bitacora
    {
        private readonly MapperBitacora mapperBitacora;

        public BLL_Bitacora()
        {
            mapperBitacora = new MapperBitacora();
        }

        public void Log(BE_Empleado oEmpleado, string evento)
        {
            try
            {
                var registro = new BE_Bitacora
                {
                    UsuarioEmpleado = oEmpleado,
                    Fecha = DateTime.Now,
                    Evento = evento
                };

                mapperBitacora.Guardar(registro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar en Bitacora: {ex.Message}");
            }
        }

        public List<BE_Bitacora> Consultar()
        {
            return mapperBitacora.Consultar();
        }

    }
}
