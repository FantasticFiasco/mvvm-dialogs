using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.CloseNonModalDialog
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
        public void CanShow()
        {
            // Act
            bool canShow = viewModel.ShowCommand.CanExecute(null);

            // Assert
            Assert.That(canShow, Is.True);
        }

        [Test]
        public void CanNotShow()
        {
            // Arrange
            viewModel.ShowCommand.Execute(null);

            // Act
            bool canShow = viewModel.ShowCommand.CanExecute(null);

            // Assert
            Assert.That(canShow, Is.False);
        }

        [Test]
        public void CanClose()
        {
            // Arrange
            viewModel.ShowCommand.Execute(null);

            // Act
            bool canClose = viewModel.CloseCommand.CanExecute(null);

            // Assert
            Assert.That(canClose, Is.True);
        }

        [Test]
        public void CanNotClose()
        {
            // Act
            bool canClose = viewModel.CloseCommand.CanExecute(null);

            // Assert
            Assert.That(canClose, Is.False);
        }
    }
}
