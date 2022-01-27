using System.Collections.Generic;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.ScreenObjects.ScreenAttributes;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace Demo.ModalCustomDialog.ScreenObjects
{
    public class MainScreen : AppScreen
    {
        [AutomationId("Vfkrmkr640yWmoMTKUWIbQ")]
        private readonly ListBox? texts = null;

        [AutomationId("FHE_oyWqBEq_9TPaU1yPTQ")]
        private readonly Button? addTextUsingDialogTypeLocatorButton = null;

        [AutomationId("Dq9ZjnVdFESxu8StkQ8jMw")]
        private readonly Button? addTextBySpecifyingDialogTypeButton = null;

        public MainScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual IEnumerable<string> Texts
        {
            get { return texts!.Items.Select(item => item.Text); }
        }

        public virtual AddTextScreen ClickAddTextUsingDialogTypeLocator()
        {
            addTextUsingDialogTypeLocatorButton!.Click();
            return ScreenRepository.GetModal<AddTextScreen>("Add Text", Window, InitializeOption.NoCache);
        }

        public virtual AddTextScreen ClickAddTextBySpecifyingDialogType()
        {
            addTextBySpecifyingDialogTypeButton!.Click();
            return ScreenRepository.GetModal<AddTextScreen>("Add Text", Window, InitializeOption.NoCache);
        }
    }
}
