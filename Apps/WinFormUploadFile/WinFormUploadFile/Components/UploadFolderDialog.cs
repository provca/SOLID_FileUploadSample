using LibServices.Configuration;

namespace WinFormUploadFile.Components
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

            // Enable the use of the description as the title of the folder dialog.
            folderBrowserDialog.UseDescriptionForTitle = true;

            // Show the folder selection dialog.
            folderBrowserDialog.ShowDialog();
        }
    }
}