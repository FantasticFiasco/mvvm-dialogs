namespace MVVM_Dialogs.Service.LegacyFrameworkDialogs
{
	/// <summary>
	/// Interface describing the FileDialog.
	/// </summary>
	public interface IFileDialog
	{
		/// <summary>
		/// Gets or sets a value indicating whether the dialog box automatically adds an extension to a
		/// file name if the user omits the extension.
		/// </summary>
		bool AddExtension { get; set; }


		/// <summary>
		/// Gets or sets a value indicating whether the dialog box displays a warning if the user
		/// specifies a file name that does not exist.
		/// </summary>
		bool CheckFileExists { get; set; }


		/// <summary>
		/// Gets or sets a value indicating whether the dialog box displays a warning if the user
		/// specifies a path that does not exist.
		/// </summary>
		bool CheckPathExists { get; set; }


		/// <summary>
		/// Gets or sets the default file name extension.
		/// </summary>
		string DefaultExt { get; set; }


		/// <summary>
		/// Gets or sets a string containing the file name selected in the file dialog box.
		/// </summary>
		string FileName { get; }


		/// <summary>
		/// Gets the file names of all selected files in the dialog box.
		/// </summary>
		string[] FileNames { get; }


		/// <summary>
		/// Gets or sets the current file name filter string, which determines the choices that appear
		/// in the "Save as file type" or "Files of type" box in the dialog box.
		/// </summary>
		string Filter { get; set; }


		/// <summary>
		/// Gets or sets the initial directory displayed by the file dialog box.
		/// </summary>
		string InitialDirectory { get; set; }


		/// <summary>
		/// Gets or sets the file dialog box title.
		/// </summary>
		string Title { get; set; }
	}
}
