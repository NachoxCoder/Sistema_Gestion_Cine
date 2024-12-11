using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using Interfaces;

namespace Mappers
{
    public class MapperSala_Butaca : MapperBase<BE_Sala_Butaca>, IAbmc<BE_Sala_Butaca>
    {
        private const string archivoSalaButaca = @".\DATA\Sala_Butaca.xml";
        private readonly MapperSala mapperSala;
        private readonly MapperButaca mapperButaca;

        public MapperSala_Butaca() : base(archivoSalaButaca)
        {
            mapperSala = new MapperSala();
            mapperButaca = new MapperButaca();
        }

        public bool Borrar(BE_Sala_Butaca pSalaButaca)
        {
            try
            {
                XDocument docXML = CargarXml();
                var salaButaca = docXML.Descendants("SalaButaca")
                    .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pSalaButaca.ID);

                if (salaButaca != null)
                {
                    salaButaca.Remove();
                    GuardarXml(docXML);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool Guardar(BE_Sala_Butaca pSalaButaca)
        {
            try
            {
                XDocument docXML = CargarXml();
                if(pSalaButaca.ID == 0) 
                {
                    pSalaButaca.ID = GenerarNuevoID(docXML);
                    var nuevoSalaButaca = new XElement("SalaButaca",
                        new XAttribute("ID", pSalaButaca.ID),
                        new XAttribute("IdSala", pSalaButaca.IdSala),
                        new XAttribute("IdButaca", pSalaButaca.IdButaca),
                        new XAttribute("Ubicacion", pSalaButaca.Ubicacion),
                        new XAttribute("Ocupada", pSalaButaca.Ocupada),
                        new XAttribute("Activa", pSalaButaca.Activa)
                    );

                    docXML.Root.Add(nuevoSalaButaca);
                }
                else
                {
                    var salaButaca = docXML.Descendants("SalaButaca")
                        .FirstOrDefault(x => int.Parse(x.Attribute("ID").Value) == pSalaButaca.ID);

                    if(salaButaca != null)
                    {
                        salaButaca.Attribute("Ubicacion").Value = pSalaButaca.Ubicacion;
                        salaButaca.Attribute("Ocupada").Value = pSalaButaca.Ocupada.ToString();
                        salaButaca.Attribute("Activa").Value = pSalaButaca.Activa.ToString();
                    }
                }

                GuardarXml(docXML);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BE_Sala_Butaca> Consultar()
        {
            try
            {
                XDocument docXML = CargarXml();
                var salas = mapperSala.Consultar();
                var butacas = mapperButaca.Consultar();

                return docXML.Descendants("Sala_Butaca").Select(x => new BE_Sala_Butaca
                    {
                        ID = int.Parse(x.Attribute("ID").Value),
                        IdSala = int.Parse(x.Attribute("IdSala").Value),
                        IdButaca = int.Parse(x.Attribute("IdButaca").Value),
                        Ubicacion = x.Attribute("Ubicacion").Value,
                        Ocupada = bool.Parse(x.Attribute("Ocupada").Value),
                        Activa = bool.Parse(x.Attribute("Activa").Value),
                        Sala = salas.FirstOrDefault(s => s.ID == int.Parse(x.Element("IdSala").Value)),
                        Butaca = butacas.FirstOrDefault(b => b.ID == int.Parse(x.Element("IdButaca").Value))
                    }).ToList();
            }
            catch (Exception)
            {
                return new List<BE_Sala_Butaca>();
            }
        }

        private int GenerarNuevoID(XDocument pDocXML)
        {
            return pDocXML.Descendants("SalaButaca").Max(x => (int?)int.Parse(x.Attribute("ID").Value)) ?? 0 + 1;
        }

        public List<BE_Sala_Butaca> ConsultarPorSala(int idSala)
        {
            return Consultar().Where(x => x.IdSala == idSala).ToList();
        }

        public bool OcuparButaca(int idSala, int idButaca)
        {
            try
            {
                var salaButaca = Consultar().FirstOrDefault(x => x.IdSala == idSala && x.IdButaca == idButaca);

                if (salaButaca != null && !salaButaca.Ocupada)
                {
                    salaButaca.Ocupada = true;
                    return Guardar(salaButaca);
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
