using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.NonModalCustomDialog.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("6U4UYFLlnUKOBx26wvyDOg")]
        private readonly Button? showCurrentTimeUsingDialogTypeLocatorButton = null;

        [AutomationId("yp7kt1tOeEqE5y2KmylhGQ")]
        private readonly Button? showCurrentTimeBySpecifyingDialogTypeButton = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual CurrentTimeScreen ClickShowCurrentTimeUsingDialogTypeLocator()
        {
            showCurrentTimeUsingDialogTypeLocatorButton!.Click();
            return ScreenRepository.GetModal<CurrentTimeScreen>("Current Time", Window, InitializeOption.NoCache);
        }

        public virtual CurrentTimeScreen ClickShowCurrentTimeBySpecifyingDialogType()
        {
            showCurrentTimeBySpecifyingDialogTypeButton!.Click();
            return ScreenRepository.GetModal<CurrentTimeScreen>("Current Time", Window, InitializeOption.NoCache);
        }
    }
}
