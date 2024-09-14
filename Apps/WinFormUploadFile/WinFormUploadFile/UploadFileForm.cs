using LibServices;
using LibServices.Adapters;
using LibServices.Interfaces;

namespace WinFormUploadFile
{
    /// <summary>
    /// Represents the form for uploading files. Provides functionality to select and upload files.
    /// </summary>
    public partial class UploadFileForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileForm"/> class.
        /// </summary>
        public UploadFileForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the file selection button click event.
        /// </summary>
        private void SelectFile_btn_Click(object sender, EventArgs e)
        {
            // ToDo: implements OpenFileDialog
        }

        /// <summary>
        /// Event handler for the upload file button click event.
        /// </summary>
        private void UploadFile_btn_Click(object sender, EventArgs e)
        {
            /*
             * Write the file name in FilePath_txt and test the button
             * by including files in the \bin\Debug\net8.0-windows\ folder
             */

            // Get the file path from the text box
            string filePath = FilePath_txt.Text;

            // Create an instance of FileService with the file path
            IFileService fileService = new FileService(filePath);

            // Create a file adapter for compatibility with IFile
            WinFormsFileToIFileServiceAdapter fileAdapter = new(fileService);

            // Initialize the FileValidatorService with parameters for validation
            var fileValidatorService = new FileValidatorService("jpg", 1 * 1024 * 1024);

            // Validate the file
            bool isValid = fileValidatorService.ValidateFile(fileService);

            // Show validation result to the user
            if (isValid)
            {
                MessageBox.Show("File is valid.");
            }
            else
            {
                MessageBox.Show("File is not valid.");
            }
        }
    }
}
