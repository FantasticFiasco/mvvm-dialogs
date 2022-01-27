using System.IO;
using System.Reflection;
using Demo.NonModalDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using FlaUI.Core;
using System.Linq;
using FlaUI.Core.AutomationElements;

namespace Demo.NonModalDialog.Features
{
    [Binding]
    public class ShowCurrentTimeSteps : FeatureSteps<MainScreen>
    {
        private CurrentTimeScreen? currentTimeScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "Demo.NonModalDialog.exe");

            return Application.Launch(applicationFilePath);
        }


        [When("dialog is shown using the dialog type locator")]
        public void WhenDialogIsShownUsingTheDialogTypeLocator()
        {
            currentTimeScreen = MainScreen.ClickShowCurrentTimeUsingDialogTypeLocator();
        }

        [When("dialog is shown by specifying dialog type")]
        public void WhenDialogIsShownBySpecifyingDialogType()
        {
            currentTimeScreen = MainScreen.ClickShowCurrentTimeBySpecifyingDialogType();
        }

        [Then("the current time should be displayed")]
        public void VerifyCurrentTimeIsDisplayed()
        {
            Assert.That(currentTimeScreen!.CurrentTimeVisible, Is.True);
        }
    }
}
