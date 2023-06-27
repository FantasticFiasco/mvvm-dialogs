using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using Xunit;

namespace Demo.CustomSaveFileDialog
{
    public class MainWindowViewModelTest
    {
        [Fact]
        public void SaveFileSuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowSaveFileDialog(viewModel, It.IsAny<SaveFileDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings) =>
                    settings.FileName = @"C:\SomeFile.txt");

            // Act
            viewModel.SaveFileCommand.Execute(null);

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
                .Setup(mock => mock.ShowSaveFileDialog(viewModel, It.IsAny<SaveFileDialogSettings>()))
                .Returns(false);

            // Act
            viewModel.SaveFileCommand.Execute(null);

            // Assert
            Assert.Null(viewModel.Path);
        }
    }
}
