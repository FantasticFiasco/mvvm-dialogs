using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.FolderBrowserDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly TextBox? pathTextBox = null;

        private readonly Button? browseButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            pathTextBox = FindFirstDescendant(cf => cf.ByAutomationId("RQ_N2kIsN0C39sxTonCRtA")).AsTextBox();
            browseButton = FindFirstDescendant(cf => cf.ByAutomationId("TTK4W3coCE2skIHpcUe97Q")).AsButton();
        }

        public virtual string? FileName => pathTextBox?.Text;

        public virtual BrowseFolderScreen ClickBrowse()
        {
            browseButton!.Click();

            var title =
#if NETCOREAPP3_0_OR_GREATER
            "Select Folder"
#else
            "Browse For Folder"
#endif
            ;

            return this.WaitForModalWindow<BrowseFolderScreen>(title);
        }
    }
}
