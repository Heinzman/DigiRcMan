using System;
using System.Collections.Generic;
using System.Drawing;
using Elreg.Log;

namespace Elreg.WindowsFormsPresenter
{
    public class ResourceProxy
    {
        private readonly List<KeyValuePair<string, Bitmap>> _bitmapKeyValuePairs = new List<KeyValuePair<string, Bitmap>>();

        public Bitmap GetBitmap(string name)
        {
            Bitmap bitmap = null;
            try
            {
                KeyValuePair<string, Bitmap> bitmapKeyValuePair = _bitmapKeyValuePairs.Find(b => b.Key.Equals(name));
                if (bitmapKeyValuePair.Value == null)
                {
                    object obj = Resource1.ResourceManager.GetObject(name, Resource1.Culture);
                    bitmapKeyValuePair = new KeyValuePair<string, Bitmap>(name, (Bitmap)obj);
                    _bitmapKeyValuePairs.Add(bitmapKeyValuePair);
                }
                bitmap = bitmapKeyValuePair.Value;
            }
            catch (Exception ex)
            {
                ErrorLog.LogError(false, ex);
            }
            return bitmap;
        }
    }
}
