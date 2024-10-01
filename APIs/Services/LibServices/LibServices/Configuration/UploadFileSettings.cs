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
        /// FolderDialog parameters.
        /// Title for the file dialog window when selecting an image file.
        /// </summary>
        public static readonly string FDTitle = "Select Image";

        /// <summary>
        /// FolderDialog parameters.
        /// Initial directory for the file dialog window.
        /// </summary>
        public static readonly string FDInitialDirectory = @"C:\";

        /// <summary>
        /// FolderDialog parameters.
        /// Filter for file types displayed in the file dialog.
        /// </summary>
        public static readonly string FDFilter = "All files (*.*)|*.*";

        /// <summary>
        /// FolderDialog parameters.
        /// Default filter index for the file dialog.
        /// </summary>
        public static readonly int FDFilterIndex = 1;

        /// <summary>
        /// FolderDialog parameters.
        /// Description for the folder dialog window when selecting a folder.
        /// </summary>
        public static readonly string FBDDescription = "Select the folder to upload the image.";

        /// <summary>
        /// Default Values.
        /// Maximum allowed file size for upload (in bytes).
        /// </summary>
        public static readonly long MaxFileSize = 1 * 1024 * 1024;

        /// <summary>
        /// Default Values.
        /// Maximum allowed file size for Webassembly.
        /// Maximum is specified and is smaller than initial . initial exceeds 65,536 (2^16). 2^16 pages is 2^16 * 64KiB = 4GiB bytes, which is the maximum range that a Wasm module can address, as Wasm currently only allows 32-bit addressing.
        /// <see href="https://developer.mozilla.org/en-US/docs/WebAssembly/JavaScript_interface/Memory/Memory" />
        /// </summary>
        public static readonly long MaxFileSizeWASM = 1 * 1024 * 1024;

        /// <summary>
        /// Default Values.
        /// Default folder path to upload files if none is provided.
        /// </summary>
        public static readonly string FilePathTarget =
            Path.Combine(Path.GetPathRoot(Environment.CurrentDirectory)
                ?? throw new InvalidOperationException(
                    "The root directory could not be determined."),
                    "DefaultUploadedImages"
                );

        /// <summary>
        /// Default Values.
        /// Default custom file name to use when no custom name is provided.
        /// </summary>
        public static readonly string CustomFileName = "customFileName.jpg";
    }
}