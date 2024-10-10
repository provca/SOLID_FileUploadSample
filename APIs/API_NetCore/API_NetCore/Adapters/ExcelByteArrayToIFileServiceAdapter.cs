using LibServices.DataManager.Interfaces;
using LibServices.DataManager.Adapters;
//using HeyRed.Mime;

namespace API_NetCore.Adapters
{
    /// <summary>
    /// Adapter that converts a byte array to an <see cref="IFileService"/> implementation.
    /// This allows handling file operations for files represented as byte arrays.
    /// </summary>
    public class ExcelByteArrayToIFileServiceAdapter : IFileService
    {
        private readonly byte[] _fileBytes;
        private readonly string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelByteArrayToIFileServiceAdapter"/> class.
        /// </summary>
        /// <param name="fileBytes">The file content represented as a byte array.</param>
        /// <param name="fileName">The name of the file, including its extension.</param>
        public ExcelByteArrayToIFileServiceAdapter(byte[] fileBytes, string fileName)
        {
            _fileBytes = fileBytes;
            _fileName = fileName;
        }

        /// <inheritdoc />
        public string FileName => _fileName;

        /// <inheritdoc />
        public string Extension => Path.GetExtension(_fileName);
        //public string ContentType => MimeTypesMap.GetMimeType(_fileName);

        /// <inheritdoc />
        public string ContentType => GetMimeType(_fileName);

        /// <inheritdoc />
        public long Length => _fileBytes.Length;

        /// <inheritdoc />
        public Stream OpenReadStream() => new MemoryStream(_fileBytes);

        /// <summary>
        /// Determines the MIME type based on the file extension.
        /// </summary>
        /// <returns>
        /// A string representing the MIME type of the file.
        /// If the extension is unrecognized, the method returns "application/octet-stream" as a default.
        /// Take a look to <see cref="IFileToIFileServiceAdapter"/> class.
        /// </returns>
        public string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream",
            };
        }
    }
}
