using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.MessageBox.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private Button MessageBoxWithMessageButton => ElementByAutomationId<Button>("1k7d1Nm8MkOYK5qGrdVX4Q");
        private Button MessageBoxWithCaptionButton => ElementByAutomationId<Button>("EvNqZT9tYkuNzKDDrLJ8Yw");
        private Button MessageBoxWithButtonsButton => ElementByAutomationId<Button>("FWGzBkom5ESJz_p7KCPKqQ");
        private Button MessageBoxWithIconButton => ElementByAutomationId<Button>("SapYi2J7bkiJ1z1GWwOZAQ");
        private Button MessageBoxWithDefaultResultButton => ElementByAutomationId<Button>("sUjm2_m1LUGWso8S2Us5ow");
        private Label ConfirmationLabel => ElementByAutomationId<Label>("kT3_ZUZfsEK1QdZ2jBfuIQ");

        public string Confirmation => ConfirmationLabel.Text;

        public MessageBoxScreen ClickMessageBoxWithMessage()
        {
            MessageBoxWithMessageButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == string.Empty);
            return new MessageBoxScreen(dialog);
        }

        public MessageBoxScreen ClickMessageBoxWithCaption()
        {
            MessageBoxWithCaptionButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "This Is The Caption");
            return new MessageBoxScreen(dialog);
        }

        public MessageBoxScreen ClickMessageBoxWithButtons()
        {
            MessageBoxWithButtonsButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "This Is The Caption");
            return new MessageBoxScreen(dialog);
        }

        public MessageBoxScreen ClickMessageBoxWithIcon()
        {
            MessageBoxWithIconButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "This Is The Caption");
            return new MessageBoxScreen(dialog);
        }

        public MessageBoxScreen ClickMessageBoxWithDefaultResult()
        {
            MessageBoxWithDefaultResultButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "This Is The Caption");
            return new MessageBoxScreen(dialog);
        }
    }
}
