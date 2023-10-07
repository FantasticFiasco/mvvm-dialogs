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
        Ioc.Default.ConfigureServices(
            new ServiceCollection()
                .AddSingleton<IDialogService, DialogService>()
                .AddTransient<MainWindowViewModel>()
                .BuildServiceProvider());

        for (var id = 0; id < 2; id++)
        {
            var windowThread = new WindowThread(id);
            
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
            
            Dispatcher.Run();
        }
    }
}
