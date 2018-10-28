using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.NonModalDialog
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
        public void ImplicitShowCurrentTime()
        {
            // Arrange
            dialogService
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // Act
            viewModel.ImplicitShowCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }

        [Test]
        public void ExplicitShowCurrentTime()
        {
            // Arrange
            dialogService
                .Setup(mock => mock.Show<CurrentTimeDialog>(It.IsAny<MainWindowViewModel>(), It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // Act
            viewModel.ExplicitShowCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }
    }
}
