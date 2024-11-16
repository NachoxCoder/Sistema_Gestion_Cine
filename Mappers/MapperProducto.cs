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
    public class MapperProducto : MapperBase<BE_Producto>, IAbmc<BE_Producto>
    {
        private const string archivoProducto = @".\DATA\Producto.xml";
        private const string archivoOrdenCompraProducto = @".\DATA\OrdenCompra_Producto.xml";

        public MapperProducto() : base(archivoProducto) { }

        public bool Borrar(BE_Producto pProducto)
        {
            try
            {
                XDocument docXML = CargarXml();

                var producto = docXML.Descendants("Producto").
                    FirstOrDefault(x => int.Parse(x.Attribute("IdProducto").Value) == pProducto.ID);

                if (producto != null)
                {
                    //Verifico si el producto esta asociado a una orden de compra
                    XDocument xmlOrdenCompraProducto = XDocument.Load(archivoOrdenCompraProducto);
                    var productoEnOrden = xmlOrdenCompraProducto.Descendants("OrdenCompra_Producto")
                        .Any(x => int.Parse(x.Element("IdProducto").Value) == pProducto.ID);
                    if (!productoEnOrden)
                    {
                        producto.Remove();
                        GuardarXml(docXML);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar borrar el producto: {ex.Message}", ex);
            }
        }

        public bool Guardar(BE_Producto pProducto)
        {
            try
            {
                XDocument docXML = CargarXml();

                if (pProducto.ID == 0)
                {
                    pProducto.ID = GenerarNuevoId(docXML);
                    var nuevoProducto = new XElement("Producto",
                    new XAttribute("ID", pProducto.ID),
                    new XElement("NombreProducto", pProducto.NombreProducto),
                    new XElement("DescripcionProducto", pProducto.DescripcionProducto),
                    new XElement("PrecioProducto", pProducto.PrecioProducto.ToString("F2")),
                    new XElement("Stock", pProducto.Stock));

                    docXML.Root.Add(nuevoProducto);
                }
                else
                {
                    var producto = docXML.Descendants("Producto")
                                          .FirstOrDefault(x => int.Parse(x.Attribute("IdProducto").Value) ==
                                          pProducto.ID);

                    if (producto != null)
                    {
                        producto.Element("Nombre").Value = pProducto.NombreProducto;
                        producto.Element("Descripcion").Value = pProducto.DescripcionProducto;
                        producto.Element("Precio").Value = pProducto.PrecioProducto.ToString("F2");
                        producto.Element("Stock").Value = pProducto.Stock.ToString();
                    }
                }
                GuardarXml(docXML);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar guardar el producto: {ex.Message}", ex);
            }
        }

        public List<BE_Producto> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();

                return docXML.Descendants("Producto").Select(x => new BE_Producto
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    NombreProducto = x.Element("NombreProducto").Value,
                    DescripcionProducto = x.Element("DescripcionProducto").Value,
                    PrecioProducto = decimal.Parse(x.Element("PrecioProducto").Value),
                    Stock = int.Parse(x.Element("Stock").Value)
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar consultar los productos: {ex.Message}", ex);
            }
        }

        public BE_Producto ConsultarPorId(int pId)
        {
            try
            {
                return Consultar().FirstOrDefault(x => x.ID == pId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar consultar el producto: {ex.Message}", ex);
            }
        }

        private int GenerarNuevoId(XDocument docXML)
        {
            return docXML.Descendants("Producto").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }


        public List<BE_Producto> ConsultarProductosPorOrdenCompra(int idOrdenCompra)
        {
            try
            {
                XDocument xmlOrdenCompra = XDocument.Load(archivoOrdenCompraProducto);

                var productosEnOrden = xmlOrdenCompra.Descendants("OrdenCompra_Producto")
                    .Where(x => int.Parse(x.Element("IdOrdenCompra").Value) == idOrdenCompra)
                    .Select(x => new
                    {
                        IdProducto = int.Parse(x.Element("IdProducto").Value),
                        Stock = int.Parse(x.Element("Cantidad").Value),
                        PrecioProducto = decimal.Parse(x.Element("PrecioUnitario").Value)
                    });

                var productos = Consultar();

                foreach (var productoEnOrden in productosEnOrden)
                {
                    var producto = productos.FirstOrDefault(x => x.ID == productoEnOrden.IdProducto);
                    if (producto != null)
                    {
                        producto.Stock = productoEnOrden.Stock;
                        producto.PrecioProducto = productoEnOrden.PrecioProducto;
                    }
                }

                return productos.Where(x => productosEnOrden.Any(y => y.IdProducto == x.ID)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar consultar los productos: {ex.Message}", ex);
            }
        }
    }
}
