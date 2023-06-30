using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.CustomSaveFileDialog.ScreenObjects
{
    public class SaveFileScreen : Screen
    {
        public SaveFileScreen(Window window)
            : base(window)
        {
        }

        private TextBox FileNameTextBox => ElementByAutomationId<TextBox>("1001");
        
        public string FileName
        {
            set => FileNameTextBox.Text = value;
        }

        public void ClickSave()
        {
            DefaultSaveButton.Click();
        }

        public void ClickCancel()
        {
            DefaultCancelButton.Click();
        }
    }
}
