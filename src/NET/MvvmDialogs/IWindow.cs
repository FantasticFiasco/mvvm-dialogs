using System;
using System.Windows;

namespace MvvmDialogs
{
    /// <summary>
    /// Interface describing a window.
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Gets or sets the dialog result value, which is the value that is returned from the
        /// <see cref="Window.ShowDialog" /> method.
        /// </summary>
        /// <value>
        /// The default is false.
        /// </value>
        /// <exception cref="InvalidOperationException">
        /// DialogResult is set before a window is opened by calling
        /// <see cref="Window.ShowDialog"/>.
        /// <para />
        /// -or-
        /// <para />
        /// DialogResult is set on a window that is opened by calling <see cref="Window.Show"/>.
        /// </exception>
        bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Window"/> that owns this <see cref="Window"/>.
        /// </summary>
        Window Owner { get; set; }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        /// A <see cref="Nullable{Boolean}"/> value that specifies whether the activity was
        /// accepted (true) or canceled (false). The return value is the value of the
        /// <see cref="DialogResult"/> property before a window closes.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// ShowDialog is called on a Window that is visible
        /// <para />
        /// -or-
        /// <para />
        /// ShowDialog is called on a visible <see cref="Window"/> that was opened by calling ShowDialog.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// ShowDialog is called on a window that is closing (<see cref="Window.Closing"/>) or has
        /// been closed (<see cref="Window.Closed"/>).
        /// </exception>
        bool? ShowDialog();

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Show is called on a window that is closing (<see cref="Window.Closing"/>) or has
        /// been closed (<see cref="Window.Closed"/>).
        /// </exception>
        void Show();
    }
}
