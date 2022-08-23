using NUnit.Framework;

namespace Demo.ModalDialog
{
    [TestFixture]
    public class AddTextDialogViewModelTest
    {
        [TestCase("Some text", true)]
        [TestCase("", null)]
        [TestCase(null, null)]
        public void Ok(string text, bool? expectedDialogResult)
        {
            // Arrange
            var viewModel = new AddTextDialogViewModel
            {
                Text = text
            };

            // Act
            viewModel.OkCommand.Execute(null);

            // Assert
            Assert.That(viewModel.DialogResult, Is.EqualTo(expectedDialogResult));
        }
    }
}
