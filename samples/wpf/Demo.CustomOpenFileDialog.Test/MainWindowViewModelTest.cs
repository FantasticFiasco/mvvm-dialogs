using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using NUnit.Framework;

namespace Demo.CustomOpenFileDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private MainWindowViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new MainWindowViewModel(dialogService.Object);
        }

        [Test]
        public void OpenFileSuccessful()
        {
            // Arrange
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
