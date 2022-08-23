using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.ModalCustomDialog.ScreenObjects
{
    public class AddTextScreen : AppScreen
    {
        [AutomationId("Csl8dP93gUGQLj7rVZxDAg")]
        private readonly TextBox? text = null;

        [AutomationId("eyRW_87u20qR7QTCypm2RQ")]
        private readonly Button? okButton = null;

        [AutomationId("I91auHr_EECzhSZyIfvvzQ")]
        private readonly Button? cancelButton = null;

        public AddTextScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual string Text
        {
            set => text!.Text = value;
        }

        public virtual void ClickOK() => okButton!.Click();

        public virtual void ClickCancel() => cancelButton!.Click();
    }
}
