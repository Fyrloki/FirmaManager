using FimaManager.Business.Interfaces;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Repositories;
using FirmaManager.EntityFrameworkData.Repositories.Interfaces;
using System;
using System.Windows.Forms;
using FirmaManager.WinFormsClient.Interfaces;
using FimaManager.Business;

namespace FirmaManager.WinFormsClient
{
    public static class Program
    {
        public readonly static INameManipulator _nameManipulator = new NameManipulator();
        private readonly static IPersonModelReadRepository _personModelreadRepository = new PersonModelReadRepository();
        private readonly static IPersonModelWriteRepository _personModelWriteRepositority = new PersonModelWriteRepository();
        public readonly static IPersonManager _personManager = new PersonManager(_personModelreadRepository, _personModelWriteRepositority);
        public static MainForm _mainForm = new MainForm(_personManager, _nameManipulator);

        public static IServiceProvider ServiceProvider { get; set; }

        [STAThread]
        public static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(_mainForm);
            }
            catch(Exception e)
            {
                MessageBox.Show(Constants.EXCEPTION_MESSAGE_FOR_USER + e.Message, Constants.EXCEPTION_TITLE_MESSAGEBOX, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}