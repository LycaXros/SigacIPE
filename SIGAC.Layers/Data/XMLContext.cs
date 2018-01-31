using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SIGAC.Layers.Data
{
    public static class XMLContext
    {

        /*  https://codehandbook.org/c-object-xml/

            https://stackoverflow.com/questions/17739330/xmlserializer-convert-c-sharp-object-to-xml-string

            https://stackoverflow.com/questions/11330643/serialize-property-as-xml-attribute-in-element

            This tutorials will help to use XML Serealizer to convert a class to XML             */


        #region     Variables y Propiedades

        private static string Ruta { get; set; }
        private static string NombreArchivo { get; set; }

        #endregion  Variables y Propiedades


        #region     Inicializar la clase

        /// <summary>
        /// Inicializar la clase
        /// </summary>
        /// <param name="ruta">Ruta del Archivo</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        public static void Inicializar(string ruta, string nombreArchivo)
        {
            Ruta = ruta;
            NombreArchivo = nombreArchivo;
        }

        #endregion  Inicializar la clase


        #region    Conseguir el inner text o el valor del atributo del XML  

        /// <summary>
        /// Conseguir el inner text o el valor del atributo del XML
        /// </summary>
        /// <param name="node">Nodo que contiene el valor que se quiere conseguir</param>
        /// <param name="attribute">Opcional. El atributo que contiene el valor</param>
        /// <returns>Valor del atributo o inner text del nodo</returns>
        public static string buscarNodo(string nodo, string atributo = "")
        {
            XDocument document = XDocument.Load(Ruta + NombreArchivo);
            string search = string.Empty;

            if (string.IsNullOrWhiteSpace(atributo))
            {
                search = document.Elements()
                     .Where(x => x.Name == nodo)
                     .First()
                     .Value;
            }
            else
            {
                search = document.Elements()
                     .Where(x => x.Name == nodo)
                     .First()
                     .Attributes()
                     .Where(y => y.Name == atributo)
                     .First()
                     .Value;
            }

            return search;

        }

        #endregion Conseguir el inner text o el valor del atributo del XML


        #region     Escribir un XML basado en un objeto de una clase

        /// <summary>
        /// Escribir un XML basado en un objeto de una clase
        /// </summary>
        /// <param name="ObjectToXML">Object to be convert to XML file</param>
        /// <returns>True for Success, else False</returns>
        public static bool escribirXML(object ObjectToXML)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(ObjectToXML.GetType());

                serializer.Serialize(File.Create(Ruta + NombreArchivo), ObjectToXML);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        #endregion  Escribir un XML basado en un objeto de una clase

    }
}
