using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.NonModalDialog.ScreenObjects;

public class MainScreen : Screen
{
    public MainScreen(Window window)
        : base(window)
    {
    }

    private Button ShowCurrentTimeUsingDialogTypeLocatorButton => ElementByAutomationId<Button>("6U4UYFLlnUKOBx26wvyDOg");
    private Button ShowCurrentTimeBySpecifyingDialogTypeButton => ElementByAutomationId<Button>("yp7kt1tOeEqE5y2KmylhGQ");
        
    public CurrentTimeScreen ClickShowCurrentTimeUsingDialogTypeLocator()
    {
        ShowCurrentTimeUsingDialogTypeLocatorButton.Click();
        Wait.UntilInputIsProcessed();

        return new CurrentTimeScreen(GetNonModalWindow("Current time"));
    }

    public CurrentTimeScreen ClickShowCurrentTimeBySpecifyingDialogType()
    {
        ShowCurrentTimeBySpecifyingDialogTypeButton.Click();
        Wait.UntilInputIsProcessed();

        return new CurrentTimeScreen(GetNonModalWindow("Current time"));
    }
}