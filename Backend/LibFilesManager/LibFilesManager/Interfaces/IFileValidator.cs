
namespace LibFilesManager.Interfaces
{
    /// <summary>
    /// Interface for validating a file.
    /// </summary>
    public interface IFileValidator
    {
        /// <summary>
        /// Validates the file based on its name, extension, content type, and size.
        /// </summary>
        /// <param name="file">The file to be validated.</param>
        /// <returns>True if the file is valid; otherwise, false.</returns>
        bool ValidateFile(IFile file);
    }
}
