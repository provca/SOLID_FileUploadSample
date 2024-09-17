using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager.Factories
{
    public class FilesManagerServiceFactory
    {
        /// <summary>
        /// Validates a file using the specified parameters.
        /// </summary>
        /// <param name="filePath">The path of the file to validate.</param>
        /// <param name="selectedExtension">The expected file extension.</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes.</param>
        /// <returns>True if the file is valid; otherwise, false.</returns>
        public static bool ValidateFile(string filePath, string selectedExtension, long maxFileSize)
        {
            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

            // Initialize the FileValidatorService with parameters for validation.
            IFileValidatorService fileValidatorService = new FileValidatorService(selectedExtension, maxFileSize);

            // Validate state.
            return fileValidatorService.ValidateFile(fileService);
        }

        /// <summary>
        /// Uploads a file to the specified target path with the given custom file name.
        /// </summary>
        /// <param name="filePath">The path of the file to upload.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> UploadFileAsync(string filePath, string filePathTarget, string customFileName)
        {
            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

            // Create FileUploadService instance to manage file upload.
            IFileUploadService fileUploadService = new FileUploadService(filePathTarget, null);

            // Upload file.
            return await fileUploadService.UploadFileAsync(fileService, customFileName);
        }

        /// <summary>
        /// Validates and uploads a file using the specified parameters.
        /// </summary>
        /// <param name="filePath">The path of the file to validate and upload.</param>
        /// <param name="filePathTarget">The target path where the file will be uploaded.</param>
        /// <param name="selectedExtension">The expected file extension for validation.</param>
        /// <param name="maxFileSize">The maximum allowed file size in bytes for validation.</param>
        /// <param name="customFileName">The custom name for the uploaded file.</param>
        /// <returns>A task representing the asynchronous operation, with a tuple containing a boolean indicating success and the uploaded file path.</returns>
        public static async Task<(bool isSuccess, string uploadedFilePath)> ValidateAndUploadFileAsync(string filePath, string filePathTarget, string selectedExtension, long maxFileSize, string customFileName)
        {
            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

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
