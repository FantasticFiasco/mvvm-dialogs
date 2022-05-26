using System.Collections.Generic;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using TestBaseClasses.Features;

namespace Demo.ModalCustomDialog.ScreenObjects
{
    public class MainScreen : Window
    {
        private readonly ListBox? texts = null;

        private readonly Button? addTextUsingDialogTypeLocatorButton = null;

        private readonly Button? addTextBySpecifyingDialogTypeButton = null;

        public MainScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            texts = FindFirstDescendant(cf => cf.ByAutomationId("Vfkrmkr640yWmoMTKUWIbQ")).AsListBox();
            addTextUsingDialogTypeLocatorButton = FindFirstDescendant(cf => cf.ByAutomationId("FHE_oyWqBEq_9TPaU1yPTQ")).AsButton();
            addTextBySpecifyingDialogTypeButton = FindFirstDescendant(cf => cf.ByAutomationId("Dq9ZjnVdFESxu8StkQ8jMw")).AsButton();
        }

        public virtual IEnumerable<string> Texts
        {
            get { return texts!.Items.Select(item => item.Text); }
        }

        public virtual AddTextScreen ClickAddTextUsingDialogTypeLocator()
        {
            addTextUsingDialogTypeLocatorButton!.Click();
            return this.WaitForModalWindow<AddTextScreen>("Add Text");
        }

        public virtual AddTextScreen ClickAddTextBySpecifyingDialogType()
        {
            addTextBySpecifyingDialogTypeButton!.Click();
            return this.WaitForModalWindow<AddTextScreen>("Add Text");
        }
    }
}
