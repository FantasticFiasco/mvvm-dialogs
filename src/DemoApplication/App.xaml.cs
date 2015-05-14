using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Windows;
using DemoApplication.View;
using DemoApplication.ViewModel;
using MvvmDialogs;
using MvvmDialogs.DialogLocators;

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
            var catalog = new AggregateCatalog();

            // MvvmDialogs assembly
            var picker = new RegistrationBuilder();
            picker
                .ForType<NameConventionDialogTypeLocator>()
                .Export<IDialogTypeLocator>();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(DialogService).Assembly, picker));

            // This assembly
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            
            return new CompositionContainer(catalog);
        }
    }
}