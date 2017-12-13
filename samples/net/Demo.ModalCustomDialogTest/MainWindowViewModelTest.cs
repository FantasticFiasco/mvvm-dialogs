using System.ComponentModel;
using Demo.ModalCustomDialog;
using Moq;
using MvvmDialogs;
using NUnit.Framework;

namespace Demo.ModalCustomDialogTest
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
        public void ImplicitAddTextSuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextCustomDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, AddTextCustomDialogViewModel addTextDialogViewModel) =>
                    addTextDialogViewModel.Text = "Some text");

            var expected = new[]
            {
                "Some text"
            };

            // ACT
            viewModel.ImplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.EqualTo(expected));
        }

        [Test]
        public void ImplicitAddTextUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextCustomDialogViewModel>()))
                .Returns(false);

            // ACT
            viewModel.ImplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.Empty);
        }

        [Test]
        public void ExplicitAddTextSuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowCustomDialog<AddTextCustomDialog>(viewModel, It.IsAny<AddTextCustomDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, AddTextCustomDialogViewModel addTextDialogViewModel) =>
                    addTextDialogViewModel.Text = "Some text");

            var expected = new[]
            {
                "Some text"
            };

            // ACT
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.EqualTo(expected));
        }

        [Test]
        public void ExplicitAddTextUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowCustomDialog<AddTextCustomDialog>(viewModel, It.IsAny<AddTextCustomDialogViewModel>()))
                .Returns(false);

            // ACT
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.Empty);
        }
    }
}