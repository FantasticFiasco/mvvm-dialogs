using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.CloseNonModalDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {

        [Test]
        public void CanShow()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            // Act
            bool canShow = viewModel.ShowCommand.CanExecute(null);

            // Assert
            Assert.That(canShow, Is.True);
        }

        [Test]
        public void CanNotShow()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

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
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            viewModel.ShowCommand.Execute(null);

            // Act
            bool canClose = viewModel.CloseCommand.CanExecute(null);

            // Assert
            Assert.That(canClose, Is.True);
        }

        [Test]
        public void CanNotClose()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            // Act
            bool canClose = viewModel.CloseCommand.CanExecute(null);

            // Assert
            Assert.That(canClose, Is.False);
        }
    }
}
