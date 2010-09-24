using System;
using System.Diagnostics.Contracts;

namespace MVVM_Dialogs.WindowViewModelMapping
{
	/// <summary>
	/// Interface describing the Window-ViewModel mappings used by the dialog service.
	/// </summary>
	[ContractClass(typeof(IWindowViewModelMappingsContract))]
	public interface IWindowViewModelMappings
	{
		/// <summary>
		/// Gets the window type based on registered ViewModel type.
		/// </summary>
		/// <param name="viewModelType">The type of the ViewModel.</param>
		/// <returns>The window type based on registered ViewModel type.</returns>
		Type GetWindowTypeFromViewModelType(Type viewModelType);
	}
}
