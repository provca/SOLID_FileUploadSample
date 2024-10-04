using LibServices.Configuration;
using LibServices.DataManager.Factories;
using SwitchLoggers.Loggers.Interfaces;
using SwitchLoggers.Settings;
using System.Diagnostics;
using WinFormUploadFile.Components;

namespace WinFormUploadFile
{
    /// <summary>
    /// Represents the form for uploading files. Provides functionality to select and upload files.
    /// </summary>
    public partial class UploadFileForm : Form
    {
        // Selected logger.
        private readonly ILoggers _logger = SwitchLoggersSettings.Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileForm"/> class.
        /// </summary>
        public UploadFileForm()
        {
            InitializeComponent();
            FilePath_txt.Enabled = false;
            FilePathTarget_txt.Enabled = false;
            FilePathTarget_lbl.Text = $"Select target folder, '{UploadFileSettings.FilePathTarget}' by default:";
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
                    // If no file is selected leave empty.
                    FilePath_txt.Text = string.Empty;
                    _logger.LogWarning($"No file was selected.");
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
                    FilePathTarget_txt.Text = Path.GetFullPath(fbd.SelectedPath);
                }
                else
                {
                    // If there is not a valid folder, textbox gets a default value.
                    FilePathTarget_txt.Text = UploadFileSettings.FilePathTarget;
                    _logger.LogWarning($"No folder selected. Image will be saved in {UploadFileSettings.FilePathTarget}");
                }
            }
        }

        /// <summary>
        /// Event handler for the upload file button click event.
        /// </summary>
        private async void UploadFile_btn_Click(object sender, EventArgs e)
        {
            // Get the file path from the text box.
            string filePath = FilePath_txt.Text;

            // Target Folder.
            string filePathTarget = string.IsNullOrEmpty(FilePathTarget_txt.Text) ? UploadFileSettings.FilePathTarget : FilePathTarget_txt.Text;

            // Custom name for the file, if not specified, use the original name.
            string customFileName = string.IsNullOrWhiteSpace(CustomFileName_txt.Text) ? Path.GetFileName(filePath) : CustomFileName_txt.Text;

            // Validate and upload the file.
            var (isSuccess, uploadedFilePath) = await FilesManagerServiceFactory.ValidateAndUploadFileAsync(filePath, UploadFileSettings.MaxFileSize, filePathTarget, customFileName);

            // Check the upload result.
            if (isSuccess)
            {
                MessageBox.Show($"File uploaded successfully to: {uploadedFilePath}");
            }
            else
            {
                MessageBox.Show("File upload failed.");
            }
        }
    }
}
