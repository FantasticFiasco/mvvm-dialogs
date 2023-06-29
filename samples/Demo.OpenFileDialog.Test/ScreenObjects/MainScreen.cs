using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.OpenFileDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private TextBox PathTextBox => TextBoxByAutomationId("cqkeItgI3UaZc-mQ6mYPAA");
        private Button OpenButton => ButtonByAutomationId("MZ16xHTzYE2UP8S9vd-EGw");

        public string FileName => PathTextBox.Text;
        
        public virtual OpenFileScreen ClickOpen()
        {
            OpenButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "This Is The Title");
            return new OpenFileScreen(dialog);
        }
    }
}
