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
    public class MapperOrdenCompra : IAbmc<BE_OrdenCompra>
    {
        private const string ARCHIVO_ORDEN_COMPRA = @"\DATA\OrdenCompra.xml";
        private const string ARCHIVO_DETALLE_ORDEN_COMPRA = @"\DATA\Detalle_OrdenCompra.xml";

        public bool Borrar(BE_OrdenCompra pObjOrdenCompra)
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);

                var query = from ordenCompra in docXML.Descendants("OrdenCompra")
                            where int.Parse(ordenCompra.Attribute("IdOrdenCompra").Value) == pObjOrdenCompra.ID
                            select ordenCompra;

                query.Remove();
                docXML.Save(ARCHIVO_ORDEN_COMPRA);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GenerarNuevoId()
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);

                int ultimoId = docXML.Descendants("OrdenCompra").Select(e => (int?)e.Attribute("IdOrdenCompra"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_OrdenCompra pObjOrdenCompra)
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);
                XDocument xmlDetalleOrdenCompra = XDocument.Load(ARCHIVO_DETALLE_ORDEN_COMPRA);

                if (pObjOrdenCompra.ID == 0)
                {
                    pObjOrdenCompra.ID = GenerarNuevoId();

                    docXML.Element("OrdenesCompra").Add(new XElement("OrdenCompra",
                        new XAttribute("IdOrdenCompra", pObjOrdenCompra.ID),
                        new XAttribute("Fecha", pObjOrdenCompra.FechaOrdenCompra.ToString("yyyy-MM-dd")),
                        new XAttribute("Total", pObjOrdenCompra.TotalOrdenCompra.ToString("F2")),
                        new XAttribute("PrecioUnitario", pObjOrdenCompra.PrecioUnitario.ToString("F2")),
                        new XAttribute("Proveedor", pObjOrdenCompra.Proveedor?.ID ?? 0)));

                    foreach (BE_Producto producto in pObjOrdenCompra.Productos)
                    {
                        xmlDetalleOrdenCompra.Element("OrdenCOmpra_Productos").Add(new XElement("OrdenCompra_Producto",
                            new XElement("IdOrden", pObjOrdenCompra.ID),
                            new XElement("Producto ID", producto.ID),
                            new XElement("Cantidad", producto.Stock.ToString()),
                            new XElement("PrecioUnitario", producto.PrecioProducto.ToString("F2"))));
                    }

                    docXML.Save(ARCHIVO_ORDEN_COMPRA);
                    xmlDetalleOrdenCompra.Save(ARCHIVO_DETALLE_ORDEN_COMPRA);
                    return true;
                }
                else
                {
                    var query = from ordenCompra in docXML.Descendants("OrdenCompra")
                                where ordenCompra.Attribute("IdOrdenCompra").Value == pObjOrdenCompra.ID.ToString()
                                select ordenCompra;

                    foreach (var ordenCompra in query)
                    {
                        ordenCompra.Attribute("Fecha").Value = pObjOrdenCompra.FechaOrdenCompra.ToString("yyyy-MM-dd");
                        ordenCompra.Attribute("Proveedor").Value = (pObjOrdenCompra.Proveedor?.ID ?? 0).ToString();
                        ordenCompra.Attribute("Total").Value = pObjOrdenCompra.TotalOrdenCompra.ToString("F2");
                        ordenCompra.Attribute("PrecioUnitario").Value = pObjOrdenCompra.PrecioUnitario.ToString("F2");
                    }

                    docXML.Save(ARCHIVO_ORDEN_COMPRA);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_OrdenCompra> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);
                XDocument xmlDetalleOrdenCompra = XDocument.Load(ARCHIVO_DETALLE_ORDEN_COMPRA);
                MapperProveedor objMapperProveedor = new MapperProveedor();
                MapperProducto objMapperProducto = new MapperProducto();
                MapperFactura objMapperFactura = new MapperFactura();

                var query = from ordenCompra in docXML.Descendants("OrdenCompra")
                            select ordenCompra;

                List<BE_OrdenCompra> lstOrdenesCompra = new List<BE_OrdenCompra>();

                foreach (var ordenCompra in query)
                {
                    BE_OrdenCompra objOrdenCompra = new BE_OrdenCompra();
                    objOrdenCompra.ID = int.Parse(ordenCompra.Attribute("IdOrdenCompra").Value);
                    objOrdenCompra.FechaOrdenCompra = DateTime.Parse(ordenCompra.Attribute("Fecha").Value);
                    objOrdenCompra.TotalOrdenCompra = decimal.Parse(ordenCompra.Attribute("Total").Value);
                    objOrdenCompra.PrecioUnitario = decimal.Parse(ordenCompra.Attribute("PrecioUnitario").Value);
                    objOrdenCompra.Proveedor = objMapperProveedor.ConsultarPorId
                                               (int.Parse(ordenCompra.Attribute("Proveedor").Value));
                    objOrdenCompra.Productos = ListarProductos(int.Parse(ordenCompra.Attribute("IdOrden").Value));

                }
                return lstOrdenesCompra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BE_Producto> ListarProductos(int pIdOrdenCompra)
        {
            try
            {
                XDocument docXML = XDocument.Load(ARCHIVO_ORDEN_COMPRA);
                MapperProducto mapperProducto = new MapperProducto();

                var query = from detalleOrdenCompra in docXML.Descendants("OrdenCompra_Producto")
                            where int.Parse(detalleOrdenCompra.Element("IdOrden").Value) == pIdOrdenCompra
                            select detalleOrdenCompra;

                List<BE_Producto> lstProductos = new List<BE_Producto>();

                foreach (var detalleOrdenCompra in query)
                {
                    BE_Producto objProducto = objMapperProducto.ConsultarPorId
                                             (int.Parse(detalleOrdenCompra.Element("Producto ID").Value));
                    objProducto.Stock = int.Parse(detalleOrdenCompra.Element("Cantidad").Value);
                    objProducto.PrecioProducto = decimal.Parse(detalleOrdenCompra.Element("PrecioUnitario").Value);
                    lstProductos.Add(objProducto);
                }

                return lstProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
