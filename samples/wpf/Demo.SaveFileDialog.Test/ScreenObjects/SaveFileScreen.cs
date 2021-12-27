using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Demo.SaveFileDialog.ScreenObjects
{
    public class SaveFileScreen : AppScreen
    {
        public SaveFileScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string FileName
        {
            set => Window.Get<TextBox>(SearchCriteria.ByAutomationId("1001")).Text = value;
        }

        public virtual void ClickSave()
        {
            Window.Get<Button>(SearchCriteria.ByText("Save")).Click();
        }

        public virtual void ClickCancel()
        {
            Window.Get<Button>(SearchCriteria.ByText("Cancel")).Click();
        }
    }
}
