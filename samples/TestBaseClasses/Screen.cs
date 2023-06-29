using FlaUI.Core.AutomationElements;

namespace TestBaseClasses
{
    public abstract class Screen
    {
        protected readonly Window Window;

        protected Screen(Window window) => Window = window;

        protected Button ButtonByAutomationId(string automationId) => Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsButton();
        protected Button ButtonByText(string text) => Window.FindFirstDescendant(cf => cf.ByText(text)).AsButton();
        protected ComboBox ComboBoxByAutomationId(string automationId) => Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsComboBox();
        protected Label LabelByAutomationId(string automationId) => Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsLabel();
        protected ListBox ListBoxByAutomationId(string automationId) => Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsListBox();
        protected TextBox TextBoxByAutomationId(string automationId) => Window.FindFirstDescendant(cf => cf.ByAutomationId(automationId)).AsTextBox();
    }
}
