using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.NonModalDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly Button? showCurrentTimeUsingDialogTypeLocatorButton = null;

        private readonly Button? showCurrentTimeBySpecifyingDialogTypeButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            showCurrentTimeUsingDialogTypeLocatorButton = FindFirstDescendant(cf => cf.ByAutomationId("6U4UYFLlnUKOBx26wvyDOg")).AsButton();
            showCurrentTimeBySpecifyingDialogTypeButton = FindFirstDescendant(cf => cf.ByAutomationId("yp7kt1tOeEqE5y2KmylhGQ")).AsButton();
        }

        public virtual CurrentTimeScreen ClickShowCurrentTimeUsingDialogTypeLocator()
        {
            showCurrentTimeUsingDialogTypeLocatorButton!.Click();
            return this.GetChildWindow<CurrentTimeScreen>("Current Time")!;
        }

        public virtual CurrentTimeScreen ClickShowCurrentTimeBySpecifyingDialogType()
        {
            showCurrentTimeBySpecifyingDialogTypeButton!.Click();
            return this.GetChildWindow<CurrentTimeScreen>("Current Time")!;
        }
    }
}
