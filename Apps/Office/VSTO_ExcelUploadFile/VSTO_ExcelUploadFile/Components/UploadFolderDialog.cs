using System.Windows.Forms;

namespace VSTO_ExcelUploadFile.Configuration
{
    /// <summary>
    /// Class that configures and shows a FolderBrowserDialog for folder selection during file uploads.
    /// </summary>
    internal class UploadFolderDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFolderDialog"/> class
        /// and configures the FolderBrowserDialog settings based on predefined upload settings.
        /// </summary>
        /// <param name="folderBrowserDialog">The FolderBrowserDialog to configure and display.</param>
        public UploadFolderDialog(FolderBrowserDialog folderBrowserDialog)
        {
            // Set the description or title of the folder dialog window.
            folderBrowserDialog.Description = UploadFileSettings.FBDDescription;

            // Show the folder selection dialog.
            folderBrowserDialog.ShowDialog();
        }
    }
}
