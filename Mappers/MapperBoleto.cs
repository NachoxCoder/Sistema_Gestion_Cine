using BE;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mappers
{
    public class MapperBoleto : MapperBase<BE_Boleto>, IAbmc<BE_Boleto>
    {
        private const string archivoBoleto = @".\DATA\Boleto.xml";
        private readonly MapperCliente _mapperCliente;
        private readonly MapperFuncion _mapperFuncion;

        public MapperBoleto() : base(archivoBoleto)
        {
            _mapperCliente = new MapperCliente();
            _mapperFuncion = new MapperFuncion();
        }

        public bool Borrar(BE_Boleto pObjBoleto)
        {
            //Por razones de seguridad no se permite la eliminación de boletos
            return false;
        }

        public bool Guardar(BE_Boleto pBoleto)
        {
            try
            {
                XDocument xml = CargarXml();

                if (pBoleto.ID == 0)
                {
                    pBoleto.ID = GenerarNuevoId(xml);

                    var nuevoBoleto = new XElement("Boleto",
                        new XAttribute("ID", pBoleto.ID),
                        new XElement("IdCliente", pBoleto.IdCliente),
                        new XElement("IdFuncion", pBoleto.IdFuncion),
                        new XElement("FechaVenta", pBoleto.FechaVenta.ToString("yyyy-MM-dd")),
                        new XElement("Precio", pBoleto.Precio.ToString("F2")),
                        new XElement("NumeroButaca", pBoleto.NumeroButaca));

                    xml.Root.Add(nuevoBoleto);
                }
                else
                {
                    var boleto = xml.Descendants("Boleto").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pBoleto.ID);

                    if (boleto != null)
                    {
                        boleto.Element("IdCliente").Value = pBoleto.IdCliente.ToString();
                        boleto.Element("IdFuncion").Value = pBoleto.IdFuncion.ToString();
                        boleto.Element("FechaVenta").Value = pBoleto.FechaVenta.ToString("yyyy-MM-dd");
                        boleto.Element("Precio").Value = pBoleto.Precio.ToString("F2");
                        boleto.Element("NumeroButaca").Value = pBoleto.NumeroButaca;
                    }
                }
                GuardarXml(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BE_Boleto> Consultar()
        {
            try
            {
                XDocument xml = CargarXml();
                var clientes = _mapperCliente.Consultar();
                var funciones = _mapperFuncion.Consultar();

                var boletos = xml.Descendants("Boleto").Select(x => new BE_Boleto
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdCliente = int.Parse(x.Element("IdCliente").Value),
                    IdFuncion = int.Parse(x.Element("IdFuncion").Value),
                    FechaVenta = DateTime.Parse(x.Element("FechaVenta").Value),
                    Precio = decimal.Parse(x.Element("Precio").Value),
                    NumeroButaca = x.Element("NumeroButaca").Value
                }).ToList();

                foreach (var boleto in boletos)
                {
                    boleto.Cliente = clientes.FirstOrDefault(c => c.ID == boleto.IdCliente);
                    boleto.Funcion = funciones.FirstOrDefault(f => f.ID == boleto.IdFuncion);
                }

                return boletos;
            }
            catch
            {
                return new List<BE_Boleto>();
            }
        }

        public int GenerarNuevoId(XDocument xml)
        {
            return xml.Descendants("Boleto").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public List<BE_Boleto> ConsultarPorFuncion(int pIdFuncion)
        {
            return Consultar().Where(x => x.IdFuncion == pIdFuncion).ToList();
        }

        public List<BE_Boleto> ConsultarPorCliente(int pIdCliente)
        {
            return Consultar().Where(x => x.IdCliente == pIdCliente).ToList();
        }
    }
}
