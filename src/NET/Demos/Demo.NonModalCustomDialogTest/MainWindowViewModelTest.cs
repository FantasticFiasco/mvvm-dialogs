using Demo.NonModalCustomDialog;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.NonModalCustomDialogTest
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
            // ARRANGE
            dialogService
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeCustomDialogViewModel>()))
                .Verifiable();

            // ACT
            viewModel.ImplicitShowCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }

        [Test]
        public void ExplicitShowCurrentTime()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowCustom<CurrentTimeCustomDialog>(It.IsAny<MainWindowViewModel>(), It.IsAny<CurrentTimeCustomDialogViewModel>()))
                .Verifiable();

            // ACT
            viewModel.ExplicitShowCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }
    }
}