using System.Windows;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.CustomMessageBox
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void ShowMessageBoxWithMessage()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        "",
                        MessageBoxButton.OK,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(MessageBoxResult.OK);

            // Act
            viewModel.ShowMessageBoxWithMessageCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithCaption()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OK,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(MessageBoxResult.OK);

            // Act
            viewModel.ShowMessageBoxWithCaptionCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithButton()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.None,
                        MessageBoxResult.None))
                .Returns(MessageBoxResult.OK); ;

            // Act
            viewModel.ShowMessageBoxWithButtonCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithIcon()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Information,
                        MessageBoxResult.None))
                .Returns(MessageBoxResult.OK); ;

            // Act
            viewModel.ShowMessageBoxWithIconCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithDefaultResult()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock =>
                    mock.ShowMessageBox(
                        viewModel,
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        MessageBoxButton.OKCancel,
                        MessageBoxImage.Information,
                        MessageBoxResult.Cancel))
                .Returns(MessageBoxResult.OK); ;

            // Act
            viewModel.ShowMessageBoxWithDefaultResultCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }
    }
}
