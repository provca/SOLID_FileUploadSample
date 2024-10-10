using API_NetCore.Adapters;
using API_NetCore.Models;
using API_NetCore.Responses;
using LibServices.Configuration;
using LibServices.DataManager.Factories;
using Microsoft.AspNetCore.Mvc;

namespace API_NetCore.Controllers
{
    /// <summary>
    /// Controller for handling file uploads from the Excel Add-in.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UploadFileFromExcelController : ControllerBase
    {
        /// <summary>
        /// Uploads a file sent as a byte array from the Excel Add-in.
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
                // Use the adapter to convert the byte array to an IFileService compatible object.
                var fileAdapter = new ExcelByteArrayToIFileServiceAdapter(model.FileBytes, model.FileName);

                // Validate and upload the file using the factory.
                var fileUrlResult = await FilesManagerServiceFactoryForWASM.ValidateAndUploadFileAsync(
                    fileAdapter,
                    UploadFileSettings.MaxFileSizeWASM,
                    model.FilePathTarget,
                    model.CustomFileName
                );

                // Check if the file upload was successful.
                if (fileUrlResult.isSuccess)
                {
                    return Ok(new FileUploadResponse
                    {
                        Message = $"File uploaded successfully to {fileUrlResult.uploadedFilePath}!",
                        UploadedFilePath = fileUrlResult.uploadedFilePath
                    });
                }

                // If any unexpected error occurs, return an error.
                return StatusCode(500, "An unexpected error occurred during the file upload.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error response.
                return StatusCode(500, $"File upload failed: {ex.Message}");
            }
        }
    }
}

