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
    public class BLL_Sala : IAbmc<BE_Sala>
    {
        private readonly MapperSala mapperSala;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Sala()
        {
            mapperSala = new MapperSala();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Sala oSala)
        {
            try
            {
                //Verificar que la sala no tenga funciones activas
                var mapperFuncion = new MapperFuncion();
                var funcionesActivas = mapperFuncion.Consultar()
                                    .Any(x => x.Sala.ID == oSala.ID && x.EstaActiva);

                if (funcionesActivas)
                {
                    throw new Exception("No se puede eliminar una sala con funciones activas");
                }

                return mapperSala.Borrar(oSala);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar borrar la sala: {ex.Message}");
            }
        }

        public bool Guardar(BE_Sala oSala)
        {
            try
            {
                ValidarSala(oSala);
                return mapperSala.Guardar(oSala);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar guardar la sala: {ex.Message}");
            }
        }

        public List<BE_Sala> Consultar()
        { return mapperSala.Consultar(); }

        private void ValidarSala(BE_Sala oSala)
        {
            if (string.IsNullOrWhiteSpace(oSala.Nombre))
            {
                throw new Exception("El nombre de la sala no puede estar vacío");
            }

            if (oSala.Capacidad <= 0)
            {
                throw new Exception("La capacidad de la sala debe ser mayor a 0");
            }

            var salaExistente = Consultar().FirstOrDefault(x => x.Nombre.ToLower() == oSala.Nombre.ToLower()
                                && x.ID != oSala.ID);

            if (salaExistente != null)
            {
                throw new Exception("Ya existe una sala con el mismo nombre");
            }
        }

        public List<BE_Sala> ConsultarSalasDisponibles(DateTime fecha, TimeSpan hora, int duracion)
        {
            var mapperFuncion = new MapperFuncion();
            var funciones = mapperFuncion.Consultar()
                            .Where(x => x.FechaFuncion == fecha.Date && x.EstaActiva).ToList();

            var horaFin = hora.Add(TimeSpan.FromMinutes(duracion));

            return Consultar().Where(sala => !funciones.Any(f => f.IdSala == sala.ID &&
            ((hora >= f.HoraFuncion && hora < f.HoraFuncion.Add(TimeSpan.FromMinutes(duracion))) ||
            (horaFin > f.HoraFuncion && horaFin <= f.HoraFuncion.Add(TimeSpan.FromMinutes(duracion)))))).ToList();
        }

        public BE_Sala ConsultarPorId(int idSala)
        {
            return Consultar().FirstOrDefault(x => x.ID == idSala);
        }
    }
}
