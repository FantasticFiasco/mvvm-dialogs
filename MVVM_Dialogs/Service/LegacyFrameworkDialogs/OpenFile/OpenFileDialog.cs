using System;
using System.Windows.Forms;
using FormsOpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace MVVM_Dialogs.Service.LegacyFrameworkDialogs.OpenFile
{
	/// <summary>
	/// Class wrapping System.Windows.Forms.OpenFileDialog, making it accept a ViewModel.
	/// </summary>
	public class OpenFileDialog : IDisposable
	{
		private FormsOpenFileDialog openFileDialog;
		private OpenFileDialogViewModel viewModel;


		public OpenFileDialog(OpenFileDialogViewModel viewModel)
		{
			this.viewModel = viewModel;

			// Create OpenFileDialog
			openFileDialog = new FormsOpenFileDialog
			{
				AddExtension = viewModel.AddExtension,
				CheckFileExists = viewModel.CheckFileExists,
				CheckPathExists = viewModel.CheckPathExists,
				DefaultExt = viewModel.DefaultExt,
				FileName = viewModel.FileName,
				Filter = viewModel.Filter,
				InitialDirectory = viewModel.InitialDirectory,
				Multiselect = viewModel.Multiselect,
				Title = viewModel.Title
			};
		}


		/// <summary>
		/// Runs a common dialog box with the specified owner.
		/// </summary>
		/// <param name="owner">Any object that implements System.Windows.Forms.IWin32Window that
		/// represents the top-level window that will own the modal dialog box.</param>
		/// <returns>System.Windows.Forms.DialogResult.OK if the user clicks OK in the dialog box;
		/// otherwise, System.Windows.Forms.DialogResult.Cancel.</returns>
		public DialogResult ShowDialog(IWin32Window owner)
		{
			DialogResult result = openFileDialog.ShowDialog(owner);

			// Update ViewModel
			viewModel.FileName = openFileDialog.FileName;
			viewModel.FileNames = openFileDialog.FileNames;

			return result;
		}


		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


		~OpenFileDialog()
		{
			Dispose(false);
		}


		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (openFileDialog != null)
				{
					openFileDialog.Dispose();
					openFileDialog = null;
				}
			}
		}

		#endregion
	}
}
