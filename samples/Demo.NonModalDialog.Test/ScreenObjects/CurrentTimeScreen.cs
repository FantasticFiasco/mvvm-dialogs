using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.NonModalDialog.ScreenObjects
{
    public class CurrentTimeScreen : Screen
    {
        public CurrentTimeScreen(Window window)
            : base(window)
        {
        }

        private Label CurrentTimeLabel => ElementByAutomationId<Label>("n_Mu0TdFak-4VJD8RosMEQ");

        public bool CurrentTimeVisible => !CurrentTimeLabel.IsOffscreen;
    }
}
