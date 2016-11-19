using System;
using System.Windows;
using System.Windows.Controls;

namespace MvvmDialogs.DialogFactories
{
    /// <summary>
    /// Class wrapping an instance of <see cref="Window"/> in <see cref="IWindow"/>.
    /// </summary>
    /// <seealso cref="IWindow" />
    public class WindowWrapper : IWindow
    {
        private readonly Window window;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowWrapper"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public WindowWrapper(Window window)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));

            this.window = window;
        }

        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        public object DataContext
        {
            get { return window.DataContext; }
            set { window.DataContext = value; }
        }

        /// <summary>
        /// Gets or sets the dialog result value, which is the value that is returned from the
        /// <see cref="ShowDialog" /> method.
        /// </summary>
        /// <value>
        /// The default is false.
        /// </value>
        public bool? DialogResult
        {
            get { return window.DialogResult; }
            set { window.DialogResult = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="ContentControl"/> that owns this <see cref="IWindow"/>.
        /// </summary>
        public ContentControl Owner
        {
            get { return window.Owner; }
            set { window.Owner = (Window)value; }
        }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns>
        /// A <see cref="Nullable{Boolean}"/> value that specifies whether the activity was
        /// accepted (true) or canceled (false). The return value is the value of the
        /// <see cref="DialogResult"/> property before a window closes.
        /// </returns>
        public bool? ShowDialog()
        {
            return window.ShowDialog();
        }

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        public void Show()
        {
            window.Show();
        }
    }
}
