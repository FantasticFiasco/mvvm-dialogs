using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.SaveFileDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly TextBox? pathTextBox = null;

        private readonly Button? saveButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            pathTextBox = FindFirstDescendant(cf => cf.ByAutomationId("-u3vcUdRMUaG4Af_kzSeZQ")).AsTextBox();
            saveButton = FindFirstDescendant(cf => cf.ByAutomationId("HstqC8HI9EOGiTfPA4_xag")).AsButton();
        }

        public virtual string? FileName => pathTextBox?.Text;

        public virtual SaveFileScreen ClickSave()
        {
            saveButton!.Click();
            return this.WaitForModalWindow<SaveFileScreen>("This Is The Title");
        }
    }
}
