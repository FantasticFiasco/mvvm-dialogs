using System.Windows;

namespace MvvmDialogs.Views
{
    /// <summary>
    /// Interface describing a view in WPF.
    /// </summary>
    internal interface IView
    {
        /// <summary>
        /// Occurs when the view is laid out, rendered, and ready for interaction.
        /// </summary>
        event RoutedEventHandler Loaded;

        /// <summary>
        /// Gets the id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        FrameworkElement Source { get; }

        /// <summary>
        /// Gets the data context for an element when it participates in data binding.
        /// </summary>
        object DataContext { get; }

        /// <summary>
        /// Gets an indication whether the view been garbage collected.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Gets the owning <see cref="Window"/>.
        /// </summary>
        Window GetOwner();
    }
}
