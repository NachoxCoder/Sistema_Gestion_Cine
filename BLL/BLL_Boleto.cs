using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;

namespace BLL
{
    public class BLL_Boleto : IAbmc<BE_Boleto>
    {
        private readonly MapperBoleto mapperBoleto;
        private readonly MapperFuncion MapperFuncion;
        private readonly BLL_Bitacora bllBitacora;

        public BLL_Boleto()
        {
            mapperBoleto = new MapperBoleto();
            MapperFuncion = new MapperFuncion();
            bllBitacora = new BLL_Bitacora();
        }

        public bool Borrar(BE.BE_Boleto oBoleto)
        {
            //Los Boletos no se pueden borrar por motivos de negocio
            return false;
        }

        public bool Guardar(BE_Boleto oBoleto)
        {
            try
            {
                ValidarBoleto(oBoleto);

                if(oBoleto.ID == 0)
                {
                   var funcion = MapperFuncion.Consultar().FirstOrDefault(x => x.ID == oBoleto.IdFuncion);
                    if (funcion == null)
                    {
                        throw new Exception("La función no existe.");
                    }
                    if (oBoleto.Cliente.TieneMembresia())
                    {
                        oBoleto.Precio = AplicarDescuentoMembresia(oBoleto.Cliente, funcion.Precio);
                    }
                    else
                    {
                        oBoleto.Precio = funcion.Precio;
                    }
                }
                return mapperBoleto.Guardar(oBoleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Boleto> Consultar()
        {
            return mapperBoleto.Consultar();
        }

        public List<BE_Boleto> ListarBoletosClientes(int idCliente)
        {
            return Consultar().Where(x => x.Cliente.ID == idCliente).ToList();
        }

        private void ValidarBoleto(BE_Boleto oBoleto)
        {
            if (oBoleto.IdFuncion == 0)
            {
                throw new Exception("Debe especificar una Funcion");
            }
            if (oBoleto.Cliente == null)
            {
                throw new Exception("Debe especificar un Cliente");
            }
            if (string.IsNullOrEmpty(oBoleto.NumeroButaca))
            {
                throw new Exception("Debe especificar una Butaca");
            }

            var butacaOcupada = Consultar().Any(x => x.IdFuncion == oBoleto.IdFuncion && 
                                x.NumeroButaca == oBoleto.NumeroButaca);
            if (butacaOcupada)
            {
                throw new Exception("La butaca seleccionada ya está ocupada.");
            }
        }

        private decimal AplicarDescuentoMembresia(BE_Cliente cliente, decimal precioBase)
        {
            switch (cliente.DevuelveMembresiaTipo())
            {
                case TipoMembresia.Plata:
                    return precioBase * 0.9m;
                case TipoMembresia.Oro:
                    return precioBase * 0.8m;
                case TipoMembresia.Premium:
                    return precioBase * 0.7m;
                default:
                    return precioBase;
            }
        }
    }
}
