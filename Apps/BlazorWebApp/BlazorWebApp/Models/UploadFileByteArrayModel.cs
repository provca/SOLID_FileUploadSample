namespace BlazorWebApp.Models
{
    /// <summary>
    /// Represents the model used for uploading files as a byte array in the Blazor Web application.
    /// </summary>
    public class UploadFileByteArrayModel
    {
        /// <summary>
        /// Gets or sets the byte array representing the file to be uploaded.
        /// </summary>
        public byte[]? FileBytes { get; set; }

        /// <summary>
        /// Gets or sets the original file name as provided by the user.
        /// This is typically used to retain the name of the uploaded file.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the custom file name specified by the user for the uploaded file.
        /// If not specified, a default name may be used during the upload process.
        /// </summary>
        public string CustomFileName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the target path where the file will be uploaded.
        /// If not provided, a default upload path may be used.
        /// </summary>
        public string FilePathTarget { get; set; } = string.Empty;
    }
}

