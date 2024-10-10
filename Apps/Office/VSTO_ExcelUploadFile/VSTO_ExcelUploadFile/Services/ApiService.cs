using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VSTO_ExcelUploadFile.Configuration;
using VSTO_ExcelUploadFile.Responses;

namespace VSTO_ExcelUploadFile.Services
{
    /// <summary>
    /// Provides methods to interact with the API for file upload operations.
    /// </summary>
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class, 
        /// setting the base address for the HTTP client.
        /// </summary>
        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001")
            };
        }

        /// <summary>
        /// Uploads a file to the API using the provided file path.
        /// </summary>
        /// <param name="filePath">The full path of the file to upload.</param>
        /// <returns>
        /// A tuple containing a boolean indicating success or failure, 
        /// and a string with either the file path on success or an error message on failure.
        /// </returns>
        public async Task<(bool, string)> UploadFileToApi(string filePath)
        {
            // Reads the file bytes from the specified file path.
            var fileContent = File.ReadAllBytes(filePath);

            // Prepares the file upload model.
            var uploadModel = new
            {
                FileBytes = fileContent,
                FileName = Path.GetFileName(filePath),
                UploadFileSettings.CustomFileName,
                UploadFileSettings.FilePathTarget,
            };

            // Serializes the upload model to JSON format.
            var jsonContent = JsonConvert.SerializeObject(uploadModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Sends a POST request to the API with the JSON payload.
            var response = await _httpClient.PostAsync("/api/UploadFileFromExcel/UploadFile", content);

            // Checks if the response was successful.
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FileUploadResponse>(responseContent);

                // Returns true and the uploaded file path if the upload was successful.
                return result.IsUploaded
                    ? (true, result.UploadedFilePath)
                    : (false, result.Message);
            }
            else
            {
                // Returns false and the HTTP error message if the request failed.
                return (false, $"HTTP Error: {response.ReasonPhrase}");
            }
        }
    }
}

