namespace API_NetCore.Models
{
    /// <summary>
    /// Represents the model for uploading a file using a byte array in the API.
    /// </summary>
    public class UploadFileByteArrayModel
    {
        /// <summary>
        /// Gets or sets the file content as a byte array.
        /// </summary>
        public byte[]? FileBytes { get; set; }

        /// <summary>
        /// The name of the uploaded file.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The custom file name provided by the user (optional).
        /// Defaults to "customFileName" if not provided.
        /// </summary>
        public string CustomFileName { get; set; } = string.Empty;

        /// <summary>
        /// The folder path where the uploaded file will be saved.
        /// Defaults to "C:\DefaultUploadedImages\" if not specified.
        /// </summary>
        public string FilePathTarget { get; set; } = string.Empty;
    }
}
