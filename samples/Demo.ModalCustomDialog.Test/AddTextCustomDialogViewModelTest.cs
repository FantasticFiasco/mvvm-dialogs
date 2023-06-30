using Xunit;

namespace Demo.ModalCustomDialog;

public class AddTextCustomDialogViewModelTest
{
    [Theory]
    [InlineData("Some text", true)]
    [InlineData("", null)]
    [InlineData(null, null)]
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
        Assert.Equal(expectedDialogResult, viewModel.DialogResult);
    }
}