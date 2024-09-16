using LibFilesManager;
using LibFilesManager.Interfaces;
using LibServices.Adapters;
using LibServices.Interfaces;

namespace LibServices
{
    /// <summary>
    /// Provides file upload services including validation before upload.
    /// </summary>
    public class FileUploadService : IFileUploadService
    {
        private readonly string _baseUploadPath;
        private readonly IFileValidatorService _fileValidatorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadService"/> class.
        /// </summary>
        /// <param name="baseUploadPath">The base path where the file will be uploaded.</param>
        /// <param name="fileValidatorService">The service used to validate the file before uploading.</param>
        public FileUploadService(string baseUploadPath, IFileValidatorService fileValidatorService)
        {
            _fileValidatorService = fileValidatorService ?? throw new ArgumentNullException(nameof(fileValidatorService));
            _baseUploadPath = baseUploadPath ?? throw new ArgumentNullException(nameof(baseUploadPath));
        }

        /// <inheritdoc cref="IFileUploadService.UploadFileAsync" />
        public async Task<string> UploadFileAsync(IFileService fileToUpload, string customFileName)
        {
            if (fileToUpload == null)
                throw new ArgumentNullException(nameof(fileToUpload), "No file provided for upload.");

            // Adapt the IFileService to IFile for file operations.
            IFile fileAdapter = new WinFormsFileToIFileServiceAdapter(fileToUpload);

            // Validate the file before uploading.
            if (!_fileValidatorService.ValidateFile(fileToUpload))
            {
                throw new InvalidOperationException("File validation failed.");
            }

            // Prepare the file uploader.
            IFileUpload fileUpload = new FileUpload(_baseUploadPath);

            // Upload the file and return the result.
            return await fileUpload.UploadFileAsync(fileAdapter, customFileName);
        }
    }
}
