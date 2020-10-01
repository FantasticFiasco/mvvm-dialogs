using System;
using System.Windows;

namespace MvvmDialogs.Views
{
    internal class ViewWrapper : IView
    {
        private readonly WeakReference viewReference;

        internal ViewWrapper(FrameworkElement view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));

            viewReference = new WeakReference(view);
        }

        public event RoutedEventHandler Loaded
        {
            add => Source.Loaded += value;
            remove => Source.Loaded -= value;
        }

        public int Id { get; } = IdGenerator.Generate();

        public FrameworkElement Source
        {
            get
            {
                if (!IsAlive) throw new InvalidOperationException("View has been garbage collected.");
                if (viewReference.Target == null) throw new InvalidOperationException("View has been set to null.");

                return (FrameworkElement)viewReference.Target;
            }
        }

        public object DataContext => Source.DataContext;

        public bool IsAlive => viewReference.IsAlive;

        public Window GetOwner() => Source.GetOwner();

        public override int GetHashCode() => Source.GetHashCode();

        public override bool Equals(object? obj)
        {
            if (!(obj is ViewWrapper other))
                return false;

            return Source.Equals(other.Source);
        }
    }
}
