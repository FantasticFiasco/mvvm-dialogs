using Demo.FolderBrowserDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.FolderBrowserDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.FolderBrowserDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Folder Browser Dialog"));
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void SuccessfullyBrowseFolder()
        {
            var browseFolderScreen = mainScreen.ClickBrowse();
            browseFolderScreen.ClickOK();

            Assert.NotEqual(string.Empty, mainScreen.FileName);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void CancelingWhenBrowsingFolder()
        {
            var browseFolderScreen = mainScreen.ClickBrowse();
            browseFolderScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.FileName);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
