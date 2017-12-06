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
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowSaveFileDialog(viewModel, It.IsAny<SaveFileDialogSettings>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings) =>
                    settings.FileName = @"C:\SomeFile.txt");

            // ACT
            viewModel.SaveFileCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.EqualTo(@"C:\SomeFile.txt"));
        }

        [Test]
        public void OpenFileUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowSaveFileDialog(viewModel, It.IsAny<SaveFileDialogSettings>()))
                .Returns(false);

            // ACT
            viewModel.SaveFileCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Path, Is.Null);
        }
    }
}