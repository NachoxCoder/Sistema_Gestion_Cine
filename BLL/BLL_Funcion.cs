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
    public class BLL_Funcion : IAbmc<BE.BE_Funcion>
    {
        private readonly MapperFuncion mapperFuncion;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Funcion()
        {
            mapperFuncion = new MapperFuncion();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Funcion oFuncion)
        {
            try
            {
                var mapperBoleto = new MapperBoleto();
                var boletosVendidos = mapperBoleto.Consultar()
                    .Any(x => x.IdFuncion == oFuncion.ID);

                if (boletosVendidos)
                {
                    throw new Exception("No se puede eliminar la función con boletos vendidos.");
                }
                return mapperFuncion.Borrar(oFuncion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Funcion oFuncion)
        {
            try
            {
                ValidarFuncion(oFuncion);
                ValidarDisponibilidadSala(oFuncion);
                return mapperFuncion.Guardar(oFuncion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Funcion> Consultar()
        {
            return mapperFuncion.Consultar();
        }

        public List<BE_Funcion> ListarFuncionesFuturas()
        {
            return Consultar().Where(x => x.FechaFuncion > DateTime.Today || 
                   (x.FechaFuncion == DateTime.Today && x.HoraFuncion > DateTime.Now.TimeOfDay))
                   .OrderBy(x => x.FechaFuncion).ThenBy(x => x.HoraFuncion).ToList();
        }

        public void ValidarFuncion(BE_Funcion oFuncion)
        {
            if (oFuncion.FechaFuncion < DateTime.Today)
            {
                throw new Exception("La fecha de la función no puede ser anterior a la fecha actual");
            }
            if (oFuncion.IdPelicula == 0)
            {
                throw new Exception("Debe seleccionar una pelicula");
            }
            if (oFuncion.IdSala == 0)
            {
                throw new Exception("Debe seleccionar una sala");
            }
            if (oFuncion.Precio <= 0)
            {
                throw new Exception("El Precio debe ser mayor a 0");
            }
        }

        private void ValidarDisponibilidadSala(BE_Funcion oFuncion)
        {
            var funcionesExistentes = Consultar().Where(x => x.IdSala == oFuncion.IdSala &&
                                      x.FechaFuncion == oFuncion.FechaFuncion).ToList();

            var mapperPelicula = new MapperPelicula();
            var pelicula = mapperPelicula.Consultar().FirstOrDefault(x => x.ID == oFuncion.IdPelicula);

            if (pelicula == null)
            {
                throw new Exception("La película seleccionada no existe");
            }

            var duracionFuncion = TimeSpan.FromMinutes(pelicula.Duracion + 30);
            var horaInicio = oFuncion.HoraInicio;
            var horaFin = oFuncion.HoraFin;

            foreach (var funcion in funcionesExistentes)
            {
                var peliculaExistente = mapperPelicula.Consultar().FirstOrDefault(x => x.ID == funcion.IdPelicula);

                if (peliculaExistente == null) continue;

                var duracionPeliculaExistente = TimeSpan.FromMinutes(peliculaExistente.Duracion + 30);
                var horaInicioPeliculaExistente = funcion.HoraInicio;
                var horaFinPeliculaExistente = funcion.HoraFin;

                if ((horaInicio >= horaInicioPeliculaExistente && horaInicio < horaFinPeliculaExistente) ||
                    (horaFin > horaInicioPeliculaExistente && horaFin <= horaFinPeliculaExistente) ||
                    (horaInicio <= horaInicioPeliculaExistente && horaFin >= horaFinPeliculaExistente))
                {
                    throw new Exception("La sala no esta disponible en ese horario");
                }
            }
        }

        public bool ValidarHorarios(BE_Funcion nuevaFuncion)
        {
            var funcionesExistentes = Consultar().Where(x => x.IdSala == nuevaFuncion.IdSala &&
                                      x.FechaFuncion.Date == nuevaFuncion.FechaFuncion.Date);

            foreach (var funcion in funcionesExistentes)
            {
                if (SeSuperponen(funcion, nuevaFuncion))
                {
                    throw new Exception("La sala no esta disponible en ese horario");
                }
            }

            return true;
         }

        private bool SeSuperponen(BE_Funcion funcionExistente, BE_Funcion nuevaFuncion)
        {
            return (funcionExistente.HoraInicio <= nuevaFuncion.HoraFin && 
                nuevaFuncion.HoraInicio <= funcionExistente.HoraFin);
        }
    }
}
