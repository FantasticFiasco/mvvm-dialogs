using System;
using Windows.UI.Xaml.Controls;

namespace MvvmDialogs.ContentDialogFactories
{
	/// <summary>
	/// Class responsible for creating content dialogs using reflection.
	/// </summary>
	public class ReflectionContentDialogFactory : IContentDialogFactory
	{
		/// <summary>
		/// Creates a <see cref="ContentDialog" /> of specified type using
		/// <see cref="Activator.CreateInstance(Type)"/>.
		/// </summary>
		public ContentDialog Create(Type dialogType)
		{
			if (dialogType == null)
				throw new ArgumentNullException(nameof(dialogType));

			return (ContentDialog)Activator.CreateInstance(dialogType);
		}
	}
}
