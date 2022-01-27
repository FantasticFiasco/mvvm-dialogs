using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.OpenFileDialog.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("cqkeItgI3UaZc-mQ6mYPAA")]
        private readonly TextBox? pathTextBox = null;

        [AutomationId("MZ16xHTzYE2UP8S9vd-EGw")]
        private readonly Button? openButton = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string FileName => pathTextBox!.Text;

        public virtual OpenFileScreen ClickOpen()
        {
            openButton!.Click();
            return ScreenRepository.GetModal<OpenFileScreen>("This Is The Title", Window, InitializeOption.NoCache);
        }
    }
}
