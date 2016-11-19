using System;
using System.Windows;
using System.Windows.Controls;
using MvvmDialogs;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;

namespace Demo.ModalCustomDialog
{
    public class AddTextCustomDialog : MessageBox, IWindow
    {
        object IWindow.DataContext 
        {
            get { return DataContext; }
            set { DataContext = value; }
        }

        bool? IWindow.DialogResult { get; set; }

        ContentControl IWindow.Owner { get; set; }

        bool? IWindow.ShowDialog()
        {
            var self = (IWindow)this;

            InitializeMessageBox(
                (Window)self.Owner,
                "Add current time?",
                "Add Text",
                MessageBoxButton.OKCancel, 
                MessageBoxImage.Question, 
                MessageBoxResult.OK);

            self.DialogResult = ShowDialog();

            return self.DialogResult;
        }

        void IWindow.Show()
        {
            throw new NotSupportedException();
        }
    }
}
