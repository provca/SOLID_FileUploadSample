using System.ComponentModel.DataAnnotations;
using LibServices.Configuration;

namespace ASPNETCore_MVC.Models
{
    /// <summary>
    /// Model representing the form data for file uploads.
    /// </summary>
    public class UploadFileFormModel
    {
        /// <summary>
        /// The file uploaded by the user. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Please select a file.")]
        public IFormFile? FormFile { get; set; }

        /// <summary>
        /// The name of the uploaded file.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The file path where the uploaded file will be saved.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// The folder path where the uploaded file will be saved.
        /// Default value from <see cref="UploadFileSettings"/> if not specified.
        /// </summary>
        public string FilePathTarget { get; set; } = UploadFileSettings.FilePathTarget;

        /// <summary>
        /// The custom file name provided by the user (optional).
        /// Default value from <see cref="UploadFileSettings"/> if not provided.
        /// </summary>
        [Display(Name = "Custom File Name")]
        public string CustomFileName { get; set; } = UploadFileSettings.CustomFileName;
    }
}

