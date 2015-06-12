using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.Properties;
using MvvmDialogs.Views;

namespace MvvmDialogs
{
    /// <summary>
    /// Class containing means to register a <see cref="FrameworkElement"/> as a view for a view
    /// model when using the MVVM pattern. The view will then be used by the 
    /// <see cref="DialogService"/> when opening dialogs.
    /// </summary>
    public static class DialogServiceViews
    {
        /// <summary>
        /// The registered views.
        /// </summary>
        private static readonly List<IView> InternalViews = new List<IView>();

        #region Attached properties

        /// <summary>
        /// Attached property describing whether a <see cref="FrameworkElement"/> is acting as a
        /// view for a view model when using the MVVM pattern.
        /// </summary>
        public static readonly DependencyProperty IsRegisteredProperty =
            DependencyProperty.RegisterAttached(
                "IsRegistered",
                typeof(bool),
                typeof(DialogServiceViews),
                new PropertyMetadata(IsRegisteredChanged));

        /// <summary>
        /// Gets value describing whether <see cref="DependencyObject"/> is acting as a view for a
        /// view model when using the MVVM pattern
        /// </summary>
        public static bool GetIsRegistered(DependencyObject target)
        {
            return (bool)target.GetValue(IsRegisteredProperty);
        }

        /// <summary>
        /// Sets value describing whether <see cref="DependencyObject"/> is acting as a view for a
        /// view model when using the MVVM pattern
        /// </summary>
        public static void SetIsRegistered(DependencyObject target, bool value)
        {
            target.SetValue(IsRegisteredProperty, value);
        }

        /// <summary>
        /// Is responsible for handling <see cref="IsRegisteredProperty"/> changes, i.e.
        /// whether <see cref="FrameworkElement"/> is acting as a view for a view model when using
        /// the MVVM pattern.
        /// </summary>
        private static void IsRegisteredChanged(
            DependencyObject target,
            DependencyPropertyChangedEventArgs e)
        {
            // The Visual Studio Designer or Blend will run this code when setting the attached
            // property in XAML, however we wish to abort the execution since the behavior adds
            // nothing to a designer.
            if (DesignerProperties.GetIsInDesignMode(target))
                return;

            var view = target as FrameworkElement;
            if (view != null)
            {
                if ((bool)e.NewValue)
                {
                    Register(new ViewWrapper(view));
                }
                else
                {
                    Unregister(new ViewWrapper(view));
                }
            }
        }

        #endregion

        /// <summary>
        /// Gets the registered views.
        /// </summary>
        internal static IEnumerable<IView> Views
        {
            get
            {
                return InternalViews
                    .Where(view => view.IsAlive)
                    .ToArray();
            }
        }

        /// <summary>
        /// Registers specified view.
        /// </summary>
        /// <param name="view">The view to register.</param>
        internal static void Register(IView view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            
            // Get owner window
            Window owner = view.GetOwner();
            if (owner == null)
            {
                // Perform a late register when the view hasn't been loaded yet.
                // This will happen if e.g. the view is contained in a Frame.
                view.Loaded += LateRegister;
                return;
            }

            PruneInternalViews();

            // Register for owner window closing, since we then should unregister view reference
            owner.Closed += OwnerClosed;

            InternalViews.Add(view);
        }

        /// <summary>
        /// Clears the registered views.
        /// </summary>
        internal static void Clear()
        {
            InternalViews.Clear();
        }

        /// <summary>
        /// Unregisters specified view.
        /// </summary>
        /// <param name="view">The view to unregister.</param>
        private static void Unregister(IView view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            if (!InternalViews.Any(registeredView => ReferenceEquals(registeredView.Source, view.Source)))
                throw new ArgumentException(Resources.ViewNotRegistered.CurrentFormat(view.GetType()), "view");

            InternalViews.RemoveAll(registeredView => ReferenceEquals(registeredView.Source, view.Source));
        }

        /// <summary>
        /// Callback for late view register. It wasn't possible to do a instant register since the
        /// view wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private static void LateRegister(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.Source as FrameworkElement;
            if (frameworkElement != null)
            {
                // Unregister loaded event
                frameworkElement.Loaded -= LateRegister;

                // Register the view
                var view = frameworkElement as IView;
                if (view != null)
                {
                    Register(view);
                }
                else
                {
                    Register(new ViewWrapper(frameworkElement));    
                }
            }
        }

        /// <summary>
        /// Handles owner window closed. All views acting within the closed window should be
        /// unregistered.
        /// </summary>
        private static void OwnerClosed(object sender, EventArgs e)
        {
            var owner = sender as Window;
            if (owner != null)
            {
                // Find views acting within closed window
                IView[] windowViews = Views
                    .Where(view => ReferenceEquals(view.GetOwner(), owner))
                    .ToArray();
                
                // Unregister Views in window
                foreach (IView windowView in windowViews)
                {
                    Unregister(windowView);
                }
            }
        }

        private static void PruneInternalViews()
        {
            InternalViews.RemoveAll(reference => !reference.IsAlive);
        }
    }
}