using System;
using System.Windows;
using Catel.Logging;

namespace Heinzman.WpfView.CommonXamls
{
    public partial class SplashInfoWindow 
    {
        public SplashInfoWindow()
        {
            InitializeComponent();
            SetMinMaxSize();
        }

        private void SetMinMaxSize()
        {
            const int heightToReduce =20;
            MinWidth = Width;
            MinHeight = Height - heightToReduce;
            MaxWidth = Width;
            MaxHeight = Height - heightToReduce;
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
            }
        }
    }
}
