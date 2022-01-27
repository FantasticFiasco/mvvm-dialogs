using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using NUnit.Framework;

namespace Demo.SaveFileDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
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
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFile.txt"));
        }

        [Test]
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
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}
