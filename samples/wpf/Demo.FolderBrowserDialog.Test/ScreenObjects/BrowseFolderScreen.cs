using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.FolderBrowserDialog.ScreenObjects
{
    public class BrowseFolderScreen : Window
    {
        public BrowseFolderScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public virtual void ClickOK()
        {
            var okText =
#if NETCOREAPP3_0_OR_GREATER
            "Select Folder"
#else
            "OK"
#endif
            ;
            FindFirstDescendant(cf => cf.ByText(okText)).AsButton().Click();
        }

        public virtual void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
