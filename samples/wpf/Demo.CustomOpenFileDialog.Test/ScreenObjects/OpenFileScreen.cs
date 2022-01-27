using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;

namespace Demo.CustomOpenFileDialog.ScreenObjects
{
    public class OpenFileScreen : Window
    {
        public OpenFileScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
        }

        public virtual string FileName
        {
            set => FindFirstDescendant(cf => cf.ByAutomationId("1148")).AsComboBox().EditableText = value;
        }

        public virtual void ClickOpen()
        {
            Keyboard.Type(VirtualKeyShort.RETURN);
        }

        public virtual void ClickCancel()
        {
            FindFirstDescendant(cf => cf.ByText("Cancel")).AsButton().Click();
        }
    }
}
