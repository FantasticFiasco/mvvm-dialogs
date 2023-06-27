using Moq;
using MvvmDialogs;
using Xunit;

namespace Demo.NonModalDialog
{
    public class MainWindowViewModelTest
    {
        [Fact]
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

        [Fact]
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
