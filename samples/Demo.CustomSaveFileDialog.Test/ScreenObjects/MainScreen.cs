using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.CustomSaveFileDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private TextBox PathTextBox => ElementByAutomationId<TextBox>("-u3vcUdRMUaG4Af_kzSeZQ");
        private Button SaveButton => ElementByAutomationId<Button>("HstqC8HI9EOGiTfPA4_xag");

        public string FileName
        {
            get => PathTextBox.Text;
        }

        public SaveFileScreen ClickSave()
        {
            SaveButton.Click();
            Wait.UntilInputIsProcessed();

            return new SaveFileScreen(GetModalWindow("This Is The Title"));
        }
    }
}
