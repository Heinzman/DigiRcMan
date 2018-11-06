using System.Reflection;
using System.Windows;
using Catel.MVVM;
using Elreg.ViewModelContracts;

namespace Elreg.WpfViewModel
{
    public class SplashInfoViewModel : ViewModelBase, ISplashInfoViewModel
    {
        private bool _isInfo;
        private string _infoText;
        private string _environment;

        public SplashInfoViewModel()
        {
            
        }

        public string SplashTitle
        {
            get { return "Digital Slot Manager"; }
        }

        public string VersionText
        {
            get
            {
                string environmentInfo = string.Empty;
                if (!string.IsNullOrEmpty(Environment))
                    environmentInfo = " (" + Environment + ")";
                return "Version: " + Assembly.GetExecutingAssembly().GetName().Version + environmentInfo;                
            }
        }

        public string InfoText
        {
            get { return _infoText; }
            set
            {
                _infoText = value;
                RaisePropertyChanged(this, "InfoText");
            }
        }

        public bool IsInfo
        {
            get { return _isInfo; }
            set
            {
                _isInfo = value;
                RaisePropertyChangedEvents();
            }
        }

        public string Environment
        {
            get { return _environment; }
            set
            {
                _environment = value;
                RaisePropertyChangedEvents();
            }
        }

        public Visibility VisibilityOfButton
        {
            get
            {
                Visibility visibility = Visibility.Hidden;
                if (IsInfo)
                    visibility = Visibility.Visible;
                return visibility;
            }
        }

        public Visibility VisibilityOfInfo
        {
            get
            {
                Visibility visibility = Visibility.Visible;
                if (IsInfo)
                    visibility = Visibility.Hidden;
                return visibility;
            }
        }

        private void RaisePropertyChangedEvents()
        {
            RaisePropertyChanged(this, "InfoText");
            RaisePropertyChanged(this, "VersionText");
            RaisePropertyChanged(this, "IsInfo");
            RaisePropertyChanged(this, "Environment");
            RaisePropertyChanged(this, "VisibilityOfButton");
            RaisePropertyChanged(this, "VisibilityOfInfo");
        }
    }
}
