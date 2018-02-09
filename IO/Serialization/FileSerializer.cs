using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.IO.Serialization
{
    /// <summary>
    /// Сериализует класс и сохраняет/открывает из файла.
    /// Если происходят исключения, то функции возвращает false/null
    /// </summary>
    public static class FileSerializer
    {
        static readonly XmlWriterSettings _settings = new XmlWriterSettings();
        static readonly XmlSerializerNamespaces _blank = new XmlSerializerNamespaces();
        static Exception _lastException;

        /// <summary>
        /// После использования, обнуляется
        /// </summary>
        public static Exception LastException
        {
            get 
            {
                Exception ex = _lastException;
                _lastException = null;
                return ex; 
            }
        }

        static FileSerializer()
        {
            SetSettingsDefault();
            
            _blank.Add("", "");
        }

        /// <summary>
        /// В начале xml не добавляет шапку.
        /// Не делает отступов и переходов на новую страницу
        /// </summary>
        public static void SetSettingsWithMinSize()
        {
            _settings.Indent = false;
            _settings.NewLineHandling = NewLineHandling.None;
            _settings.NewLineOnAttributes = false;
            _settings.OmitXmlDeclaration = true;
        }

        public static void SetSettingsDefault()
        {
            _settings.Indent = true;
            _settings.NewLineHandling = NewLineHandling.Replace;
            _settings.NewLineOnAttributes = true;
            _settings.OmitXmlDeclaration = false;            
        }
        
        public static XmlWriterSettings Settings
        {
            get { return _settings; }            
        }

        public static bool XmlWriteToFile(string fileName, object obj)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());

                using (XmlWriter writer = XmlWriter.Create(fileName, _settings))
                {
                    xs.Serialize(writer, obj, _blank);                    
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
                return false;
            }

            _lastException = null;
            return true;
        }

        public static object XmlReadFromFile(string fileName, Type type)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(type);

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    _lastException = null;
                    return xs.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }

            return null;
        }

        public static bool BinWriteToFile(string fileName, object obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream f = new FileStream(fileName, FileMode.Create))
                {
                    bf.Serialize(f, obj);
                }

            }
            catch (Exception ex)
            {
                _lastException = ex;
                return false;
            }

            _lastException = null;
            return true;
        }

        public static object BinReadFromFile(string fileName, Type type)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream f = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    _lastException = null;
                    return bf.Deserialize(f);
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }

            return null;
        }
    }
}
