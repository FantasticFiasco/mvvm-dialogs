using System;
using Windows.Foundation;
using Windows.UI.Xaml;
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
            if (contentDialog == null)
                throw new ArgumentNullException(nameof(contentDialog));

            this.contentDialog = contentDialog;
        }

        /// <summary>
        /// Gets or sets the data context for a <see cref="FrameworkElement"/> when it participates
        /// in data binding.
        /// </summary>
        public object DataContext
        {
            get { return contentDialog.DataContext; }
            set { contentDialog.DataContext = value; }
        }

        /// <summary>
        /// Begins an asynchronous operation to show the dialog.
        /// </summary>
        /// <returns>
        /// An asynchronous operation showing the dialog. When complete, returns a
        /// <see cref="ContentDialogResult"/>.
        /// </returns>
        public IAsyncOperation<ContentDialogResult> ShowAsync()
        {
            return contentDialog.ShowAsync();
        }
    }
}
