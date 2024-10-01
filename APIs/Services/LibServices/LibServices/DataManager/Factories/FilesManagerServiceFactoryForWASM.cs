using LibServices.DataManager.Interfaces;
using LibServices.DataManager.Utilities;

namespace LibServices.DataManager.Factories
{
    /// <summary>
    /// Factory class for managing file uploads specific to WebAssembly applications.
    /// </summary>
    public class FilesManagerServiceFactoryForWASM
    {
        /// <summary>
        /// Validates and uploads a file asynchronously.
        /// </summary>
        /// <param name="fileService">An object that implements the IFileService interface, representing the file to upload.</param>
        /// <param name="maxFileSize">The maximum allowable size of the file in bytes. Defaults to 0, which uses the value from settings.</param>
        /// <param name="filePathTarget">The target directory path where the file should be uploaded.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A tuple containing a boolean indicating success and the path of the uploaded file if successful.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> ValidateAndUploadFileAsync(
            IFileService fileService,
            long maxFileSize = 0,
            string filePathTarget = "",
            string customFileName = "")
        {
            // Retrieve custom values for file upload, including max file size, target path, and custom file name.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(maxFileSize, filePathTarget, customFileName, true);

            // Initialize the file validator service with the maximum file size for validation.
            IFileValidatorService fileValidatorService = new FileValidatorService(customValues.MaxFileSize);

            // Validate the file; if validation fails, return false with an empty string.
            if (!fileValidatorService.ValidateFile(fileService))
            {
                return (false, string.Empty);
            }

            // Initialize the file upload service with the validated file and the target path.
            IFileUploadService fileUploadService = new FileUploadService(fileValidatorService, customValues.FilePathTarget);

            // Attempt to upload the file asynchronously and return the result.
            return await fileUploadService.UploadFileAsync(fileService, customValues.CustomFileName);
        }
    }
}
