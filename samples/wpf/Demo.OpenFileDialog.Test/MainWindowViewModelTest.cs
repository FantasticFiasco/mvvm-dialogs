using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using NUnit.Framework;

namespace Demo.OpenFileDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
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
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFile.txt"));
        }

        [Test]
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
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}
