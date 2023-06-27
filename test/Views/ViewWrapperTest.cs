//using System.Threading;
//using System.Windows;

//namespace MvvmDialogs.Views
//{
//    [Apartment(ApartmentState.STA)]
//    public class ViewWrapperTest
//    {
//        [Fact]
//        public void Source()
//        {
//            // Arrange
//            var frameworkElement = new FrameworkElement();
//            var viewWrapper = new ViewWrapper(frameworkElement);

//            // Assert
//            Assert.That(viewWrapper.Source, Is.EqualTo(frameworkElement));
//        }

//        [Fact]
//        public void GetHashCodeOverride()
//        {
//            // Arrange
//            var frameworkElement = new FrameworkElement();

//            var viewWrapperA = new ViewWrapper(frameworkElement);
//            var viewWrapperB = new ViewWrapper(frameworkElement);

//            // Act
//            int hashCodeA = viewWrapperA.GetHashCode();
//            int hashCodeB = viewWrapperB.GetHashCode();

//            // Assert
//            Assert.That(hashCodeA, Is.EqualTo(hashCodeB));
//        }

//        [Fact]
//        public void EqualsOverride()
//        {
//            // Arrange
//            var frameworkElement = new FrameworkElement();

//            var viewWrapperA = new ViewWrapper(frameworkElement);
//            var viewWrapperB = new ViewWrapper(frameworkElement);

//            // Act
//            bool equals = viewWrapperA.Equals(viewWrapperB);

//            // Assert
//            Assert.That(equals, Is.True);
//        }
//    }
//}
