using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.MessageBox.ScreenObjects
{
    public class MessageBoxScreen : Screen
    {
        public MessageBoxScreen(Window window)
            : base(window)
        {
        }

        private Label MessageLabel => ElementByAutomationId<Label>("65535");
        private Button OKButton => ElementByText<Button>("OK");
        private Button CancelButton => ElementByText<Button>("Cancel");


        public string Caption => Window.Title;

        public string Message => MessageLabel.Text;

        public bool IsIconVisible => throw new NotImplementedException();
        //public bool IsIconVisible => Window.Exists<Image>(SearchCriteria.ByAutomationId("20"));

        public bool IsOKButtonVisible => throw new NotImplementedException();

        public bool IsCancelButtonVisible => throw new NotImplementedException();

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
