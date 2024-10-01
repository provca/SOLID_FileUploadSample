using HeyRed.Mime;
using LibServices.DataManager.Interfaces;

namespace LibServices.DataManager.Adapters
{
    /// <summary>
    /// Adapter that converts a byte array to an <see cref="IFileService"/> implementation.
    /// This allows handling file operations for files represented as byte arrays.
    /// </summary>
    public class ByteArrayToIFileServiceAdapter : IFileService
    {
        private readonly byte[] _fileBytes;
        private readonly string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ByteArrayToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="fileBytes">The file content represented as a byte array.</param>
        /// <param name="fileName">The name of the file, including its extension.</param>
        public ByteArrayToIFileServiceAdapter(byte[] fileBytes, string fileName)
        {
            _fileBytes = fileBytes;
            _fileName = fileName;
        }

        /// <inheritdoc />
        public string FileName => _fileName;

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_fileName);

        /// <inheritdoc />
        public string ContentType => MimeTypesMap.GetMimeType(_fileName);

        /// <inheritdoc />
        public long Length => _fileBytes.Length;

        /// <inheritdoc />
        public Stream OpenReadStream()
        {
            return new MemoryStream(_fileBytes);
        }
    }
}
