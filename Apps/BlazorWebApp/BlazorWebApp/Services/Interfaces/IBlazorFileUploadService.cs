using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebApp.Services.Interfaces
{
    internal interface IBlazorFileUploadService
    {
        /// <summary>
        /// Uploads the selected file to the server using the provided file name and target path.
        /// </summary>
        /// <param name="browserFile">The file selected by the user in the Blazor application.</param>
        /// <param name="customFileName">The custom file name for the uploaded file. If empty, the original file name is used.</param>
        /// <param name="filePathTarget">The folder path where the file will be uploaded.</param>
        /// <returns>A task representing the asynchronous operation containing a boolean indicating success of the uploaded file.</returns>
        /// <exception cref="HttpRequestException">Thrown when the file upload fails.</exception>
        Task<bool> UploadFileAsync(IBrowserFile browserFile, string customFileName, string filePathTarget);
    }
}
