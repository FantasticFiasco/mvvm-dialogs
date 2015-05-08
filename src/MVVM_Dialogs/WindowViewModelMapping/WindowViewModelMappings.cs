using System;
using System.Collections.Generic;
using MVVM_Dialogs.View;
using MVVM_Dialogs.ViewModel;

namespace MVVM_Dialogs.WindowViewModelMapping
{
	/// <summary>
	/// Class describing the Window-ViewModel mappings used by the dialog service.
	/// </summary>
	public class WindowViewModelMappings : IWindowViewModelMappings
	{
		private IDictionary<Type, Type> mappings;


		/// <summary>
		/// Initializes a new instance of the <see cref="WindowViewModelMappings"/> class.
		/// </summary>
		public WindowViewModelMappings()
		{
			mappings = new Dictionary<Type, Type>
			{
				{ typeof(MainWindowViewModel), typeof(string) },
				{ typeof(PersonDialogViewModel), typeof(PersonDialog) }			
			};
		}


		/// <summary>
		/// Gets the window type based on registered ViewModel type.
		/// </summary>
		/// <param name="viewModelType">The type of the ViewModel.</param>
		/// <returns>The window type based on registered ViewModel type.</returns>
		public Type GetWindowTypeFromViewModelType(Type viewModelType)
		{
			return mappings[viewModelType];
		}
	}
}