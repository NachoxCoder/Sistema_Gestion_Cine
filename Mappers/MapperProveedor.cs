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
     public class MapperProveedor : MapperBase<BE_Proveedor>, IAbmc<BE_Proveedor>
    {
        private const string archivoProveedor = @".\DATA\Proveedor.xml";
        private readonly MapperOrdenCompra mapperOrdenCompra;

        public MapperProveedor() : base(archivoProveedor)
        {
            mapperOrdenCompra = new MapperOrdenCompra();
        }

        public bool Borrar(BE_Proveedor pProveedor)
        {
            try
            {
                XDocument docXML = CargarXml();

                var proveedor = docXML.Descendants("Proveedor")
                    .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pProveedor.ID);

                if (proveedor != null)
                {
                    var ordenesActivas = mapperOrdenCompra.Consultar()
                        .Any(x => x.IdProveedor == pProveedor.ID);

                    if (!ordenesActivas)
                    {
                        proveedor.Remove();
                        GuardarXml(docXML);
                        return true;
                    }
                    else
                    {
                        throw new Exception("No se puede eliminar el proveedor porque tiene ordenes de compra activas");
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Proveedor pProveedor)
        {
            try
            {
                XDocument docXML = CargarXml();
                if (pProveedor.ID == 0)
                {
                    pProveedor.ID = GenerarNuevoID(docXML);
                    var nuevoProveedor = new XElement("Proveedor",
                        new XAttribute("ID", pProveedor.ID),
                        new XElement("Razon Social", pProveedor.RazonSocial),
                        new XElement("CUIT", pProveedor.CUIT),
                        new XElement("Direccion", pProveedor.DireccionProveedor),
                        new XElement("Telefono", pProveedor.TelefonoProveedor),
                        new XElement("Email", pProveedor.EmailProveedor),
                        new XElement("EstaActivo", pProveedor.EstaActivo)
                    );
                    docXML.Root.Add(nuevoProveedor);
                }
                else
                {
                    var proveedor = docXML.Descendants("Proveedor")
                        .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pProveedor.ID);

                    if (proveedor != null)
                    {
                        proveedor.Element("RazonSocial").Value = pProveedor.RazonSocial;
                        proveedor.Element("CUIT").Value = pProveedor.CUIT;
                        proveedor.Element("Direccion").Value = pProveedor.DireccionProveedor;
                        proveedor.Element("Telefono").Value = pProveedor.TelefonoProveedor;
                        proveedor.Element("Email").Value = pProveedor.EmailProveedor;
                        proveedor.Element("EstaActivo").Value = pProveedor.EstaActivo.ToString();
                    }
                }
                GuardarXml(docXML);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Proveedor> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var ordenesCompra = mapperOrdenCompra.Consultar();

                var proveedores = docXML.Descendants("Proveedor").Select(x => new BE_Proveedor
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    RazonSocial = x.Element("RazonSocial").Value,
                    CUIT = x.Element("CUIT").Value,
                    DireccionProveedor = x.Element("Direccion").Value,
                    TelefonoProveedor = x.Element("Telefono").Value,
                    EmailProveedor = x.Element("Email").Value,
                    EstaActivo = bool.Parse(x.Element("EstaActivo").Value)
                }).ToList();

                foreach (var proveedor in proveedores)
                {
                    proveedor.OrdenesCompra = ordenesCompra.Where(x => x.IdProveedor == proveedor.ID).ToList();
                    
                }

                return proveedores;
            }
            catch (Exception ex)
            {
                return new List<BE_Proveedor>();
            }
        }

        private int GenerarNuevoID(XDocument docXML)
        {
            return docXML.Descendants("Proveedor").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public BE_Proveedor ConsultarPorId(int pId)
        {
            return Consultar().FirstOrDefault(x => x.ID == pId);
        }
    }
}
