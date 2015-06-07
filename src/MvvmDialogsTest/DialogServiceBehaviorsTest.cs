using System.Windows;
using Moq;
using MvvmDialogs.Views;
using NUnit.Framework;

namespace MvvmDialogs
{
// ReSharper disable UnusedVariable
    [TestFixture]
    [RequiresSTA]
    public class DialogServiceBehaviorsTest
    {
        [TearDown]
        public void TearDown()
        {
            DialogServiceBehaviors.Clear();
        }

        [Test]
        public void RegisterWindowUsingAttachedProperty()
        {
            // ARRANGE
            var window = new Window();

            var expected = new[]
            {
                new ViewWrapper(window)
            };

            // ACT
            window.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, true);
            
            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWindowUsingAttachedProperty()
        {
            // ARRANGE
            var window = new Window();
            window.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, true);
            
            // ACT
            window.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, false);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void RegisterFrameworkElementUsingAttachedProperty()
        {
            // ARRANGE
            var frameworkElement = new FrameworkElement();
            
            var window = new Window
            {
                Content = frameworkElement
            };

            var expected = new[]
            {
                new ViewWrapper(frameworkElement)
            };

            // ACT
            frameworkElement.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, true);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterFrameworkElementUsingAttachedProperty()
        {
            // ARRANGE
            var frameworkElement = new FrameworkElement();
            

            var window = new Window
            {
                Content = frameworkElement
            };

            frameworkElement.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, true);
            
            // ACT
            frameworkElement.SetValue(DialogServiceBehaviors.IsRegisteredViewProperty, false);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void RegisterLoadedView()
        {
            // ARRANGE
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new Window());

            var expected = new[]
            {
                view.Object
            };
            
            // ACT
            DialogServiceBehaviors.Register(view.Object);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterLoadedView()
        {
            // ARRANGE
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new Window());

            DialogServiceBehaviors.SetIsRegisteredView(view.Object, true);

            // ACT
            DialogServiceBehaviors.SetIsRegisteredView(view.Object, false);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatNeverGetsLoaded()
        {
            // ARRANGE
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            
            // ACT
            DialogServiceBehaviors.Register(view.Object);

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatGetsLoaded()
        {
            // ARRANGE
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            
            // At time of register the view has no parent, thus is not loaded
            DialogServiceBehaviors.Register(view.Object);

            // After register we can simulate that the view gets loaded
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new Window());

            var expected = new[]
            {
                view.Object
            };

            // ACT
            view.Raise(mock => mock.Loaded += null, new RoutedEventArgs(null, view.Object));

            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWhenClosingOwner()
        {
            // ARRANGE
            var window = new Window();

            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(window);

            DialogServiceBehaviors.Register(view.Object);

            // ACT
            window.Close();
            
            // ASSERT
            Assert.That(DialogServiceBehaviors.Views, Is.Empty);
        }

        #region Helper classes

// ReSharper disable once MemberCanBePrivate.Global
        public abstract class FrameworkElementMock : FrameworkElement, IView
        {
            new public abstract event RoutedEventHandler Loaded;

            public abstract FrameworkElement Source { get; }

            new public abstract object DataContext { get; }

            public abstract bool IsAlive { get; }

            public abstract Window GetOwner();
        }

        #endregion
    }
// ReSharper restore UnusedVariable
}