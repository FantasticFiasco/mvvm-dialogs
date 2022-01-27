using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.ModalDialog.ScreenObjects
{
    public class AddTextScreen : Window
    {
        private readonly TextBox? text = null;

        private readonly Button? okButton = null;

        private readonly Button? cancelButton = null;

        public AddTextScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            text = FindFirstDescendant(cf => cf.ByAutomationId("Csl8dP93gUGQLj7rVZxDAg")).AsTextBox();
            okButton = FindFirstDescendant(cf => cf.ByAutomationId("eyRW_87u20qR7QTCypm2RQ")).AsButton();
            cancelButton = FindFirstDescendant(cf => cf.ByAutomationId("I91auHr_EECzhSZyIfvvzQ")).AsButton();
        }

        public virtual string Text
        {
            set => text!.Text = value;
        }

        public virtual void ClickOK() => okButton!.Click();

        public virtual void ClickCancel() => cancelButton!.Click();
    }
}
