using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.CustomOpenFileDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private TextBox PathTextBox => ElementByAutomationId<TextBox>("cqkeItgI3UaZc-mQ6mYPAA");
        private Button OpenButton => ElementByAutomationId<Button>("MZ16xHTzYE2UP8S9vd-EGw");

        public string FileName => PathTextBox.Text;

        public OpenFileScreen ClickOpen()
        {
            OpenButton.Click();
            Wait.UntilInputIsProcessed();

            return new OpenFileScreen(GetModalWindow("This Is The Title"));
        }
    }
}
