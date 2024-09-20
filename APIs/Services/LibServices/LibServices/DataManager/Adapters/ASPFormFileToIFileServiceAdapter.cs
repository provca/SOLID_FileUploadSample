using LibFilesManager.Interfaces;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager.Adapters
{
    /// <summary>
    /// Adapter class to convert an <see cref="IFileService"/> object into the <see cref="IFile"/> interface.
    /// This allows for compatibility for ASP projects.
    /// </summary>
    public class ASPFormFileToIFileServiceAdapter : IFile
    {
        // The original file service object being adapted.
        private readonly IFileService _formFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="ASPFormFileToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="formFile">The file service object to adapt.</param>
        public ASPFormFileToIFileServiceAdapter(IFileService formFile)
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
