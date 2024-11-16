using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Xml.Linq;

namespace Mappers
{
    public class MappperHistorialPago : MapperBase<BE_HistorialPago>, IAbmc<BE_HistorialPago>
    {
        private const string archivoHistorialPago = @".\DATA\HistorialPago.xml";
        private readonly MapperFactura mapperFactura;

        public MappperHistorialPago() : base(archivoHistorialPago)
        {
            mapperFactura = new MapperFactura();
        }

        public bool Borrar(BE_HistorialPago pHistorialPago)
        {
            try
            {
                XDocument docXML = CargarXml();

                var pago = docXML.Descendants("HistorialPago").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pHistorialPago.ID);

                if (pago != null)
                {
                    pago.Remove();
                    GuardarXml(docXML);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Guardar(BE_HistorialPago pHistorialPago)
        {
            try
            {
                XDocument docXML = CargarXml();

                if (pHistorialPago.ID == 0)
                {
                    pHistorialPago.ID = GenerarNuevoId(docXML);
                    var nuevoPago = new XElement("HistorialPago",
                    new XAttribute("ID", pHistorialPago.ID),
                    new XElement("IdFactura", pHistorialPago.IdFactura),
                    new XElement("FechaPago", pHistorialPago.FechaPago.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XElement("Monto", pHistorialPago.Monto.ToString("F2")),
                    new XElement("MetodoPago", pHistorialPago.MetodoPago),
                    new XElement("NumeroTransaccion", pHistorialPago.NumeroTransaccion),
                    new XElement("Estado", pHistorialPago.Estado));

                    docXML.Root.Add(nuevoPago);
                }
                else
                {
                    var pago = docXML.Descendants("HistorialPago").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pHistorialPago.ID);

                    if (pago != null)
                    {
                        pago.Element("Estado").Value = pHistorialPago.Estado;
                    }
                }

                GuardarXml(docXML);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BE_HistorialPago> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var facturas = mapperFactura.Consultar();

                return docXML.Descendants("HistorialPago").Select(x => new BE_HistorialPago
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdFactura = int.Parse(x.Element("IdFactura").Value),
                    FechaPago = DateTime.Parse(x.Element("FechaPago").Value),
                    Monto = decimal.Parse(x.Element("Monto").Value),
                    MetodoPago = x.Element("MetodoPago").Value,
                    NumeroTransaccion = x.Element("NumeroTransaccion").Value,
                    Estado = x.Element("Estado").Value,
                    Factura = facturas.FirstOrDefault(f => f.ID == int.Parse(x.Element("IdFactura").Value))
                }).ToList();
            }
            catch
            {
                return new List<BE_HistorialPago>();
            }
        }

        public int GenerarNuevoId(XDocument docXML)
        {
            return docXML.Descendants("HistorialPago").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public List<BE_HistorialPago> ConsultarPorFactura(int pIdFactura)
        {
            return Consultar().Where(x => x.IdFactura == pIdFactura).ToList();
        }
    }
}
