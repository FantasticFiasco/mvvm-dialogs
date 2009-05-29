using System;
using System.Windows;
using System.Windows.Forms;
using WindowInteropHelper = System.Windows.Interop.WindowInteropHelper;

namespace MVVM_Dialogs.Service.LegacyFrameworkDialogs
{
	/// <summary>
	/// WindowWrapper is an IWin32Window wrapper around a WPF window.
	/// </summary>
	class WindowWrapper : IWin32Window
	{
		/// <summary>
		/// Gets the handle to the window represented by the implementer.
		/// </summary>
		/// <returns>A handle to the window represented by the implementer.</returns>
		public IntPtr Handle { get; private set; }


		/// <summary>
		/// Construct a new wrapper taking a WPF window.
		/// </summary>
		/// <param name="window">The WPF window to wrap.</param>
		public WindowWrapper(Window window)
		{
			Handle = new WindowInteropHelper(window).Handle;
		}
	}
}
