using Demo.CustomOpenFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.CustomOpenFileDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("\"Demo.CustomOpenFileDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Custom Open File Dialog"));
        }

        [Fact]
        public void SuccessfullyOpeningFile()
        {
            var openScreen = mainScreen.ClickOpen();
            openScreen.FileName = "OpenMe.txt";
            openScreen.ClickOpen();

            Assert.EndsWith("OpenMe.txt", mainScreen.FileName);
        }

        [Fact]
        public void CancelingWhenOpeningFile()
        {
            var saveScreen = mainScreen.ClickOpen();
            saveScreen.FileName = "OpenMe.txt";
            saveScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.FileName);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
