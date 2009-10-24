using System.Windows;
using MVVM_Dialogs.Service;
using MVVM_Dialogs.ViewModel;

namespace MVVM_Dialogs
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			// Configure service locator
			ServiceLocator.Add<IDialogService>(new DialogService());
			ServiceLocator.Add<IPersonService>(new PersonService());

			// Create and show main window
			View.MainWindow view = new View.MainWindow();
			view.DataContext = new MainWindowViewModel();
			view.Show();
		}
	}
}
