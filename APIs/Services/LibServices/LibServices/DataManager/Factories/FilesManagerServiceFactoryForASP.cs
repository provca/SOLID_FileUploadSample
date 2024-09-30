using LibServices.Configuration;
using LibServices.DataManager.Interfaces;
using LibServices.DataManager.Utilities;

namespace LibServices.DataManager.Factories
{
    public class FilesManagerServiceFactoryForASP
    {
        /// <summary>
        /// Validates a file using the provided <see cref="IFileService"/> and an optional maximum file size.
        /// Uses static methods from <see cref="CustomValues_Utilities"/> class.
        /// </summary>
        /// <param name="fileService">The service representing the file to be validated.</param>
        /// <param name="maxFileSize">
        /// The maximum allowable file size in bytes. If not provided or set to zero, 
        /// the default size from <see cref="UploadFileSettings.MaxFileSize"/> is used.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the file is valid according to the validation rules; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="fileService"/> is null.
        /// </exception>
        public static bool ValidateFile(IFileService fileService, long maxFileSize = 0)
        {
            // Ensure that the file service is not null.
            if (fileService == null)
            {
                throw new ArgumentNullException(nameof(fileService), "File service cannot be null.");
            }

            //Retrieves custom values for file upload parameters, using default settings if not provided.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(maxFileSize, string.Empty, string.Empty);

            // Initialize the FileValidatorService to handle validation logic, passing the max file size.
            IFileValidatorService fileValidatorService = new FileValidatorService(customValues.MaxFileSize);

            // Validate the file using the file validator service and return the result.
            return fileValidatorService.ValidateFile(fileService);
        }

        /// <summary>
        /// Uploads a file to the specified target path with the given custom file name for ASP.NET applications.
        /// Uses static methods from <see cref="CustomValues_Utilities"/> class.
        /// </summary>
        /// <param name="fileService">The file to be validated and uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(IFileService fileService, string filePathTarget = "", string customFileName = "")
        {
            //Retrieves custom values for file upload parameters, using default settings if not provided.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(0, filePathTarget, customFileName);

            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(null, customValues.FilePathTarget);

            // Upload file.
            return await fileUploadService.UploadFileAsync(fileService, customValues.CustomFileName);
        }

        /// <summary>
        /// Validates and uploads a file asynchronously for ASP.NET applications.
        /// Uses static methods from <see cref="CustomValues_Utilities"/> class.
        /// </summary>
        /// <param name="fileService">The file to be validated and uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes for validation.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="customFileName">Optional custom file name for the uploaded file. If not provided, the original file name will be used.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a tuple with a boolean indicating whether the upload was successful, 
        /// and a string representing the path to the uploaded file if successful.
        /// </returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> ValidateAndUploadFileAsync(IFileService fileService, long maxFileSize = 0, string filePathTarget = "", string customFileName = "")
        {
            //Retrieves custom values for file upload parameters, using default settings if not provided.
            var customValues = CustomValues_Utilities.GetCustomValuesFromFile(maxFileSize, filePathTarget, customFileName);

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
