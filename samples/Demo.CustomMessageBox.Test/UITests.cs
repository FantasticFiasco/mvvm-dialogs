using Demo.CustomMessageBox.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.CustomMessageBox
{
    public class UITests : IDisposable
    {
        private readonly Application app;
        private readonly MainScreen mainScreen;

        public UITests()
        {
            app = Application.Launch("Demo.CustomMessageBox.exe");
            mainScreen = new MainScreen(app.GetMainWindow("Demo - Custom Message Box"));
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void ConfirmationWithText()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithMessage();
            Assert.Equal(" ", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.False(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void ConfirmationWithTextAndCaption()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithCaption();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.False(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void ConfirmationWithTextAndCaptionWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithButtons();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);
            
            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void CancellationWithTextAndCaptionWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithButtons();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void ConfirmationWithTextCaptionAndIconWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithIcon();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void CancellationWithTextCaptionAndIconWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithIcon();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickCancel();

            Assert.Equal(string.Empty, mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void ConfirmationWithTextCaptionIconAndDefaultChoiceWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithDefaultResult();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
            Assert.True(messageBoxScreen.IsOKButtonVisible);
            Assert.True(messageBoxScreen.IsCancelButtonVisible);

            messageBoxScreen.ClickOK();

            Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
        }

        [Fact]
        [Trait("Category", "Manual")]
        public void CancellationWithTextCaptionIconAndDefaultChoiceWithOptionToCancel()
        {
            var messageBoxScreen = mainScreen.ClickMessageBoxWithDefaultResult();
            Assert.Equal("This Is The Caption", messageBoxScreen.Caption);
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
