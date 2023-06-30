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
        private Button OKButton => ElementByAutomationId<Button>("eyRW_87u20qR7QTCypm2RQ");
        private Button CancelButton => ElementByAutomationId<Button>("I91auHr_EECzhSZyIfvvzQ");

        public string Text
        {
            set => TextTextBox.Text = value;
        }

        public void ClickOK()
        {
            OKButton.Click();
        }

        public void ClickCancel()
        {
            CancelButton.Click();
        }
    }
}
