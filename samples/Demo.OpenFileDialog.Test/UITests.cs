using Demo.OpenFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.OpenFileDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.OpenFileDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Open File Dialog"));
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void SuccessfullyOpeningFile()
        {
            var openScreen = mainScreen.ClickOpen();
            openScreen.FileName = "OpenMe.txt";
            openScreen.ClickOpen();

            Assert.EndsWith("OpenMe.txt", mainScreen.FileName);
        }

        [Fact]
        [Trait("Category", "Manual")]
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
