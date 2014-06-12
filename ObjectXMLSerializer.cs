using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Animelist_v0._1
{
    public static class ObjectXMLSerializer<T> where T : class
    {
        #region Public Members
        public static T Load(string path)
        {
            T serializableObject = LoadFromFile(path);
            return serializableObject;
        }

        public static void Save(T serializableObject, string path)
        {
            SaveToFile(serializableObject, path);
        }

        #endregion

        #region Private Members

        private static T LoadFromFile(string path)
        {
            T serializableObject = null;

            using (FileStream stream = File.OpenRead(path))
            {
                try
                {
                    XmlSerializer xmlSerializer = CreateXmlSerializer();
                    serializableObject = xmlSerializer.Deserialize(stream) as T;
                }
                catch (Exception ex)
                {
                    Exception ie = ex.InnerException;
                }
            }
            return serializableObject;
        }

        private static void SaveToFile(T serializableObject, string path)
        {
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                using (XmlWriter xmlWriter = CreateXmlWriter(stream))
                {
                    XmlSerializer xmlSerializer = CreateXmlSerializer();
                    xmlSerializer.Serialize(xmlWriter, serializableObject);
                }
            }
        }

        private static XmlWriter CreateXmlWriter(FileStream stream)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false, Encoding = Encoding.UTF8 };
            XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings);

            return xmlWriter;
        }

        private static XmlSerializer CreateXmlSerializer()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            return xmlSerializer;
        }


        #endregion

    }
}
