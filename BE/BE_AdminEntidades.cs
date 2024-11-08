using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_AdminEntidades : BE_Entidad
    {
        public List<BE_Pelicula> Peliculas { get; set; }
        public List<BE_Funcion> Funciones { get; set; }
        public List<BE_Cliente> Clientes { get; set; }
        public List<BE_Boleto> Boletos { get; set; }
        public List<BE_Membresia> Membresias { get; set; }

        public BE_AdminEntidades()
        {
            Peliculas = new List<BE_Pelicula>();
            Funciones = new List<BE_Funcion>();
            Clientes = new List<BE_Cliente>();
            Boletos = new List<BE_Boleto>();
            Membresias = new List<BE_Membresia>();
        }

        public BE_Pelicula BuscarPelicula(int pId)
        {
            return Peliculas.Find(p => p.IdPelicula == pId);
        }

        public BE_Funcion BuscarFuncion(int pId)
        {
            return Funciones.Find(p => p.IdFuncion == pId);
        }

        public BE_Cliente BuscarCliente(int pId)
        {
            return Clientes.Find(p => p.IdCliente == pId);
        }

        public BE_Boleto BuscarBoleto(int pId)
        {
            return Boletos.Find(p => p.IdBoleto == pId);
        }

        public BE_Membresia BuscarMembresia(int pId)
        {
            return Membresias.Find(p => p.IdMembresia == pId);
        }

        public bool GuardarPelicula(BE_Pelicula pPelicula)
        {
            if (BuscarPelicula(pPelicula.IdPelicula) == null)
            {
                Peliculas.Add(pPelicula);
                return true;
            }
            return false;
        }

        public bool GuardarFuncion(BE_Funcion pFuncion)
        {
            if (BuscarFuncion(pFuncion.IdFuncion) == null)
            {
                Funciones.Add(pFuncion);
                return true;
            }
            return false;
        }

        public bool GuardarCliente(BE_Cliente pCliente)
        {
            if (BuscarCliente(pCliente.IdCliente) == null)
            {
                Clientes.Add(pCliente);
                return true;
            }
            return false;
        }

        public static void AsignarFuncionaPelicula(BE_Funcion pFuncion, BE_Pelicula pPelicula)
        {
            if (pPelicula == null || pFuncion == null) return;

            pFuncion.Pelicula = pPelicula;
            pFuncion.IdPelicula = pPelicula.IdPelicula;
            pPelicula.Funciones.Add(pFuncion);
        }

        public static void AsignarMembresiaACliente(BE_Cliente pCliente, BE_Membresia pMembresia)
        {
            if (pCliente == null || pMembresia == null) return;

            pMembresia.IdCliente = pCliente.IdCliente;
            pCliente.Membresia = pMembresia;
        }

        public static void AsignarBoletoACliente(BE_Cliente pCliente, BE_Boleto pBoleto)
        {
            if (pCliente == null || pBoleto == null) return;

            pBoleto.IdCliente = pCliente.IdCliente;
            pBoleto.Cliente = pCliente;
            pCliente.Boletos.Add(pBoleto);
        }

        public static decimal CalcularPrecioBoleto(this BE_Funcion pFuncion, BE_Cliente pCliente)
        {
            if (pFuncion == null) return 0;

            decimal precioBase = pFuncion.Precio;

            if (pCliente.TieneMembresia() == true)
            {
                switch(pCliente.DevuelveMembresiaTipo())
                {
                    case TipoMembresia.Plata:
                        precioBase *= 0.9m;
                        break;
                    case TipoMembresia.Oro:
                        precioBase *= 0.8m;
                        break; 
                    case TipoMembresia.Premium:
                        precioBase *= 0.7m;
                        break;
                }
            }
            return precioBase;
        }
    }
}
