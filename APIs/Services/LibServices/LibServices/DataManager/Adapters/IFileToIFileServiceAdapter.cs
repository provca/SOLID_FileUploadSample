using LibFilesManager.Enums;
using LibFilesManager.Interfaces;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager.Adapters
{
    /// <summary>
    /// Adapter class for converting an <see cref="IFileService"/> instance into an <see cref="IFile"/>.
    /// Specifically designed for use in Windows Forms projects.
    /// </summary>
    public class IFileToIFileServiceAdapter : IFile
    {
        // The original file service object being adapted.
        private readonly IFileService _fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IFileToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="fileService">An instance of <see cref="IFileService"/> to be adapted.</param>
        public IFileToIFileServiceAdapter(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <inheritdoc />
        public string FileName => Path.GetFileName(_fileService.FileName);

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_fileService.FileName);

        /// <inheritdoc />
        public string ContentType => GetMimeType();

        /// <inheritdoc />
        public long Length => _fileService.Length;

        /// <inheritdoc />
        public Stream OpenReadStream() => _fileService.OpenReadStream();

        /// <summary>
        /// Determines the MIME type based on the file extension.
        /// </summary>
        /// <returns>
        /// A string representing the MIME type of the file.
        /// If the extension is unrecognized, the method returns "application/octet-stream" as a default.
        /// </returns>
        private string GetMimeType()
        {
            // Convert the file extension to lowercase and remove the leading dot (if any).
            string extension = Extension.ToLowerInvariant().Replace(".", string.Empty);

            // Use a switch expression to map known file extensions to their MIME types.
            return extension switch
            {
                nameof(ImageFileExtensions.jpg) => "image/jpg",
                nameof(ImageFileExtensions.jpeg) => "image/jpeg",
                nameof(ImageFileExtensions.png) => "image/png",
                nameof(ImageFileExtensions.gif) => "image/gif",
                // Default MIME type if the extension is not recognized.
                _ => "application/octet-stream",
            };
        }

    }
}
