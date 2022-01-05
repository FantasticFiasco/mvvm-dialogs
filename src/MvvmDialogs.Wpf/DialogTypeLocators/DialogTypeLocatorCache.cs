using System;
using System.Collections.Generic;

namespace MvvmDialogs.DialogTypeLocators
{
    /// <summary>
    /// A cache holding the known mappings between view model types and dialog types.
    /// </summary>
    internal class DialogTypeLocatorCache
    {
        private readonly Dictionary<Type, Type> cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogTypeLocatorCache"/> class.
        /// </summary>
        internal DialogTypeLocatorCache() => cache = new Dictionary<Type, Type>();

        /// <summary>
        /// Adds the specified view model type with its corresponding dialog type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="dialogType">Type of the dialog.</param>
        internal void Add(Type viewModelType, Type dialogType)
        {
            if (viewModelType == null) throw new ArgumentNullException(nameof(viewModelType));
            if (dialogType == null) throw new ArgumentNullException(nameof(dialogType));
            if (cache.ContainsKey(viewModelType)) throw new ArgumentException($"View model of type '{viewModelType}' is already added.", nameof(viewModelType));

            cache.Add(viewModelType, dialogType);
        }

        /// <summary>
        /// Gets the dialog type for specified view model type.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <returns>The dialog type if found; otherwise null.</returns>
#if NETFX_CORE
        internal Type Get(Type viewModelType)
#else
        internal Type? Get(Type viewModelType)
#endif
        {
            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));

            cache.TryGetValue(viewModelType, out var dialogType);

            return dialogType;
        }

        /// <summary>
        /// Removes all view model types with its corresponding dialog types.
        /// </summary>
        internal void Clear() => cache.Clear();

        /// <summary>
        /// Gets the number of dialog type/view model type pairs contained in the cache.
        /// </summary>
        internal int Count => cache.Count;
    }
}
