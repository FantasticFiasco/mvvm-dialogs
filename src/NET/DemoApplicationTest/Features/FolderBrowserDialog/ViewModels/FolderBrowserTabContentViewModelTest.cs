using System.ComponentModel;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using NUnit.Framework;
using Moq;

namespace DemoApplication.Features.FolderBrowserDialog.ViewModels
{
    [TestFixture]
    public class FolderBrowserTabContentViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private FolderBrowserTabContentViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new FolderBrowserTabContentViewModel(dialogService.Object);
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