namespace LibServices.Interfaces
{
    /// <summary>
    /// Interface for services that validate files.
    /// </summary>
    public interface IFileValidatorService
    {
        /// <summary>
        /// Validates the given file.
        /// </summary>
        /// <param name="file">The file to validate, represented by <see cref="IFileService"/>.</param>
        /// <returns>True if the file is valid; otherwise, false.</returns>
        bool ValidateFile(IFileService file);
    }
}
