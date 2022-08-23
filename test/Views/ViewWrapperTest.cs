using System.Threading;
using System.Windows;
using NUnit.Framework;

namespace MvvmDialogs.Views
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class ViewWrapperTest
    {
        [Test]
        public void Source()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();
            var viewWrapper = new ViewWrapper(frameworkElement);

            // Assert
            Assert.That(viewWrapper.Source, Is.EqualTo(frameworkElement));
        }

        [Test]
        public void GetHashCodeOverride()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();

            var viewWrapperA = new ViewWrapper(frameworkElement);
            var viewWrapperB = new ViewWrapper(frameworkElement);

            // Act
            int hashCodeA = viewWrapperA.GetHashCode();
            int hashCodeB = viewWrapperB.GetHashCode();

            // Assert
            Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
        }

        [Test]
        public void EqualsOverride()
        {
            // Arrange
            var frameworkElement = new FrameworkElement();

            var viewWrapperA = new ViewWrapper(frameworkElement);
            var viewWrapperB = new ViewWrapper(frameworkElement);

            // Act
            bool equals = viewWrapperA.Equals(viewWrapperB);

            // Assert
            Assert.That(equals, Is.True);
        }
    }
}
