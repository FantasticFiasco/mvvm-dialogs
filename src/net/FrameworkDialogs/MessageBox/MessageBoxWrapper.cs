using System;
using System.Windows;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Class wrapping <see cref="System.Windows.MessageBox"/>.
    /// </summary>
    internal sealed class MessageBoxWrapper : IMessageBox
    {
        private readonly IMessageBoxShow messageBoxShow;
        private readonly MessageBoxSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxWrapper"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public MessageBoxWrapper(MessageBoxSettings settings)
            : this(new MessageBoxShow(), settings)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxWrapper"/> class.
        /// </summary>
        /// <param name="messageBoxShow">
        /// The interface responsible for showing the actual message box.
        /// </param>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public MessageBoxWrapper(IMessageBoxShow messageBoxShow, MessageBoxSettings settings)
        {
            this.messageBoxShow = messageBoxShow ?? throw new ArgumentNullException(nameof(messageBoxShow));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <inheritdoc />
        public MessageBoxResult Show(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            return messageBoxShow.Show(
                owner,
                settings.MessageBoxText,
                settings.Caption,
                settings.Button,
                settings.Icon,
                settings.DefaultResult,
                settings.Options);
        }
    }
}
