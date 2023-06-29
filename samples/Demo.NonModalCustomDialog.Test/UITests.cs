using Demo.NonModalCustomDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.NonModalCustomDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;

        public UITests()
        {
            app = Application.Launch("Demo.NonModalCustomDialog.exe");
        }

        [Fact]
        public void ShowCurrentTimeUsingDialogTypeLocator()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Non-Modal Custom Dialog"));

            var currentTimeScreen = mainScreen.ClickShowCurrentTimeUsingDialogTypeLocator();

            Assert.True(currentTimeScreen.CurrentTimeVisible);
        }

        [Fact]
        public void ShowCurrentTimeBySpecifyingDialogType()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Non-Modal Dialog"));

            var currentTimeScreen = mainScreen.ClickShowCurrentTimeBySpecifyingDialogType();

            Assert.True(currentTimeScreen.CurrentTimeVisible);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
