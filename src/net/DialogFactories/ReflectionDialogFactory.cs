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
        public IWindow Create(Type dialogType)
        {
            if (dialogType == null)
                throw new ArgumentNullException(nameof(dialogType));

            var instance = Activator.CreateInstance(dialogType);

            // Is instance of type IWindow?
            IWindow customDialog = instance as IWindow;
            if (customDialog != null)
            {
                return customDialog;
            }

            // Is instance of type Window?
            var dialog = instance as Window;
            if (dialog != null)
            {
                return new WindowWrapper(dialog);
            }

            throw new ArgumentException($"Only dialogs of type {typeof(Window)} or {typeof(IWindow)} are supported.");
        }
    }
}
