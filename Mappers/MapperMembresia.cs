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
    public class MapperMembresia : IAbmc<BE_Membresia>
    {
        const string archivo = @".\Data\Membresia.xml";
        const string archivoClienteMembresia = @".\Data\Cliente_Membresia.xml";

        public bool Borrar(BE_Membresia pObjMembresia)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                XDocument xmlClienteMembresia = XDocument.Load(archivoClienteMembresia);

                //Verificar que no existan clientes asociados a la membresia antes de borrarla
                var membresiaEnUso = xmlClienteMembresia.Descendants("Cliente_Membresia").
                                Any(x => int.Parse(x.Element("IdMembresia").Value) == pObjMembresia.IdMembresia);
                if (!membresiaEnUso)
                {
                    var query = from x in docXML.Descendants("Membresia")
                                where int.Parse(x.Attribute("IdMembresia").Value) == pObjMembresia.ID
                                select x;

                    query.Remove();
                    docXML.Save(archivo);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int MembresiaID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Membresia").Select(e => (int?)e.Attribute("IdMembresia"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Membresia pObjBEMembresia)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);

                if (pObjBEMembresia.ID == 0)
                {
                    docXML.Element("Membresias").Add(new XElement("Membresia",
                                        new XAttribute("IdMembresia", MembresiaID()),
                                        new XElement("Tipo", pObjBEMembresia.Tipo.ToString()),
                                        new XElement("CostoMensual", pObjBEMembresia.CostoMensual.ToString()),
                                        new XElement("FechaInicio", pObjBEMembresia.FechaInicio.ToString()),
                                        new XElement("FechaFin", pObjBEMembresia.FechaFin.ToString()),
                                        new XElement("Estado", pObjBEMembresia.EstaActiva.ToString())
                                        ));
                    docXML.Save(archivo);
                    return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Membresia")
                                where x.Attribute("IdMembresia").Value == pObjBEMembresia.ID.ToString()
                                select x;

                    foreach (XElement item in query)
                    {
                        item.Element("Tipo").Value = pObjBEMembresia.Tipo.ToString();
                        item.Element("CostoMensual").Value = pObjBEMembresia.CostoMensual.ToString();
                        item.Element("FechaInicio").Value = pObjBEMembresia.FechaInicio.ToString();
                        item.Element("FechaFin").Value = pObjBEMembresia.FechaFin.ToString();
                        item.Element("Estado").Value = pObjBEMembresia.EstaActiva.ToString();
                    }
                    docXML.Save(archivo);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Membresia> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                var query = from x in docXML.Descendants("Membresia")
                            select x;
                List<BE_Membresia> listaMembresias = new List<BE_Membresia>();
                foreach (XElement item in query)
                {
                    BE_Membresia membresia = new BE_Membresia();
                    {
                        membresia.ID = int.Parse(item.Attribute("IdMembresia").Value);
                        membresia.Tipo = item.Element("Tipo").Value;
                        membresia.CostoMensual = decimal.Parse(item.Element("CostoMensual").Value);
                        membresia.FechaInicio = DateTime.Parse(item.Element("FechaInicio").Value);
                        membresia.FechaFin = DateTime.Parse(item.Element("FechaFin").Value);
                        membresia.EstaActiva = bool.Parse(item.Element("Estado").Value);
                    }
                    listaMembresias.Add(membresia);
                }
                return listaMembresias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
