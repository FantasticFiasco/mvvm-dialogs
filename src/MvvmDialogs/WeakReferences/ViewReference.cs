using System;
using System.Windows;

namespace MvvmDialogs.WeakReferences
{
    /// <summary>
    /// Class holding a view using a weak reference.
    /// </summary>
    internal class ViewReference
    {
        private readonly WeakReference viewReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewReference"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        internal ViewReference(FrameworkElement view)
        {
            if (view == null)
                throw new ArgumentNullException("view");

            viewReference = new WeakReference(view);
        }

        /// <summary>
        /// Gets the target if it hasn't been garbage collected; otherwise null.
        /// </summary>
        internal object Target
        {
            get
            {
                return viewReference.IsAlive ?
                  viewReference.Target :
                  null;
            }
        }

        /// <summary>
        /// Gets the view if it hasn't been garbage collected; otherwise null.
        /// </summary>
        internal FrameworkElement View
        {
            get
            {
                object view = Target;
                
                return view != null ?
                    (FrameworkElement)view :
                    null;
            }
        }

        /// <summary>
        /// Gets an indication whether the view been garbage collected.
        /// </summary>
        public bool IsAlive
        {
            get { return viewReference.IsAlive; }
        }
    }
}