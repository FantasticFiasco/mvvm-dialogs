using NUnit.Framework;

namespace Demo.ModalCustomDialog
{
    [TestFixture]
    public class AddTextCustomDialogViewModelTest
    {
        [TestCase("Some text", true)]
        [TestCase("", null)]
        [TestCase(null, null)]
        public void Ok(string text, bool? expectedDialogResult)
        {
            // Arrange
            var viewModel = new AddTextCustomDialogViewModel
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
