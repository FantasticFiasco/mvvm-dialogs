using Demo.ModalDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.ModalDialog
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.ModalDialog.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Modal Dialog"));
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void EnterTextAndAcceptUsingDialogTypeLocator()
        {
            var addTextScreen = mainScreen.ClickAddTextUsingDialogTypeLocator();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            Assert.Equal(mainScreen.Texts, new[] { "Added text" });
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void EnterTextAndAbortUsingDialogTypeLocator()
        {
            var addTextScreen = mainScreen.ClickAddTextUsingDialogTypeLocator();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickCancel();

            Assert.Empty(mainScreen.Texts);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void EnterTextAndAcceptWhenSpecifyingDialogType()
        {
            var addTextScreen = mainScreen.ClickAddTextBySpecifyingDialogType();
            addTextScreen.Text = "Added text";
            addTextScreen.ClickOK();

            Assert.Equal(mainScreen.Texts, new[] { "Added text" });
        }

        [Fact]
        [Trait("Category", "Manual")]
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
