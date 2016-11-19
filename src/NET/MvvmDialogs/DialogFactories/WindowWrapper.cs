using System;
using System.Windows;
using System.Windows.Controls;

namespace MvvmDialogs.DialogFactories
{
	internal class WindowWrapper : IWindow
	{
		private readonly Window window;

		public WindowWrapper(Window window)
		{
			if (window == null)
				throw new ArgumentNullException(nameof(window));

			this.window = window;
		}

		public object DataContext
		{
			get { return window.DataContext; }
			set { window.DataContext = value; }
		}

		public bool? DialogResult
		{
			get { return window.DialogResult; }
			set { window.DialogResult = value; }
		}

		public ContentControl Owner
		{
			get { return window.Owner; }
			set { window.Owner = (Window)value; }
		}

		public bool? ShowDialog()
		{
			return window.ShowDialog();
		}

		public void Show()
		{
			window.Show();
		}
	}
}
