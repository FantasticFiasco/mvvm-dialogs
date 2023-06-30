using Xunit;

namespace Demo.ModalDialog
{
    public class AddTextDialogViewModelTest
    {
        [Theory]
        [InlineData("Some text", true)]
        [InlineData("", null)]
        [InlineData(null, null)]
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
            Assert.Equal(expectedDialogResult, viewModel.DialogResult);
        }
    }
}
