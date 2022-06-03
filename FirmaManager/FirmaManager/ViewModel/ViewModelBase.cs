using System;

namespace FirmaManager.ViewModel
{
    public class ViewModelBase
    {
        public event EventHandler OnRequestClose;

        public void CloseWindow()
        {
            OnRequestClose(this, new EventArgs());
        }
    }
}