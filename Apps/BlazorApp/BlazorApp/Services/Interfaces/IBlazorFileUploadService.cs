using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Services.Interfaces
{
    internal interface IBlazorFileUploadService
    {
        /// <summary>
        /// Uploads a file asynchronously to the server.
        /// </summary>
        /// <param name="browserFile">The file selected by the user in the browser.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <param name="filePathTarget">The target folder path where the file should be uploaded.</param>
        /// <returns>A tuple indicating success or failure and the uploaded file path.</returns>
        Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(IBrowserFile browserFile, string customFileName, string filePathTarget);
    }
}
