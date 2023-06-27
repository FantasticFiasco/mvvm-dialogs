using System.IO;
using System.Reflection;
using Demo.SaveFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.SaveFileDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;

        public UITests() => app = new Application("Demo.SaveFileDialog.exe");

        [Fact]
        public void SuccessfullySavingFile()
        {
            var mainScreen = new MainScreen(app.Launch().GetMainWindow("Demo - Save File Dialog"));

            var saveScreen = mainScreen.ClickSave();
            saveScreen.FileName = "SaveMe.txt";
            saveScreen.ClickSave();

            Assert.EndsWith("SaveMe.txt", mainScreen.FileName);
        }

        [Fact]
        public void CancelingWhenSavingFile()
        {
            var mainScreen = new MainScreen(app.Launch().GetMainWindow("Demo - Save File Dialog"));

            var saveScreen = mainScreen.ClickSave();
            saveScreen.FileName = "SaveMe.txt";
            saveScreen.ClickCancel();

            Assert.Equal("", mainScreen.FileName);
        }

        public void Dispose() => app.Dispose();
    }
}
