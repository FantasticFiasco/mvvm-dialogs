using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.NonModalCustomDialog
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
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeCustomDialogViewModel>()))
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
                .Setup(mock => mock.ShowCustom<CurrentTimeCustomDialog>(It.IsAny<MainWindowViewModel>(), It.IsAny<CurrentTimeCustomDialogViewModel>()))
                .Verifiable();

            // Act
            viewModel.ExplicitShowCommand.Execute(null);

            // Assert
            dialogService.VerifyAll();
        }
    }
}
