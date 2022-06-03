using FimaManager.Business.Interfaces;
using FimaManager.Common.Configs;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.WinFormsClient.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FirmaManager.WinFormsClient
{
    public partial class MainForm : Form
    {
        private readonly IPersonManager _personManager;
        private readonly INameManipulator _nameManipulator;

        public MainForm(IPersonManager personManager, INameManipulator nameManipulator)
        {
            InitializeComponent();
            _personManager = personManager;
            _nameManipulator = nameManipulator;
        }

        private void ActivateTools()
        {
            toolStripMenuPerson.Enabled = true;
        }

        private void EndApplication()
        {
            if (MessageBox.Show(Constants.DO_YOU_WANT_TO_END_APP_REQUEST, Constants.ENDING_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private bool CheckConfiguration()
        {
            try
            {
                Configurator configurator = new Configurator();
                toolStripStatusConnected.ToolTipText = configurator.ConnectionString;

                new DieFirmaContext(configurator).CheckConnection();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Constants.FAILURE_MESSAGE} {ex.Message}", Constants.FAILURE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            bool isConnected = CheckConfiguration();

            if (!isConnected)
            {
                toolStripStatusConnected.Text = Constants.NO_CONNECTION_TO_SERVER;
                toolStripStatusConnected.ForeColor = Color.Red;
            }
            else if (isConnected)
            {
                ActivateTools();
            }
        }

        private void ToolStripMenuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void ToolStripMenuPerson_Click(object sender, EventArgs e)
        {
            new PersonViewForm(_personManager, _nameManipulator).ShowDialog();
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            EndApplication();
        }

        private void ToolStripMenuEnd_Click(object sender, EventArgs e)
        {
            EndApplication();
        }
    }
}