namespace VSTO_ExcelUploadFile.Responses
{
    /// <summary>
    /// Represents the response received after attempting to upload a file.
    /// </summary>
    internal class FileUploadResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the file was uploaded successfully.
        /// </summary>
        public bool IsUploaded { get; set; }

        /// <summary>
        /// Gets or sets the message returned from the file upload operation, 
        /// providing additional details about the result.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the path of the uploaded file on the server.
        /// </summary>
        public string UploadedFilePath { get; set; }
    }
}