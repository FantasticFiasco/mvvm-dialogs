using System.ComponentModel;
using Demo.CustomOpenFileDialog;
using Moq;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using NUnit.Framework;

namespace Demo.CustomOpenFileDialogTest
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
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings) =>
                    settings.FileName = @"C:\SomeFile.txt");

            // ACT
            viewModel.OpenFileCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFile.txt"));
        }

        [Test]
        public void OpenFileUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowOpenFileDialog(viewModel, It.IsAny<OpenFileDialogSettings>()))
                .Returns(false);

            // ACT
            viewModel.OpenFileCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}