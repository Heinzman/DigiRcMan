using System.Windows;
using Catel.MVVM;

namespace Elreg.ViewModelContracts
{
    public interface ISplashInfoViewModel : IViewModel
    {
        string VersionText { get; }
        string InfoText { get; set; }
        bool IsInfo { get; set; }
        string Environment { get; set; }
        Visibility VisibilityOfButton { get; }
        Visibility VisibilityOfInfo { get; }
    }
}