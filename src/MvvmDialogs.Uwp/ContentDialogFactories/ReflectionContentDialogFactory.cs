using System;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs.ContentDialogFactories
{
    /// <summary>
    /// Class responsible for creating content dialogs using reflection.
    /// </summary>
    public class ReflectionContentDialogFactory : IContentDialogFactory
    {
        /// <inheritdoc />
        public IContentDialog Create(Type dialogType)
        {
            if (dialogType == null) throw new ArgumentNullException(nameof(dialogType));

            var instance = Activator.CreateInstance(dialogType);

            // Is instance of type IContentDialog?
            if (instance is IContentDialog customContentDialog)
            {
                return customContentDialog;
            }

            // Is instance of type ContentDialog?
            if (instance is ContentDialog contentDialog)
            {
                return new ContentDialogWrapper(contentDialog);
            }

            throw new ArgumentException($"Only dialogs of type {typeof(ContentDialog)} or {typeof(IContentDialog)} are supported.");
        }
    }
}
