using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace MvvmDialogs
{
    /// <summary>
    /// Class containing means to register a <see cref="FrameworkElement"/> as a view for a view
    /// model in the MVVM pattern. The view will then be used by <see cref="DialogService"/> when
    /// opening dialogs.
    /// </summary>
    public static class DialogServiceBehaviors
    {
        /// <summary>
        /// The registered views.
        /// </summary>
        internal static readonly HashSet<FrameworkElement> Views = new HashSet<FrameworkElement>();

        #region Attached properties

        /// <summary>
        /// Attached property describing whether a <see cref="FrameworkElement"/> is acting as a
        /// view for a view model in the MVVM pattern.
        /// </summary>
        public static readonly DependencyProperty IsRegisteredViewProperty =
            DependencyProperty.RegisterAttached(
                "IsRegisteredView",
                typeof(bool),
                typeof(DialogServiceBehaviors),
                new UIPropertyMetadata(IsRegisteredViewChanged));

        /// <summary>
        /// Gets value describing whether <see cref="DependencyObject"/> is acting as a view for a
        /// view model in the MVVM pattern.
        /// </summary>
        public static bool GetIsRegisteredView(DependencyObject target)
        {
            return (bool)target.GetValue(IsRegisteredViewProperty);
        }

        /// <summary>
        /// Sets value describing whether <see cref="DependencyObject"/> is acting as a view for a
        /// view model in the MVVM pattern.
        /// </summary>
        public static void SetIsRegisteredView(DependencyObject target, bool value)
        {
            target.SetValue(IsRegisteredViewProperty, value);
        }

        /// <summary>
        /// Is responsible for handling <see cref="IsRegisteredViewProperty"/> changes, i.e.
        /// whether <see cref="FrameworkElement"/> is acting as a view for a view model in the MVVM
        /// pattern.
        /// </summary>
        private static void IsRegisteredViewChanged(
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
                    Register(view);
                }
                else
                {
                    Unregister(view);
                }
            }
        }

        #endregion

        /// <summary>
        /// Registers specified view.
        /// </summary>
        /// <param name="view">The view to register.</param>
        private static void Register(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            if (Views.Contains(view))
                throw new ArgumentException("View of type {0} has already been already registered.".InvariantFormat(view.GetType()), "view");

            // Get owner window
            Window owner = view.GetOwner();
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

            Views.Add(view);
        }

        /// <summary>
        /// Unregisters specified view.
        /// </summary>
        /// <param name="view">The view to unregister.</param>
        private static void Unregister(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");
            if (!Views.Contains(view))
                throw new ArgumentException("View of type {0} has never been registered.".InvariantFormat(view.GetType()), "view");

            Views.Remove(view);
        }

        /// <summary>
        /// Callback for late view register. It wasn't possible to do a instant register since the
        /// view wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private static void LateRegister(object sender, RoutedEventArgs e)
        {
            var view = sender as FrameworkElement;
            if (view != null)
            {
                // Unregister loaded event
                view.Loaded -= LateRegister;

                // Register the view
                Register(view);
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
                FrameworkElement[] windowViews = Views
                    .Where(view => Window.GetWindow(view) == owner)
                    .ToArray();
                
                // Unregister Views in window
                foreach (FrameworkElement windowView in windowViews)
                {
                    Unregister(windowView);
                }
            }
        }
    }
}