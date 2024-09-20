using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager.Factories
{
    public class FilesManagerServiceFactoryForASP
    {
        /// <summary>
        /// Validates a file using the specified parameters FOR asp.net applications.
        /// </summary>
        /// <param name="fileService">The file to be validated and uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="selectedExtension">The expected file extension.</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes.</param>
        /// <returns>True if the file is valid; otherwise, false.</returns>
        public static bool ValidateFile(IFileService fileService, string selectedExtension, long maxFileSize)
        {
            // Initialize the FileValidatorService with parameters for validation.
            IFileValidatorService fileValidatorService = new FileValidatorService(selectedExtension, maxFileSize);

            // Validate state.
            return fileValidatorService.ValidateFile(fileService);
        }

        /// <summary>
        /// Uploads a file to the specified target path with the given custom file name for ASP.NET applications.
        /// </summary>
        /// <param name="fileService">The file to be validated and uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(IFileService fileService, string filePathTarget, string customFileName)
        {
            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(filePathTarget, null);

            // Upload file.
            return await fileUploadService.UploadFileAsync(fileService, customFileName);
        }

        /// <summary>
        /// Validates and uploads a file asynchronously for ASP.NET applications.
        /// </summary>
        /// <param name="fileService">The file to be validated and uploaded, wrapped in an <see cref="IFileService"/> adapter.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="selectedExtension">The expected file extension for validation (e.g., "jpg").</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes for validation.</param>
        /// <param name="customFileName">Optional custom file name for the uploaded file. If not provided, the original file name will be used.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains a tuple with a boolean indicating whether the upload was successful, 
        /// and a string representing the path to the uploaded file if successful.
        /// </returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> ValidateAndUploadFileAsync(IFileService fileService, string filePathTarget, string selectedExtension, long maxFileSize, string customFileName)
        {
            // Initialize the validation service.
            IFileValidatorService fileValidatorService = new FileValidatorService(selectedExtension, maxFileSize);

            // Validate the file before uploading it.
            if (!fileValidatorService.ValidateFile(fileService))
            {
                return (false, string.Empty);
            }

            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(filePathTarget, fileValidatorService);

            // Upload file if valid.
            return await fileUploadService.UploadFileAsync(fileService, customFileName);
        }

    }
}
