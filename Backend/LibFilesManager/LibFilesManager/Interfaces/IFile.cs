namespace LibFilesManager.Interfaces
{
    /// <summary>
    /// Interface representing a file with basic properties and functionality.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the MIME content type of the file.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Gets the size of the file in bytes.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Opens a stream to read the file's contents.
        /// </summary>
        /// <returns>A <see cref="Stream"/> that can be used to read the file.</returns>
        Stream OpenReadStream();
    }
}
