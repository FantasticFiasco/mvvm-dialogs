using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.OpenFileDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly TextBox? pathTextBox = null;

        private readonly Button? openButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            pathTextBox = FindFirstDescendant(cf => cf.ByAutomationId("cqkeItgI3UaZc-mQ6mYPAA")).AsTextBox();
            openButton = FindFirstDescendant(cf => cf.ByAutomationId("MZ16xHTzYE2UP8S9vd-EGw")).AsButton();
        }

        public virtual string? FileName => pathTextBox?.Text;

        public virtual OpenFileScreen ClickOpen()
        {
            openButton!.Click();
            return this.GetModal<OpenFileScreen>("This Is The Title");
        }
    }
}
