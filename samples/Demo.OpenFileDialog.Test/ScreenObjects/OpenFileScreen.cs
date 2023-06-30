using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using TestBaseClasses;

namespace Demo.OpenFileDialog.ScreenObjects
{
    public class OpenFileScreen : Screen
    {
        public OpenFileScreen(Window window)
            : base(window)
        {
        }

        private Button CancelButton => ButtonByText("Cancel");
        private ComboBox FileNameComboBox => ComboBoxByAutomationId("1148");

        public string FileName
        {
            set => FileNameComboBox.EditableText = value;
        }

        public void ClickOpen()
        {
            Keyboard.Press(VirtualKeyShort.ENTER);
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }
    }
}
