using System.Windows;
using Elreg.WpfEvalApp.ViewModels;

namespace Elreg.WpfEvalApp.Views
{
    public partial class RaceGridView2
    {
        readonly RaceGridViewModel _raceGridViewModel = new RaceGridViewModel();

        public RaceGridView2()
        {
            InitializeComponent();
            DataContext = _raceGridViewModel;
        }

        private void ButtonCar1Click(object sender, RoutedEventArgs e)
        {
            _raceGridViewModel.GoOnCar1();
        }

        private void ButtonCar2Click(object sender, RoutedEventArgs e)
        {
            _raceGridViewModel.GoOnCar2();
        }

        private void ButtonCar3Click(object sender, RoutedEventArgs e)
        {
            _raceGridViewModel.GoOnCar3();
        }

    }
}
