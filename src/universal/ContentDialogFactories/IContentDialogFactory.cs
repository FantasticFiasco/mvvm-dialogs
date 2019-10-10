using System;

namespace MvvmDialogs.ContentDialogFactories
{
    /// <summary>
    /// Interface responsible for creating content dialogs.
    /// </summary>
    public interface IContentDialogFactory
    {
        /// <summary>
        /// Creates a <see cref="IContentDialog"/> of specified type.
        /// </summary>
        IContentDialog Create(Type dialogType);
    }
}
