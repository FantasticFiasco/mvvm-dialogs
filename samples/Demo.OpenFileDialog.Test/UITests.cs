using Demo.OpenFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.OpenFileDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;

        public UITests()
        {
            app = Application.Launch("Demo.OpenFileDialog.exe");
        }

        [Fact]
        public void SuccessfullyOpeningFile()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Open File Dialog"));

            var openScreen = mainScreen.ClickOpen();
            openScreen.FileName = "OpenMe.txt";
            openScreen.ClickOpen();

            Assert.EndsWith("OpenMe.txt", mainScreen.FileName);
        }

        [Fact]
        public void CancelingWhenOpeningFile()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Open File Dialog"));

            var saveScreen = mainScreen.ClickOpen();
            saveScreen.FileName = "OpenMe.txt";
            saveScreen.ClickCancel();

            Assert.Equal("", mainScreen.FileName);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
