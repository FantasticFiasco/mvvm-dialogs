using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.FolderBrowserDialog.ScreenObjects
{
    public class BrowseFolderScreen : Screen
    {
        public BrowseFolderScreen(Window window)
            : base(window)
        {
        }

        public void ClickOK()
        {
            OKButton.Click();
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }
    }
}
