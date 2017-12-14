﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.DialogFactories;
using MvvmDialogs.DialogTypeLocators;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.MessageBox;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using MvvmDialogs.Logging;
using MvvmDialogs.Reflection;
using MvvmDialogs.Views;

namespace MvvmDialogs
{
    /// <summary>
    /// Class abstracting the interaction between view models and views when it comes to
    /// opening dialogs using the MVVM pattern in WPF.
    /// </summary>
    public class DialogService : IDialogService
    {
        private static readonly string DialogResultPropertyName =
            Members.GetPropertyName((IModalDialogViewModel viewModel) => viewModel.DialogResult);

        private readonly IDialogFactory dialogFactory;
        private readonly IDialogTypeLocator dialogTypeLocator;
        private readonly IFrameworkDialogFactory frameworkDialogFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <remarks>
        /// By default <see cref="ReflectionDialogFactory"/> is used as dialog factory,
        /// <see cref="NamingConventionDialogTypeLocator"/> is used as dialog type locator
        /// and <see cref="DefaultFrameworkDialogFactory"/> is used as framework dialog factory.
        /// </remarks>
        public DialogService()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        /// <param name="dialogFactory">
        /// Factory responsible for creating dialogs. Default value is an instance of
        /// <see cref="ReflectionDialogFactory"/>.
        /// </param>
        /// <param name="dialogTypeLocator">
        /// Locator responsible for finding a dialog type matching a view model. Default value is
        /// an instance of <see cref="NamingConventionDialogTypeLocator"/>.
        /// </param>
        /// <param name="frameworkDialogFactory">
        /// Factory responsible for creating framework dialogs. Default value is an instance of
        /// <see cref="DefaultFrameworkDialogFactory"/>.
        /// </param>
        public DialogService(
            IDialogFactory dialogFactory = null,
            IDialogTypeLocator dialogTypeLocator = null,
            IFrameworkDialogFactory frameworkDialogFactory = null)
        {
            this.dialogFactory = dialogFactory ?? new ReflectionDialogFactory();
            this.dialogTypeLocator = dialogTypeLocator ?? new NamingConventionDialogTypeLocator();
            this.frameworkDialogFactory = frameworkDialogFactory ?? new DefaultFrameworkDialogFactory();
        }

        #region IDialogService Members

        /// <summary>
        /// Displays a non-modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public void Show<T>(
        INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : Window
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            Show(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a non-modal custom dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the custom dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new custom dialog.</param>
        /// <typeparam name="T">The type of the custom dialog to show.</typeparam>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public void ShowCustom<T>(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            Show(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a non-modal dialog of a type that is determined by the dialog type locator.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public void Show(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            Show(ownerViewModel, viewModel, dialogType);
        }

        /// <summary>
        /// Displays a modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <typeparam name="T">The type of the dialog to show.</typeparam>
        /// <returns>
        /// A nullable value of type <see cref="bool"/> that signifies how a window was closed by
        /// the user.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowDialog<T>(
        INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
            where T : Window
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a custom modal dialog of specified type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the custom dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new custom dialog.</param>
        /// <typeparam name="T">The type of the custom dialog to show.</typeparam>
        /// <returns>
        /// A nullable value of type <see cref="bool"/> that signifies how a window was closed by
        /// the user.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowCustomDialog<T>(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Displays a modal dialog of a type that is determined by the dialog type locator.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <returns>
        /// A nullable value of type <see cref="bool"/> that signifies how a window was closed by
        /// the user.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowDialog(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            
            Type dialogType = dialogTypeLocator.Locate(viewModel);
            return ShowDialog(ownerViewModel, viewModel, dialogType);
        }

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="messageBoxText">
        /// A <see cref="string"/> that specifies the text to display.
        /// </param>
        /// <param name="caption">
        /// A <see cref="string"/> that specifies the title bar caption to display. Default value
        /// is an empty string.
        /// </param>
        /// <param name="button">
        /// A <see cref="MessageBoxButton"/> value that specifies which button or buttons to
        /// display. Default value is <see cref="MessageBoxButton.OK"/>.
        /// </param>
        /// <param name="icon">
        /// A <see cref="MessageBoxImage"/> value that specifies the icon to display. Default value
        /// is <see cref="MessageBoxImage.None"/>.
        /// </param>
        /// <param name="defaultResult">
        /// A <see cref="MessageBoxResult"/> value that specifies the default result of the
        /// message box. Default value is <see cref="MessageBoxResult.None"/>.
        /// </param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string messageBoxText,
            string caption = "",
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            var settings = new MessageBoxSettings
            {
                MessageBoxText = messageBoxText,
                Caption = caption,
                Button = button,
                Icon = icon,
                DefaultResult = defaultResult
            };

            return ShowMessageBox(ownerViewModel, settings);
        }

        /// <summary>
        /// Displays a message box that has a message, title bar caption, button, and icon; and
        /// that accepts a default message box result and returns a result.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="settings">The settings for the message box dialog.</param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            MessageBoxSettings settings)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Caption: {settings.Caption}; Message: {settings.MessageBoxText}");

            var messageBox = frameworkDialogFactory.CreateMessageBox(settings);
            return messageBox.Show(FindOwnerWindow(ownerViewModel));
        }

        /// <summary>
        /// Shows the open file dialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="settings">The settings for the open file dialog.</param>
        /// <returns>
        /// If the user clicks the OK button of the dialog that is displayed, true is returned;
        /// otherwise false.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowOpenFileDialog(
            INotifyPropertyChanged ownerViewModel,
            OpenFileDialogSettings settings)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Title: {settings.Title}");

            return frameworkDialogFactory
                .CreateOpenFileDialog(settings)
                .ShowDialog(FindOwnerWindow(ownerViewModel));
        }

        /// <summary>
        /// Shows the save file dialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="settings">The settings for the save file dialog.</param>
        /// <returns>
        /// If the user clicks the OK button of the dialog that is displayed, true is returned;
        /// otherwise false.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowSaveFileDialog(
            INotifyPropertyChanged ownerViewModel,
            SaveFileDialogSettings settings)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Title: {settings.Title}");

            return frameworkDialogFactory
                .CreateSaveFileDialog(settings)
                .ShowDialog(FindOwnerWindow(ownerViewModel));
        }

        /// <summary>
        /// Shows the folder browser dialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="settings">The settings for the folder browser dialog.</param>
        /// <returns>
        /// If the user clicks the OK button of the dialog that is displayed, true is returned;
        /// otherwise false.
        /// </returns>
        /// <exception cref="ViewNotRegisteredException">
        /// No view is registered with specified owner view model as data context.
        /// </exception>
        public bool? ShowFolderBrowserDialog(
            INotifyPropertyChanged ownerViewModel,
            FolderBrowserDialogSettings settings)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Description: {settings.Description}");

            return frameworkDialogFactory
                .CreateFolderBrowserDialog(settings)
                .ShowDialog(FindOwnerWindow(ownerViewModel));
        }

        #endregion

        private void Show(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel,
            Type dialogType)
        {
            Logger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);
            dialog.Show();
        }

        private bool? ShowDialog(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel,
            Type dialogType)
        {
            Logger.Write($"Dialog: {dialogType}; View model: {viewModel.GetType()}; Owner: {ownerViewModel.GetType()}");

            IWindow dialog = CreateDialog(dialogType, ownerViewModel, viewModel);
            
            PropertyChangedEventHandler handler = RegisterDialogResult(dialog, viewModel);
            dialog.ShowDialog();
            UnregisterDialogResult(viewModel, handler);

            return viewModel.DialogResult;
        }

        private IWindow CreateDialog(
            Type dialogType,
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
        {
            var dialog = dialogFactory.Create(dialogType);
            dialog.Owner = FindOwnerWindow(ownerViewModel);
            dialog.DataContext = viewModel;

            return dialog;
        }

        private static PropertyChangedEventHandler RegisterDialogResult(
            IWindow dialog,
            IModalDialogViewModel viewModel)
        {
            PropertyChangedEventHandler handler = (sender, e) =>
            {
                if (e.PropertyName == DialogResultPropertyName && dialog.DialogResult != viewModel.DialogResult)
                {
                    Logger.Write($"Dialog: {dialog.GetType()}; Result: {viewModel.DialogResult}");
                    dialog.DialogResult = viewModel.DialogResult;
                }
            };

            viewModel.PropertyChanged += handler;

            return handler;
        }

        private static void UnregisterDialogResult(
            IModalDialogViewModel viewModel,
            PropertyChangedEventHandler handler)
        {
            viewModel.PropertyChanged -= handler;
        }

        /// <summary>
        /// Finds window corresponding to specified view model.
        /// </summary>
        private static Window FindOwnerWindow(INotifyPropertyChanged viewModel)
        {
            IView view = DialogServiceViews.Views.SingleOrDefault(
                registeredView =>
                    registeredView.Source.IsLoaded &&
                    ReferenceEquals(registeredView.DataContext, viewModel));

            if (view == null)
            {
                string message = $"View model of type '{viewModel.GetType()}' is not present as data context on any registered view." +
                    "Please register the view by setting DialogServiceViews.IsRegistered=\"True\" in your XAML.";

                throw new ViewNotRegisteredException(message);
            }

            // Get owner window
            Window owner = view.GetOwner();
            if (owner == null)
                throw new InvalidOperationException($"View of type '{view.GetType()}' is not registered.");

            return owner;
        }
    }
}