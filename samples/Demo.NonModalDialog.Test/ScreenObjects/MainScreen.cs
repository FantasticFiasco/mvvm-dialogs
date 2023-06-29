using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.NonModalDialog.ScreenObjects
{
    public class MainScreen : Screen
    {
        public MainScreen(Window window)
            : base(window)
        {
        }

        private Button ShowCurrentTimeUsingDialogTypeLocatorButton => ButtonByAutomationId("6U4UYFLlnUKOBx26wvyDOg");
        private Button ShowCurrentTimeBySpecifyingDialogTypeButton => ButtonByAutomationId("yp7kt1tOeEqE5y2KmylhGQ");
        
        public CurrentTimeScreen ClickShowCurrentTimeUsingDialogTypeLocator()
        {
            ShowCurrentTimeUsingDialogTypeLocatorButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Current Time");
            return new CurrentTimeScreen(dialog);
        }

        public CurrentTimeScreen ClickShowCurrentTimeBySpecifyingDialogType()
        {
            ShowCurrentTimeBySpecifyingDialogTypeButton.Click();
            Wait.UntilInputIsProcessed();

            var dialog = Window.ModalWindows.Single(w => w.Title == "Current Time");
            return new CurrentTimeScreen(dialog);
        }
    }
}
