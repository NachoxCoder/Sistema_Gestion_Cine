using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using Interfaces;

namespace Mappers
{
    public class MapperButaca : IAbmc<BE_Butaca>
    {
        const string archivo = @".\Data\Butaca.xml";
        const string archivoButacaFuncion = @".\Data\Butaca_Funcion.xml";

        public bool Borrar(BE_Butaca pObjButaca)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                XDocument xmlButacaFuncion = XDocument.Load(archivoButacaFuncion);

                //Verificar que no existan butacas ocupadas o asociadas a alguna funcion antes de borrarla
                bool butacaOupada = xmlButacaFuncion.Descendants("Butaca_Funcion").
                                    Any(x => int.Parse(x.Element("IdButaca").Value) == pObjButaca.ID);
                if (!butacaOupada)
                {
                    var query = from x in docXML.Descendants("Butaca")
                                where int.Parse(x.Attribute("IdButaca").Value) == pObjButaca.IdButaca
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

        public int ButacaID()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                int ultimoId = docXML.Descendants("Butaca").Select(e => (int?)e.Attribute("IdButaca"))
                               .Max() ?? 0;
                return ultimoId == 0 ? 1 : ultimoId + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Guardar(BE_Butaca objBEButaca)
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                if (objBEButaca.IdButaca == 0)
                {
                    docXML.Element("Butacas").Add(new XElement("Butaca",
                    new XAttribute("IdButaca", ButacaID()),
                    new XElement("IdSala", objBEButaca.Sala.ID),
                    new XElement("Fila", objBEButaca.Fila),
                    new XElement("Numero", objBEButaca.Numero),
                    new XElement("Disponible", objBEButaca.Disponible)
                    ));

                docXML.Save(archivo);
                return true;
                }
                else
                {
                    var query = from x in docXML.Descendants("Butaca")
                                where int.Parse(x.Attribute("IdButaca").Value) == objBEButaca.IdButaca
                                select x;
                    foreach (var item in query)
                    {
                        item.Element("IdSala").Value = objBEButaca.Sala.ID.ToString();
                        item.Element("Fila").Value = objBEButaca.Fila;
                        item.Element("Numero").Value = objBEButaca.Numero.ToString();
                        item.Element("Disponible").Value = objBEButaca.Disponible.ToString();
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

        public List<BE_Butaca> Consultar()
        {
            try
            {
                XDocument docXML = XDocument.Load(archivo);
                MapperSala mppSala = new MapperSala();

                var query = from x in docXML.Descendants("Butaca") select x;
                List<BE_Butaca> listaButacas = new List<BE_Butaca>();
                foreach (XElement item in query)
                {
                    BE_Butaca objBEButaca = new BE_Butaca();
                    objBEButaca.IdButaca = int.Parse(item.Attribute("IdButaca").Value);
                    objBEButaca.Sala.ID = int.Parse(item.Element("IdSala").Value);
                    objBEButaca.Fila = item.Element("Fila").Value;
                    objBEButaca.Numero = int.Parse(item.Element("Numero").Value);
                    objBEButaca.Disponible = bool.Parse(item.Element("Disponible").Value);
                    listaButacas.Add(objBEButaca);
                }
                return listaButacas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BE_Butaca> ListarButacasDisponibles(BE_Funcion pFuncion)
        {
            try
            {
                //Obtener todas las butacas de la sala de la funcion
                List<BE_Butaca> listaButacas = Consultar().
                                               Where(b => b.Sala.ID == pFuncion.Sala.ID && b.Disponible == true).
                                               ToList();
                //Obtener las butacas ocupadas de la funcion
                XDocument docButacaFuncion = XDocument.Load(archivoButacaFuncion);
                var butacasOcupadas = docButacaFuncion.Descendants("Butaca_Funcion").
                                      Where(x => int.Parse(x.Element("IdFuncion").Value) == pFuncion.ID).
                                      Select(x => int.Parse(x.Element("IdButaca").Value));
                // Retorna solo las butacas disponibles
                return listaButacas.Where(x => !butacasOcupadas.Contains(x.IdButaca)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool OcuparButaca(BE_Butaca pButaca, BE_Funcion pFuncion)
        {
            try
            {
                XDocument docButacaFuncion = XDocument.Load(archivoButacaFuncion);

                //Verificar que la butaca no este ocupada
                bool butacaOcupada = docButacaFuncion.Descendants("Butaca_Funcion").
                                     Any(x => int.Parse(x.Element("IdButaca").Value) == pButaca.IdButaca &&
                                              int.Parse(x.Element("IdFuncion").Value) == pFuncion.ID);
                if (!butacaOcupada)
                {
                    docButacaFuncion.Element("Butacas_Funciones").Add(new XElement("Butaca_Funcion",
                    new XElement("IdButaca", pButaca.ID),
                    new XElement("IdFuncion", pFuncion.ID),
                    new XElement("FechaOcupacion", DateTime.Now.ToString())
                    ));

                docButacaFuncion.Save(archivoButacaFuncion);
                return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
