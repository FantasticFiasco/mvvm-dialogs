using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Demo.MessageBox.ScreenObjects
{
    public class MessageBoxScreen : AppScreen
    {
        public MessageBoxScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public string Caption => Window.Title;

        public string Message => Window.Get<Label>(SearchCriteria.ByAutomationId("65535")).Text;

        public bool IsIconVisible => Window.Exists<Image>(SearchCriteria.ByAutomationId("20"));

        public bool IsOKButtonVisible => Window.Exists<Button>(SearchCriteria.ByText("OK"));

        public bool IsCancelButtonVisible => Window.Exists<Button>(SearchCriteria.ByText("Cancel"));

        public void ClickOK()
        {
            Window.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }

        public void ClickCancel()
        {
            Window.Get<Button>(SearchCriteria.ByText("Cancel")).Click();
        }
    }
}
