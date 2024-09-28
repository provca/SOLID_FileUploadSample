using LibServices.Configuration;
using Microsoft.AspNetCore.Components.Forms;

namespace API_NetCore.Models
{
    /// <summary>
    /// Model representing the form data for file uploads.
    /// </summary>
    public class FileUploadBrowserFileModel
    {
        /// <summary>
        /// The file uploaded by the user.
        /// </summary>
        public IBrowserFile? BrowserFile { get; set; }

        /// <summary>
        /// The name of the uploaded file.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The file path where the uploaded file will be saved.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// The custom file name provided by the user (optional).
        /// Defaults to "customFileName" if not provided.
        /// </summary>
        public string CustomFileName { get; set; } = UploadFileSettings.CustomFileName;

        /// <summary>
        /// The folder path where the uploaded file will be saved.
        /// Defaults to "C:\DefaultUploadedImages\" if not specified.
        /// </summary>
        public string FolderTarget { get; set; } = UploadFileSettings.CustomFolderName;
    }
}
