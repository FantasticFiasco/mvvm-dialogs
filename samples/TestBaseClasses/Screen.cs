using FlaUI.Core.AutomationElements;

namespace TestBaseClasses
{
    public abstract class Screen
    {
        protected readonly Window Window;

        protected Screen(Window window)
        {
            Window = window;
        }

        protected Button DefaultOKButton
        {
            get => ElementByText<Button>("OK");
        }

        protected Button DefaultSaveButton
        {
            get => ElementByText<Button>("Save");
        }

        protected Button DefaultCancelButton
        {
            get => ElementByText<Button>("Cancel");
        }

        protected T ElementByAutomationId<T>(string automationId) where T : AutomationElement
        {
            return Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).As<T>();
        }

        protected T ElementByText<T>(string text) where T : AutomationElement
        {
            return Window.FindFirstDescendant(cf => cf.ByText(text)).As<T>();
        }

        protected Window GetModalWindow(string title)
        {
            return Window.ModalWindows.Single(w => w.Title == title);
        }
    }
}
