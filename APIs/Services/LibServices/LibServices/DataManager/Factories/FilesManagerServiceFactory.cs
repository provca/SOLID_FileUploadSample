using LibServices.Configuration;
using LibServices.DataManager.Interfaces;
using LibServices.DataManager.Utilities;

namespace LibServices.DataManager.Factories
{
    public class FilesManagerServiceFactory
    {
        /// <summary>
        /// Validates a file based on its path and size.
        /// </summary>
        /// <param name="filePath">The full path of the file to be validated.</param>
        /// <param name="maxFileSize">
        /// The maximum allowable file size in bytes. If the value is less than or equal to zero, 
        /// the default size from <see cref="UploadFileSettings.MaxFileSize"/> is used.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the file is valid according to the validation rules; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="filePath"/> is null or empty.
        /// </exception>
        public static bool ValidateFile(string filePath, long maxFileSize = 0)
        {
            // Use the default max file size from settings if none is provided.
            maxFileSize = maxFileSize <= 0 ? UploadFileSettings.MaxFileSize : maxFileSize;

            // Create an instance of FileService using the provided file path.
            IFileService fileService = new FileService(filePath);

            // Initialize the FileValidatorService to handle validation logic, passing the max file size.
            IFileValidatorService fileValidatorService = new FileValidatorService(maxFileSize);

            // Validate the file using the validator service and return the result.
            return fileValidatorService.ValidateFile(fileService);
        }

        /// <summary>
        /// Uploads a file to the specified target path with the given custom file name.
        /// Uses static methods from <see cref="CustomValues_Utilities"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file to upload.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(string filePath, string filePathTarget = "", string customFileName = "")
        {
            //Retrieves custom values for file upload parameters, using default settings if not provided.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(0, filePathTarget, customFileName);

            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(null, customValues.FilePathTarget);

            // Upload file.
            return await fileUploadService.UploadFileAsync(fileService, customValues.CustomFileName);
        }

        /// <summary>
        /// Validates and uploads a file using the specified parameters.
        /// Uses static methods from <see cref="CustomValues_Utilities"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file to validate and upload.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes for validation.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> ValidateAndUploadFileAsync(string filePath, long maxFileSize = 0, string filePathTarget = "", string customFileName = "")
        {
            //Retrieves custom values for file upload parameters, using default settings if not provided.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(maxFileSize, filePathTarget, customFileName);

            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

            // Initialize the validation service.
            IFileValidatorService fileValidatorService = new FileValidatorService(customValues.MaxFileSize);

            // Validate the file before uploading it.
            if (!fileValidatorService.ValidateFile(fileService))
            {
                return (false, string.Empty);
            }

            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(fileValidatorService, customValues.FilePathTarget);

            // Upload file if valid.
            return await fileUploadService.UploadFileAsync(fileService, customValues.CustomFileName);
        }
    }
}
