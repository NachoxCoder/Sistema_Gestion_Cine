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
    public class BLL_Configuracion : IAbmc<BE_Configuracion>
    {
        private readonly MapperConfiguracion mapperConfiguracion;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Configuracion()
        {
            mapperConfiguracion = new MapperConfiguracion();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Configuracion oConfiguracion)
        {
            try
            {
                return mapperConfiguracion.Borrar(oConfiguracion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Configuracion oConfiguracion)
        {
            try
            {
                ValidarConfiguracion(oConfiguracion);
                oConfiguracion.FechaModificacion = DateTime.Now;
                return mapperConfiguracion.Guardar(oConfiguracion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Configuracion> Consultar()
        {
            return mapperConfiguracion.Consultar();
        }

        public string ObtenerValorConfiguracion(string clave)
        {
            var configuracion = Consultar().FirstOrDefault(x => x.Clave == clave);

            return configuracion?.Valor ?? string.Empty;
        }

        private void ValidarConfiguracion(BE_Configuracion oConfiguracion)
        {
            if (string.IsNullOrEmpty(oConfiguracion.Clave))
            {
                throw new Exception("La clave no puede estar vacía.");
            }
            if (string.IsNullOrEmpty(oConfiguracion.Valor))
            {
                throw new Exception("El valor no puede estar vacío.");
            }
        }
    }
}
