using LibServices.Configuration;

namespace WinFormUploadFile.Components
{
    /// <summary>
    /// Class that configures and shows an OpenFileDialog for file uploads.
    /// </summary>
    internal class UploadFileDialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileDialog"/> class
        /// and configures the OpenFileDialog settings based on predefined upload settings.
        /// </summary>
        /// <param name="openFileDialog">The OpenFileDialog to configure and display.</param>
        public UploadFileDialog(OpenFileDialog openFileDialog)
        {
            // Set the title of the file dialog window.
            openFileDialog.Title = UploadFileSettings.FDTitle;

            // Set the initial directory to be displayed when the dialog opens.
            openFileDialog.InitialDirectory = UploadFileSettings.FDInitialDirectory;

            // Set the file filter to control which file types are displayed.
            openFileDialog.Filter = UploadFileSettings.FDFilter;

            // Set the default filter index (which file type is selected by default).
            openFileDialog.FilterIndex = UploadFileSettings.FDFilterIndex;

            // Show the file dialog.
            openFileDialog.ShowDialog();
        }
    }
}

