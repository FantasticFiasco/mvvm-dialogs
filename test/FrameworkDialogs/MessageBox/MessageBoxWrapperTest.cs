using System.Threading;
using System.Windows;
using Moq;
using NUnit.Framework;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    [TestFixture]
    public class MessageBoxWrapperTest
    {
        [Test]
        [RequiresThread(ApartmentState.STA)]
        public void Show()
        {
            // Arrange
            var settings = new MessageBoxSettings();
            var messageBoxShow = new Mock<IMessageBoxShow>();
            var dialog = new MessageBoxWrapper(messageBoxShow.Object, settings);

            settings.Button = MessageBoxButton.YesNoCancel;
            settings.Caption = "Some caption";
            settings.DefaultResult = MessageBoxResult.Yes;
            settings.Icon = MessageBoxImage.Warning;
            settings.MessageBoxText = "Some message box text";
            settings.Options = MessageBoxOptions.RightAlign;

            var owner = new Window();

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
                .Returns(MessageBoxResult.Cancel);

            // Act
            dialog.Show(owner);

            // Assert
            messageBoxShow.VerifyAll();
        }
    }
}
