using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Registration;
using System.Reflection;
using System.Windows;
using MvvmDialogs;
using MvvmDialogs.DialogTypeLocators;

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

            catalog.Catalogs.Add(CreateDemoApplicationCatalog());
            catalog.Catalogs.Add(CreateMvvmDialogsCatalog());
            
            return new CompositionContainer(catalog);
        }

        private static ComposablePartCatalog CreateDemoApplicationCatalog()
        {
            return new AssemblyCatalog(Assembly.GetExecutingAssembly());
        }

        private static ComposablePartCatalog CreateMvvmDialogsCatalog()
        {
            // Since MvvmDialogs doesn't use MEF attributes, we have to configure the exports
            var picker = new RegistrationBuilder();
            picker
                .ForType<DialogService>()
                .ExportInterfaces();
            picker
                .ForType<NamingConventionDialogTypeLocator>()
                .ExportInterfaces();

            return new AssemblyCatalog(Assembly.Load("MvvmDialogs"), picker);
        }
    }
}