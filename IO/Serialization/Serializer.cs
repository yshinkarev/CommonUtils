using System;

namespace Common.IO.Serialization
{
    /// <summary>
    /// делает копию объекта source через сериализацию
    /// </summary>
    static public class Serializer
    {
        /// <param name="type">Допустимые значения: xml, bin</param>        
        public static object CopyObj(object source, string type)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            object dest;

            if (type == "xml")
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(source.GetType());

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    xs.Serialize(ms, source);
                    ms.Position = 0;
                    dest = xs.Deserialize(ms);
                }

            }
            else if (type == "bin")
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bf.Serialize(ms, source);
                    ms.Position = 0;
                    dest = bf.Deserialize(ms);
                }
            }
            else
                throw new ArgumentException("type");

            return dest;
        }
    }
}
