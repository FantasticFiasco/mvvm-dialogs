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
            // Arrange
            var window = new Window();

            var expected = new[]
            {
                new ViewWrapper(window)
            };

            // Act
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // Assert
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWindowUsingAttachedProperty()
        {
            // Arrange
            var window = new Window();
            window.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // Act
            window.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.Empty);
        }

        [Test]
        public void RegisterFrameworkElementUsingAttachedProperty()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();
            
            var window = new Window
            {
                Content = frameworkElement
            };

            var expected = new[]
            {
                new ViewWrapper(frameworkElement)
            };

            // Act
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterFrameworkElementUsingAttachedProperty()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();
            

            var window = new Window
            {
                Content = frameworkElement
            };

            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, true);
            
            // Act
            frameworkElement.SetValue(DialogServiceViews.IsRegisteredProperty, false);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.Empty);
        }

        [Test]
        public void RegisterLoadedView()
        {
            // Arrange
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
            
            // Act
            DialogServiceViews.Register(view.Object);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterLoadedView()
        {
            // Arrange
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(new Window());

            DialogServiceViews.SetIsRegistered(view.Object, true);

            // Act
            DialogServiceViews.SetIsRegistered(view.Object, false);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatNeverGetsLoaded()
        {
            // Arrange
            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            
            // Act
            DialogServiceViews.Register(view.Object);

            // Assert
            Assert.That(DialogServiceViews.Views, Is.Empty);
        }

        [Test]
        public void RegisterViewThatGetsLoaded()
        {
            // Arrange
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

            // Act
            view.Raise(mock => mock.Loaded += null, new RoutedEventArgs(null, view.Object));

            // Assert
            Assert.That(DialogServiceViews.Views, Is.EqualTo(expected));
        }

        [Test]
        public void UnregisterWhenClosingOwner()
        {
            // Arrange
            var window = new Window();

            var view = new Mock<FrameworkElementMock>();
            view
                .Setup(mock => mock.IsAlive)
                .Returns(true);
            view
                .Setup(mock => mock.GetOwner())
                .Returns(window);

            DialogServiceViews.Register(view.Object);

            // Act
            window.Close();
            
            // Assert
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