using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomSaveFileDialog.ScreenObjects
{
    public class SaveFileScreen : Window
    {
        public SaveFileScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public virtual string FileName
        {
            set => FindFirstDescendant(cf => cf.ByAutomationId("1001")).AsTextBox().Text = value;
        }

        public virtual void ClickSave()
        {
            FindFirstDescendant(cf => cf.ByText("Save")).AsButton().Click();
        }

        public virtual void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
