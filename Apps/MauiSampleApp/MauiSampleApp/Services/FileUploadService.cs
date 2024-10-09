using LibServices.Configuration;
using LibServices.DataManager.Adapters;
using LibServices.DataManager.Factories;
using MauiSampleApp.Models;
using MauiSampleApp.Services.Interfaces;
using MauiSampleApp.Utilities;

namespace MauiSampleApp.Services
{
    /// <summary>
    /// Implements the file upload functionality, handling the upload of files to a server.
    /// </summary>
    public class FileUploadService : IFileUploadService
    {
        /// <inheritdoc />
        public async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(FileResult file, string customFileName, string filePathTarget)
        {
            // Converts the selected file to a byte array for processing.
            byte[] fileBytes = await Utilities_ConvertTo.ConvertToByteArray(file);

            // Creates a model to contain the file data needed for upload.
            UploadFileByteArrayModel model = new()
            {
                FileBytes = fileBytes,
                FileName = file.FileName,
                CustomFileName = customFileName,
                FilePathTarget = filePathTarget
            };

            try
            {
                // Adapts the byte array to an object compatible with the file service.
                ByteArrayToIFileServiceAdapter fileAdapter = new(model.FileBytes, model.FileName);

                // Validates and uploads the file using the file manager service.
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
                // Returns a failed result with the error message if an exception occurs.
                return (false, ex.ToString());
            }
        }
    }
}

