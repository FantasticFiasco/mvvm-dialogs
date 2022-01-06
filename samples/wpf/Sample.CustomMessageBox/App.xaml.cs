using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;

namespace Sample.CustomMessageBox
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IDialogService>(_ => new DialogService(frameworkDialogFactory: new CustomFrameworkDialogFactory()))
                    .AddTransient<MainWindowViewModel>()
                    .BuildServiceProvider());
        }
    }
}
