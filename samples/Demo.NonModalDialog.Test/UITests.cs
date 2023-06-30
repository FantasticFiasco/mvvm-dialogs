using Demo.NonModalDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.NonModalDialog;

public class UITests : IDisposable
{
    private readonly Application app;
    private readonly MainScreen mainScreen;

    public UITests()
    {
        app = Application.Launch("Demo.NonModalDialog.exe");
        mainScreen = new MainScreen(app.GetMainWindow("Demo - Non-Modal Dialog"));
    }

    [Fact]
    [Trait("Category", "Manual")]
    public void ShowCurrentTimeUsingDialogTypeLocator()
    {
        var currentTimeScreen = mainScreen.ClickShowCurrentTimeUsingDialogTypeLocator();

        Assert.True(currentTimeScreen.CurrentTimeVisible);
    }

    [Fact]
    [Trait("Category", "Manual")]
    public void ShowCurrentTimeBySpecifyingDialogType()
    {
        var currentTimeScreen = mainScreen.ClickShowCurrentTimeBySpecifyingDialogType();

        Assert.True(currentTimeScreen.CurrentTimeVisible);
    }

    public void Dispose()
    {
        app.Dispose();
    }
}