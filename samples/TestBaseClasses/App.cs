using System.IO;
using System.Reflection;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using Xunit;

namespace TestBaseClasses;

public class Application : IDisposable
{
    private readonly FlaUI.Core.Application app;
    private readonly UIA3Automation automation;

    public Application(FlaUI.Core.Application app)
    {
        this.app = app;
            
        automation = new UIA3Automation();
    }

    public static Application Launch(string relativeExePath)
    {
        var filePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException(),
            relativeExePath);

        var app = FlaUI.Core.Application.Launch(filePath);

        return new Application(app);
    }

    public Window GetMainWindow(string title)
    {
        var window = app.GetMainWindow(automation, TimeSpan.FromSeconds(3));
        Assert.Equal(title, window.Title);

        return window;
    }

    public Window GetMainWindowThatStartsWith(string title)
    {
        var window = app.GetMainWindow(automation, TimeSpan.FromSeconds(3));
        Assert.StartsWith(title, window.Title);

        return window;
    }

    public void Dispose()
    {
        app.Close();
        app.Dispose();
        automation.Dispose();
    }
}
