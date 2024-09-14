using LibFilesManager.Enums;
using LibServices.Interfaces;

namespace LibServices
{
    /// <summary>
    /// Service class representing a file to be processed. Implements <see cref="IFileService"/> to provide file operations.
    /// </summary>
    public class FileService : IFileService
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="filePath">The full path of the file to be managed.</param>
        /// <exception cref="ArgumentException">Thrown when the file path is null or empty.</exception>
        public FileService(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));

            _filePath = filePath;
        }

        /// <inheritdoc />
        public string FileName => Path.GetFileName(_filePath);

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_filePath);

        /// <inheritdoc />
        public string ContentType
        {
            get
            {
                string extension = Path.GetExtension(_filePath).ToLowerInvariant().Replace(".", string.Empty);
                return extension switch
                {
                    nameof(ImageFileExtensions.jpg) => "image/jpg",
                    nameof(ImageFileExtensions.jpeg) => "image/jpeg",
                    nameof(ImageFileExtensions.png) => "image/png",
                    nameof(ImageFileExtensions.gif) => "image/gif",
                    _ => "application/octet-stream",
                };
            }
        }

        /// <inheritdoc />
        public long Length => new FileInfo(_filePath).Length;

        /// <inheritdoc />
        public Stream OpenReadStream() => new FileStream(_filePath, FileMode.Open, FileAccess.Read);
    }
}
