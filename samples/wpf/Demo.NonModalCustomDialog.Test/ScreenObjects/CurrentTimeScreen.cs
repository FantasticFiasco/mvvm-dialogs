using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.NonModalCustomDialog.ScreenObjects
{
    public class CurrentTimeScreen : AppScreen
    {
        [AutomationId("n_Mu0TdFak-4VJD8RosMEQ")]
        private readonly Label? currentTime = null;

        public CurrentTimeScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual bool CurrentTimeVisible => currentTime!.Visible;
    }
}
