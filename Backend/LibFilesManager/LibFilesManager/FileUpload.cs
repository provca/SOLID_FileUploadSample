using LibFilesManager.Interfaces;
using System.Diagnostics;

namespace LibFilesManager
{
    public class FileUpload : IFileUpload
    {
        // The base path where files are stored.
        private readonly string _baseUploadPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUpload"/> class with necessary dependencies.
        /// </summary>
        /// <param name="baseUploadPath">The base path where files will be uploaded.</param>
        public FileUpload(string baseUploadPath)
        {
            _baseUploadPath = baseUploadPath;
        }

        /// <inheritdoc />
        public async Task<string> UploadFileAsync(IFile fileToUpload, string customFileName)
        {
            // Save the file to the desired location.
            return await SaveFileAsync(fileToUpload, customFileName);
        }

        /// <summary>
        /// Saves the file to the server with a custom or automatically generated name.
        /// </summary>
        /// <param name="fileToUpload">The file to save.</param>
        /// <param name="customFileName">Custom file name.</param>
        /// <returns>The file path where the file was saved.</returns>
        private async Task<string> SaveFileAsync(IFile fileToUpload, string customFileName)
        {
            // Ensure the directory for the uploaded files exists.
            Directory.CreateDirectory(_baseUploadPath);

            string fileName;

            // Extract original file name and extension
            string originalFileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileToUpload.FileName);
            string originalFileExtension = Path.GetExtension(fileToUpload.FileName);

            // If a custom file name is provided, use it. Otherwise, use the original file name.
            if (!string.IsNullOrEmpty(customFileName))
            {
                // Check if the custom file name already includes the extension.
                if (!customFileName.EndsWith(originalFileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    // Add the original extension to the custom file name if not present.
                    fileName = $"{customFileName}{originalFileExtension}";
                }
                else
                {
                    // Use the custom file name as is (it already contains the extension).
                    fileName = customFileName;
                }
            }
            else
            {
                // Use original file name and extension.
                fileName = $"{originalFileNameWithoutExtension}{originalFileExtension}";
            }

            // Generate the full path for the file.
            string filePath = Path.Combine(_baseUploadPath, fileName);

            try
            {
                // Save the file to the specified path.
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (var uploadStream = fileToUpload.OpenReadStream())
                    {
                        // Asynchronously copy the file content to the file stream.
                        await uploadStream.CopyToAsync(fileStream);
                    }
                }

                // Log the successful file save operation.
                Trace.WriteLine($"File saved as {fileName}.");

                // Return the full path where the file was saved.
                return filePath;
            }
            catch (Exception ex)
            {
                // Log any errors encountered during file save.
                Trace.WriteLine($"Error to save the file: {ex.Message}");
                throw;
            }
        }
    }
}
