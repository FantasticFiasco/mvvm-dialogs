using System.Windows;
using NUnit.Framework;

namespace MvvmDialogs.Views
{
    [TestFixture]
    [RequiresSTA]
    public class ViewWrapperTest
    {
        private FrameworkElement frameworkElement;

        [SetUp]
        public void SetUp()
        {
            frameworkElement = new FrameworkElement();
        }

        [Test]
        public void Source()
        {
            // ARRANGE
            var viewWrapper = new ViewWrapper(frameworkElement);

            // ASSERT
            Assert.That(viewWrapper.Source, Is.EqualTo(frameworkElement));
        }

        [Test]
        public void GetHashCodeOverride()
        {
            // ARRANGE
            var viewWrapperA = new ViewWrapper(frameworkElement);
            var viewWrapperB = new ViewWrapper(frameworkElement);

            // ACT
            int hashCodeA = viewWrapperA.GetHashCode();
            int hashCodeB = viewWrapperB.GetHashCode();

            // ASSERT
            Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
        }

        [Test]
        public void EqualsOverride()
        {
            // ARRANGE
            var viewWrapperA = new ViewWrapper(frameworkElement);
            var viewWrapperB = new ViewWrapper(frameworkElement);

            // ACT
            bool equals = viewWrapperA.Equals(viewWrapperB);

            // ASSERT
            Assert.That(equals, Is.True);
        }
    }
}