using System.IO;
using System.Reflection;
using Sample.NonModalDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;

namespace Sample.NonModalDialog.Features
{
    [Binding]
    public class ShowCurrentTimeSteps : FeatureSteps<MainScreen>
    {
        private CurrentTimeScreen currentTimeScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Sample.NonModalDialog.exe");

            return Application.Launch(applicationFilePath);
        }

        protected override MainScreen GetMainScreen(ScreenRepository screenRepository)
        {
            return ScreenRepository.Get<MainScreen>("Sample - Non-Modal Dialog", InitializeOption.NoCache);
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
            Assert.That(currentTimeScreen.CurrentTimeVisible, Is.True);
        }
    }
}
