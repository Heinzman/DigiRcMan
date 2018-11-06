using System.Drawing;

namespace Elreg.WindowsFormsApplication
{
    public class ResourceLoader
    {
        private static readonly ResourceLoader Inst = new ResourceLoader();
        private Bitmap _glossymetal;

        public static Bitmap GetGlossymetal()
        {
            return Inst._glossymetal ?? (Inst._glossymetal = Properties.Resources.glossymetal);
        }
    }
}
