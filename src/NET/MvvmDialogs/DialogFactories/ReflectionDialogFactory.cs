using System;
using System.Windows;

namespace MvvmDialogs.DialogFactories
{
    /// <summary>
    /// Class responsible for creating dialogs using reflection.
    /// </summary>
    public class ReflectionDialogFactory : IDialogFactory
    {
        /// <summary>
        /// Creates a <see cref="Window" /> of specified type using
        /// <see cref="Activator.CreateInstance(Type)"/>.
        /// </summary>
        public Window Create(Type dialogType)
        {
            if (dialogType == null)
                throw new ArgumentNullException(nameof(dialogType));

            return (Window)Activator.CreateInstance(dialogType);
        }
    }
}
