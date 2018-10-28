using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Demo.CustomMessageBox.ScreenObjects
{
    public class MessageBoxScreen : AppScreen
    {
        public MessageBoxScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string Caption => Window.Title;

        public virtual bool IsOKButtonVisible => Window.Exists<Button>(SearchCriteria.ByText("OK"));

        public virtual bool IsCancelButtonVisible => Window.Exists<Button>(SearchCriteria.ByText("Cancel"));

        public virtual void ClickOK()
        {
            Window.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }

        public virtual void ClickCancel()
        {
            Window.Get<Button>(SearchCriteria.ByText("Cancel")).Click();
        }
    }
}
