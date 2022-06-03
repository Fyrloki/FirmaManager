using System.Windows.Forms;

namespace FirmaManager.WinFormsClient
{
    public class MessageBoxDisplayer
    {
        internal static DialogResult ShowYesNoQuestion(string message, string title) => MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}