using System.Windows;
using WinMessageBox = System.Windows.MessageBox;

namespace MvvmDialogs.FrameworkDialogs.MessageBox
{
    /// <summary>
    /// Settings for <see cref="WinMessageBox"/>.
    /// </summary>
    public class MessageBoxSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="string"/> that specifies the text to display.
        /// </summary>
        public string MessageBoxText { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="string"/> that specifies the title bar caption to display.
        /// Default value is an empty string.
        /// </summary>
        public string Caption { get; set; } = "";

        /// <summary>
        /// Gets or sets the <see cref="MessageBoxButton"/> value that specifies which button or
        /// buttons to display. Default value is <see cref="MessageBoxButton.OK"/>.
        /// </summary>
        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;

        /// <summary>
        /// Gets or sets the <see cref="MessageBoxImage"/> value that specifies the icon to
        /// display. Default value is <see cref="MessageBoxImage.None"/>.
        /// </summary>
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        /// <summary>
        /// Gets or sets the <see cref="MessageBoxResult"/> value that specifies the default result
        /// of the message box. Default value is <see cref="MessageBoxResult.None"/>.
        /// </summary>
        public MessageBoxResult DefaultResult { get; set; } = MessageBoxResult.None;
    }
}
