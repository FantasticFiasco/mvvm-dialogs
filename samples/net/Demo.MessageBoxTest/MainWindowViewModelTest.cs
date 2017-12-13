using System.Windows;
using Demo.MessageBox;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.MessageBoxTest
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private MainWindowViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new MainWindowViewModel(dialogService.Object);
        }

        [Test]
        public void ShowMessageBoxWithMessage()
        {
            // ARRANGE
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

            // ACT
            viewModel.ShowMessageBoxWithMessageCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithCaption()
        {
            // ARRANGE
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

            // ACT
            viewModel.ShowMessageBoxWithCaptionCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithButton()
        {
            // ARRANGE
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

            // ACT
            viewModel.ShowMessageBoxWithButtonCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithIcon()
        {
            // ARRANGE
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

            // ACT
            viewModel.ShowMessageBoxWithIconCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithDefaultResult()
        {
            // ARRANGE
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

            // ACT
            viewModel.ShowMessageBoxWithDefaultResultCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }
    }
}