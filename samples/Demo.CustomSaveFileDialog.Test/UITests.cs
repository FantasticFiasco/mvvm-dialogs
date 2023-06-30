using Demo.CustomSaveFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.CustomSaveFileDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.CustomSaveFileDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Custom Save File Dialog"));
        }

        [Fact]
        public void SuccessfullySavingFile()
        {
            var saveFileScreen = mainScreen.ClickSave();
            saveFileScreen.FileName = "SaveMe.txt";

            saveFileScreen.ClickSave();

            Assert.EndsWith("SaveMe.txt", mainScreen.FileName);
        }

        [Fact]
        public void CancelingWhenSavingFile()
        {
            var saveFileScreen = mainScreen.ClickSave();
            saveFileScreen.FileName = "SaveMe.txt";

            saveFileScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.FileName);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
