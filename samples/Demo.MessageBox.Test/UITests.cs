using Demo.MessageBox.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.MessageBox
{
    public class UITests : IDisposable
    {
        private readonly Application app;

        public UITests()
        {
            app = Application.Launch("Demo.MessageBox.exe");
        }

        [Fact]
        public void ConfirmationWithText()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithMessage();
            Assert.Equal(string.Empty, messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.False(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.False(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        public void ConfirmationWithTextAndCaption()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithCaption();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.False(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.False(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        public void ConfirmationWithTextAndCaptionWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithButtons();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.False(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);
            
            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        public void CancellationWithTextAndCaptionWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithButtons();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.False(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.Confirmation);
        }

        [Fact]
        public void ConfirmationWithTextCaptionAndIconWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithIcon();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.True(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        public void CancellationWithTextCaptionAndIconWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithIcon();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.True(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.Confirmation);
        }

        [Fact]
        public void ConfirmationWithTextCaptionIconAndDefaultChoiceWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithDefaultResult();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.True(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        public void CancellationWithTextCaptionIconAndDefaultChoiceWithOptionToCancel()
        {
            var mainScreen = new MainScreen(app.GetMainWindow("Demo - Message Box"));

            var messageBoxScreen = mainScreen.ClickMessageBoxWithDefaultResult();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.Equal("This is the text.", messageBoxScreen.Message);
            Assert.True(messageBoxScreen.IsIconVisible);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.Confirmation);
        }

        public void Dispose()
        {
            app.Dispose();
        }
    }
}
