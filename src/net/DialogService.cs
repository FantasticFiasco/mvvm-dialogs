using System;
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
            IDialogFactory? dialogFactory = null,
            IDialogTypeLocator? dialogTypeLocator = null,
            IFrameworkDialogFactory? frameworkDialogFactory = null)
        {
            this.dialogFactory = dialogFactory ?? new ReflectionDialogFactory();
            this.dialogTypeLocator = dialogTypeLocator ?? new NamingConventionDialogTypeLocator();
            this.frameworkDialogFactory = frameworkDialogFactory ?? new DefaultFrameworkDialogFactory();
        }

        #region IDialogService Members

        /// <inheritdoc />
        public void Show<T>(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : Window
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Show(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public void ShowCustom<T>(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Show(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public void Show(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type dialogType = dialogTypeLocator.Locate(viewModel);
            Show(ownerViewModel, viewModel, dialogType);
        }

        /// <inheritdoc />
        public bool? ShowDialog<T>(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
            where T : Window
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public bool? ShowCustomDialog<T>(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
            where T : IWindow
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }

        /// <inheritdoc />
        public bool? ShowDialog(
            INotifyPropertyChanged ownerViewModel,
            IModalDialogViewModel viewModel)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            Type dialogType = dialogTypeLocator.Locate(viewModel);
            return ShowDialog(ownerViewModel, viewModel, dialogType);
        }

        /// <inheritdoc />
        public bool Activate(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return (
                from Window? window in Application.Current.Windows
                where window != null
                where viewModel.Equals(window.DataContext)
                select window.Activate()
            ).FirstOrDefault();
        }

        /// <inheritdoc />
        public bool Close(INotifyPropertyChanged viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            foreach (Window? window in Application.Current.Windows)
            {
                if (window == null || !viewModel.Equals(window.DataContext))
                {
                    continue;
                }

                try
                {
                    window.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Write($"Failed to close dialog: {e}");
                    break;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string? messageBoxText,
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

        /// <inheritdoc />
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            MessageBoxSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Caption: {settings.Caption}; Message: {settings.MessageBoxText}");

            var messageBox = frameworkDialogFactory.CreateMessageBox(settings);
            return messageBox.Show(FindOwnerWindow(ownerViewModel));
        }

        /// <inheritdoc />
        public bool? ShowOpenFileDialog(
            INotifyPropertyChanged ownerViewModel,
            OpenFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Title: {settings.Title}");

            return frameworkDialogFactory
                .CreateOpenFileDialog(settings)
                .ShowDialog(FindOwnerWindow(ownerViewModel));
        }

        /// <inheritdoc />
        public bool? ShowSaveFileDialog(
            INotifyPropertyChanged ownerViewModel,
            SaveFileDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            Logger.Write($"Title: {settings.Title}");

            return frameworkDialogFactory
                .CreateSaveFileDialog(settings)
                .ShowDialog(FindOwnerWindow(ownerViewModel));
        }

        /// <inheritdoc />
        public bool? ShowFolderBrowserDialog(
            INotifyPropertyChanged ownerViewModel,
            FolderBrowserDialogSettings settings)
        {
            if (ownerViewModel == null) throw new ArgumentNullException(nameof(ownerViewModel));
            if (settings == null) throw new ArgumentNullException(nameof(settings));

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
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName != DialogResultPropertyName || dialog.DialogResult == viewModel.DialogResult)
                    return;

                Logger.Write($"Dialog: {dialog.GetType()}; Result: {viewModel.DialogResult}");
                dialog.DialogResult = viewModel.DialogResult;
            }

            viewModel.PropertyChanged += Handler;

            return Handler;
        }

        private static void UnregisterDialogResult(
            IModalDialogViewModel viewModel,
            PropertyChangedEventHandler handler) =>
            viewModel.PropertyChanged -= handler;

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
                string message =
                    $"View model of type '{viewModel.GetType()}' is not present as data context on any registered view. Please register the view by setting DialogServiceViews.IsRegistered=\"True\" in your XAML.";

                throw new ViewNotRegisteredException(message);
            }

            // Get owner window
            Window? owner = view.GetOwner();
            if (owner == null) throw new InvalidOperationException($"View of type '{view.GetType()}' is not registered.");

            return owner;
        }
    }
}
