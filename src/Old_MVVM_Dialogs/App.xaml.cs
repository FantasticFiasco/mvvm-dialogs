using System.Windows;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.WindowViewModelMapping;
using MVVM_Dialogs.Service;
using MVVM_Dialogs.ViewModel;
using MVVM_Dialogs.WindowViewModelMapping;

namespace MVVM_Dialogs
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure service locator
            ServiceLocator.RegisterSingleton<IDialogService, DialogService>();
            ServiceLocator.RegisterSingleton<IPersonService, PersonService>();
            ServiceLocator.RegisterSingleton<IWindowViewModelMappings, WindowViewModelMappings>();
            ServiceLocator.Register<IOpenFileDialog, OpenFileDialogViewModel>();

            // Create and show main window
            View.MainWindow view = new View.MainWindow();
            view.DataContext = new MainWindowViewModel();
            view.Show();
        }
    }
}