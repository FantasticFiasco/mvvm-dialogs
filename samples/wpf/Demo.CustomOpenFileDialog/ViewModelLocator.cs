using CommunityToolkit.Mvvm.DependencyInjection;

namespace Demo.CustomOpenFileDialog
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindow => Ioc.Default.GetRequiredService<MainWindowViewModel>();
    }
}
