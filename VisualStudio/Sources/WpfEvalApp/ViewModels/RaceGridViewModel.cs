namespace Elreg.WpfEvalApp.ViewModels
{
    public class RaceGridViewModel
    {
        private readonly PositionsViewModel _positionsViewModel = new PositionsViewModel();

        public RaceGridViewModel()
        {
            HeaderHeight = 75;
        }

        public PositionsViewModel PositionsViewModel
        {
            get { return _positionsViewModel; }
        }

        public void GoOnCar1()
        {
            PositionsViewModel.LaneCars[0].Laps += 0.2;
            PositionsViewModel.CalcCarXPercentages();
        }

        public void GoOnCar2()
        {
            PositionsViewModel.LaneCars[1].Laps += 0.1;
            PositionsViewModel.CalcCarXPercentages();
        }

        public void GoOnCar3()
        {
            PositionsViewModel.LaneCars[2].Laps += 0.1;
            PositionsViewModel.CalcCarXPercentages();
        }

        public double HeaderHeight { get; set; }
    }
}
