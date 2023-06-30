using Moq;
using MvvmDialogs;
using Xunit;

namespace Demo.ActivateNonModalDialog
{
    public class MainWindowViewModelTest
    {
        [Fact]
        public void CanShow()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            // Act
            var canShow = viewModel.ShowCommand.CanExecute(null);

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
            var canShow = viewModel.ShowCommand.CanExecute(null);

            // Assert
            Assert.False(canShow);
        }

        [Fact]
        public void CanActivate()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            viewModel.ShowCommand.Execute(null);

            // Act
            var canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.True(canActivate);
        }

        [Fact]
        public void CanNotActivate()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            // Act
            var canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.False(canActivate);
        }
    }
}
