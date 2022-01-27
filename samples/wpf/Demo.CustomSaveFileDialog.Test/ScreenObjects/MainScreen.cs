using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.CustomSaveFileDialog.ScreenObjects
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
            return this.GetModal<SaveFileScreen>("This Is The Title");
        }
    }
}
