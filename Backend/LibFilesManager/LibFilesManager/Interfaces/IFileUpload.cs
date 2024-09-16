namespace LibFilesManager.Interfaces
{
    /// <summary>
    /// Interface for uploading a file.
    /// </summary>
    public interface IFileUpload
    {
        /// <summary>
        /// Asynchronously uploads a file and returns the file's path.
        /// </summary>
        /// <param name="fileToUpload">The file to be uploaded.</param>
        /// <param name="customFileName">A custom file name for the uploaded file.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the file path of the uploaded file.</returns>
        Task<string> UploadFileAsync(IFile fileToUpload, string customFileName);
    }
}
