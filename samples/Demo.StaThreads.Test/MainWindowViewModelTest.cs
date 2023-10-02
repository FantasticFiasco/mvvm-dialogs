using System.Windows;
using Moq;
using MvvmDialogs;
using Xunit;

namespace Demo.StaThreads;

public class MainWindowViewModelTest
{
    [Fact]
    public void ShowMessageBox()
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
        viewModel.ShowMessageBoxCommand.Execute(null);

        // Assert
        dialogService.VerifyAll();
    }
}
