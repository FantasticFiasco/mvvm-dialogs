using System;
using System.Collections.Generic;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// A cache holding the known mappings between view model types and dialog types.
    /// </summary>
    internal static class DialogTypeLocatorCache
    {
        private static readonly Dictionary<Type, Type> Cache = new Dictionary<Type, Type>();

        /// <summary>
        /// Adds the specified view model type with its corresponding dialog type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        internal static void Add(Type viewModelType, Type dialogType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");
            if (dialogType == null)
                throw new ArgumentNullException("dialogType");

            Cache.Add(viewModelType, dialogType);
        }

        /// <summary>
        /// Gets the dialog type for specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>The dialog type if found; otherwise null.</returns>
        internal static Type Get(Type viewModelType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException("viewModelType");

            Type dialogType;
            Cache.TryGetValue(viewModelType, out dialogType);
            return dialogType;
        }

        /// <summary>
        /// Gets the number of dialog type/view model type pairs contained in the cache.
        /// </summary>
        internal static int Count
        {
            get { return Cache.Count; }
        }

        /// <summary>
        /// Removes all dialog type/view model type pairs from the cache.
        /// </summary>
        internal static void Clear()
        {
            Cache.Clear();
        }
    }
}