using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.CustomDialogTypeLocator
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        private Mock<IDialogService> dialogService;
        private MainWindowVM viewModel;

        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new MainWindowVM(dialogService.Object);
        }

        [Test]
        public void ShowDialog()
        {
            // Act
            viewModel.ShowDialogCommand.Execute(null);

            // Assert
            dialogService.Verify(
                mock => mock.ShowDialog(viewModel, It.IsAny<IModalDialogViewModel>()),
                Times.Once());
        }
    }
}
