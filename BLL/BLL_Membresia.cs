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
    public class BLL_Membresia : IAbmc<BE_Membresia>
    {
        private readonly MapperMembresia mapperMembresia;
        private readonly BLL_Bitacora bLLBitacora;
        private readonly BLL_Configuracion bllConfiguracion;

        public BLL_Membresia()
        {
            mapperMembresia = new MapperMembresia();
            bLLBitacora = new BLL_Bitacora();
            bllConfiguracion = new BLL_Configuracion();
        }

        public bool Borrar(BE_Membresia oMembresia)
        {
            try
            {
                if(oMembresia.EstaActiva)
                {
                    throw new Exception("No se puede eliminar una membresía activa");
                }

                return mapperMembresia.Borrar(oMembresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Membresia oMembresia)
        {
            try
            {
                ValidarMembresia(oMembresia);

                if (oMembresia.ID == 0)
                {
                    AsignarCostoMembresia(oMembresia);
                    oMembresia.FechaInicio = DateTime.Today;
                    oMembresia.FechaFin = DateTime.Today.AddMonths(1);
                    oMembresia.EstaActiva = true;
                }
                return mapperMembresia.Guardar(oMembresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Membresia> Consultar()
        {
            return mapperMembresia.Consultar();
        }

        public bool RenovarMembresia(BE_Membresia oMembresia)
        {
            try
            {
                if (!oMembresia.EstaActiva)
                {
                    throw new Exception("No se puede renovar una membresía inactiva");
                }

                oMembresia.FechaFin = oMembresia.FechaFin.AddMonths(1);
                return Guardar(oMembresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CancelarMembresia(BE_Membresia oMembresia)
        {
            try
            {
                if (!oMembresia.EstaActiva)
                {
                    throw new Exception("No se puede cancelar una membresía inactiva");
                }

                oMembresia.EstaActiva = false;
                oMembresia.FechaFin = DateTime.Today;
                return Guardar(oMembresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarMembresia(BE_Membresia oMembresia)
        {
            if (oMembresia.IdCliente == 0)
            {
                throw new Exception("Debe especificar un cliente");
            }

            if (oMembresia.ID <= 0)
            {
                var membresiasActivas = Consultar().Any(x => x.IdCliente == oMembresia.IdCliente && x.EstaActiva);

                if (membresiasActivas)
                {
                    throw new Exception("El cliente ya posee una membresía activa");
                }
            }   
        }

        private void AsignarCostoMembresia(BE_Membresia oMembresia)
        {
            var configuraciones = bllConfiguracion.Consultar();

            switch (oMembresia.Tipo)
            {
                case TipoMembresia.Plata:
                    oMembresia.CostoMensual = decimal.Parse(configuraciones
                                              .First(c => c.Clave == "COSTO_MEMBRESIA_PLATA").Valor);
                    break;
                case TipoMembresia.Oro:
                    oMembresia.CostoMensual = decimal.Parse(configuraciones
                                              .First(c => c.Clave == "COSTO_MEMBRESIA_ORO").Valor);
                    break;
                case TipoMembresia.Premium:
                    oMembresia.CostoMensual = decimal.Parse(configuraciones
                                              .First(c => c.Clave == "COSTO_MEMBRESIA_PREMIUM").Valor);
                    break;

                default:
                    throw new Exception("Tipo de membresía inválido");
            }
        }
    }
}
