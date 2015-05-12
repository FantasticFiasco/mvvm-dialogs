using System.Windows;
using NUnit.Framework;

namespace MvvmDialogs
{
    [TestFixture]
    [RequiresSTA]
// ReSharper disable UnusedVariable
    public class DialogServiceBehaviorsTest
    {
        [TearDown]
        public void TearDown()
        {
            DialogServiceBehaviors.Views.Clear();
        }

        [Test]
        public void RegisterWindow()
        {
            // ARRANGE
            var window = new Window();

            var expected = new[]
            {
                window
            };

            // ACT
            DialogServiceBehaviors.SetIsRegisteredView(window, true);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void RegisterFrameworkElement()
        {
            // ARRANGE
            var frameworkElement = new FrameworkElement();
            
            var window = new Window
            {
                Content = frameworkElement
            };

            var expected = new[]
            {
                frameworkElement
            };

            // ACT
            DialogServiceBehaviors.SetIsRegisteredView(frameworkElement, true);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void LateRegister()
        {
            // ARRANGE

            // ACT

            // ASSERT
            Assert.Fail();
        }

        [Test]
        public void UnregisterWindow()
        {
            // ARRANGE
            var window = new Window();
            
            DialogServiceBehaviors.SetIsRegisteredView(window, true);

            // ACT
            DialogServiceBehaviors.SetIsRegisteredView(window, false);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void UnregisterFrameworkElement()
        {
            // ARRANGE
            var frameworkElement = new FrameworkElement();

            var window = new Window
            {
                Content = frameworkElement
            };

            DialogServiceBehaviors.SetIsRegisteredView(frameworkElement, true);

            // ACT
            DialogServiceBehaviors.SetIsRegisteredView(frameworkElement, false);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void UnregisterWhenClosingOwner()
        {
            // ARRANGE

            // ACT

            // ASSERT
            Assert.Fail();
        }
    }
// ReSharper restore UnusedVariable
}