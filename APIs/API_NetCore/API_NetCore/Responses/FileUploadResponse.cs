namespace API_NetCore.Responses
{
    /// <summary>
    /// Represents the response returned after a file upload operation.
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// Gets or sets a message indicating the result of the upload operation.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the file path of the uploaded file.
        /// </summary>
        public string UploadedFilePath { get; set; } = string.Empty;
    }

}
