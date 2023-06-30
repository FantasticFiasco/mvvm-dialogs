using System.Windows;

namespace MvvmDialogs.Views;

public class ViewWrapperTest
{
    [StaFact]
    public void Source()
    {
        // Arrange
        var frameworkElement = new FrameworkElement();
        var viewWrapper = new ViewWrapper(frameworkElement);

        // Assert
        Assert.Equal(frameworkElement, viewWrapper.Source);
    }

    [StaFact]
    public void GetHashCodeOverride()
    {
        // Arrange
        var frameworkElement = new FrameworkElement();

        var viewWrapperA = new ViewWrapper(frameworkElement);
        var viewWrapperB = new ViewWrapper(frameworkElement);

        // Act
        var hashCodeA = viewWrapperA.GetHashCode();
        var hashCodeB = viewWrapperB.GetHashCode();

        // Assert
        Assert.Equal(hashCodeB, hashCodeA);
    }

    [StaFact]
    public void EqualsOverride()
    {
        // Arrange
        var frameworkElement = new FrameworkElement();

        var viewWrapperA = new ViewWrapper(frameworkElement);
        var viewWrapperB = new ViewWrapper(frameworkElement);

        // Act
        var equals = viewWrapperA.Equals(viewWrapperB);

        // Assert
        Assert.True(equals);
    }
}