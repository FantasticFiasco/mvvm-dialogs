using System;
using System.Diagnostics.Contracts;

namespace MvvmDialogs.WindowViewModelMapping
{
    /// <summary>
    /// Interface describing the Window-view model mappings used by the dialog service.
    /// </summary>
    [ContractClass(typeof(IWindowViewModelMappingsContract))]
    public interface IWindowViewModelMappings
    {
        /// <summary>
        /// Gets the window type based on registered view model type.
        /// </summary>
        /// <param name="viewModelType">The type of the view model.</param>
        /// <returns>The window type based on registered view model type.</returns>
        Type GetWindowTypeFromViewModelType(Type viewModelType);
    }
}