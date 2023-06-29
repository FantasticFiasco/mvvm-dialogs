using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.ModalDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private ListBox TextsListBox => ListBoxByAutomationId("Vfkrmkr640yWmoMTKUWIbQ");
        private Button AddTextUsingDialogTypeLocatorButton => ButtonByAutomationId("FHE_oyWqBEq_9TPaU1yPTQ");
        private Button AddTextBySpecifyingDialogTypeButton => ButtonByAutomationId("Dq9ZjnVdFESxu8StkQ8jMw");

        public virtual IEnumerable<string> Texts
        {
            get { return TextsListBox.Items.Select(item => item.Text); }
        }

        public virtual AddTextScreen ClickAddTextUsingDialogTypeLocator()
        {
            AddTextUsingDialogTypeLocatorButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Add Text");
            return new AddTextScreen(dialog);
        }

        public virtual AddTextScreen ClickAddTextBySpecifyingDialogType()
        {
            AddTextBySpecifyingDialogTypeButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Add Text");
            return new AddTextScreen(dialog);
        }
    }
}
