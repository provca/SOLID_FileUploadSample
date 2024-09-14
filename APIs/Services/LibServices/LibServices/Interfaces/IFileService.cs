namespace LibServices.Interfaces
{
    /// <summary>
    /// Interface representing a service that handles file operations.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Gets the file name (without path) of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the file extension of the file.
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Gets the MIME type of the file based on the file extension.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the size of the file in bytes.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Opens a read stream for the uploaded file.
        /// </summary>
        /// <returns>A <see cref="Stream"/> that can be used to read the file.</returns>
        Stream OpenReadStream();
    }
}
