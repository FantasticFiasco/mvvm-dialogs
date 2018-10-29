using System;
using System.Windows;
using MvvmDialogs.FrameworkDialogs.MessageBox;
using Ookii.Dialogs.Wpf;

namespace Demo.CustomMessageBox
{
    public class CustomMessageBox : IMessageBox
    {
        private readonly MessageBoxSettings settings;
        private readonly TaskDialog messageBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        public CustomMessageBox(MessageBoxSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));

            messageBox = new TaskDialog
            {
                Content = settings.MessageBoxText
            };

            SetUpTitle();
            SetUpButtons();
            SetUpIcon();
        }

        /// <summary>
        /// Opens a message box with specified owner.
        /// </summary>
        /// <param name="owner">
        /// Handle to the window that owns the dialog.
        /// </param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        public MessageBoxResult Show(Window owner)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));

            var result = messageBox.ShowDialog(owner);
            return ToMessageBoxResult(result);
        }

        private void SetUpTitle()
        {
            messageBox.WindowTitle = string.IsNullOrEmpty(settings.Caption) ?
                " " :
                settings.Caption;
        }

        private void SetUpButtons()
        {
            switch (settings.Button)
            {
                case MessageBoxButton.OKCancel:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Ok));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    break;

                case MessageBoxButton.YesNo:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Yes));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.No));
                    break;

                case MessageBoxButton.YesNoCancel:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Yes));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.No));
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    break;

                default:
                    messageBox.Buttons.Add(new TaskDialogButton(ButtonType.Ok));
                    break;
            }
        }

        private void SetUpIcon()
        {
            switch (settings.Icon)
            {
                case MessageBoxImage.Error:
                    messageBox.MainIcon = TaskDialogIcon.Error;
                    break;

                case MessageBoxImage.Information:
                    messageBox.MainIcon = TaskDialogIcon.Information;
                    break;

                case MessageBoxImage.Warning:
                    messageBox.MainIcon = TaskDialogIcon.Warning;
                    break;

                default:
                    messageBox.MainIcon = TaskDialogIcon.Custom;
                    break;
            }
        }

        private static MessageBoxResult ToMessageBoxResult(TaskDialogButton button)
        {
            switch (button.ButtonType)
            {
                case ButtonType.Cancel:
                    return MessageBoxResult.Cancel;

                case ButtonType.No:
                    return MessageBoxResult.No;

                case ButtonType.Ok:
                    return MessageBoxResult.OK;

                case ButtonType.Yes:
                    return MessageBoxResult.Yes;

                default:
                    return MessageBoxResult.None;
            }
        }
    }
}
