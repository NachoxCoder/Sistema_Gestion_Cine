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
    public class BLL_Pelicula : IAbmc<BE_Pelicula>
    {
        private readonly MapperPelicula mapperPelicula;
        private readonly BLL_Bitacora _bllBitacora;

        public BLL_Pelicula()
        {
            mapperPelicula = new MapperPelicula();
            _bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE_Pelicula oPelicula)
        {
            try
            {
                var mapperFuncion = new MapperFuncion();
                var funcionesActivas = mapperFuncion.Consultar().
                    Any(x => x.IdPelicula == oPelicula.ID && x.EstaActiva);
                if (funcionesActivas)
                {
                    throw new Exception("No se puede eliminar la película porque tiene funciones activas.");
                }
                return mapperPelicula.Borrar(oPelicula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Pelicula oPelicula)
        {
            try
            {
                ValidarPelicula(oPelicula);
                return mapperPelicula.Guardar(oPelicula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Pelicula> Consultar()
        {
            return mapperPelicula.Consultar();
        }

        public List<BE_Pelicula> ListarPeliculasActivas()
        {
            return mapperPelicula.Consultar().Where(x => x.EstaActiva).ToList();
        }

        private void ValidarPelicula(BE_Pelicula oPelicula)
        {
            if (string.IsNullOrEmpty(oPelicula.Titulo))
            {
                throw new Exception("El título de la película es obligatorio.");
            }
            if (oPelicula.Duracion <= 0)
            {
                throw new Exception("La duración de la película debe ser mayor a 0.");
            }
            if (string.IsNullOrEmpty(oPelicula.Rating))
            {
                throw new Exception("El rating de la película es requerido.");
            }
        }
    }
}
