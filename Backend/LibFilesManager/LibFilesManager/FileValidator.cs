using LibFilesManager.Enums;
using LibFilesManager.Interfaces;
using System.Diagnostics;

namespace LibFilesManager
{
    /// <summary>
    /// Validates uploaded files based on allowed extensions, file type, and size restrictions.
    /// </summary>
    public class FileValidator : IFileValidator
    {
        // List of valid image file extensions, initialized from the enum.
        private static readonly List<string> _listOfExtensions = PopulateListOfExtensions();

        // The selected file extension to validate against.
        private readonly string _selectedExtension;

        // Maximum allowed file size for uploads (in bytes).
        private readonly long _maxFileSize;

        // Public property of valid image file extensions, initialized from the enum.
        public static List<string> ListOfExtensions { get => _listOfExtensions; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileValidator"/> class with specific validation settings.
        /// </summary>
        /// <param name="selectedExtension">The file extension to validate against.</param>
        /// <param name="maxFileSize">The maximum file size allowed for uploads.</param>
        public FileValidator(string selectedExtension, long maxFileSize)
        {
            _selectedExtension = selectedExtension;
            _maxFileSize = maxFileSize;
        }

        /// <inheritdoc />
        public bool ValidateFile(IFile fileToUpload)
        {
            // Check if file is null or empty.
            if (fileToUpload == null || fileToUpload.Length == 0)
            {
                Trace.WriteLine("No file was provided for upload.");
                return false;
            }

            // Extract the file extension and ensure it's valid.
            var extension = Path.GetExtension(fileToUpload.FileName).ToLowerInvariant().Replace(".", string.Empty);

            // Check if the file extension matches the selected one.
            if (_selectedExtension != extension)
            {
                Trace.WriteLine("Selected file has a different extension from configuration.");
                return false;
            }

            // Verify that the extension is part of the allowed list.
            if (string.IsNullOrEmpty(extension) || !_listOfExtensions.Contains(extension))
            {
                Trace.WriteLine("The file has a disallowed extension.");
                return false;
            }

            // Verify that the file does not exceed the maximum allowed size.
            if (fileToUpload.Length > _maxFileSize)
            {
                Trace.WriteLine("The file exceeds the allowed size.");
                return false;
            }

            // File passed all validations.
            return true;
        }

        /// <summary>
        /// Populates the list of allowed file extensions based on the <see cref="ImageFileExtensions"/> enum.
        /// </summary>
        /// <returns>A list of allowed file extensions as strings.</returns>
        private static List<string> PopulateListOfExtensions()
        {
            // Clear list to initialize.
            List<string> list = new();

            // Iterate through each extension type in the enum and add its string representation to the list.
            foreach (ImageFileExtensions extensions in Enum.GetValues(typeof(ImageFileExtensions)))
                list.Add(extensions.ToString());

            // Return the populated list.
            return list;
        }
    }
}
