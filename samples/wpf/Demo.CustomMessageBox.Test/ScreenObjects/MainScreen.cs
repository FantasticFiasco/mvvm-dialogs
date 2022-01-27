using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomMessageBox.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly Button? messageBoxWithMessageButton = null;

        private readonly Button? messageBoxWithCaptionButton = null;

        private readonly Button? messageBoxWithButtonsButton = null;

        private readonly Button? messageBoxWithIconButton = null;

        private readonly Button? messageBoxWithDefaultResultButton = null;

        private readonly Label? confirmation = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            messageBoxWithMessageButton = FindFirstDescendant(cf => cf.ByAutomationId("1k7d1Nm8MkOYK5qGrdVX4Q")).AsButton();
            messageBoxWithCaptionButton = FindFirstDescendant(cf => cf.ByAutomationId("EvNqZT9tYkuNzKDDrLJ8Yw")).AsButton();
            messageBoxWithButtonsButton = FindFirstDescendant(cf => cf.ByAutomationId("FWGzBkom5ESJz_p7KCPKqQ")).AsButton();
            messageBoxWithIconButton = FindFirstDescendant(cf => cf.ByAutomationId("SapYi2J7bkiJ1z1GWwOZAQ")).AsButton();
            messageBoxWithDefaultResultButton = FindFirstDescendant(cf => cf.ByAutomationId("sUjm2_m1LUGWso8S2Us5ow")).AsButton();
            confirmation = FindFirstDescendant(cf => cf.ByAutomationId("kT3_ZUZfsEK1QdZ2jBfuIQ")).AsLabel();
        }

        public virtual string? Confirmation => confirmation?.Text;

        public virtual MessageBoxScreen ClickMessageBoxWithMessage()
        {
            messageBoxWithMessageButton!.Click();
            return this.GetModal<MessageBoxScreen>(" ");
        }

        public virtual MessageBoxScreen ClickMessageBoxWithCaption()
        {
            messageBoxWithCaptionButton!.Click();
            return this.GetModal<MessageBoxScreen>("This Is The Caption");
        }

        public virtual MessageBoxScreen ClickMessageBoxWithButtons()
        {
            messageBoxWithButtonsButton!.Click();
            return this.GetModal<MessageBoxScreen>("This Is The Caption");
        }

        public virtual MessageBoxScreen ClickMessageBoxWithIcon()
        {
            messageBoxWithIconButton!.Click();
            return this.GetModal<MessageBoxScreen>("This Is The Caption");
        }

        public virtual MessageBoxScreen ClickMessageBoxWithDefaultResult()
        {
            messageBoxWithDefaultResultButton!.Click();
            return this.GetModal<MessageBoxScreen>("This Is The Caption");
        }
    }
}
