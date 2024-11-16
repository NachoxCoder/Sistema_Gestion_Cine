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
    public class MapperButaca : MapperBase<BE_Butaca>, IAbmc<BE_Butaca>
    {
        private const string archivoButaca = @".\Data\Butaca.xml";
        private const string archivoButacaFuncion = @".\Data\Butaca_Funcion.xml";
        private readonly MapperSala mapperSala;

        public MapperButaca() : base(archivoButaca) 
        {
            mapperSala = new MapperSala();
        }

        public bool Borrar(BE_Butaca pObjButaca)
        {
            try
            {
                XDocument docXML = CargarXml();

                var butaca = docXML.Descendants("Butaca").
                    FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pObjButaca.ID);

                if (butaca != null)
                {
                    butaca.Remove();
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

        public int GenerarNuevoId(XDocument xml)
        {
            return xml.Descendants("Butaca").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public bool Guardar(BE_Butaca pButaca)
        {
            try
            {
                XDocument docXML = CargarXml();
                if (pButaca.ID == 0)
                {
                    pButaca.ID = GenerarNuevoId(docXML);
                    var nuevaButaca = new XElement("Butaca",
                    new XAttribute("ID", pButaca.ID),
                    new XElement("IdSala", pButaca.IdSala),
                    new XElement("Fila", pButaca.Fila),
                    new XElement("Numero", pButaca.Numero),
                    new XElement("Disponible", pButaca.Disponible));

                    docXML.Root.Add(nuevaButaca);
                }
                else
                {
                    var butaca = docXML.Descendants("Butaca").
                        FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pButaca.ID);
                    if (butaca != null) 
                    {
                        butaca.Element("IdSala").Value = pButaca.IdSala.ToString();
                        butaca.Element("Fila").Value = pButaca.Fila;
                        butaca.Element("Numero").Value = pButaca.Numero.ToString();
                        butaca.Element("Disponible").Value = pButaca.Disponible.ToString();
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

        public List<BE_Butaca> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var salas = mapperSala.Consultar();

                var butacas = docXML.Descendants("Butaca").Select(x => new BE_Butaca
                {
                    ID = int.Parse(x.Attribute("ID").Value),
                    IdSala = int.Parse(x.Element("IdSala").Value),
                    Fila = x.Element("Fila").Value,
                    Numero = int.Parse(x.Element("Numero").Value),
                    Disponible = bool.Parse(x.Element("Disponible").Value)
                }).ToList();

                foreach (var butaca in butacas)
                {
                    butaca.Sala = salas.FirstOrDefault(x => x.ID == butaca.IdSala);
                }
                return butacas;
            }
            catch
            {
                return new List<BE_Butaca>();
            }
        }

        public List<BE_Butaca> ConsultarButacasPorSala(int idSala)
        {
            return Consultar().Where(x => x.IdSala == idSala).ToList();
        }

        public List<BE_Butaca> ConsultarButacasDisponiblesPorSala(int idSala)
        {
            return Consultar().Where(x => x.IdSala == idSala && x.Disponible).ToList();
        }

        public List<BE_Butaca> ConsultarButacasOcupadas()
        {
            try
            {
                XDocument xmlButacaFuncion = XDocument.Load(archivoButacaFuncion);

                var butacasOcupadas = xmlButacaFuncion.Descendants("Butaca_Funcion")
                                      .Select(x => int.Parse(x.Element("IdButaca").Value)).Distinct().ToList();

                return Consultar().Where(x => butacasOcupadas.Contains(x.ID)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al consultar butacas ocupadas: {ex.Message}", ex);
            }
        }

        public bool OcuparButaca(BE_Butaca pButaca, BE_Funcion pFuncion)
        {
            try
            {
                XDocument docXML = CargarXml();
                XDocument xmlButacaFuncion = XDocument.Load(archivoButacaFuncion);

                var butacaOcupada = xmlButacaFuncion.Descendants("Butaca_Funcion")
                                    .Any(x => int.Parse(x.Element("IdButaca").Value) == pButaca.ID &&
                                    int.Parse(x.Element("IdFuncion").Value) == pFuncion.ID);

                if (!butacaOcupada)
                {
                    //Registrar butaca ocupada
                    xmlButacaFuncion.Element("Butacas_Funciones").Add(new XElement("Butaca_Funcion",
                        new XElement("IdButaca", pButaca.ID),
                        new XElement("IdFuncion", pFuncion.ID),
                        new XElement("FechaOcupacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))));

                    //Actualizar el Estado de la Butaca
                    var butaca = docXML.Descendants("Butaca")
                                 .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pButaca.ID);

                    if (butaca != null)
                    {
                        butaca.Element("Disponible").Value = "false";
                    }

                    docXML.Save(archivoButaca);
                    xmlButacaFuncion.Save(archivoButacaFuncion);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ocupar la butaca: {ex.Message}", ex);
            }
        }
    }
}
