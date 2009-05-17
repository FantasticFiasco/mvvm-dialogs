using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MVVM_Dialogs.Service
{
	class DialogService : IDialogService
	{
		private static IDialogService instance;
		private HashSet<FrameworkElement> views;


		/// <summary>
		/// The Singleton instance of this class.
		/// </summary>
		public static IDialogService Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DialogService();
				}
				return instance;
			}
		}


		private DialogService()
		{
			views = new HashSet<FrameworkElement>();
		}


		#region IDialogService Members

		/// <summary>
		/// Registers a view.
		/// </summary>
		/// <param name="view">The registered view.</param>
		public void Register(FrameworkElement view)
		{
			if (views.Contains(view)) throw new ArgumentException("View has already been registered.");

			// Get owner window
			Window owner = view as Window;
			if (owner == null)
			{
				owner = Window.GetWindow(view);
			}
						
			if (owner == null)
			{
				throw new InvalidOperationException("View is not contained within a Window.");
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
			if (!views.Contains(view)) throw new ArgumentException("View has never been registered.");

			views.Remove(view);
		}


		/// <summary>
		/// Shows a dialog.
		/// </summary>
		/// <param name="ownerViewModel">A viewmodel that represents the owner window of
		/// the dialog.</param>
		/// <param name="viewModel">The viewmodel of the new dialog.</param>
		/// <returns>A nullable value of type bool that signifies how a window was closed
		/// by the user.</returns>
		public bool? ShowDialog<T>(object ownerViewModel, object viewModel) where T : Window
		{
			// Create dialog and set properties
			T dialog = Activator.CreateInstance<T>();
			dialog.Owner = FindOwnerWindow(ownerViewModel);
			dialog.DataContext = viewModel;

			// Show dialog
			return dialog.ShowDialog();
		}


		/// <summary>
		/// Shows a message box.
		/// </summary>
		/// <param name="ownerViewModel">A viewmodel that represents the owner window of
		/// the message box.</param>
		/// <param name="messageBoxText">A string that specifies the text to display.</param>
		/// <param name="caption">A string that specifies the title bar caption to display.</param>
		/// <param name="button">A MessageBoxButton value that specifies which button or buttons
		/// to display.</param>
		/// <param name="icon">A MessageBoxImage value that specifies the icon to display.</param>
		/// <returns>A MessageBoxResult value that specifies which message box button is clicked
		/// by the user.</returns>
		public MessageBoxResult ShowMessageBox(object ownerViewModel, string messageBoxText, string caption,
			MessageBoxButton button, MessageBoxImage icon)
		{
			return MessageBox.Show(FindOwnerWindow(ownerViewModel), messageBoxText, caption, button, icon);
		}

		#endregion


		#region Attached properties

		/// <summary>
		/// Attached property describing whether a FrameworkElement is acting as a view in MVVM.
		/// </summary>
		public static readonly DependencyProperty IsRegisteredViewProperty = DependencyProperty.RegisterAttached(
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
		private static void IsRegisteredViewPropertyChanged(DependencyObject target,
			DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement view = target as FrameworkElement;
			if (view != null)
			{
				// Cast values
				bool newValue = (bool)e.NewValue;
				bool oldValue = (bool)e.OldValue;

				if (newValue)
				{
					Instance.Register(view);
				}
				else
				{
					Instance.Unregister(view);
				}
			}
		}

		#endregion


		/// <summary>
		/// Finds window corresponding to specified viewmodel.
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
		/// Handles owner window closed, view service should then unregister all views acting
		/// within the closed window.
		/// </summary>
		private void OwnerClosed(object sender, EventArgs e)
		{
			Window owner = sender as Window;
			if (owner != null)
			{
				// Find views acting within closed window
				IEnumerable<FrameworkElement> windowViews =
					from view in views
					where Window.GetWindow(view) == owner
					select view;

				// Unregister views in window
				foreach (FrameworkElement view in windowViews.ToArray())
				{
					Unregister(view);
				}
			}
		}
	}
}
