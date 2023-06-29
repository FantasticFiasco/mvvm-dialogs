using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.ModalDialog.ScreenObjects
{
    public class AddTextScreen : Screen
    {
        public AddTextScreen(Window window)
            : base(window)
        {
        }

        private TextBox TextTextBox => TextBoxByAutomationId("Csl8dP93gUGQLj7rVZxDAg");
        private Button OKButton => ButtonByAutomationId("eyRW_87u20qR7QTCypm2RQ");
        private Button CancelButton => ButtonByAutomationId("I91auHr_EECzhSZyIfvvzQ");

        public virtual string Text
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
