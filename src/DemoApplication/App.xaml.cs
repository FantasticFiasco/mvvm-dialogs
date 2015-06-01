using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using MefContrib.Hosting;
using MvvmDialogs;

namespace DemoApplication
{
    public partial class App
    {
        private CompositionContainer container;

        [Import]
        public MainWindow View;

        [Import]
        public  MainWindowViewModel ViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            container = CreateContainer();
            container.SatisfyImportsOnce(this);

            View.DataContext = ViewModel;
            View.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            container.Dispose();
        }

        private static CompositionContainer CreateContainer()
        {
            var executingAssemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            
            var dialogServiceProvider = new FactoryExportProvider()
                .RegisterInstance<IDialogService>(_ => new DialogService());

            return new CompositionContainer(executingAssemblyCatalog, dialogServiceProvider);
        }
    }
}