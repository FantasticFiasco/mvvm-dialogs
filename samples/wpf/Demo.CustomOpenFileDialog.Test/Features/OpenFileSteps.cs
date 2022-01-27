using System.IO;
using System.Reflection;
using Demo.CustomOpenFileDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using FlaUI.Core;

namespace Demo.CustomOpenFileDialog.Features
{
    [Binding]
    public class OpenFileSteps : FeatureSteps<MainScreen>
    {
        private OpenFileScreen? openFileScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "Demo.CustomOpenFileDialog.exe");

            return Application.Launch(applicationFilePath);
        }


        [Given("I have selected to open a file")]
        public void OpenFile()
        {
            openFileScreen = MainScreen.ClickOpen();
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
            StringAssert.EndsWith("OpenMe.txt", MainScreen.FileName);
        }

        [Then("the file should not be opened")]
        public void VerifyFileWasNotOpened()
        {
            Assert.That(MainScreen.FileName, Is.Empty);
        }
    }
}
