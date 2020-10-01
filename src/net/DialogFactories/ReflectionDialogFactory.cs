using System;
using System.Windows;

namespace MvvmDialogs.DialogFactories
{
    /// <summary>
    /// Class responsible for creating dialogs using reflection.
    /// </summary>
    public class ReflectionDialogFactory : IDialogFactory
    {
        /// <inheritdoc />
        public IWindow Create(Type dialogType)
        {
            if (dialogType == null) throw new ArgumentNullException(nameof(dialogType));

            var instance = Activator.CreateInstance(dialogType);

            return instance switch
            {
                IWindow customDialog => customDialog,
                Window dialog => new WindowWrapper(dialog),
                _ => throw new ArgumentException($"Only dialogs of type {typeof(Window)} or {typeof(IWindow)} are supported.")
            };
        }
    }
}
