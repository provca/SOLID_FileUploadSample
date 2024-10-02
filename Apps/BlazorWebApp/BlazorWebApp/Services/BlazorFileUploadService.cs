using BlazorWebApp.Models;
using BlazorWebApp.Services.Interfaces;
using BlazorWebApp.Utilities;
using Microsoft.AspNetCore.Components.Forms;
using System.Text;
using System.Text.Json;

namespace BlazorWebApp.Services
{
    /// <summary>
    /// This class implements the <see cref="IBlazorFileUploadService"/> interface to handle 
    /// the file upload process from a Blazor WebAssembly application.
    /// It converts the selected file into a byte array and sends it via an HTTP POST request 
    /// to the API for storage.
    /// </summary>
    public class BlazorFileUploadService : IBlazorFileUploadService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlazorFileUploadService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to send requests to the API.</param>
        public BlazorFileUploadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<bool> UploadFileAsync(IBrowserFile browserFile, string customFileName, string filePathTarget)
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

            // Serializes the model to JSON format for the HTTP request.
            var jsonContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

            // Sends a POST request to the API to upload the file.
            var response = await _httpClient.PostAsync("api/UploadFileByteArray/UploadFile", jsonContent);

            // Checks if the response indicates a successful upload.
            if (!response.IsSuccessStatusCode)
            {
                // Logs an error message if the upload fails, including the error content.
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error uploading file: {error}");
            }

            // File successfully uploaded.
            return true;
        }
    }
}
