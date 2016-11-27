using System;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs.ContentDialogFactories
{
    /// <summary>
    /// Class responsible for creating content dialogs using reflection.
    /// </summary>
    public class ReflectionContentDialogFactory : IContentDialogFactory
    {
        /// <summary>
        /// Creates a <see cref="ContentDialog" /> of specified type using
        /// <see cref="Activator.CreateInstance(Type)"/>.
        /// </summary>
        public IContentDialog Create(Type dialogType)
        {
            if (dialogType == null)
                throw new ArgumentNullException(nameof(dialogType));

            var instance = Activator.CreateInstance(dialogType);

            // Is instance of type IContentDialog?
            IContentDialog customContentDialog = instance as IContentDialog;
            if (customContentDialog != null)
            {
                return customContentDialog;
            }

            // Is instance of type ContentDialog?
            var contentDialog = instance as ContentDialog;
            if (contentDialog != null)
            {
                return new ContentDialogWrapper(contentDialog);
            }

            throw new ArgumentException($"Only dialogs of type {typeof(ContentDialog)} or {typeof(IContentDialog)} are supported.");
        }
    }
}
