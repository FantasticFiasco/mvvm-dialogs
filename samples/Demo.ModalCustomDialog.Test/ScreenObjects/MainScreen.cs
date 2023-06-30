using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.ModalCustomDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private ListBox TextsListBox => ElementByAutomationId<ListBox>("Vfkrmkr640yWmoMTKUWIbQ");
        private Button AddTextUsingDialogTypeLocatorButton => ElementByAutomationId<Button>("FHE_oyWqBEq_9TPaU1yPTQ");
        private Button AddTextBySpecifyingDialogTypeButton => ElementByAutomationId<Button>("Dq9ZjnVdFESxu8StkQ8jMw");


        public IEnumerable<string> Texts
        {
            get { return TextsListBox.Items.Select(item => item.Text); }
        }

        public AddTextScreen ClickAddTextUsingDialogTypeLocator()
        {
            AddTextUsingDialogTypeLocatorButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Add Text");
            return new AddTextScreen(dialog);
        }

        public AddTextScreen ClickAddTextBySpecifyingDialogType()
        {
            AddTextBySpecifyingDialogTypeButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Add Text");
            return new AddTextScreen(dialog);
        }
    }
}
