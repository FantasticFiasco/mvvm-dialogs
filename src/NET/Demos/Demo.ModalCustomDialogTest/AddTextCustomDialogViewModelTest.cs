using Demo.ModalCustomDialog;
using NUnit.Framework;

namespace Demo.ModalCustomDialogTest
{
    [TestFixture]
    public class AddTextCustomDialogViewModelTest
    {
        private AddTextCustomDialogViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new AddTextCustomDialogViewModel();
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