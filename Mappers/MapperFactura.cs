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
    public class MapperFactura : IAbmc<BE_Factura>
    {
        const string archivo = @".\DATA\Factura.xml";
        const string archivoDetalleFactura = @".\DATA\Detalle_Factura.xml";

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
        public bool Guardar(BE_Factura pObjFactura)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                XDocument xmlDetalleFactura = XDocument.Load(archivoDetalleFactura);

                if (pObjFactura.ID == 0)
                {
                    int nuevoId = FacturaID();
                    pObjFactura.ID = nuevoId;
                    pObjFactura.NumeroFactura = GenerarNumeroFactura(nuevoId);

                    docXML.Element("Facturas").Add(new XElement("Factura", 
                        new XAttribute("FacturaId",nuevoId),
                        new XElement("IdFactura", pObjFactura.NumeroFactura),
                        new XElement("IdCliente", pObjFactura.Cliente.ID),
                        new XElement("FechaEmision", pObjFactura.FechaEmision.ToString("yyyy-MM-dd HH:mm:ss")),
                        new XElement("IdEmpleado", pObjFactura.Empleado.ID),
                        new XElement("TipoFactura", pObjFactura.TipoFactura),
                        new XElement("Subtotal", pObjFactura.Subtotal.ToString()),
                        new XElement("Total", pObjFactura.Total.ToString()),
                        new XElement("IVA", pObjFactura.IVA.ToString()),
                        new XElement("MetodoPago", pObjFactura.MetodoPago)));

                    foreach (BE_DetalleFactura item in pObjFactura.Detalles)
                    {
                        xmlDetalleFactura.Element("Detalle_Facturas").Add(new XElement("Detalle_Factura",
                            new XElement("FacturaId", nuevoId),
                            new XElement("Descripcion", item.Descripcion),
                            new XElement("Cantidad", item.Cantidad),
                            new XElement("PrecioUnitario", item.PrecioUnitario.ToString()),
                            new XElement("Subtotal", item.Subtotal.ToString())));
                    }
                }
                docXML.Save(archivo);
                xmlDetalleFactura.Save(archivoDetalleFactura);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Factura> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                XDocument xmlDetalleFactura = XDocument.Load(archivoDetalleFactura);
                MapperCliente objMapperCliente = new MapperCliente();
                MapperEmpleado objMapperEmpleado = new MapperEmpleado();

                var query = from x in docXML.Descendants("Factura")
                            select x;
                List<BE_Factura> listaFacturas = new List<BE_Factura>();

                foreach (XElement x in query)
                {
                    BE_Factura factura = new BE_Factura
                    {
                        ID = int.Parse(x.Attribute("FacturaId").Value),
                        NumeroFactura = int.Parse(x.Element("NumeroFactura").Value),
                        Cliente = objMapperCliente.Consultar().
                                  Find(e => e.ID == int.Parse(x.Element("ClientID").Value)),
                        Empleado = objMapperEmpleado.Consultar().
                                  Find(e => e.ID == int.Parse(x.Element("EmpleadoID").Value)),
                        FechaEmision = (DateTime)x.Element("FechaEmision"),
                        TipoFactura = x.Element("TipoFactura").Value,
                        Subtotal = decimal.Parse(x.Element("Subtotal").Value),
                        Total = decimal.Parse(x.Element("Total").Value),
                        IVA = decimal.Parse(x.Element("IVA").Value),
                        MetodoPago = x.Element("MetodoPago").Value
                    };

                    //Cargar detalles de la factura
                    var queryDetalle = from y in xmlDetalleFactura.Descendants("Detalle_Factura")
                                       where y.Element("FacturaId").Value == factura.ID.ToString()
                                       select new BE_DetalleFactura
                                       {
                                           Descripcion = y.Element("Descripcion").Value,
                                           Cantidad = int.Parse(y.Element("Cantidad").Value),
                                           PrecioUnitario = decimal.Parse(y.Element("PrecioUnitario").Value),
                                           Subtotal = decimal.Parse(y.Element("Subtotal").Value)
                                       };
                    factura.Detalles = queryDetalle.ToList();
                    listaFacturas.Add(factura);
                }
                
                return listaFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GenerarNumeroFactura(int pIdFactura)
        {
            return $"F{DateTime.Now:yyMM}{pIdFactura:D6}";
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
