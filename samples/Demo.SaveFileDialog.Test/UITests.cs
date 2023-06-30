using Demo.SaveFileDialog.ScreenObjects;
using TestBaseClasses;
using Xunit;

namespace Demo.SaveFileDialog;

public class UITests : IDisposable
{
    private readonly Application app;
    private readonly MainScreen mainScreen;

    public UITests()
    {
        app = Application.Launch("Demo.SaveFileDialog.exe");
        mainScreen = new MainScreen(app.GetMainWindow("Demo - Save File Dialog"));
    }

    [Fact]
    [Trait("Category", "Manual")]
    public void SuccessfullySavingFile()
    {
        var saveScreen = mainScreen.ClickSave();
        saveScreen.FileName = "SaveMe.txt";
        saveScreen.ClickSave();

        Assert.EndsWith("SaveMe.txt", mainScreen.FileName);
    }

    [Fact]
    [Trait("Category", "Manual")]
    public void CancelingWhenSavingFile()
    {
        var saveScreen = mainScreen.ClickSave();
        saveScreen.FileName = "SaveMe.txt";
        saveScreen.ClickCancel();

        Assert.Equal(string.Empty, mainScreen.FileName);
    }

    public void Dispose()
    {
        app.Dispose();
    }
}