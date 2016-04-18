// ReSharper disable once CheckNamespace
namespace System.Windows
{
    /// <summary>
    /// Extension methods for <see cref="FrameworkElement"/>.
    /// </summary>
    internal static class FrameworkElementExtensions
    {
        /// <summary>
        /// Gets the owning <see cref="Window"/> of a <see cref="FrameworkElement"/>.
        /// </summary>
        /// <param name="frameworkElement">
        /// The <see cref="FrameworkElement"/> to find the <see cref="Window"/> for.
        /// </param> 
        /// <returns>The owning <see cref="Window"/> if found; otherwise null.</returns>
        internal static Window GetOwner(this FrameworkElement frameworkElement) =>
            frameworkElement as Window ?? Window.GetWindow(frameworkElement);
    }
}