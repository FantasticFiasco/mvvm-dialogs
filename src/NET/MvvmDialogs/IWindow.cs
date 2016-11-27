using System;
using System.Windows;
using System.Windows.Controls;

namespace MvvmDialogs
{
    /// <summary>
    /// Interface describing a window.
    /// </summary>
    /// <remarks>
    /// This interface is intended for use when custom windows, i.e. windows not inheriting from
    /// <see cref="Window"/>, should be shown.
    /// </remarks>
    public interface IWindow
    {
        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Gets or sets the dialog result value, which is the value that is returned from the
        /// <see cref="ShowDialog" /> method.
        /// </summary>
        /// <value>
        /// The default is false.
        /// </value>
        bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ContentControl"/> that owns this <see cref="IWindow"/>.
        /// </summary>
        ContentControl Owner { get; set; }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        /// A <see cref="Nullable{Boolean}"/> value that specifies whether the activity was
        /// accepted (true) or canceled (false). The return value is the value of the
        /// <see cref="DialogResult"/> property before a window closes.
        /// </returns>
        bool? ShowDialog();

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        void Show();
    }
}
