using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.SaveFileDialog.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("-u3vcUdRMUaG4Af_kzSeZQ")]
        private readonly TextBox? pathTextBox = null;

        [AutomationId("HstqC8HI9EOGiTfPA4_xag")]
        private readonly Button? saveButton = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string FileName => pathTextBox!.Text;

        public virtual SaveFileScreen ClickSave()
        {
            saveButton!.Click();
            return ScreenRepository.GetModal<SaveFileScreen>("This Is The Title", Window, InitializeOption.NoCache);
        }
    }
}
