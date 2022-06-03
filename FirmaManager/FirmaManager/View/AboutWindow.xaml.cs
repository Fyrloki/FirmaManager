using FirmaManager.Common;
using FirmaManager.ViewModel;
using System;
using System.Windows;

namespace FirmaManager.View
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        private readonly Guid? _guid;

        public CreatePersonWindow() : this(null) { }

        public CreatePersonWindow(Guid? guid)
        {
            IsWindowClosing = false;
            _guid = guid;

            InitializeComponent();


            var viewModel = DataContext as CreatePersonViewModel;
            viewModel.OnRequestClose += (s, e) => CloseWinow();

            if (_guid != null)
            {
                viewModel.PrepareWindowForUpdate((Guid)_guid);
            }
            else
            {
                viewModel.PrepareWindowForCreate();
            }
        }

        private void CloseWinow()
        {
            IsWindowClosing = true;
            Close();
        }

        public bool IsWindowClosing { get; private set; }
    }
}