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
    public class UploadFileFormModelController : ControllerBase
    {
        /// <summary>
        /// Uploads a file using the provided model.
        /// </summary>
        /// <param name="model">The model containing the file and other metadata.</param>
        /// <returns>An IActionResult indicating the outcome of the upload.</returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileFormModel model)
        {
            // Initial validation of the uploaded file.
            if (model.FormFile == null || model.FormFile.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                // Sets the default values in the model.
                var valuesToCheck = SetDefaultValuesForModel(model);

                // Check if the model state is invalid.
                if (!ModelState.IsValid)
                {
                    LogModelStateErrors();
                    return BadRequest("Invalid model.");
                }

                // File adapter for the file handling service.
                var fileAdapter = new FormFileToIFileServiceAdapter(model.FormFile);

                // Try to validate and upload the file using the factory.
                var fileUrlResult = await FilesManagerServiceFactoryForASP.ValidateAndUploadFileAsync(
                    fileAdapter,
                    UploadFileSettings.MaxFileSize,
                    valuesToCheck.FilePathTarget,
                    valuesToCheck.CustomFileName
                );

                // If the upload process is successful, return a success message.
                if (fileUrlResult.isSuccess)
                {
                    return Ok(new FileUploadResponse
                    {
                        Message = $"File uploaded successfully to {fileUrlResult.uploadedFilePath}!",
                        UploadedFilePath = fileUrlResult.uploadedFilePath
                    });
                }

                // If an unexpected error occurred during the upload.
                return StatusCode(500, "An unexpected error occurred during the file upload.");
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                // Handle specific exceptions related to file validation.
                return BadRequest($"File validation failed: {ex.Message}");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                // Handle exceptions related to problems during file uploads (e.g. file system access).
                return StatusCode(500, $"File upload failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions.
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets default values for the <see cref="UploadFileFormModel"/> if the user has not provided them.
        /// </summary>
        /// <param name="model">The <see cref="UploadFileFormModel"/> containing the form data for file upload.</param>
        /// <returns>
        /// A tuple containing the folder target path, the file extension, the maximum file size, and the custom file name.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="model.FormFile"/> is null.
        /// </exception>
        private static (string FilePathTarget, string CustomFileName) SetDefaultValuesForModel(UploadFileFormModel model)
        {
            if (model.FormFile == null)
            {
                throw new ArgumentNullException($"A valid FormFile is needed: {nameof(model.FormFile)}");
            }

            // Set custom file name to the original file name without extension if not provided by the user.
            model.CustomFileName = string.IsNullOrEmpty(model.CustomFileName)
                ? Path.GetFileNameWithoutExtension(model.FormFile.FileName)
                : model.CustomFileName;

            // Set folder target to a default path if not provided by the user.
            model.FilePathTarget = string.IsNullOrEmpty(model.FilePathTarget)
                ? Path.GetFullPath(UploadFileSettings.FilePathTarget)
                : model.FilePathTarget;

            // Return the file size, folder target, and custom file name.
            return (model.FilePathTarget, model.CustomFileName);
        }

        /// <summary>
        /// Logs errors from the model state when validation fails.
        /// </summary>
        private void LogModelStateErrors()
        {
            // Loop through the model state to extract errors and log them.
            foreach (var state in ModelState)
            {
                var errors = string.Join(",", state.Value.Errors.Select(e => e.ErrorMessage));
                Console.WriteLine($"{state.Key}: {errors}");
            }
        }
    }
}
