using GalaSoft.MvvmLight.Ioc;

namespace Demo.NonModalDialog
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<CurrentTimeDialogViewModel>();
        }

        public MainWindowViewModel MainWindow => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}
