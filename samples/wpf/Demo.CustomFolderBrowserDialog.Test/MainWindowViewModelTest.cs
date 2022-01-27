using System.ComponentModel;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using NUnit.Framework;

namespace Demo.CustomFolderBrowserDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void BrowseFolderSuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<FolderBrowserDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings) =>
                    settings.SelectedPath = @"C:\SomeFolder");

            // Act
            viewModel.BrowseFolderCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFolder"));
        }

        [Test]
        public void BrowseFolderUnsuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<FolderBrowserDialogSettings>()))
                .Returns(false);

            // Act
            viewModel.BrowseFolderCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}
