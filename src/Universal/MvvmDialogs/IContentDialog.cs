using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs
{
    /// <summary>
    /// Interface describing a content dialog.
    /// </summary>
    /// <remarks>
    /// This interface is intended for use when custom content dialogs, i.e. dialogs not inheriting
    /// from <see cref="ContentDialog"/>, should be shown.
    /// </remarks>
    public interface IContentDialog
    {
        /// <summary>
        /// Gets or sets the data context for a <see cref="FrameworkElement"/> when it participates
        /// in data binding.
        /// </summary>
        object DataContext { get; set; }

        /// <summary>
        /// Begins an asynchronous operation to show the dialog.
        /// </summary>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult"/>.
        /// </returns>
        IAsyncOperation<ContentDialogResult> ShowAsync();
    }
}
