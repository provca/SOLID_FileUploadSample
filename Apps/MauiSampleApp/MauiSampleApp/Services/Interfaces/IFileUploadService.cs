namespace MauiSampleApp.Services.Interfaces
{
    /// <summary>
    /// Provides methods for uploading files within the application.
    /// </summary>
    public interface IFileUploadService
    {
        /// <summary>
        /// Asynchronously uploads a file to a specified location on the server.
        /// </summary>
        /// <param name="file">The file selected by the user for upload.</param>
        /// <param name="customFileName">The custom name to assign to the uploaded file.</param>
        /// <param name="filePathTarget">The target directory path where the file should be uploaded.</param>
        /// <returns>A tuple indicating the success of the upload and the path to the uploaded file if successful.</returns>
        Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(FileResult file, string customFileName, string filePathTarget);
    }
}
