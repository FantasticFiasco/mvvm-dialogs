using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;

namespace Demo.MessageBox
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
        }
    }
}