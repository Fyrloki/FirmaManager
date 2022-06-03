using FirmaManager.ViewModel;
using System.Windows;

namespace FirmaManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = DataContext as MainViewModel;
            viewModel.OnRequestClose += (s, e) => Close();
        }
    }
}
