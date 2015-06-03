using System.Reflection;
using System.Windows;
using Autofac;
using MvvmDialogs;

namespace DemoApplication
{
    public partial class App
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            container = CreateContainer();
            
            var window = container.Resolve<MainWindow>();
            var viewModel = container.Resolve<MainWindowViewModel>();

            window.DataContext = viewModel;
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            container.Dispose();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsSelf();

            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<TabItemViewModel>()
                .As<TabItemViewModel>();

            builder
                .RegisterType<DialogService>()
                .AsImplementedInterfaces()
                .SingleInstance();
            
            return builder.Build();
        }
    }
}