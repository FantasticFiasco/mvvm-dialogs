using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomFolderBrowserDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly TextBox? pathTextBox = null;

        private readonly Button? browseButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            browseButton = FindFirstDescendant(cf => cf.ByAutomationId("TTK4W3coCE2skIHpcUe97Q")).AsButton();
            pathTextBox = FindFirstDescendant(cf => cf.ByAutomationId("RQ_N2kIsN0C39sxTonCRtA")).AsTextBox();
        }

        public virtual string? FileName => pathTextBox?.Text;

        public virtual BrowseFolderScreen ClickBrowse()
        {
            browseButton!.Click();
            return this.WaitForModalWindow<BrowseFolderScreen>("Select Folder"/*, Window, InitializeOption.NoCache*/);
        }
    }
}
