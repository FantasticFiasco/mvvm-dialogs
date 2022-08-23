using System.IO;
using System.Reflection;
using Demo.SaveFileDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;

namespace Demo.SaveFileDialog.Features
{
    [Binding]
    public class SaveFileSteps : FeatureSteps<MainScreen>
    {
        private SaveFileScreen? saveFileScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Demo.SaveFileDialog.exe");

            return Application.Launch(applicationFilePath);
        }

        protected override MainScreen GetMainScreen(ScreenRepository screenRepository)
        {
            return ScreenRepository!.Get<MainScreen>("Demo - Save File Dialog", InitializeOption.NoCache);
        }

        [Given("I have selected to save a file")]
        public void SaveFile()
        {
            saveFileScreen = MainScreen!.ClickSave();
            saveFileScreen.FileName = "SaveMe.txt";
        }

        [When("I press confirm")]
        public void Confirm()
        {
            saveFileScreen!.ClickSave();
        }

        [When("I cancel")]
        public void Cancel()
        {
            saveFileScreen!.ClickCancel();
        }

        [Then("the file should be saved")]
        public void VerifyFileWasSaved()
        {
            StringAssert.EndsWith("SaveMe.txt", MainScreen!.FileName);
        }

        [Then("the file should not be saved")]
        public void VerifyFileWasNotSaved()
        {
            Assert.That(MainScreen!.FileName, Is.Empty);
        }
    }
}
