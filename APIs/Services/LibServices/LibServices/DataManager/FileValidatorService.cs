using LibFilesManager;
using LibFilesManager.Interfaces;
using LibServices.DataManager.Adapters;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager
{
    public class FileValidatorService : IFileValidatorService
    {
        private readonly string _selectedExtension;
        private readonly long _maxFileSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="IFileValidatorService"/> class.
        /// </summary>
        /// <param name="selectedExtension">The file extension to validate against.</param>
        /// <param name="maxFileSize">The maximum file size allowed for uploads.</param>
        public FileValidatorService(string selectedExtension, long maxFileSize)
        {
            _selectedExtension = selectedExtension;
            _maxFileSize = maxFileSize;
        }

        /// <inheritdoc />
        public bool ValidateFile(IFileService fileService)
        {
            IFile fileAdapter = new WinFormsFileToIFileServiceAdapter(fileService);

            IFileValidator fileValidator = new FileValidator(_selectedExtension, _maxFileSize);

            return fileValidator.ValidateFile(fileAdapter);
        }
    }
}
