using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.NonModalDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void ImplicitShowCurrentTime()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // Act
            viewModel.ImplicitShowCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ExplicitShowCurrentTime()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.Show<CurrentTimeDialog>(It.IsAny<MainWindowViewModel>(), It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // Act
            viewModel.ExplicitShowCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }
    }
}
