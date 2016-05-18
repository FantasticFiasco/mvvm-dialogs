using System.ComponentModel;
using Demo.FolderBrowserDialog;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using NUnit.Framework;

namespace Demo.FolderBrowserDialogTest
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
        public void BrowseFolderSuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<FolderBrowserDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings) =>
                    settings.SelectedPath = @"C:\SomeFolder");

            // ACT
            viewModel.BrowseFolderCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFolder"));
        }

        [Test]
        public void BrowseFolderUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowFolderBrowserDialog(viewModel, It.IsAny<FolderBrowserDialogSettings>()))
                .Returns(false);

            // ACT
            viewModel.BrowseFolderCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}