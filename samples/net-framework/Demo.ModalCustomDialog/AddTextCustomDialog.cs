using System.Windows;
using System.Windows.Controls;
using MvvmDialogs;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialog : IWindow
    {
        private readonly AddTextDialog dialog;

        public AddTextCustomDialog()
        {
            dialog = new AddTextDialog();
        }

        object IWindow.DataContext
        {
            get => dialog.DataContext;
            set => dialog.DataContext = value;
        }

        bool? IWindow.DialogResult
        {
            get => dialog.DialogResult;
            set => dialog.DialogResult = value;
        }

        ContentControl IWindow.Owner
        {
            get => dialog.Owner;
            set => dialog.Owner = (Window)value;
        }

        bool? IWindow.ShowDialog()
        {
            return dialog.ShowDialog();
        }

        void IWindow.Show()
        {
            dialog.Show();
        }
    }
}
