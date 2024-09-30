using LibFilesManager;
using LibFilesManager.Interfaces;
using LibServices.DataManager.Adapters;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager
{
    /// <summary>
    /// Provides file upload services including validation before upload.
    /// </summary>
    public class FileUploadService : IFileUploadService
    {
        private readonly string _filePathTarget;
        private readonly IFileValidatorService _fileValidatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadService"/> class.
        /// </summary>
        /// <param name="fileValidatorService">The service used to validate the file before uploading.</param>
        /// <param name="filePathTarget">The base path where the file will be uploaded.</param>
        public FileUploadService(IFileValidatorService fileValidatorService, string filePathTarget)
        {
            _fileValidatorService = fileValidatorService ?? throw new ArgumentNullException(nameof(fileValidatorService));
            _filePathTarget = filePathTarget ?? throw new ArgumentNullException(nameof(filePathTarget));
        }

        /// <inheritdoc />
        public async Task<(bool isSuccess, string filePath)> UploadFileAsync(IFileService fileService, string customFileName)
        {
            if (fileService == null)
                throw new ArgumentNullException(nameof(fileService), "No file provided for upload.");

            // Adapt the IFileService to IFile for file operations.
            IFile fileAdapter = new IFileToIFileServiceAdapter(fileService);

            // Validate the file before uploading.
            if (!_fileValidatorService.ValidateFile(fileService))
            {
                throw new InvalidOperationException("File validation failed.");
            }

            // Prepare the file uploader.
            IFileUpload fileUpload = new FileUpload(_filePathTarget);

            // Upload the file and return the result.
            return await fileUpload.UploadFileAsync(fileAdapter, customFileName);
        }

        /// <inheritdoc />
        public async Task<(bool isSuccess, string filePath)> UploadFileAsyncASP(IFileService fileService, string customFileName)
        {
            // Check if the file to upload is null and throw an exception if no file is provided.
            if (fileService == null)
                throw new ArgumentNullException(nameof(fileService), "No file provided for upload.");

            // Adapt the IFile to IFileService for file operations.
            IFile fileAdapter = new FormFileToIFileServiceAdapter(fileService);

            // Validate the file before uploading.
            if (!_fileValidatorService.ValidateFile(fileService))
            {
                throw new InvalidOperationException("File validation failed.");
            }

            // Prepare the file uploader.
            IFileUpload fileUpload = new FileUpload(_filePathTarget);

            // Upload the file and return the result.
            return await fileUpload.UploadFileAsync(fileAdapter, customFileName);
        }

    }
}
