using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.CustomFolderBrowserDialog.ScreenObjects
{
    public class BrowseFolderScreen : Screen
    {
        public BrowseFolderScreen(Window window)
            : base(window)
        {
        }

        private Button SelectFolderButton => ElementByText<Button>("Select Folder");

        public void ClickSelectFolder()
        {
            SelectFolderButton.Click();
        }

        public void ClickCancel()
        {
            DefaultCancelButton.Click();
        }
    }
}
