using LibFilesManager;
using LibFilesManager.Enums;

namespace LibServices.Configuration
{
    /// <summary>
    /// Configuration class containing settings and constants used for file upload dialogs and validations.
    /// </summary>
    public class UploadFileSettings
    {
        /// <summary>
        /// List of valid image file extensions, initialized from the enum <see cref="ImageFileExtensions"/>.
        /// </summary>
        public static List<string> ListOfExtensions { get => FileValidator.ListOfExtensions; }

        /// <summary>
        /// Title for the file dialog window when selecting an image file.
        /// </summary>
        public static readonly string FDTitle = "Select Image";

        /// <summary>
        /// Initial directory for the file dialog window.
        /// </summary>
        public static readonly string FDInitialDirectory = @"C:\";

        /// <summary>
        /// Filter for file types displayed in the file dialog.
        /// </summary>
        public static readonly string FDFilter = "All files (*.*)|*.*";

        /// <summary>
        /// Default filter index for the file dialog.
        /// </summary>
        public static readonly int FDFilterIndex = 1;

        // FolderDialog parameters.
        /// <summary>
        /// Description for the folder dialog window when selecting a folder.
        /// </summary>
        public static readonly string FBDDescription = "Select the folder to upload the image.";

        // Default values.
        /// <summary>
        /// Maximum allowed file size for upload (in bytes).
        /// </summary>
        public static readonly long MaxFileSize = 1 * 1024 * 1024;

        /// <summary>
        /// Default custom file name to use when no custom name is provided.
        /// </summary>
        public static readonly string CustomFileName = "customFileName.jpg";

        /// <summary>
        /// Default folder path to upload files if none is provided.
        /// </summary>
        public static readonly string CustomFolderName = @"C:\DefaultUploadedImages\";
    }
}