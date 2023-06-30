using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.CustomMessageBox.ScreenObjects
{
    public class MessageBoxScreen : Screen
    {
        public MessageBoxScreen(Window window)
            : base(window)
        {
        }

        public string Caption => Window.Title;

        public bool IsOKButtonVisible => DefaultOKButton != null;

        public bool IsCancelButtonVisible => DefaultCancelButton != null;

        public void ClickOK()
        {
            DefaultOKButton.Click();
        }

        public void ClickCancel()
        {
            DefaultCancelButton.Click();
        }
    }
}
