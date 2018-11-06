using System.Windows;

namespace Heinzman.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RaceDebugWindow : Window
    {
        public RaceDebugWindow()
        {
            InitializeComponent();
        }

        public void SetDataContext(object dataContext)
        {
            DataContext = dataContext;
        }
    }
}
