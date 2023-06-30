using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.CustomFolderBrowserDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private TextBox PathTextBox => ElementByAutomationId<TextBox>("RQ_N2kIsN0C39sxTonCRtA");
        private Button BrowseButton => ElementByAutomationId<Button>("TTK4W3coCE2skIHpcUe97Q");

        public string FileName => PathTextBox.Text;

        public BrowseFolderScreen ClickBrowse()
        {
            BrowseButton.Click();
            Wait.UntilInputIsProcessed();

            return new BrowseFolderScreen(GetModalWindow("Select Folder"));
        }
    }
}
