using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;

namespace Demo.CustomOpenFileDialog
{
    public partial class App
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
