using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using DemoApplication.View;
using DemoApplication.ViewModel;
using MvvmDialogs;

namespace DemoApplication
{
    public partial class App
    {
        private CompositionContainer container;

        [Import]
        private MainWindow view;

        [Import]
        private MainWindowViewModel viewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            container = CreateContainer();
            container.SatisfyImportsOnce(this);

            view.DataContext = viewModel;
            view.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            container.Dispose();
        }

        private static CompositionContainer CreateContainer()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DialogService).Assembly));

            return new CompositionContainer(catalog);
        }
    }
}