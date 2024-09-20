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

        /// <summary>
        /// Asynchronously uploads a file to the server after validating it.
        /// </summary>
        /// <param name="fileService">The file to be uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="customFileName">custom file name for the uploaded file. If not provided, the original file name will be used.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a tuple with a boolean indicating whether the upload was successful, 
        /// and a string representing the path to the uploaded file if successful.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileService"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when file validation fails.</exception>
        Task<(bool isSuccess, string filePath)> UploadFileAsyncASP(IFileService fileService, string customFileName);
    }
}
