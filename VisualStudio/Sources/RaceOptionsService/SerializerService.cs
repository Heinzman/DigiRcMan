using System;
using Elreg.Serialization;
using System.IO;
using Elreg.Log;

namespace Elreg.RaceOptionsService
{
    public class SerializerService<T>  
        where T : class, new() 
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
            try
            {
                ObjectXmlSerializer<T>.Save(template, XmlFileName, SerializedFormat.Document);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }

        private void Save()
        {
            try
            {
                ObjectXmlSerializer<T>.Save(Object, XmlFileName, SerializedFormat.Document);
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
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
            catch (Exception ex)
            {
                CreateNew();
                ErrorLog.LogError(false, ex);
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
