using System;
using System.Xml.Serialization; // For serialization of an object to an XML Document file.
using System.IO; // For reading/writing data to an XML file.
using System.IO.IsolatedStorage; // For accessing user isolated data.

namespace Elreg.Serialization
{
    public static class ObjectXmlSerializer<T> where T : class // Specify that T must be a class.
    {
        public static T Load(string path)
        {
            T serializableObject = LoadFromDocumentFormat(null, path, null);
            return serializableObject;
        }

        public static T Load(string path, Type[] extraTypes)
        {
            T serializableObject = LoadFromDocumentFormat(extraTypes, path, null);
            return serializableObject;
        }

        public static T Load(string fileName, IsolatedStorageFile isolatedStorageDirectory)
        {
            T serializableObject = LoadFromDocumentFormat(null, fileName, isolatedStorageDirectory);
            return serializableObject;
        }

        public static T Load(string fileName, IsolatedStorageFile isolatedStorageDirectory, Type[] extraTypes)
        {
            T serializableObject = LoadFromDocumentFormat(null, fileName, isolatedStorageDirectory);
            return serializableObject;
        }

        public static void Save(T serializableObject, string path)
        {
            SaveToDocumentFormat(serializableObject, null, path, null);
        }

        public static void Save(T serializableObject, string path, Type[] extraTypes)
        {
            SaveToDocumentFormat(serializableObject, extraTypes, path, null);
        }

        public static void Save(T serializableObject, string fileName, IsolatedStorageFile isolatedStorageDirectory)
        {
            SaveToDocumentFormat(serializableObject, null, fileName, isolatedStorageDirectory);
        }

        public static void Save(T serializableObject, string fileName, IsolatedStorageFile isolatedStorageDirectory, Type[] extraTypes)
        {
            SaveToDocumentFormat(serializableObject, null, fileName, isolatedStorageDirectory);
        }

        private static FileStream CreateFileStream(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            FileStream fileStream;

            if (isolatedStorageFolder == null)
                fileStream = new FileStream(path, FileMode.OpenOrCreate);
            else
                fileStream = new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder);

            return fileStream;
        }

        private static T LoadFromDocumentFormat(Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
        {
            T serializableObject;

            using (TextReader textReader = CreateTextReader(isolatedStorageFolder, path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                serializableObject = xmlSerializer.Deserialize(textReader) as T;
            }
            return serializableObject;
        }

        private static TextReader CreateTextReader(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            TextReader textReader;

            if (isolatedStorageFolder == null)
                textReader = new StreamReader(path);
            else
                textReader = new StreamReader(new IsolatedStorageFileStream(path, FileMode.Open, isolatedStorageFolder));

            return textReader;
        }

        private static TextWriter CreateTextWriter(IsolatedStorageFile isolatedStorageFolder, string path)
        {
            TextWriter textWriter;

            if (isolatedStorageFolder == null)
                textWriter = new StreamWriter(path);
            else
                textWriter = new StreamWriter(new IsolatedStorageFileStream(path, FileMode.OpenOrCreate, isolatedStorageFolder));

            return textWriter;
        }

        private static XmlSerializer CreateXmlSerializer(Type[] extraTypes)
        {
            Type objectType = typeof(T);

            XmlSerializer xmlSerializer;

            if (extraTypes != null)
                xmlSerializer = new XmlSerializer(objectType, extraTypes);
            else
                xmlSerializer = new XmlSerializer(objectType);

            return xmlSerializer;
        }

        private static void SaveToDocumentFormat(T serializableObject, Type[] extraTypes, string path, IsolatedStorageFile isolatedStorageFolder)
        {
            using (TextWriter textWriter = CreateTextWriter(isolatedStorageFolder, path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                xmlSerializer.Serialize(textWriter, serializableObject);
            }
        }
    }
}