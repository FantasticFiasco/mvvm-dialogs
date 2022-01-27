using System.IO;
using System.Reflection;
using Demo.OpenFileDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;

namespace Demo.OpenFileDialog.Features
{
    [Binding]
    public class OpenFileSteps : FeatureSteps<MainScreen>
    {
        private OpenFileScreen? openFileScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Demo.OpenFileDialog.exe");

            return Application.Launch(applicationFilePath);
        }

        protected override MainScreen GetMainScreen(ScreenRepository screenRepository)
        {
            return ScreenRepository!.Get<MainScreen>("Demo - Open File Dialog", InitializeOption.NoCache);
        }

        [Given("I have selected to open a file")]
        public void OpenFile()
        {
            openFileScreen = MainScreen!.ClickOpen();
            openFileScreen.FileName = "OpenMe.txt";
        }

        [When("I press confirm")]
        public void Confirm()
        {
            openFileScreen!.ClickOpen();
        }

        [When("I cancel")]
        public void Cancel()
        {
            openFileScreen!.ClickCancel();
        }

        [Then("the file should be opened")]
        public void VerifyFileWasOpened()
        {
            StringAssert.EndsWith("OpenMe.txt", MainScreen!.FileName);
        }

        [Then("the file should not be opened")]
        public void VerifyFileWasNotOpened()
        {
            Assert.That(MainScreen!.FileName, Is.Empty);
        }
    }
}
