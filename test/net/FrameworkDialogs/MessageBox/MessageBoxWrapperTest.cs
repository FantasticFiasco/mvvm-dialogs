using System.Threading;
using System.Windows;
using Moq;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    [TestFixture]
    public class MessageBoxWrapperTest
    {
        private MessageBoxSettings settings;
        private Mock<IMessageBoxShow> messageBoxShow;
        private MessageBoxWrapper dialog;

        [SetUp]
        public void SetUp()
        {
            settings = new MessageBoxSettings();
            messageBoxShow = new Mock<IMessageBoxShow>();
            dialog = new MessageBoxWrapper(messageBoxShow.Object, settings);
        }

        [Test]
        [RequiresThread(ApartmentState.STA)]
        public void Show()
        {
            // Arrange
            settings.Button = MessageBoxButton.YesNoCancel;
            settings.Caption = "Some caption";
            settings.DefaultResult = MessageBoxResult.Yes;
            settings.Icon = MessageBoxImage.Warning;
            settings.MessageBoxText = "Some message box text";
            settings.Options = MessageBoxOptions.RightAlign;

            var owner = new Window();
            var expected = MessageBoxResult.Cancel;

            messageBoxShow
                .Setup(mock =>
                    mock.Show(
                        owner,
                        settings.MessageBoxText,
                        settings.Caption,
                        settings.Button,
                        settings.Icon,
                        settings.DefaultResult,
                        settings.Options))
                .Returns(expected);

            // Act
            var actual = dialog.Show(owner);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
            messageBoxShow.VerifyAll();
        }
    }
}
