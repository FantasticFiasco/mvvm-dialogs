using FlaUI.Core.AutomationElements;
using TestBaseClasses;

namespace Demo.FolderBrowserDialog.ScreenObjects;

public class BrowseFolderScreen : Screen
{
    public BrowseFolderScreen(Window window)
        : base(window)
    {
    }

    public void ClickOK()
    {
        DefaultOKButton.Click();
    }

    public void ClickCancel()
    {
        DefaultCancelButton.Click();
    }
}