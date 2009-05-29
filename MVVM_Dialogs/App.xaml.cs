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

			// Create and show main window
			View.MainWindow view = new View.MainWindow();
			view.DataContext = new MainWindowViewModel(DialogService.Instance);
			view.Show();
		}
	}
}
