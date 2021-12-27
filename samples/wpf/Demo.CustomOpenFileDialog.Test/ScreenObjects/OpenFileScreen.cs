using TestStack.White.InputDevices;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace Demo.CustomOpenFileDialog.ScreenObjects
{
    public class OpenFileScreen : AppScreen
    {
        public OpenFileScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string FileName
        {
            set => Window.Get<ComboBox>(SearchCriteria.ByAutomationId("1148")).EditableText = value;
        }

        public virtual void ClickOpen()
        {
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        public virtual void ClickCancel()
        {
            Window.Get<Button>(SearchCriteria.ByText("Cancel")).Click();
        }
    }
}
