using System;
using System.Windows;

namespace MvvmDialogs.DialogFactories
{
	/// <summary>
	/// Interface responsible for creating dialogs.
	/// </summary>
	public interface IDialogFactory
	{
		/// <summary>
		/// Creates a <see cref="Window"/> of specified type.
		/// </summary>
		Window Create(Type dialogType);
	}
}