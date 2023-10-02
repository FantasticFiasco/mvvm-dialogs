using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using TestBaseClasses;

namespace Demo.StaThreads.ScreenObjects;

public class MainScreen : Screen
{
    public MainScreen(Window window)
        : base(window)
    {
    }

    private Button MessageBoxButton => ElementByAutomationId<Button>("1k7d1Nm8MkOYK5qGrdVX4Q");
    private Label ConfirmationLabel => ElementByAutomationId<Label>("kT3_ZUZfsEK1QdZ2jBfuIQ");

    public string Confirmation => ConfirmationLabel.Text;

    public MessageBoxScreen ClickMessageBox()
    {
        MessageBoxButton.Click();
        Wait.UntilInputIsProcessed();

        return new MessageBoxScreen(GetModalWindow(string.Empty));
    }
}