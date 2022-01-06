using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs.ContentDialogFactories
{
    /// <summary>
    /// Class wrapping an instance of <see cref="ContentDialog"/> in <see cref="IContentDialog"/>.
    /// </summary>
    /// <seealso cref="IContentDialog" />
    public class ContentDialogWrapper : IContentDialog
    {
        private readonly ContentDialog contentDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentDialogWrapper"/> class.
        /// </summary>
        /// <param name="contentDialog">The content dialog.</param>
        public ContentDialogWrapper(ContentDialog contentDialog)
        {
            this.contentDialog = contentDialog ?? throw new ArgumentNullException(nameof(contentDialog));
        }

        /// <inheritdoc />
        public object DataContext
        {
            get => contentDialog.DataContext;
            set => contentDialog.DataContext = value;
        }

        /// <inheritdoc />
        public IAsyncOperation<ContentDialogResult> ShowAsync()
        {
            return contentDialog.ShowAsync();
        }
    }
}
