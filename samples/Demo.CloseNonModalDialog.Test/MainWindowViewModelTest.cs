using Moq;
using MvvmDialogs;
using Xunit;

namespace Demo.CloseNonModalDialog;

public class MainWindowViewModelTest
{

    [Fact]
    public void CanShow()
    {
        // Arrange
        var dialogService = new Mock<IDialogService>();
        var viewModel = new MainWindowViewModel(dialogService.Object);

        // Act
        bool canShow = viewModel.ShowCommand.CanExecute(null);

        // Assert
        Assert.True(canShow);
    }

    [Fact]
    public void CanNotShow()
    {
        // Arrange
        var dialogService = new Mock<IDialogService>();
        var viewModel = new MainWindowViewModel(dialogService.Object);

        viewModel.ShowCommand.Execute(null);

        // Act
        bool canShow = viewModel.ShowCommand.CanExecute(null);

        // Assert
        Assert.False(canShow);
    }

    [Fact]
    public void CanClose()
    {
        // Arrange
        var dialogService = new Mock<IDialogService>();
        var viewModel = new MainWindowViewModel(dialogService.Object);

        viewModel.ShowCommand.Execute(null);

        // Act
        bool canClose = viewModel.CloseCommand.CanExecute(null);

        // Assert
        Assert.True(canClose);
    }

    [Fact]
    public void CanNotClose()
    {
        // Arrange
        var dialogService = new Mock<IDialogService>();
        var viewModel = new MainWindowViewModel(dialogService.Object);

        // Act
        bool canClose = viewModel.CloseCommand.CanExecute(null);

        // Assert
        Assert.False(canClose);
    }
}