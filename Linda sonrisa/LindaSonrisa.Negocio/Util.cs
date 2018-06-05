/// <history> 
///     [Alexis Moya] 27/04/2018 Modificado
///     [Franco Retamal] 01/05/2018 Modificado
///     [Rodrigo Torres] 02/05/2018 Modificado
/// </history> 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LindaSonrisa.Negocio
{
   public class Util
    {
        
        //Metodo que serializa el parametro "objeto" y devuelve un string
        public static string Serializar<T>(object objeto)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            StringWriter w = new StringWriter();
            s.Serialize(w, objeto);
            return w.ToString();
        }

        //Metodo que deserializa el parametro "xml" y devuelve un objeto de clase "T"
        public static T Deserializar<T>(string xml)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            StringReader r = new StringReader(xml);
            return (T)s.Deserialize(r);
        }
    }
}

