using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Interfaces;
using System.Xml.Linq;

namespace Mappers
{
    public class MapperFactura : MapperBase<BE_Factura>, IAbmc<BE_Factura>
    {
        private const string archivoFactura = @".\DATA\Factura.xml";
        private const string archivoDetalleFactura = @".\DATA\Detalle_Factura.xml";
        private readonly MapperCliente mapperCliente;

        public MapperFactura() : base(archivoFactura)
        {
            mapperCliente = new MapperCliente();
        }

        public bool Borrar(BE_Factura pObjFactura)
        {
            try
            {
                //Por motivos de seguridad se restringe la eliminación de facturas
                return false;
            }


            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int FacturaID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Factura").Select(e => (int?)e.Attribute("IdFactura"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Guardar(BE_Factura pFactura)
        {
            try
            {
                XDocument xmlFactura = XDocument.Load(archivoFactura);
                XDocument xmlDetalleFactura = XDocument.Load(archivoDetalleFactura);

                if (pFactura.ID == 0)
                {
                    pFactura.ID = GenerarNuevoID(xmlFactura);
                    pFactura.NumeroFactura = GenerarNumeroFactura(pFactura.ID);

                    var nuevaFactura = new XElement("Factura", 
                        new XAttribute("ID",pFactura.ID),
                        new XElement("NUmeroFactura", pFactura.NumeroFactura),
                        new XElement("IdCliente", pFactura.Cliente.ID),
                        new XElement("FechaEmision", pFactura.FechaEmision.ToString("yyyy-MM-dd HH:mm:ss")),
                        new XElement("TipoFactura", pFactura.TipoFactura),
                        new XElement("Subtotal", pFactura.Subtotal.ToString("F2")),
                        new XElement("Total", pFactura.Total.ToString("F2")),
                        new XElement("IVA", pFactura.IVA.ToString("F2")),
                        new XElement("MetodoPago", pFactura.MetodoPago));

                    xmlFactura.Root.Add(nuevaFactura);

                    foreach (var producto in pFactura.Detalles)
                    {
                        var nuevoProducto = new XElement("Detalle_Factura",
                            new XAttribute("ID", GenerarNuevoProductoID(xmlDetalleFactura)),
                            new XElement("FacturaId", pFactura.ID),
                            new XElement("Descripcion", producto.Descripcion),
                            new XElement("Cantidad", producto.Cantidad),
                            new XElement("PrecioUnitario", producto.PrecioUnitario.ToString("F2")),
                            new XElement("Subtotal", producto.Subtotal.ToString("F2")));

                        xmlDetalleFactura.Root.Add(nuevoProducto);
                    }
                }
                GuardarXml(xmlFactura);
                xmlDetalleFactura.Save(archivoDetalleFactura);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BE_Factura> Consultar()
        {
            try
            {
                XDocument xmlFactura = CargarXml();
                XDocument xmlDetalleFactura = XDocument.Load(archivoDetalleFactura);
                var clientes = mapperCliente.Consultar();

                var facturas = xmlFactura.Descendants("Factura").Select(x => new BE_Factura
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    NumeroFactura = x.Element("NumeroFactura").Value,
                    Cliente = clientes.Find(c => c.ID == int.Parse(x.Element("IdCliente").Value)),
                    FechaEmision = DateTime.Parse(x.Element("FechaEmision").Value),
                    TipoFactura = x.Element("TipoFactura").Value,
                    Subtotal = decimal.Parse(x.Element("Subtotal").Value),
                    Total = decimal.Parse(x.Element("Total").Value),
                    IVA = decimal.Parse(x.Element("IVA").Value),
                    MetodoPago = x.Element("MetodoPago").Value
                }).ToList();

                foreach (var factura in facturas)
                {
                    factura.Cliente = clientes.FirstOrDefault(c => c.ID == factura.IdCliente);
                    factura.Detalles = CargarDetalles(xmlDetalleFactura, factura.ID);
                }

                return facturas;
            }
            catch
            {
                return new List<BE_Factura>();
            }
        }

        private List<BE_DetalleFactura> CargarDetalles(XDocument pXmlDoc, int pIdFactura)
        {
            return pXmlDoc.Descendants("Detalle_Factura")
                .Where(x => int.Parse(x.Element("FacturaId").Value) == pIdFactura)
                .Select(x => new BE_DetalleFactura
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdFactura = pIdFactura,
                    Descripcion = x.Element("Descripcion").Value,
                    Cantidad = int.Parse(x.Element("Cantidad").Value),
                    PrecioUnitario = decimal.Parse(x.Element("PrecioUnitario").Value),
                    Subtotal = decimal.Parse(x.Element("Subtotal").Value)
                }).ToList();
        }

        private string GenerarNumeroFactura(int pIdFactura)
        {
            return $"F{DateTime.Now:yyMM}{pIdFactura:D6}";
        }

        private int GenerarNuevoId(XDocument xml)
        {
            return xml.Descendants("Factura").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        private int GenerarNuevoProductoID(XDocument xml)
        {
            return xml.Descendants("Detalle_Factura").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public List<BE_Factura> ListarFacturasPorCliente(BE_Cliente pCliente)
        {
            return Consultar().Where(f => f.Cliente.ID == pCliente.ID).ToList();
        }
        public List<BE_Factura> ListarFacturasPorPeriodo(DateTime pDesde, DateTime pHasta)
        {
            return Consultar().Where(f => f.FechaEmision >= pDesde && f.FechaEmision <= pHasta).ToList();
        }
        public decimal CalcularVentasPeriodo(DateTime pDesde, DateTime pHasta)
        {
            return ListarFacturasPorPeriodo(pDesde, pHasta).Sum(f => f.Total);
        }
    }
}
