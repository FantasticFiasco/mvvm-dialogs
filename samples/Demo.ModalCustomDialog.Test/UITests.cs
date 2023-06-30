using Demo.ModalCustomDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.ModalCustomDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.ModalCustomDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Modal Custom Dialog"));
        }

        [Fact]
        public void EnterTextAndAcceptUsingDialogTypeLocator()
        {
            var addTextScreen = mainScreen.ClickAddTextUsingDialogTypeLocator();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            Assert.Equal(mainScreen.Texts, new []{ "Added text" });
        }

        [Fact]
        public void EnterTextAndAbortUsingDialogTypeLocator()
        {
            var addTextScreen = mainScreen.ClickAddTextUsingDialogTypeLocator();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickCancel();

            Assert.Empty(mainScreen.Texts);
        }

        [Fact]
        public void EnterTextAndAcceptWhenSpecifyingDialogType()
        {
            var addTextScreen = mainScreen.ClickAddTextBySpecifyingDialogType();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            Assert.Equal(mainScreen.Texts, new[] { "Added text" });
        }

        [Fact]
        public void EnterTextAndAbortWhenSpecifyingDialogType()
        {
            var addTextScreen = mainScreen.ClickAddTextBySpecifyingDialogType();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickCancel();

            Assert.Empty(mainScreen.Texts);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
