using System;

namespace MvvmDialogs.DialogFactories
{
    /// <summary>
    /// Interface responsible for creating dialogs.
    /// </summary>
    public interface IDialogFactory
    {
        /// <summary>
        /// Creates a <see cref="IWindow"/> of specified type.
        /// </summary>
        IWindow Create(Type dialogType);
    }
}
