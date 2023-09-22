using System;
using System.Windows;

namespace MvvmDialogs.Views;

/// <summary>
/// Wraps <see cref="FrameworkElement"/> objects for the properties needed.
/// </summary>
public class ViewWrapper : IView
{
    private readonly WeakReference viewReference;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewWrapper"/> class.
    /// </summary>
    /// <param name="view"><see cref="FrameworkElement"/> that makes up the view.</param>
    /// <exception cref="ArgumentNullException" />
    public ViewWrapper(FrameworkElement view)
    {
        if (view == null) throw new ArgumentNullException(nameof(view));

        viewReference = new WeakReference(view);
    }


    /// <inheritdoc />
    public event RoutedEventHandler Loaded
    {
        add => Source.Loaded += value;
        remove => Source.Loaded -= value;
    }


    /// <inheritdoc />
    public int Id { get; } = IdGenerator.Generate();


    /// <inheritdoc />
    /// <exception cref="InvalidOperationException" />
    public FrameworkElement Source
    {
        get
        {
            if (!IsAlive) throw new InvalidOperationException("View has been garbage collected.");
            if (viewReference.Target == null) throw new InvalidOperationException("View has been set to null.");

            return (FrameworkElement)viewReference.Target;
        }
    }

    /// <inheritdoc />
    public object DataContext => Source.DataContext;

    /// <inheritdoc />
    public bool IsAlive => viewReference.IsAlive;


    /// <inheritdoc />
    public Window GetOwner() => Source.GetOwner();


    /// <summary>
    /// GetHashCode override based on the Source property
    /// </summary>
    /// <returns>HashCode of Source property</returns>
    public override int GetHashCode() => Source.GetHashCode();


    /// <summary>
    /// Equals Override comparing the Source property
    /// </summary>
    /// <param name="obj">Object of type <see cref="ViewWrapper"/></param>
    /// <returns>True if the object is the same</returns>
    public override bool Equals(object? obj)
    {
        if (!(obj is ViewWrapper other))
            return false;

        return Source.Equals(other.Source);
    }
}
