using System.Windows;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    internal class MessageBoxShow : IMessageBoxShow
    {
        public MessageBoxResult Show(
            Window owner,
            string? messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon,
            MessageBoxResult defaultResult,
            MessageBoxOptions options) =>
            System.Windows.MessageBox.Show(
                owner,
                messageBoxText,
                caption,
                button,
                icon,
                defaultResult,
                options);
    }
}
