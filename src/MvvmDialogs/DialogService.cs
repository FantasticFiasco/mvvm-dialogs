using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.FrameworkDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using DialogResult = System.Windows.Forms.DialogResult;
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace MvvmDialogs
{
    /// <summary>
    /// Class responsible for abstracting view models from Views.
    /// </summary>
    public class DialogService : IDialogService
    {
        private readonly HashSet<FrameworkElement> views;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogService"/> class.
        /// </summary>
        public DialogService()
        {
            views = new HashSet<FrameworkElement>();
        }

        #region IDialogService Members

        /// <summary>
        /// Gets the registered views.
        /// </summary>
        public ReadOnlyCollection<FrameworkElement> Views
        {
            get { return new ReadOnlyCollection<FrameworkElement>(views.ToList()); }
        }
        
        /// <summary>
        /// Registers a view.
        /// </summary>
        /// <param name="view">The registered view.</param>
        public void Register(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            if (views.Contains(view))
                throw new ArgumentException("View of type {0} has already been already registered.".InvariantFormat(view.GetType()), "view");
            
            // Get owner window
            Window owner = GetOwner(view);
            if (owner == null)
            {
                // Perform a late register when the view hasn't been loaded yet.
                // This will happen if e.g. the view is contained in a Frame.
                view.Loaded += LateRegister;
                return;
            }

            // Register for owner window closing, since we then should unregister view reference,
            // preventing memory leaks
            owner.Closed += OwnerClosed;

            views.Add(view);
        }
        
        /// <summary>
        /// Unregisters a view.
        /// </summary>
        /// <param name="view">The unregistered view.</param>
        public void Unregister(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            if (views.Contains(view))
                throw new ArgumentException("View of type {0} has never been registered.".InvariantFormat(view.GetType()), "view");
            
            views.Remove(view);
        }

        /// <summary>
        /// Shows a dialog of specified type <typeparamref name="T"/>.
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
        public bool? ShowDialog<T>(
            INotifyPropertyChanged ownerViewModel,
            INotifyPropertyChanged viewModel)
            where T : Window
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException("ownerViewModel");
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");

            return ShowDialog(ownerViewModel, viewModel, typeof(T));
        }

        /// <summary>
        /// Shows a <see cref="MessageBox"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the message box.
        /// </param>
        /// <param name="messageBoxText">A string that specifies the text to display.</param>
        /// <param name="caption">A string that specifies the title bar caption to display.</param>
        /// <param name="button">
        /// A <see cref="MessageBoxButton"/> value that specifies which button or buttons to
        /// display.
        /// </param>
        /// <param name="icon">
        /// A <see cref="MessageBoxImage"/> value that specifies the icon to display.
        /// </param>
        /// <returns>
        /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
        /// clicked by the user.
        /// </returns>
        public MessageBoxResult ShowMessageBox(
            INotifyPropertyChanged ownerViewModel,
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException("ownerViewModel");
            
            return MessageBox.Show(FindOwnerWindow(ownerViewModel), messageBoxText, caption, button, icon);
        }

        /// <summary>
        /// Shows the <see cref="OpenFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="openFileDialogViewModel">The view model of a open file dialog.</param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        public DialogResult ShowOpenFileDialog(
            INotifyPropertyChanged ownerViewModel,
            OpenFileDialogViewModel openFileDialogViewModel)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException("ownerViewModel");
            if (openFileDialogViewModel == null)
                throw new ArgumentNullException("openFileDialogViewModel");

            // Create OpenFileDialog with specified view model
            var dialog = new OpenFileDialogWrapper(openFileDialogViewModel);

            // Show dialog
            return dialog.ShowDialog(new WindowWrapper(FindOwnerWindow(ownerViewModel)));
        }

        /// <summary>
        /// Shows the <see cref="SaveFileDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="saveFileDialogViewModel">The view model of a save file dialog.</param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        public DialogResult ShowSaveFileDialog(
            INotifyPropertyChanged ownerViewModel,
            SaveFileDialogViewModel saveFileDialogViewModel)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException("ownerViewModel");
            if (saveFileDialogViewModel == null)
                throw new ArgumentNullException("saveFileDialogViewModel");

            // Create SaveFileDialog with specified view model
            var dialog = new SaveFileDialogWrapper(saveFileDialogViewModel);

            // Show dialog
            return dialog.ShowDialog(new WindowWrapper(FindOwnerWindow(ownerViewModel)));
        }

        /// <summary>
        /// Shows the <see cref="FolderBrowserDialog"/>.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="folderBrowserDialogViewModel">
        /// The view model of a folder browser dialog.
        /// </param>
        /// <returns>
        /// <see cref="DialogResult.OK"/> if successful; otherwise
        /// <see cref="DialogResult.Cancel"/>.
        /// </returns>
        public DialogResult ShowFolderBrowserDialog(
            INotifyPropertyChanged ownerViewModel,
            FolderBrowserDialogViewModel folderBrowserDialogViewModel)
        {
            if (ownerViewModel == null)
                throw new ArgumentNullException("ownerViewModel");
            if (folderBrowserDialogViewModel == null)
                throw new ArgumentNullException("folderBrowserDialogViewModel");

            // Create FolderBrowserDialogWrapper with specified view model
            var dialog = new FolderBrowserDialogWrapper(folderBrowserDialogViewModel);

            // Show dialog
            return dialog.ShowDialog(new WindowWrapper(FindOwnerWindow(ownerViewModel)));
        }

        #endregion
        
        #region Attached properties

        /// <summary>
        /// Attached property describing whether a FrameworkElement is acting as a view in MVVM.
        /// </summary>
        public static readonly DependencyProperty IsRegisteredViewProperty =
            DependencyProperty.RegisterAttached(
                "IsRegisteredView",
                typeof(bool),
                typeof(DialogService),
                new UIPropertyMetadata(IsRegisteredViewPropertyChanged));


        /// <summary>
        /// Gets value describing whether FrameworkElement is acting as view in MVVM.
        /// </summary>
        public static bool GetIsRegisteredView(FrameworkElement target)
        {
            return (bool)target.GetValue(IsRegisteredViewProperty);
        }

        /// <summary>
        /// Sets value describing whether FrameworkElement is acting as view in MVVM.
        /// </summary>
        public static void SetIsRegisteredView(FrameworkElement target, bool value)
        {
            target.SetValue(IsRegisteredViewProperty, value);
        }

        /// <summary>
        /// Is responsible for handling IsRegisteredViewProperty changes, i.e. whether
        /// FrameworkElement is acting as view in MVVM or not.
        /// </summary>
        private static void IsRegisteredViewPropertyChanged(
            DependencyObject target,
            DependencyPropertyChangedEventArgs e)
        {
            // The Visual Studio Designer or Blend will run this code when setting the attached
            // property, however at that point there is no IDialogService registered
            // in the ServiceLocator which will cause the Resolve method to throw a ArgumentException.
            if (DesignerProperties.GetIsInDesignMode(target))
                return;

            FrameworkElement view = target as FrameworkElement;
            if (view != null)
            {
                // Cast values
                bool newValue = (bool)e.NewValue;
                bool oldValue = (bool)e.OldValue;

                if (newValue)
                {
                    ServiceLocator.Resolve<IDialogService>().Register(view);
                }
                else
                {
                    ServiceLocator.Resolve<IDialogService>().Unregister(view);
                }
            }
        }

        #endregion
        

        /// <summary>
        /// Shows a dialog.
        /// </summary>
        /// <param name="ownerViewModel">
        /// A view model that represents the owner window of the dialog.
        /// </param>
        /// <param name="viewModel">The view model of the new dialog.</param>
        /// <param name="dialogType">The type of the dialog.</param>
        /// <returns>
        /// A nullable value of type bool that signifies how a window was closed by the user.
        /// </returns>
        private bool? ShowDialog(object ownerViewModel, object viewModel, Type dialogType)
        {
            // Create dialog and set properties
            Window dialog = (Window)Activator.CreateInstance(dialogType);
            dialog.Owner = FindOwnerWindow(ownerViewModel);
            dialog.DataContext = viewModel;

            // Show dialog
            return dialog.ShowDialog();
        }

        /// <summary>
        /// Finds window corresponding to specified view model.
        /// </summary>
        private Window FindOwnerWindow(object viewModel)
        {
            FrameworkElement view = views.SingleOrDefault(v => ReferenceEquals(v.DataContext, viewModel));
            if (view == null)
            {
                throw new ArgumentException("Viewmodel is not referenced by any registered view.");
            }

            // Get owner window
            Window owner = view as Window;
            if (owner == null)
            {
                owner = Window.GetWindow(view);
            }

            // Make sure owner window was found
            if (owner == null)
            {
                throw new InvalidOperationException("View is not contained within a Window.");
            }

            return owner;
        }

        /// <summary>
        /// Callback for late view register. It wasn't possible to do a instant register since the
        /// view wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private void LateRegister(object sender, RoutedEventArgs e)
        {
            FrameworkElement view = sender as FrameworkElement;
            if (view != null)
            {
                // Unregister loaded event
                view.Loaded -= LateRegister;

                // Register the view
                Register(view);
            }
        }

        /// <summary>
        /// Handles owner window closed, view service should then unregister all Views acting
        /// within the closed window.
        /// </summary>
        private void OwnerClosed(object sender, EventArgs e)
        {
            Window owner = sender as Window;
            if (owner != null)
            {
                // Find Views acting within closed window
                IEnumerable<FrameworkElement> windowViews =
                    from view in views
                    where Window.GetWindow(view) == owner
                    select view;

                // Unregister Views in window
                foreach (FrameworkElement view in windowViews.ToArray())
                {
                    Unregister(view);
                }
            }
        }

        /// <summary>
        /// Gets the owning Window of a view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>The owning Window if found; otherwise null.</returns>
        private Window GetOwner(FrameworkElement view)
        {
            return view as Window ?? Window.GetWindow(view);
        }
    }
}