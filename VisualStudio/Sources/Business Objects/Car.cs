using System;
using System.Drawing;
using System.Xml.Serialization;
using Elreg.HelperClasses;
using Elreg.Log;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global
namespace Elreg.BusinessObjects
{
    [Serializable]
    public class Car
    {
        private Bitmap _image;

        public event EventHandler DataChanged;

        public int? Id { get; set; }

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string PictureFilename { get; set; }

        [JsonIgnore]
        public string PictureTopViewFilename { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Image Image
        {
            get
            {
                if (_image == null)
                    CreateImage();
                return _image;
            }
            set { _image = (Bitmap) value; }
        }

        public void RaiseEventDataChanged()
        {
            if (DataChanged != null)
                DataChanged(this, null);
        }

        private void CreateImage()
        {
            try
            {
                if (string.IsNullOrEmpty(PictureFilename))
                    _image = null;
                else
                    _image = new Bitmap(SystemHelper.GetAbsolutePath(PictureFilename));
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
        }
    }
}