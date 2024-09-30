using LibFilesManager.Interfaces;
using System.Diagnostics;

namespace LibFilesManager
{
    public class FileUpload : IFileUpload
    {
        // The base path where files are stored.
        private readonly string _filePathTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUpload"/> class with necessary dependencies.
        /// </summary>
        /// <param name="filePathTarget">The base path where files will be uploaded.</param>
        public FileUpload(string filePathTarget)
        {
            _filePathTarget = filePathTarget;
        }

        /// <inheritdoc />
        public async Task<(bool isSuccess, string filePath)> UploadFileAsync(IFile file, string customFileName)
        {
            try
            {
                // Save the file to the desired location.
                string savedFilePath = await SaveFileAsync(file, customFileName);

                // Returns true and the path if everything goes well.
                return (true, savedFilePath);
            }
            catch
            {
                // Returns false and an empty string on failure.
                return (false, string.Empty);
            }
        }

        /// <summary>
        /// Saves the file to the server with a custom or automatically generated name.
        /// </summary>
        /// <param name="file">The file to save.</param>
        /// <param name="customFileName">Custom file name.</param>
        /// <returns>The file path where the file was saved.</returns>
        private async Task<string> SaveFileAsync(IFile file, string customFileName)
        {
            // Ensure the directory for the uploaded files exists.
            Directory.CreateDirectory(_filePathTarget);

            string fileName;

            // Extract original file name and extension
            string originalFileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            string originalFileExtension = Path.GetExtension(file.FileName);

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
            string filePath = Path.Combine(_filePathTarget, fileName);

            try
            {
                // Save the file to the specified path.
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    using (var uploadStream = file.OpenReadStream())
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
