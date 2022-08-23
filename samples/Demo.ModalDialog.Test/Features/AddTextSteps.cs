using System.IO;
using System.Reflection;
using Demo.ModalDialog.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;

namespace Demo.ModalDialog.Features
{
    [Binding]
    public class AddTextSteps : FeatureSteps<MainScreen>
    {
        private AddTextScreen? addTextScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Demo.ModalDialog.exe");

            return Application.Launch(applicationFilePath);
        }

        protected override MainScreen GetMainScreen(ScreenRepository screenRepository)
        {
            return ScreenRepository!.Get<MainScreen>("Demo - Modal Dialog", InitializeOption.NoCache);
        }

        [Given("dialog is shown using the dialog type locator")]
        public void ShowDialogUsingDialogTypeLocator()
        {
            addTextScreen = MainScreen!.ClickAddTextUsingDialogTypeLocator();
        }

        [Given("dialog is shown by specifying dialog type")]
        public void ShowDialogBySpecifyingType()
        {
            addTextScreen = MainScreen!.ClickAddTextBySpecifyingDialogType();
        }

        [When(@"I enter the text (.*)")]
        public void Enter(string text)
        {
            addTextScreen!.Text = text;
        }

        [When("accept")]
        public void Accept()
        {
            addTextScreen!.ClickOK();
        }

        [When("abort")]
        public void Abort()
        {
            addTextScreen!.ClickCancel();
        }

        [Then("the list of texts should contain (.*)")]
        public void VerifyListContains(string text)
        {
            CollectionAssert.AreEqual(new[] { text }, MainScreen!.Texts);
        }

        [Then("the list of texts should be empty")]
        public void VerifyListIsEmpty()
        {
            CollectionAssert.AreEqual(new string[0], MainScreen!.Texts);
        }
    }
}
