using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MvvmDialogs.Logging;
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

            if (target is FrameworkElement view)
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
        internal static IEnumerable<IView> Views =>
            InternalViews
                .Where(view => view.IsAlive)
                .ToArray();

        /// <summary>
        /// Registers specified view.
        /// </summary>
        /// <param name="view">The view to register.</param>
        internal static void Register(IView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));

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

            // Register for owner window closing to cleanup views connected to this window, but
            // only register for the event once, thus the un-registration of any prior
            // registrations.
            owner.Closed -= OwnerClosed;
            owner.Closed += OwnerClosed;

            Logger.Write($"Register view {view.Id}");
            InternalViews.Add(view);
            Logger.Write($"Registered view {view.Id} ({InternalViews.Count} registered)");
        }

        /// <summary>
        /// Clears the registered views.
        /// </summary>
        internal static void Clear()
        {
            Logger.Write("Clearing views");
            InternalViews.Clear();
            Logger.Write("Cleared views");
        }

        /// <summary>
        /// Unregisters specified view.
        /// </summary>
        /// <param name="view">The view to unregister.</param>
        private static void Unregister(IView view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));

            PruneInternalViews();

            Logger.Write($"Unregister view {view.Id}");
            InternalViews.RemoveAll(registeredView => ReferenceEquals(registeredView.Source, view.Source));
            Logger.Write($"Unregistered view {view.Id} ({InternalViews.Count} registered)");
        }

        /// <summary>
        /// Callback for late view register. It wasn't possible to do a instant register since the
        /// view wasn't at that point part of the logical nor visual tree.
        /// </summary>
        private static void LateRegister(object sender, RoutedEventArgs e)
        {
            if (e.Source is FrameworkElement frameworkElement)
            {
                // Unregister loaded event
                frameworkElement.Loaded -= LateRegister;

                // Register the view
                if (frameworkElement is IView view)
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
        private static void OwnerClosed(object? sender, EventArgs e)
        {
            if (sender is Window owner)
            {
                // Find views acting within closed window
                IView[] windowViews = Views
                    .Where(view => ReferenceEquals(view.GetOwner(), owner))
                    .ToArray();

                // Unregister Views in window
                foreach (IView windowView in windowViews)
                {
                    Logger.Write($"Window containing view {windowView.Id} closed");
                    Unregister(windowView);
                }
            }
        }

        private static void PruneInternalViews()
        {
            Logger.Write($"Before pruning ({InternalViews.Count} registered)");
            InternalViews.RemoveAll(reference => !reference.IsAlive);
            Logger.Write($"After pruning ({InternalViews.Count} registered)");
        }
    }
}
