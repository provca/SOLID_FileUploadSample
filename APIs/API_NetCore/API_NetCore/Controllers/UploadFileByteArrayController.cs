using API_NetCore.Adapters;
using API_NetCore.Models;
using API_NetCore.Responses;
using LibServices.Configuration;
using LibServices.DataManager.Factories;
using Microsoft.AspNetCore.Mvc;

namespace API_NetCore.Controllers
{
    /// <summary>
    /// Controller for handling file uploads from Blazor WebAssembly using byte arrays.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileByteArrayController : ControllerBase
    {
        /// <summary>
        /// Uploads a file sent as a byte array from the client.
        /// </summary>
        /// <param name="model">The model containing the file as a byte array, along with the file name, custom file name, and target path.</param>
        /// <returns>Returns a success response if the file is uploaded, or an error if the upload fails.</returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileByteArrayModel model)
        {
            // Validate if the file content exists.
            if (model.FileBytes == null || model.FileBytes.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                // Adapter to transform the byte array into a file service compatible object.
                var fileAdapter = new ByteArrayToIFileServiceAdapter(model.FileBytes, model.FileName);

                // Use the file manager service to validate and upload the file.
                var fileUrlResult = await FilesManagerServiceFactoryForASP.ValidateAndUploadFileAsync(
                    fileAdapter,
                    UploadFileSettings.MaxFileSize,
                    model.FilePathTarget,
                    model.CustomFileName
                );

                // If the upload succeeds, return a success message and the file path.
                if (fileUrlResult.isSuccess)
                {
                    return Ok(new FileUploadResponse
                    {
                        Message = $"File uploaded successfully to {fileUrlResult.uploadedFilePath}!",
                        UploadedFilePath = fileUrlResult.uploadedFilePath
                    });
                }

                // If something goes wrong during the upload process, return an error.
                return StatusCode(500, "An unexpected error occurred during the file upload.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return a failure response with the error message.
                return StatusCode(500, $"File upload failed: {ex.Message}");
            }
        }
    }
}

