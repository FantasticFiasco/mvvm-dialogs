using System;
using System.Windows.Controls;
using MvvmDialogs;
using Xceed.Wpf.Toolkit;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialog : MessageBox, IWindow
    {
        public bool? DialogResult
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ContentControl Owner
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
