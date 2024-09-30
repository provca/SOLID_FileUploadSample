using LibServices.DataManager.Interfaces;

namespace API_NetCore.Adapters
{
    /// <summary>
    /// Adapter that converts an IFormFile to an <see cref="IFileService"/> implementation.
    /// </summary>
    public class FormFileToIFileServiceAdapter : IFileService
    {
        private readonly IFormFile _formFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormFileToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="formFile">An instance of <see cref="IFormFile"/> to be adapted.</param>
        public FormFileToIFileServiceAdapter(IFormFile formFile)
        {
            _formFile = formFile;
        }

        /// <inheritdoc />
        public string FileName => _formFile.FileName;

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_formFile.FileName);

        /// <inheritdoc />
        public string ContentType => _formFile.ContentType;

        /// <inheritdoc />
        public long Length => _formFile.Length;

        /// <inheritdoc />
        public Stream OpenReadStream() => _formFile.OpenReadStream();
    }
}
