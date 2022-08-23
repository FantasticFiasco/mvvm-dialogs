using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.CustomFolderBrowserDialog.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("RQ_N2kIsN0C39sxTonCRtA")]
        private readonly TextBox? pathTextBox = null;

        [AutomationId("TTK4W3coCE2skIHpcUe97Q")]
        private readonly Button? browseButton = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string? FileName => pathTextBox?.Text;

        public virtual BrowseFolderScreen ClickBrowse()
        {
            browseButton!.Click();
            return ScreenRepository.GetModal<BrowseFolderScreen>("Select Folder", Window, InitializeOption.NoCache);
        }
    }
}
