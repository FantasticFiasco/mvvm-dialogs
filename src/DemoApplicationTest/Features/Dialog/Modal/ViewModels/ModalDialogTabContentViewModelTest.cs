using System.ComponentModel;
using DemoApplication.Features.Dialog.Modal.Views;
using MvvmDialogs;
using NUnit.Framework;
using Moq;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    [TestFixture]
    public class ModalDialogTabContentViewModelTest
    {
        private Mock<IDialogService> dialogService; 
        private ModalDialogTabContentViewModel viewModel;
        
        [SetUp]
        public void SetUp()
        {
            dialogService = new Mock<IDialogService>();
            viewModel = new ModalDialogTabContentViewModel(dialogService.Object);
        }

        [Test]
        public void ImplicitAddTextSuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, AddTextDialogViewModel addTextDialogViewModel) =>
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
        public void ImplicitAddTextUnsuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowDialog(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(false);

            // ACT
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.Empty);
        }

        [Test]
        public void ExplicitAddTextSuccessful()
        {
            // ARRANGE
            dialogService
                .Setup(mock => mock.ShowDialog<AddTextDialog>(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(true)
                .Callback((INotifyPropertyChanged ownerViewModel, AddTextDialogViewModel addTextDialogViewModel) =>
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
                .Setup(mock => mock.ShowDialog<AddTextDialog>(viewModel, It.IsAny<AddTextDialogViewModel>()))
                .Returns(false);

            // ACT
            viewModel.ExplicitShowDialogCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.Texts, Is.Empty);
        }
    }
}