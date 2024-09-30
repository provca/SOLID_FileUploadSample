using LibFilesManager;
using LibFilesManager.Interfaces;
using LibServices.DataManager.Adapters;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager
{
    public class FileValidatorService : IFileValidatorService
    {
        private readonly long _maxFileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="IFileValidatorService"/> class.
        /// </summary>
        /// <param name="maxFileSize">The maximum file size allowed for uploads.</param>
        public FileValidatorService(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        /// <inheritdoc />
        public bool ValidateFile(IFileService fileService)
        {
            IFile fileAdapter = new IFileToIFileServiceAdapter(fileService);

            IFileValidator fileValidator = new FileValidator(_maxFileSize);

            return fileValidator.ValidateFile(fileAdapter);
        }
    }
}
