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
    public class BLL_Butaca : IAbmc<BE_Butaca>
    {
        private readonly MapperButaca mapperButaca;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Butaca()
        {
            mapperButaca = new MapperButaca();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Butaca oButaca)
        {
            try
            {
                //Verificar si la butaca tiene boletos vendidos
                var butacaEnUso = mapperButaca.ConsultarButacasOcupadas().Any(x => x.ID == oButaca.ID);

                if (butacaEnUso)
                {
                    throw new Exception("No se puede eliminar la butaca porque tiene boletos vendidos.");
                }

                return mapperButaca.Borrar(oButaca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Butaca oButaca)
        {
            try
            {
                ValidarButaca(oButaca);
                return mapperButaca.Guardar(oButaca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Butaca> Consultar()
        {
            return mapperButaca.Consultar();
        }

        public List<BE_Butaca> ConsultarButacasDisponibles(int idFuncion)
        {
            return mapperButaca.ConsultarButacasDisponiblesPorSala(idFuncion);
        }

        private void ValidarButaca(BE_Butaca oButaca)
        {
            if (oButaca.IdSala == 0)
            {
                throw new Exception("La butaca debe estar asignada a una sala.");
            }

            if (string.IsNullOrEmpty(oButaca.Fila))
            {
                throw new Exception("La fila de la butaca es obligatoria.");
            }

            if (oButaca.Numero <= 0)
            {
                throw new Exception("El numero de butaca debe ser mayor a 0");
            }

            //Verificar que no exista otra butaca con el mismo numero y fila en la misma sala
            var butacaExistente = Consultar().FirstOrDefault(x => x.IdSala == oButaca.IdSala &&
                                  x.Fila == oButaca.Fila && x.Numero == oButaca.Numero && x.ID != oButaca.ID);
            if (butacaExistente != null)
            {
                throw new Exception("Ya existe una butaca con el mismo numero y fila en la misma sala.");
            }
        }

        public bool OcuparButaca(BE_Butaca oButaca, BE_Funcion oFuncion)
        {
            try
            {
                if (!oButaca.Disponible)
                {
                    throw new Exception("La butaca no esta disponible");
                }

                return mapperButaca.OcuparButaca(oButaca, oFuncion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
