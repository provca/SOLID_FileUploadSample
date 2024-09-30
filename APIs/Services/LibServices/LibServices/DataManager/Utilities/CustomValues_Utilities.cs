using LibServices.Configuration;

namespace LibServices.DataManager.Utilities
{
    internal class CustomValues_Utilities
    {
        /// <summary>
        /// Retrieves custom values for file upload parameters, using default settings if not provided.
        /// </summary>
        /// <param name="maxFileSize">
        /// The maximum allowable file size in bytes. If not provided or set to zero, 
        /// the default value from <see cref="UploadFileSettings.MaxFileSize"/> is used.
        /// </param>
        /// <param name="filePathTarget">
        /// The target folder where the file will be uploaded. If not provided or empty, 
        /// the default folder path from <see cref="UploadFileSettings.FilePathTarget"/> is used.
        /// </param>
        /// <param name="customFileName">
        /// The custom name for the uploaded file. If not provided or empty, 
        /// the default name from <see cref="UploadFileSettings.CustomFileName"/> is used.
        /// </param>
        /// <returns>
        /// A tuple containing the validated maximum file size, target file path, and custom file name.
        /// </returns>
        public static (long MaxFileSize, string FilePathTarget, string CustomFileName) GetCustomValuesFromFile(long maxFileSize, string filePathTarget, string customFileName)
        {
            // Use the default max file size from settings if none is provided or maxFileSize is zero or less.
            maxFileSize = maxFileSize <= 0 ? UploadFileSettings.MaxFileSize : maxFileSize;

            // Set filePathTarget to the default folder if not provided or if it's an empty string.
            filePathTarget = string.IsNullOrWhiteSpace(filePathTarget) ? UploadFileSettings.FilePathTarget : filePathTarget;

            // Set customFileName to the default file name if not provided or if it's an empty string.
            customFileName = string.IsNullOrWhiteSpace(customFileName) ? UploadFileSettings.CustomFileName : customFileName;

            // Return a tuple containing the max file size, target file path, and custom file name.
            return (maxFileSize, filePathTarget, customFileName);
        }
    }
}
