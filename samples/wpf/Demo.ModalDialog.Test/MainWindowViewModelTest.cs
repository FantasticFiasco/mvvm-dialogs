using System.ComponentModel;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.ModalDialog
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void ImplicitAddTextSuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, IModalDialogViewModel addTextDialogViewModel) =>
                    ((AddTextDialogViewModel)addTextDialogViewModel).Text = "Some text");

            var expected = new[]
            {
                "Some text"
            };

            // Act
            viewModel.ImplicitShowDialogCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Texts, Is.EqualTo(expected));
        }

        [Test]
        public void ImplicitAddTextUnsuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(false);

            // Act
            viewModel.ImplicitShowDialogCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Texts, Is.Empty);
        }

        [Test]
        public void ExplicitAddTextSuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowDialog<AddTextDialog>(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, IModalDialogViewModel addTextDialogViewModel) =>
                    ((AddTextDialogViewModel)addTextDialogViewModel).Text = "Some text");

            var expected = new[]
            {
                "Some text"
            };

            // Act
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Texts, Is.EqualTo(expected));
        }

        [Test]
        public void ExplicitAddTextUnsuccessful()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var viewModel = new MainWindowViewModel(dialogService.Object);

            dialogService
                .Setup(mock => mock.ShowDialog<AddTextDialog>(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(false);

            // Act
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // Assert
            Assert.That(viewModel.Texts, Is.Empty);
        }
    }
}
