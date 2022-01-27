using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomFolderBrowserDialog.ScreenObjects
{
    public class BrowseFolderScreen : Window
    {
        public BrowseFolderScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public virtual void ClickSelectFolder()
        {
            FindFirstDescendant(cf => cf.ByText("Select Folder")).AsButton().Click();
        }

        public virtual void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
