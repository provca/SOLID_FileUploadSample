using API_NetCore.Adapters;
using API_NetCore.Models;
using API_NetCore.Responses;
using LibServices.Configuration;
using LibServices.DataManager.Factories;
using Microsoft.AspNetCore.Mvc;

namespace API_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadForm_APIController : ControllerBase
    {
        /// <summary>
        /// Uploads a file using the provided model.
        /// </summary>
        /// <param name="model">The model containing the file and other metadata.</param>
        /// <returns>An IActionResult indicating the outcome of the upload.</returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadForm_APIModel model)
        {
            // Check if no file was uploaded or if the file is empty.
            if (model.FormFile == null || model.FormFile.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                // Set default values for the upload parameters.
                var valuesToCheck = SetDefaultValuesForModel(model);

                // Create an adapter for the uploaded file.
                FormFileToIFileServiceAdapter fileAdapter = new(model.FormFile);

                // Validate and upload the file.
                var fileUrl = await FilesManagerServiceFactoryForASP.ValidateAndUploadFileAsync(
                    fileAdapter,
                    valuesToCheck.folderTarget,
                    valuesToCheck.fileExtension,
                    valuesToCheck.maxFileSize,
                    valuesToCheck.customFileName
                );

                // Check if the file was uploaded successfully.
                if (fileUrl.isSuccess)
                {
                    return Ok(new FileUploadResponse
                    {
                        Message = $"File uploaded successfully in {fileUrl.uploadedFilePath}!",
                        UploadedFilePath = fileUrl.uploadedFilePath
                    });
                }
                else
                {
                    return StatusCode(500, "File upload failed.");
                }
            }
            catch (Exception ex)
            {
                // Return an error message if an exception occurs during the upload process.
                return StatusCode(500, $"An error occurred while uploading the file: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets default values for the <see cref="FileUploadForm_APIModel"/> if the user has not provided them.
        /// </summary>
        /// <param name="model">The <see cref="FileUploadForm_APIModel"/> containing the form data for file upload.</param>
        /// <returns>
        /// A tuple containing the folder target path, the file extension, the maximum file size, and the custom file name.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="model.FormFile"/> is null.
        /// </exception>
        private static (string folderTarget, string fileExtension, long maxFileSize, string customFileName) SetDefaultValuesForModel(FileUploadForm_APIModel model)
        {
            // Check if the FormFile is null and throw an exception if it is.
            if (model.FormFile == null)
            {
                throw new ArgumentNullException($"A valid FormFile is needed: {nameof(model.FormFile)}");
            }

            // Set folder target to a default path if not provided by the user.
            model.FolderTarget = string.IsNullOrEmpty(model.FolderTarget)
                ? UploadFileSettings.CustomFolderName
                : model.FolderTarget;

            // Extract the file extension.
            string extension = Path.GetExtension(model.FormFile.FileName).ToLower().Replace(".", "");

            // Define the default maximum file size (1 MB).
            long fileSize = UploadFileSettings.MaxFileSize;

            // Set custom file name to the original file name without extension if not provided by the user.
            model.CustomFileName = string.IsNullOrEmpty(model.CustomFileName)
                ? Path.GetFileNameWithoutExtension(model.FormFile.FileName)
                : model.CustomFileName;

            // Return the folder target, file extension, file size, and custom file name.
            return (model.FolderTarget, extension, fileSize, model.CustomFileName);
        }
    }
}
