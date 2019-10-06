using NUnit.Framework;

namespace Demo.ModalCustomDialog
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
            // Arrange
            viewModel.Text = text;

            // Act
            viewModel.OkCommand.Execute(null);

            // Assert
            Assert.That(viewModel.DialogResult, Is.EqualTo(expectedDialogResult));
        }
    }
}
