using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.CustomDialogTypeLocator
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void ShowDialog()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowVM(dialogService.Object);

            // Act
            viewModel.ShowDialogCommand.Execute(null);

            // Assert
            dialogService.Verify(
                mock => mock.ShowDialog(viewModel, It.IsAny<IModalDialogViewModel>()),
                Times.Once());
        }
    }
}
