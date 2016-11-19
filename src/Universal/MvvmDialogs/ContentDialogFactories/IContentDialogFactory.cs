using System;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs.ContentDialogFactories
{
    /// <summary>
    /// Interface responsible for creating content dialogs.
    /// </summary>
    public interface IContentDialogFactory
    {
        /// <summary>
        /// Creates a <see cref="ContentDialog"/> of specified type.
        /// </summary>
        ContentDialog Create(Type dialogType);
    }
}