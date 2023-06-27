using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.SaveFileDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private TextBox PathTextBox => TextBoxByAutomationId("-u3vcUdRMUaG4Af_kzSeZQ");
        private Button? SaveButton => ButtonByAutomationId("HstqC8HI9EOGiTfPA4_xag");

        public string FileName => PathTextBox!.Text;

        public SaveFileScreen ClickSave()
        {
            SaveButton!.Click();
            Wait.UntilInputIsProcessed();

            return new SaveFileScreen(Window.ModalWindows.Single(w => w.Title == "This Is The Title"));
        }
    }
}
