using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.ActivateNonModalDialog
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
        public void CanActivate()
        {
            // Arrange
            viewModel.ShowCommand.Execute(null);

            // Act
            bool canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.That(canActivate, Is.True);
        }

        [Test]
        public void CanNotActivate()
        {
            // Act
            bool canActivate = viewModel.ActivateCommand.CanExecute(null);

            // Assert
            Assert.That(canActivate, Is.False);
        }
    }
}
