using System;
using System.Windows;

namespace MvvmDialogs.Views
{
    internal class ViewWrapper : IView
    {
        private readonly WeakReference viewReference;

        internal ViewWrapper(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");

            viewReference = new WeakReference(view);
        }

        public event RoutedEventHandler Loaded
        {
            add { Source.Loaded += value; }
            remove { Source.Loaded -= value; }
        }

        public FrameworkElement Source
        {
            get
            {
                if (!IsAlive)
                    throw new InvalidOperationException("View has been garbage collected.");

                return (FrameworkElement)viewReference.Target;
            }
        }

        public object DataContext
        {
            get { return Source.DataContext; }
        }

        public bool IsAlive
        {
            get { return viewReference.IsAlive; }
        }

        public Window GetOwner()
        {
            return Source.GetOwner();
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ViewWrapper;
            if (other == null)
                return false;

            return Source.Equals(other.Source);
        }
    }
}