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
        public WindowWrapper(Window window) => this.window = window ?? throw new ArgumentNullException(nameof(window));

        /// <inheritdoc />
        public object DataContext
        {
            get => window.DataContext;
            set => window.DataContext = value;
        }

        /// <inheritdoc />
        public bool? DialogResult
        {
            get => window.DialogResult;
            set => window.DialogResult = value;
        }

        /// <inheritdoc />
        public ContentControl Owner
        {
            get => window.Owner;
            set => window.Owner = (Window)value;
        }

        /// <inheritdoc />
        public bool? ShowDialog() => window.ShowDialog();

        /// <inheritdoc />
        public void Show() => window.Show();
    }
}
