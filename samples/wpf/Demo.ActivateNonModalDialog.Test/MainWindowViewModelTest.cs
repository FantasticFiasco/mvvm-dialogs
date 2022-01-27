using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.ActivateNonModalDialog
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
        public void CanActivate()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            viewModel.ShowCommand.Execute(null);

            // Act
            bool canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.That(canActivate, Is.True);
        }

        [Test]
        public void CanNotActivate()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            // Act
            bool canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.That(canActivate, Is.False);
        }
    }
}
