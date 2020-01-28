using System.Windows;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    internal interface IMessageBoxShow
    {
        MessageBoxResult Show(
            Window owner,
            string? messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon,
            MessageBoxResult defaultResult,
            MessageBoxOptions options);
    }
}
