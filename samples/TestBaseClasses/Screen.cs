using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace TestBaseClasses;

public abstract class Screen
{
    private readonly Window window;

    protected const string OK = "OK";
    protected const string Save = "Save";
    protected const string Cancel = "Cancel";

    protected Screen(Window window)
    {
        this.window = window;
    }

    protected Window Window
    {
        get => window;
    }

    protected Button DefaultOKButton
    {
        get => ElementByText<Button>(OK);
    }

    protected Button DefaultSaveButton
    {
        get => ElementByText<Button>(Save);
    }

    protected Button DefaultCancelButton
    {
        get => ElementByText<Button>(Cancel);
    }

    protected T ElementByAutomationId<T>(string automationId) where T : AutomationElement
    {
        return window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).As<T>();
    }

    protected T ElementByText<T>(string text) where T : AutomationElement
    {
        return window.FindFirstDescendant(cf => cf.ByText(text)).As<T>();
    }

    protected bool ElementWithAutomationIdExists(string automationId)
    {
        var elements = window.FindAllDescendants(cf => cf.ByAutomationId(automationId));
        return elements.Any();
    }

    protected bool ElementWithTextExists(string text)
    {
        var elements = window.FindAllDescendants(cf => cf.ByText(text));
        return elements.Any();
    }

    protected Window GetModalWindow(string title)
    {
        return window.ModalWindows.Single(w => w.Title == title);
    }

    protected Window GetNonModalWindow(string titleContains)
    {
        var elements = window.FindAllChildren(cf => cf.ByControlType(ControlType.Window));
        var windows = elements.Select(element => new Window(element.FrameworkAutomationElement));

        return windows.Single(w => w.Title.Contains(titleContains));
    }
}