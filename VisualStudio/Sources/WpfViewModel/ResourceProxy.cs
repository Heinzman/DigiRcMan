using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Elreg.Log;

namespace Elreg.WpfViewModel
{
    public class ResourceProxy
    {
        private readonly List<KeyValuePair<string, BitmapImage>> _bitmapKeyValuePairs = new List<KeyValuePair<string, BitmapImage>>();

        public BitmapImage GetBitmap(string name)
        {
            BitmapImage bitmap = null;
            try
            {
                KeyValuePair<string, BitmapImage> bitmapKeyValuePair = _bitmapKeyValuePairs.Find(b => b.Key.Equals(name));
                if (bitmapKeyValuePair.Value == null)
                {
                    object obj = Resource1.ResourceManager.GetObject(name, Resource1.Culture);
                    BitmapImage bitmapImage = ConvertToBitmapImage((Image)obj);
                    bitmapKeyValuePair = new KeyValuePair<string, BitmapImage>(name, bitmapImage);
                    _bitmapKeyValuePairs.Add(bitmapKeyValuePair);
                }
                bitmap = bitmapKeyValuePair.Value;
                if (bitmap != null)
                    bitmap.Freeze();
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return bitmap;
        }

        private BitmapImage ConvertToBitmapImage(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }
    }
}
