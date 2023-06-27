using System.Windows;
using Moq;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    public class MessageBoxWrapperTest
    {
        [StaFact]
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
            settings.Options = System.Windows.MessageBoxOptions.RightAlign;

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
