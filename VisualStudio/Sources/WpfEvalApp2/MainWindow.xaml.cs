namespace WpfEvalApp2
{
    public partial class MainWindow
    {
        private readonly ViewModel _viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.MoveEntitiesToRight();
        }
    }
}
