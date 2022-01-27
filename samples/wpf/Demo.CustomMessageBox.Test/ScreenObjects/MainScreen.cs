using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.CustomMessageBox.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("1k7d1Nm8MkOYK5qGrdVX4Q")]
        private readonly Button? messageBoxWithMessageButton = null;

        [AutomationId("EvNqZT9tYkuNzKDDrLJ8Yw")]
        private readonly Button? messageBoxWithCaptionButton = null;

        [AutomationId("FWGzBkom5ESJz_p7KCPKqQ")]
        private readonly Button? messageBoxWithButtonsButton = null;

        [AutomationId("SapYi2J7bkiJ1z1GWwOZAQ")]
        private readonly Button? messageBoxWithIconButton = null;

        [AutomationId("sUjm2_m1LUGWso8S2Us5ow")]
        private readonly Button? messageBoxWithDefaultResultButton = null;

        [AutomationId("kT3_ZUZfsEK1QdZ2jBfuIQ")]
        private readonly Label? confirmation = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string? Confirmation => confirmation?.Text;

        public virtual MessageBoxScreen ClickMessageBoxWithMessage()
        {
            messageBoxWithMessageButton!.Click();
            return ScreenRepository.GetModal<MessageBoxScreen>(" ", Window, InitializeOption.NoCache);
        }

        public virtual MessageBoxScreen ClickMessageBoxWithCaption()
        {
            messageBoxWithCaptionButton!.Click();
            return ScreenRepository.GetModal<MessageBoxScreen>("This Is The Caption", Window, InitializeOption.NoCache);
        }

        public virtual MessageBoxScreen ClickMessageBoxWithButtons()
        {
            messageBoxWithButtonsButton!.Click();
            return ScreenRepository.GetModal<MessageBoxScreen>("This Is The Caption", Window, InitializeOption.NoCache);
        }

        public virtual MessageBoxScreen ClickMessageBoxWithIcon()
        {
            messageBoxWithIconButton!.Click();
            return ScreenRepository.GetModal<MessageBoxScreen>("This Is The Caption", Window, InitializeOption.NoCache);
        }

        public virtual MessageBoxScreen ClickMessageBoxWithDefaultResult()
        {
            messageBoxWithDefaultResultButton!.Click();
            return ScreenRepository.GetModal<MessageBoxScreen>("This Is The Caption", Window, InitializeOption.NoCache);
        }
    }
}
