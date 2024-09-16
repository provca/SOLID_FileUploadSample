namespace LibServices.Interfaces
{
    /// <summary>
    /// Interface for services that handle file uploads.
    /// </summary>
    public interface IFileUploadService
    {
        /// <summary>
        /// Uploads a file asynchronously.
        /// </summary>
        /// <param name="fileToUpload">The file to upload, represented by <see cref="IFileService"/>.</param>
        /// <param name="customFileName">A custom name for the file. If null, a default name will be used.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is the path where the file is saved.</returns>
        Task<string> UploadFileAsync(IFileService fileToUpload, string customFileName);
    }
}
