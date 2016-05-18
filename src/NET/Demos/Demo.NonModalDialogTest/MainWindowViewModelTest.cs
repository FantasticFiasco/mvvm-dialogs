using Demo.NonModalDialog;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.NonModalDialogTest
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
                .Setup(mock => mock.Show(viewModel, It.IsAny<CurrentTimeDialogViewModel>()))
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
                .Setup(mock => mock.Show<CurrentTimeDialog>(It.IsAny<MainWindowViewModel>(), It.IsAny<CurrentTimeDialogViewModel>()))
                .Verifiable();

            // ACT
            viewModel.ExplicitShowCommand.Execute(null);

            // ASSERT
            dialogService.VerifyAll();
        }
    }
}