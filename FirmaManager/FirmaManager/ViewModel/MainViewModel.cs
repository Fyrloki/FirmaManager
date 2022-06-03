using FirmaManager.Model;
using FirmaManager.Common;
using System.Windows.Input;
using FirmaManager.Command;
using System.Windows;
using FirmaManager.View;
using FimaManager.Common.Configs;
using FimaManager.Common;
using FimaManager.Business;
using FirmaManager.EntityFrameworkData.Repositories;
using FirmaManager.StaticObjects;
using System;

namespace FirmaManager.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ConnectionTestModel _connectionTestModel;

        public MainViewModel()
        {
            StaticObjectCollector.PersonManager = new PersonManager(new PersonModelReadRepository(), new PersonModelWriteRepository());

            _connectionTestModel = new ConnectionTestModel();

            if (!WasConnectionSuccessful)
            {
                MessageBox.Show(_connectionTestModel.FailureMessage, Constants.CONNECTIONPROBLEM_CAPTION, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            EndApplicationCommand = new RelayCommand(
                (s) =>
                {
                    if (MessageBox.Show(Constants.DO_YOU_WANT_TO_END_APP_REQUEST, Constants.ENDING_TITLE, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    {
                        CloseWindow();
                    }
                });

            OpenPersonViewCommand = new RelayCommand(
                (s) => new PersonOverviewWindow().ShowDialog(),
                (s) => WasConnectionSuccessful);
        }

        public ICommand OpenPersonViewCommand { get; private set; }

        public ICommand EndApplicationCommand { get; private set; }

        public bool WasConnectionSuccessful => _connectionTestModel.WasConnectionSuccessful;

        public static string ConnectionString => Configurator.Connectionstring;
    }
}