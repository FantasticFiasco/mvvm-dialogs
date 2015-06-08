using NUnit.Framework;

namespace DemoApplication.Features.Dialog.Modal.ViewModels
{
    [TestFixture]
    public class AddTextDialogViewModelTest
    {
        private AddTextDialogViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new AddTextDialogViewModel();
        }

        [TestCase("Some text", true)]
        [TestCase("", null)]
        [TestCase(null, null)]
        public void Ok(string text, bool? expectedDialogResult)
        {
            // ARRANGE
            viewModel.Text = text;

            // ACT
            viewModel.OkCommand.Execute(null);

            // ASSERT
            Assert.That(viewModel.DialogResult, Is.EqualTo(expectedDialogResult));
        }
    }
}