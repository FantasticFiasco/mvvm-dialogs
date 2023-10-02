using Demo.StaThreads.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.StaThreads;

public class UITests : IDisposable
{
    private readonly Application app;
    private readonly MainScreen mainScreen;

    public UITests()
    {
        app = Application.Launch("Demo.StaThreads.exe");
        mainScreen = new MainScreen(app.GetMainWindowThatStartsWith("Demo - STA Threads"));
    }

    [Fact]
    [Trait("Category", "Manual")]
    public void ConfirmationWithText()
    {
        var messageBoxScreen = mainScreen.ClickMessageBox();
        Assert.Equal(string.Empty, messageBoxScreen.Caption);
        Assert.Equal("This is the text.", messageBoxScreen.Message);
        Assert.False(messageBoxScreen.IsIconVisible);
        Assert.True(messageBoxScreen.IsOKButtonVisible);
        Assert.False(messageBoxScreen.IsCancelButtonVisible);

        messageBoxScreen.ClickOK();

        Assert.Equal("We got confirmation to continue!", mainScreen.Confirmation);
    }

    public void Dispose()
    {
        app.Dispose();
    }
}
