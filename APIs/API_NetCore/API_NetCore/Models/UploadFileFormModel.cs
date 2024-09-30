using LibServices.Configuration;
using System.ComponentModel.DataAnnotations;

namespace API_NetCore.Models
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
        /// The custom file name provided by the user (optional).
        /// Defaults to "customFileName" if not provided.
        /// </summary>
        [Display(Name = "Custom File Name")]
        public string CustomFileName { get; set; } = UploadFileSettings.CustomFileName;

        /// <summary>
        /// The folder path where the uploaded file will be saved.
        /// Defaults to "C:\DefaultUploadedImages\" if not specified.
        /// </summary>
        public string FilePathTarget { get; set; } = UploadFileSettings.FilePathTarget;
    }
}
