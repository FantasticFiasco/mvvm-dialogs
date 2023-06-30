using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.SaveFileDialog.ScreenObjects
{
    public class SaveFileScreen : Screen
    {
        public SaveFileScreen(Window window)
            : base(window)
        {
        }

        private TextBox FileNameTextBox => ElementByAutomationId<TextBox>("1001");
        private Button SaveButton => ElementByText<Button>("Save");
        private Button CancelButton => ElementByText<Button>("Cancel");

        public string FileName
        {
            set => FileNameTextBox.Text = value;
        }

        public void ClickSave()
        {
            SaveButton.Click();
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }
    }
}
