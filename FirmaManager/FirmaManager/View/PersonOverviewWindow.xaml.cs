using FirmaManager.ViewModel;
using System.Windows;

namespace FirmaManager.View
{
    /// <summary>
    /// Interaction logic for PersonOverviewWindow.xaml
    /// </summary>
    public partial class PersonOverviewWindow : Window
    {
        public PersonOverviewWindow()
        {
            InitializeComponent();

            var viewModel = DataContext as PersonOverviewViewModel;
            viewModel.OnRequestClose += (s, e) => Close();
        }
    }
}