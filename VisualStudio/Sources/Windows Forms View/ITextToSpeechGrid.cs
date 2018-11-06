using System.Collections.Generic;
using Elreg.WinFormsPresentationFramework.DataTransferObjects;

namespace Elreg.WindowsFormsView
{
    public interface ITextToSpeechGrid
    {
        List<TextToSpeechCreationRow> DataList { set; }
    }

}
