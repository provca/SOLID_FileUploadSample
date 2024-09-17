namespace LibServices.DataManager.Interfaces
{
    /// <summary>
    /// Interface for services that handle file uploads.
    /// </summary>
    public interface IFileUploadService
    {
        /// <summary>
        /// Asynchronously uploads a file and returns the success status and the saved file path.
        /// </summary>
        /// <param name="fileToUpload">The <see cref="IFileService"/> to be uploaded.</param>
        /// <param name="customFileName">The custom name to use for saving the file, or null to use the original file name.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a tuple:
        /// <list type="bullet">
        ///   <item><c>isSuccess</c>: A boolean indicating whether the file was successfully uploaded.</item>
        ///   <item><c>filePath</c>: The path to the saved file if successful; otherwise, an empty string.</item>
        /// </returns>
        Task<(bool isSuccess, string filePath)> UploadFileAsync(IFileService fileToUpload, string customFileName);
    }
}
