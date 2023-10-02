using System.Threading;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;

namespace Demo.StaThreads;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Ioc.Default.ConfigureServices(
            new ServiceCollection()
                .AddSingleton<IDialogService, DialogService>()
                .AddTransient<MainWindowViewModel>()
                .BuildServiceProvider());

        for (var i = 0; i < 2; i++)
        {
            var windowThread = new WindowThread(i);

            var thread = new Thread(windowThread.Run);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }

    private class WindowThread
    {
        private readonly int id;

        public WindowThread(int id)
        {
            this.id = id;
        }

        public void Run()
        {
            var mainWindow = new MainWindow();
            mainWindow.Title += $" (id {id})";
            mainWindow.DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>();
            
            mainWindow.Show();

            // Let's make sure that the windows doesn't stack up on top of each other
            mainWindow.Left += 100 * id;
            mainWindow.Top += 100 * id;

            Dispatcher.Run();
        }
    }
}
