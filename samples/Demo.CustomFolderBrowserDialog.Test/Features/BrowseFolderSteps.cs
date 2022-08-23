using System.IO;
using System.Reflection;
using Demo.CustomFolderBrowserDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;

namespace Demo.CustomFolderBrowserDialog.Features
{
    [Binding]
    public class BrowseFolderSteps : FeatureSteps<MainScreen>
    {
        private BrowseFolderScreen? browseFolderScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Demo.CustomFolderBrowserDialog.exe");

            return Application.Launch(applicationFilePath);
        }

        protected override MainScreen GetMainScreen(ScreenRepository screenRepository)
        {
            return screenRepository.Get<MainScreen>("Demo - Custom Folder Browser Dialog", InitializeOption.NoCache);
        }

        [Given("I have browsed a folder")]
        public void GivenIHaveBrowsedAFolder()
        {
            browseFolderScreen = MainScreen!.ClickBrowse();
        }
        
        [When("I press confirm")]
        public void WhenIPressConfirm()
        {
            browseFolderScreen!.ClickSelectFolder();
        }
        
        [When("I cancel")]
        public void WhenICancel()
        {
            browseFolderScreen!.ClickCancel();
        }
        
        [Then("the folder should be opened")]
        public void ThenTheFolderShouldBeOpened()
        {
            Assert.That(MainScreen!.FileName, Is.Not.Empty);
        }
        
        [Then("the folder should not be opened")]
        public void ThenTheFolderShouldNotBeOpened()
        {
            Assert.That(MainScreen!.FileName, Is.Empty);
        }
    }
}
