using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.MessageBox.ScreenObjects
{
    public class MessageBoxScreen : Window
    {
        public MessageBoxScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public string Caption => Title;

        public string Message => FindFirstDescendant(cf => cf.ByAutomationId("65535")).AsLabel().Text;

        public bool IsIconVisible => FindFirstDescendant(cf => cf.ByAutomationId("20")) != null;

        public bool IsOKButtonVisible => FindFirstDescendant(cf => cf.ByText("OK"))?.AsButton() != null;

        public bool IsCancelButtonVisible => FindFirstDescendant(cf => cf.ByText("Cancel"))?.AsButton() != null;

        public void ClickOK()
        {
            FindFirstDescendant(cf => cf.ByText("OK")).AsButton().Click();
        }

        public void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
