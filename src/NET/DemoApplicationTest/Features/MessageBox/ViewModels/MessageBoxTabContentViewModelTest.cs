using System.Windows;
using MvvmDialogs;
using NUnit.Framework;
using Moq;

namespace DemoApplication.Features.MessageBox.ViewModels
{
    [TestFixture]
    public class MessageBoxTabContentViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private MessageBoxTabContentViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new MessageBoxTabContentViewModel(dialogService.Object);
        }

        [Test]
        public void ShowMessageBoxWithMessage()
        {
            // ARRANGE
            dialogService.Setup(mock =>
                mock.ShowMessageBox(
                    viewModel,
                    It.IsAny<string>(),
                    "",
                    MessageBoxButton.OK,
                    MessageBoxImage.None,
                    MessageBoxResult.None));

            // ACT
            viewModel.ShowMessageBoxWithMessageCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithCaption()
        {
            // ARRANGE
            dialogService.Setup(mock =>
                mock.ShowMessageBox(
                    viewModel,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    MessageBoxButton.OK,
                    MessageBoxImage.None,
                    MessageBoxResult.None));

            // ACT
            viewModel.ShowMessageBoxWithCaptionCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithButton()
        {
            // ARRANGE
            dialogService.Setup(mock =>
                mock.ShowMessageBox(
                    viewModel,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.None,
                    MessageBoxResult.None));

            // ACT
            viewModel.ShowMessageBoxWithButtonCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithIcon()
        {
            // ARRANGE
            dialogService.Setup(mock =>
                mock.ShowMessageBox(
                    viewModel,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Information,
                    MessageBoxResult.None));

            // ACT
            viewModel.ShowMessageBoxWithIconCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ShowMessageBoxWithDefaultResult()
        {
            // ARRANGE
            dialogService.Setup(mock =>
                mock.ShowMessageBox(
                    viewModel,
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Information,
                    MessageBoxResult.Cancel));

            // ACT
            viewModel.ShowMessageBoxWithDefaultResultCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }
    }
}