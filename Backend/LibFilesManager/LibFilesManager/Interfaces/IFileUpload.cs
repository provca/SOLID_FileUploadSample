namespace LibFilesManager.Interfaces
{
    /// <summary>
    /// Interface for uploading a file.
    /// </summary>
    public interface IFileUpload
    {
        /// <summary>
        /// Asynchronously uploads a file and returns the success status and the saved file path.
        /// </summary>
        /// <param name="fileToUpload">The <see cref="IFile"/> to be uploaded.</param>
        /// <param name="customFileName">The custom name to use for saving the file.</param>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        ///   <item><c>isSuccess</c>: A boolean indicating whether the file was successfully uploaded.</item>
        ///   <item><c>filePath</c>: The path to the saved file if successful; otherwise, an empty string.</item>
        /// </returns>
        Task<(bool isSuccess, string filePath)> UploadFileAsync(IFile fileToUpload, string customFileName);
    }
}
