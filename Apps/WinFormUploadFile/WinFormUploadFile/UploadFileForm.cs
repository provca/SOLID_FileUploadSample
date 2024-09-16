using LibServices;
using LibServices.Interfaces;
using System.Diagnostics;
using WinFormUploadFile.Components;
using WinFormUploadFile.Settings;

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
            FilePath_txt.Enabled = false;
            FolderTarget_txt.Enabled = false;
            CustomFolder_lbl.Text = $"Select target folder, '{UploadFileSettings.CustomFolderName}' by default:";
        }

        /// <summary>
        /// Event handler for the file selection button click event.
        /// </summary>
        private void SelectFile_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Instantiates the file dialog with the configuration and displays the dialog.
                UploadFileDialog uploadFileDialog = new(ofd);

                // Check if the user selected a file and the result was OK.
                if (!string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    FilePath_txt.Text = ofd.FileName;
                }
                else
                {
                    // If no file is selected, assign a default value or leave empty.
                    FilePath_txt.Text = UploadFileSettings.CustomFileName;
                    Trace.WriteLine($"No file was selected. Image will be saves as {UploadFileSettings.CustomFileName}");
                }
            }
        }

        /// <summary>
        /// Event handler for the folder selection button click event.
        /// </summary>
        private void SelectFolder_btn_Click(object sender, EventArgs e)
        {
            // Manage errors if a folder is not selected.
            using (FolderBrowserDialog fbd = new())
            {
                DialogResult result = fbd.ShowDialog();

                // Verify if the user has selected any folder.
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // If it's a valid folder textbox is populated.
                    FolderTarget_txt.Text = Path.GetFullPath(fbd.SelectedPath);
                }
                else
                {
                    // If there is not a valid folder, textbox gets a default value.
                    FolderTarget_txt.Text = UploadFileSettings.CustomFolderName;
                    Trace.WriteLine($"No folder selected. Image will be saved in {UploadFileSettings.CustomFolderName}");
                }
            }
        }

        /// <summary>
        /// Event handler for the upload file button click event.
        /// </summary>
        private async void UploadFile_btn_Click(object sender, EventArgs e)
        {
            // Get the file path from the text box
            string filePath = FilePath_txt.Text;

            // Create an instance of FileService with the file path.
            IFileService fileService = new FileService(filePath);

            // Initialize the FileValidatorService with parameters for validation.
            var fileValidatorService = new FileValidatorService("jpg", 1 * 1024 * 1024);

            // Validate the file.
            bool isValid = fileValidatorService.ValidateFile(fileService);

            // Show validation result to the user.
            if (isValid)
            {
                MessageBox.Show("File is valid.");

                string filePathTarget = FolderTarget_txt.Text;
                filePathTarget = string.IsNullOrEmpty(FolderTarget_txt.Text) ? UploadFileSettings.CustomFolderName : filePathTarget;

                IFileUploadService fileUploadService = new FileUploadService(filePathTarget, fileValidatorService);

                string fileName = CustomFileName_txt.Text;
                fileName = string.IsNullOrWhiteSpace(fileName) ? fileService.FileName : fileName;

                try
                {
                    // Await the result of the file upload and handle the response.
                    var (isSuccess, uploadedFilePath) = await fileUploadService.UploadFileAsync(fileService, fileName);

                    if (isSuccess)
                    {
                        MessageBox.Show($"File uploaded successfully to: {uploadedFilePath}");
                    }
                    else
                    {
                        MessageBox.Show("File upload failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("File is not valid.");
            }
        }
    }
}
