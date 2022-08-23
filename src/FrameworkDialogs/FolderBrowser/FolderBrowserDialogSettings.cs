using System;
using System.Windows.Forms;

namespace MvvmDialogs.FrameworkDialogs.FolderBrowser
{
    /// <summary>
    /// Settings for <see cref="FolderBrowserDialog"/>.
    /// </summary>
    public class FolderBrowserDialogSettings
    {
        /// <summary>
        /// Gets or sets the descriptive text displayed above the tree view control in the dialog
        /// box.
        /// </summary>
        /// <value>
        /// The description to display. The default is an empty string ("").
        /// </value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the root folder where the browsing starts from.
        /// </summary>
        /// <value>
        /// One of the <see cref="Environment.SpecialFolder"/> values. The default is
        /// <c>Desktop</c>.
        /// </value>
        /// <remarks>
        /// Only the specified folder and any subfolders that are beneath it will appear in the dialog
        /// box and be selectable. The <see cref="SelectedPath"/> property, along with
        /// <see cref="RootFolder"/>, determines what the selected folder will be when the dialog
        /// box is displayed, as long as <see cref="SelectedPath"/> is an absolute path that is a
        /// subfolder of <see cref="RootFolder"/> (or more accurately, points to a subfolder of the
        /// shell namespace represented by <see cref="RootFolder"/>).
        /// </remarks>
        public Environment.SpecialFolder RootFolder { get; set; } = Environment.SpecialFolder.Desktop;

        /// <summary>
        /// Gets or sets the path selected by the user.
        /// </summary>
        /// <value>
        /// The path of the folder first selected in the dialog box or the last folder selected by
        /// the user. The default is an empty string ("").
        /// </value>
        /// <remarks>
        /// If the <see cref="SelectedPath"/> property is set before showing the dialog box, the
        /// folder with this path will be the selected folder, as long as
        /// <see cref="SelectedPath"/> is set to an absolute path that is a subfolder of
        /// <see cref="RootFolder"/> (or more accurately, points to a subfolder of the shell
        /// namespace represented by <see cref="RootFolder"/>).
        /// <para/>
        /// If the <see cref="IDialogService.ShowFolderBrowserDialog"/> returns <c>true</c>,
        /// meaning the user clicked the <c>OK</c> button, the <see cref="SelectedPath"/> property
        /// will return a string containing the path to the selected folder. If
        /// <see cref="IDialogService.ShowFolderBrowserDialog"/> returns <c>false</c>, meaning the
        /// user canceled out of the dialog box, this property will have the same value that it had
        /// prior to displaying the dialog box. If the user selects a folder that does not have a
        /// physical path (for example, My Computer), the <c>OK</c> button on the dialog box will
        /// be disabled.
        /// </remarks>
        public string SelectedPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the <b>New Folder</b> button appears in the
        /// folder browser dialog box.
        /// </summary>
        /// <value>
        /// <c>true</c> if the <b>New Folder</b> button is shown in the dialog box; otherwise,
        /// <c>false</c>. The default is <c>true</c>.
        /// </value>
        /// <remarks>
        /// When <see cref="ShowNewFolderButton"/> is <c>true</c>, the <b>New Folder</b> button is
        /// visible, giving the user a chance to create a folder. When the user clicks the
        /// <b>New Folder</b> button, a new folder is created and the user is prompted to specify
        /// the folder name. The selected node in the tree becomes the parent of the new folder.
        /// The actual caption of the <b>New Folder</b> button can vary depending upon the
        /// operating system.
        /// <para/>
        /// NOTE: Setting <see cref="ShowNewFolderButton"/> to <c>false</c> does not work on
        /// Windows 2000.
        /// </remarks>
        public bool ShowNewFolderButton { get; set; } = true;
    }
}
