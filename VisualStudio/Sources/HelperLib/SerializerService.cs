using System;
using System.IO;

namespace Elreg.HelperLib
{
    public class SerializerService<T> where T : class, new()
    {
        readonly string _path;
        readonly string _fileName;
        private T _t;

        public SerializerService(string path, string fileName)
        {
            _path = path;
            _fileName = fileName;

            if (ExistsPath() == false)
                CreatePath();
        }

        public T Object
        {
            get
            {
                if (_t == null)
                    ObtainObject();
                return _t;
            }
        }

        public void Save(T template)
        {
            ObjectXmlSerializer<T>.Save(template, XmlFileName, SerializedFormat.Document);
        }

        private void Save()
        {
            ObjectXmlSerializer<T>.Save(Object, XmlFileName, SerializedFormat.Document);
        }

        public void Reset()
        {
            _t = null;
        }

        private void ObtainObject()
        {
            try
            {
                LoadObjectFromXmlFile();
                if (_t == null)
                    _t = new T();
            }
            catch (FileNotFoundException)
            {
                CreateNew();
                Save();
            }
            catch (Exception)
            {
                CreateNew();
            }
        }

        private void CreateNew()
        {
            _t = new T();
        }

        private void LoadObjectFromXmlFile()
        {
            _t = ObjectXmlSerializer<T>.Load(XmlFileName, SerializedFormat.Document);
        }

        private string XmlFileName
        {
            get { return _path + _fileName; }
        }

        private bool ExistsPath()
        {
            return Directory.Exists(_path);
        }

        private void CreatePath()
        {
            Directory.CreateDirectory(_path);
        }
    }
}
