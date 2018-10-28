using System.ComponentModel;
using Demo.CustomSaveFileDialog;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using NUnit.Framework;

namespace Demo.CustomSaveFileDialogTest
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
        public void SaveFileSuccessful()
        {
            // Arrange
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