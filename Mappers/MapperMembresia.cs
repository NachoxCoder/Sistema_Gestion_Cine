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
    public class MapperMembresia : MapperBase<BE_Membresia>, IAbmc<BE_Membresia>
    {
        const string archivoMembresia = @".\Data\Membresia.xml";
        private readonly MapperCliente _mapperCliente;

        public MapperMembresia() : base(archivoMembresia)
        {
            _mapperCliente = new MapperCliente();
        }

        public bool Borrar(BE_Membresia pMembresia)
        {
            try
            {
                XDocument docXML = CargarXml();
                var membresia = docXML.Descendants("Membresia").
                                FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pMembresia.ID);
                if (membresia != null)
                {
                   membresia.Remove();
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

        public bool Guardar(BE_Membresia pMembresia)
        {
            try
            {
                XDocument docXML = CargarXml();

                if (pMembresia.ID == 0)
                {
                    pMembresia.ID = GenerarNuevoId(docXML);

                    var nuevaMembresia = new XElement("Membresia",
                                        new XAttribute("ID", pMembresia.ID),
                                        new XElement("IdCliente", pMembresia.IdCliente),
                                        new XElement("Tipo", pMembresia.Tipo.ToString()),
                                        new XElement("CostoMensual", pMembresia.CostoMensual.ToString("F2")),
                                        new XElement("FechaInicio", pMembresia.FechaInicio.ToString("yyyy-MM-dd")),
                                        new XElement("FechaFin", pMembresia.FechaFin.ToString("yyyy-MM-dd")),
                                        new XElement("Estado", pMembresia.EstaActiva));

                    docXML.Root.Add(nuevaMembresia);
                }
                else
                {
                    var membresia = docXML.Descendants("Membresia").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pMembresia.ID);

                    if (membresia != null)
                    {
                        membresia.Element("Tipo").Value = pMembresia.Tipo.ToString();
                        membresia.Element("CostoMensual").Value = pMembresia.CostoMensual.ToString("F2");
                        membresia.Element("FechaInicio").Value = pMembresia.FechaInicio.ToString("yyyy-MM-dd");
                        membresia.Element("FechaFin").Value = pMembresia.FechaFin.ToString("yyyy-MM-dd");
                        membresia.Element("Estado").Value = pMembresia.EstaActiva.ToString();
                        membresia.Element("IdCliente").Value = pMembresia.IdCliente.ToString();
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

        public List<BE_Membresia> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var clientes = _mapperCliente.Consultar();

                var membresias = docXML.Descendants("Membresia").Select(x => new BE_Membresia
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdCliente = int.Parse(x.Element("IdCliente").Value),
                    Tipo = (TipoMembresia)Enum.Parse(typeof(TipoMembresia), x.Element("TipoMembresia").Value),
                    CostoMensual = decimal.Parse(x.Element("CostoMensual").Value),
                    FechaInicio = DateTime.Parse(x.Element("FechaInicio").Value),
                    FechaFin = DateTime.Parse(x.Element("FechaFin").Value),
                    EstaActiva = bool.Parse(x.Element("Estado").Value),
                }).ToList();

                foreach (var membresia in membresias)
                {
                    membresia.Cliente = clientes.FirstOrDefault(c => c.ID == membresia.IdCliente);
                }
                return membresias;
            }
            catch
            {
                return new List<BE_Membresia>();
            }
        }


        public int GenerarNuevoId(XDocument pDocXml)
        {
            return pDocXml.Descendants("Membresia").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public bool AsignarMembresiaCliente(BE_Cliente pCliente, BE_Membresia pMembresia)
        {
            try
            {
                XDocument docClienteMembresia = XDocument.Load(archivoClienteMembresia);
                //verificar si el cliente ya tiene la membresia asignada
                var membresiaActiva = docClienteMembresia.Descendants("Cliente_Membresia").
                    Where(x => int.Parse(x.Element("IdCliente").Value) == pCliente.ID &&
                    x.Element("EstaActiva").Value == "true");

                //Desactivar la membresia anterior
                foreach (var item in membresiaActiva)
                {
                    item.Element("EstaActiva").Value = "false";
                    item.Element("FechaFin").Value = DateTime.Now.ToString();
                }

                //Agregar la nueva membresia
                docClienteMembresia.Element("Clientes_Membresias").Add(new XElement("Cliente_Membresia",
                    new XElement("IdCliente", pCliente.ID),
                    new XElement("IdMembresia", pMembresia.ID),
                    new XElement("FechaInicio", DateTime.Now.ToString()),
                    new XElement("FechaFin", string.Empty),
                    new XElement("EstaActiva", "true")
                    ));

                docClienteMembresia.Save(archivoClienteMembresia);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BE_Membresia ObtenerMembresiaActiva(BE_Cliente pCliente)
        {
            try
            {
                XDocument docClienteMembresia = XDocument.Load(archivoClienteMembresia);

                var membresiaActiva = docClienteMembresia.Descendants("Cliente_Membresia").
                    FirstOrDefault(x => int.Parse(x.Element("IdCliente").Value) == pCliente.ID &&
                    x.Element("EstaActiva").Value == "true");

                if (membresiaActiva != null)
                {
                    int membresiaID = int.Parse(membresiaActiva.Element("IdMembresia").Value);
                    return Consultar().FirstOrDefault(x => x.ID == membresiaID);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
