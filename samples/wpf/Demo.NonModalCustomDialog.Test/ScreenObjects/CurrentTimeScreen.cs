using FlaUI.Core;
using FlaUI.Core.AutomationElements;

namespace Demo.NonModalCustomDialog.ScreenObjects
{
    public class CurrentTimeScreen : Window
    {
        private readonly Label? currentTime = null;

        public CurrentTimeScreen(FrameworkAutomationElementBase frameworkAutomationElement)
            : base(frameworkAutomationElement)
        {
            currentTime = FindFirstDescendant(cf => cf.ByAutomationId("n_Mu0TdFak-4VJD8RosMEQ")).AsLabel();
        }

        public virtual bool CurrentTimeVisible => currentTime!.IsAvailable;
    }
}
