using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.ModalCustomDialog.ScreenObjects
{
    public class AddTextScreen : Screen
    {
        public AddTextScreen(Window window)
            : base(window)
        {
        }

        private TextBox TextTextBox => ElementByAutomationId<TextBox>("Csl8dP93gUGQLj7rVZxDAg");
        
        public string Text
        {
            set => TextTextBox.Text = value;
        }

        public void ClickOK()
        {
            DefaultOKButton.Click();
        }

        public void ClickCancel()
        {
            DefaultCancelButton.Click();
        }
    }
}
