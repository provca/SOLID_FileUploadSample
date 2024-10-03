using BlazorApp.Models;
using BlazorApp.Services.Interfaces;
using BlazorApp.Utilities;
using LibServices.Configuration;
using LibServices.DataManager.Adapters;
using LibServices.DataManager.Factories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
namespace BlazorApp.Services
{
    /// <summary>
    /// Service responsible for handling file uploads in the Blazor application.
    /// </summary>
    public class BlazorFileUploadService : IBlazorFileUploadService
    {
        private readonly IJSRuntime _jsRuntime;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlazorFileUploadService"/> class.
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime for logging and interop operations.</param>
        public BlazorFileUploadService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <inheritdoc />
        public async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(IBrowserFile browserFile, string customFileName, string filePathTarget)
        {
            // Converts the selected file to a byte array.
            byte[] fileBytes = await Utilities_ConvertTo.ConvertToByteArray(browserFile);

            // Creates a model containing the file data for the upload.
            UploadFileByteArrayModel model = new()
            {
                FileBytes = fileBytes,
                FileName = browserFile.Name,
                CustomFileName = customFileName,
                FilePathTarget = filePathTarget
            };

            try
            {
                // Adapter to transform the byte array into a file service compatible object.
                ByteArrayToIFileServiceAdapter fileAdapter = new(model.FileBytes, model.FileName);

                // Use the file manager service to validate and upload the file.
                var fileUrlResult = await FilesManagerServiceFactoryForWASM.ValidateAndUploadFileAsync(
                    fileAdapter,
                    UploadFileSettings.MaxFileSizeWASM,
                    model.FilePathTarget,
                    model.CustomFileName
                );

                return fileUrlResult;
            }
            catch (Exception ex)
            {
                // Returns false and the exception message if an error occurs.
                return (false, ex.ToString());
            }
        }
    }
}

