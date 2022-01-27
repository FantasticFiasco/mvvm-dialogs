using System.IO;
using System.Reflection;
using Demo.MessageBox.ScreenObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestBaseClasses.Features;
using FlaUI.Core;

namespace Demo.MessageBox.Features
{
    [Binding]
    public class ConfirmationSteps : FeatureSteps<MainScreen>
    {
        private MessageBoxScreen? messageBoxScreen;

        protected override Application LaunchApplication()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            string applicationFilePath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "Demo.MessageBox.exe");

            return Application.Launch(applicationFilePath);
        }


        [Given("confirmation with text is shown")]
        public void ShowConfirmationWithText()
        {
            messageBoxScreen = MainScreen.ClickMessageBoxWithMessage();

            Assert.That(messageBoxScreen.Caption, Is.Empty);
            Assert.That(messageBoxScreen.Message, Is.EqualTo("This is the text."));
            Assert.That(messageBoxScreen.IsIconVisible, Is.False);
            Assert.That(messageBoxScreen.IsOKButtonVisible, Is.True);
            Assert.That(messageBoxScreen.IsCancelButtonVisible, Is.False);
        }

        [Given("confirmation with text and caption is shown")]
        public void ShowConfirmationWithTextAndCaption()
        {
            messageBoxScreen = MainScreen.ClickMessageBoxWithCaption();

            Assert.That(messageBoxScreen.Caption, Is.EqualTo("This Is The Caption"));
            Assert.That(messageBoxScreen.Message, Is.EqualTo("This is the text."));
            Assert.That(messageBoxScreen.IsIconVisible, Is.False);
            Assert.That(messageBoxScreen.IsOKButtonVisible, Is.True);
            Assert.That(messageBoxScreen.IsCancelButtonVisible, Is.False);
        }

        [Given("confirmation with text, caption and option to cancel is shown")]
        public void ShowConfirmationWithTextCaptionAndOptionToCancel()
        {
            messageBoxScreen = MainScreen.ClickMessageBoxWithButtons();

            Assert.That(messageBoxScreen.Caption, Is.EqualTo("This Is The Caption"));
            Assert.That(messageBoxScreen.Message, Is.EqualTo("This is the text."));
            Assert.That(messageBoxScreen.IsIconVisible, Is.False);
            Assert.That(messageBoxScreen.IsOKButtonVisible, Is.True);
            Assert.That(messageBoxScreen.IsCancelButtonVisible, Is.True);
        }


        [Given("confirmation with text, caption, icon and option to cancel is shown")]
        public void ShowConfirmationWithTextCaptionAndIcon()
        {
            messageBoxScreen = MainScreen.ClickMessageBoxWithIcon();

            Assert.That(messageBoxScreen.Caption, Is.EqualTo("This Is The Caption"));
            Assert.That(messageBoxScreen.Message, Is.EqualTo("This is the text."));
            Assert.That(messageBoxScreen.IsIconVisible, Is.True);
            Assert.That(messageBoxScreen.IsOKButtonVisible, Is.True);
            Assert.That(messageBoxScreen.IsCancelButtonVisible, Is.True);
        }

        [Given("confirmation with text, caption, icon, default choice and option to cancel is shown")]
        public void ShowConfirmationWithTextCaptionIconAndDefaultChoice()
        {
            messageBoxScreen = MainScreen.ClickMessageBoxWithDefaultResult();

            Assert.That(messageBoxScreen.Caption, Is.EqualTo("This Is The Caption"));
            Assert.That(messageBoxScreen.Message, Is.EqualTo("This is the text."));
            Assert.That(messageBoxScreen.IsIconVisible, Is.True);
            Assert.That(messageBoxScreen.IsOKButtonVisible, Is.True);
            Assert.That(messageBoxScreen.IsCancelButtonVisible, Is.True);
        }

        [When("I confirm")]
        public void WhenIConfirm()
        {
            messageBoxScreen!.ClickOK();
        }

        [When("I cancel")]
        public void WhenICancel()
        {
            messageBoxScreen!.ClickCancel();
        }

        [Then("the confirmation should be acted on")]
        public void VerifyThatConfirmationWasActedOn()
        {
            Assert.That(MainScreen.Confirmation, Is.EqualTo("We got confirmation to continue!"));
        }

        [Then("the cancellation should be respected")]
        public void VerifyThatCancellationWasRespected()
        {
            Assert.That(MainScreen.Confirmation, Is.Empty);
        }
    }
}
