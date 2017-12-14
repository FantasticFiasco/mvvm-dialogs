using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.MessageBox;

namespace Demo.CustomMessageBox
{
    public class CustomFrameworkDialogFactory : DefaultFrameworkDialogFactory
    {
        public override IMessageBox CreateMessageBox(MessageBoxSettings settings)
        {
            return new CustomMessageBox(settings);
        }
    }
}
