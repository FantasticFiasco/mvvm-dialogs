using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomMessageBox.ScreenObjects
{
    public class MessageBoxScreen : Window
    {
        public MessageBoxScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public virtual string Caption => Title;

        public virtual bool IsOKButtonVisible => FindFirstDescendant(cf => cf.ByText("OK"))?.AsButton() != null;

        public virtual bool IsCancelButtonVisible => FindFirstDescendant(cf => cf.ByText("Cancel"))?.AsButton() != null;

        public virtual void ClickOK()
        {
            FindFirstDescendant(cf => cf.ByText("OK")).AsButton().Click();
        }

        public virtual void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
