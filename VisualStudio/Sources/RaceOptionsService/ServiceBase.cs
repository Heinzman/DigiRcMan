using System;
using System.IO;
using Elreg.BusinessObjects;
using Elreg.Log;

namespace Elreg.RaceOptionsService
{
    public abstract class ServiceBase<T> where T : class, new() 
    {
        private T _t;
        private SerializerService<T> _serializerService;

        private SerializerService<T> SerializerService
        {
            get
            {
                if (_serializerService == null)
                    InitSerializerService();
                return _serializerService;
            }
        }
        protected T Object
        {
            get
            {
                if (_t == null)
                    ObtainObject();
                return _t;
            }
            set { _t = value; }
        }

        public virtual void Reset()
        {
            _t = null;
            SerializerService.Reset();
        }

        public virtual void Save()
        {
            SerializerService.Save(_t);
        }

        public void Save(T t)
        {
            SerializerService.Save(t);
        }

        protected abstract string Filename { get; }

        protected virtual string Path
        {
            get { return ServiceHelper.ConfigPath; }
        }

        private void InitSerializerService()
        {
            if (ExistsConfigPath() == false)
                CreateConfigPath();
            _serializerService = new SerializerService<T>(Path, Filename);
        }

        private void ObtainObject()
        {
            try
            {
                _t = SerializerService.Object;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            finally
            {
                if (_t == null)
                {
                    _t = new T();
                    Save();
                }
            }
        }

        private bool ExistsConfigPath()
        {
            return Directory.Exists(Path);
        }

        private void CreateConfigPath()
        {
            Directory.CreateDirectory(Path);
        }

        
    }
}
