using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using Xunit;

namespace Demo.OpenFileDialog
{
    public class MainWindowViewModelTest
    {
        [Fact]
        public void OpenFileSuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings) =>
                    settings.FileName = @"C:\SomeFile.txt");

            // Act
            viewModel.OpenFileCommand.Execute(null);

            // Assert
            Assert.Equal(@"C:\SomeFile.txt", viewModel.Path);
        }

        [Fact]
        public void OpenFileUnsuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogSettings>()))
                .Returns(false);

            // Act
            viewModel.OpenFileCommand.Execute(null);

            // Assert
            Assert.Null(viewModel.Path);
        }
    }
}
