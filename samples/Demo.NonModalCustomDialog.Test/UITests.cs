using Demo.NonModalCustomDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.NonModalCustomDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.NonModalCustomDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Non-Modal Custom Dialog"));
        }

        [Fact]
        public void ShowCurrentTimeUsingDialogTypeLocator()
        {
            var currentTimeScreen = mainScreen.ClickShowCurrentTimeUsingDialogTypeLocator();

            Assert.True(currentTimeScreen.CurrentTimeVisible);
        }

        [Fact]
        public void ShowCurrentTimeBySpecifyingDialogType()
        {
            var currentTimeScreen = mainScreen.ClickShowCurrentTimeBySpecifyingDialogType();

            Assert.True(currentTimeScreen.CurrentTimeVisible);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
