using System.Threading;
using System.Windows;
using Moq;
using MvvmDialogs.Views;
using NUnit.Framework;

namespace MvvmDialogs
{
    // ReSharper disable UnusedVariable
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class DialogServiceViewsTest
    {
        [TearDown]
        public void TearDown()
        {
            DialogServiceViews.Clear();
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
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWindowUsingAttachedProperty()
        {
            // ARRANGE
            var window = new Window();
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // ACT
            window.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.Empty);
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
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
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

            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // ACT
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.Empty);
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
            DialogServiceViews.Register(view.Object);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
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

            DialogServiceViews.SetIsRegistered(view.Object, true);

            // ACT
            DialogServiceViews.SetIsRegistered(view.Object, false);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.Empty);
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
            DialogServiceViews.Register(view.Object);

            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.Empty);
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
            DialogServiceViews.Register(view.Object);

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
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
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

            DialogServiceViews.Register(view.Object);

            // ACT
            window.Close();
            
            // ASSERT
            Assert.That(DialogServiceViews.Views, Is.Empty);
        }

        #region Helper classes

// ReSharper disable once MemberCanBePrivate.Global
        public abstract class FrameworkElementMock : FrameworkElement, IView
        {
            new public abstract event RoutedEventHandler Loaded;

            public abstract int Id { get; }

            public abstract FrameworkElement Source { get; }

            new public abstract object DataContext { get; }

            public abstract bool IsAlive { get; }

            public abstract Window GetOwner();
        }

        #endregion
    }
    // ReSharper restore UnusedVariable
}