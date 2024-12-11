using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace Mappers
{
    public class MapperCliente : MapperBase<BE_Cliente>, IAbmc<BE_Cliente>
    {
        private const string ARCHIVO_CLIENTES = @".\DATA\Cliente.xml";

        public MapperCliente(): base(ARCHIVO_CLIENTES) { }

        public bool Guardar(BE_Cliente pCliente)
        {
            try
            {
                XDocument xml = CargarXml();

                var clienteExistente = xml.Descendants("Cliente").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pCliente.ID);

                if (clienteExistente != null)
                {
                    ActualizarElementoCliente(clienteExistente, pCliente);
                }
                else
                {
                    pCliente.ID = GenerarNuevoId(xml);
                    xml.Root.Add(CrearElementoCliente(pCliente));
                }

                GuardarXml(xml);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Borrar (BE_Cliente pCliente)
        {
            try
            {
                XDocument xml = CargarXml();
                var cliente = xml.Descendants("Cliente").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pCliente.ID);

                if (cliente != null)
                {
                    cliente.Remove();
                    GuardarXml(xml);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BE_Cliente> Consultar()
        {
            try
            {
                XDocument xml = CargarXml();
                return xml.Descendants("Cliente").Select(x => new BE_Cliente
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    Nombre = x.Element("Nombre").Value,
                    Apellido = x.Element("Apellido").Value,
                    DNI = x.Element("DNI").Value,
                    Direccion = x.Element("Direccion").Value,
                    Telefono = x.Element("Telefono").Value,
                    Email = x.Element("Email").Value,
                    FechaNacimiento = DateTime.Parse(x.Element("FechaNacimiento").Value)
                }).ToList();
            }
            catch (Exception)
            {
                return new List<BE_Cliente>();
            }
        }

        private int GenerarNuevoId(XDocument xml)
        {
            int maxId = xml.Descendants("Cliente").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0;
            return maxId + 1;
        }

        private XElement CrearElementoCliente(BE_Cliente pCliente)
        {
            return new XElement("Cliente",
                new XAttribute("ID", pCliente.ID),
                new XElement("Nombre", pCliente.Nombre),
                new XElement("Apellido", pCliente.Apellido),
                new XElement("DNI", pCliente.DNI),
                new XElement("Direccion", pCliente.Direccion),
                new XElement("Telefono", pCliente.Telefono),
                new XElement("Email", pCliente.Email),
                new XElement("FechaNacimiento", pCliente.FechaNacimiento.ToString("yyyy-MM-dd")));
        }

        private void ActualizarElementoCliente(XElement pCliente, BE_Cliente pObjCliente)
        {
            pCliente.Element("Nombre").Value = pObjCliente.Nombre;
            pCliente.Element("Apellido").Value = pObjCliente.Apellido;
            pCliente.Element("DNI").Value = pObjCliente.DNI;
            pCliente.Element("Direccion").Value = pObjCliente.Direccion;
            pCliente.Element("Telefono").Value = pObjCliente.Telefono;
            pCliente.Element("Email").Value = pObjCliente.Email;
            pCliente.Element("FechaNacimiento").Value = pObjCliente.FechaNacimiento.ToString("yyyy-MM-dd");
        } 
    }
}
