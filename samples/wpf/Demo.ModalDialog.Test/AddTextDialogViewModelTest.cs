using NUnit.Framework;

namespace Demo.ModalDialog
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
            // Arrange
            viewModel.Text = text;

            // Act
            viewModel.OkCommand.Execute(null);

            // Assert
            Assert.That(viewModel.DialogResult, Is.EqualTo(expectedDialogResult));
        }
    }
}
