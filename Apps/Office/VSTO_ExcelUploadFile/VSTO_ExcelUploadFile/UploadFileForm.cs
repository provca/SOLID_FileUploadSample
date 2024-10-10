using System;
using System.IO;
using System.Windows.Forms;
using VSTO_ExcelUploadFile.Components;
using VSTO_ExcelUploadFile.Configuration;
using VSTO_ExcelUploadFile.Services;

namespace VSTO_ExcelUploadFile
{
    /// <summary>
    /// Represents the form for uploading files in the VSTO Excel application.
    /// </summary>
    public partial class UploadFileForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFileForm"/> class.
        /// Sets default values for the custom file name and target file path.
        /// </summary>
        public UploadFileForm()
        {
            InitializeComponent();

            // Disable file path and target path textboxes.
            FilePath_txt.Enabled = false;
            FilePathTarget_txt.Enabled = false;

            // Set the default custom file name.
            CustomFileName_txt.Text = UploadFileSettings.CustomFileName;

            // Set the default target file path label and textbox.
            FilePathTarget_lbl.Text = $"Select target folder, '{UploadFileSettings.FilePathTarget}' by default:";
            FilePathTarget_txt.Text = UploadFileSettings.FilePathTarget;
        }

        /// <summary>
        /// Handles the click event for selecting a file.
        /// Opens a file dialog to choose a file and sets the file path in the text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SelectFile_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Instantiates the file dialog with the configuration and displays the dialog.
                UploadFileDialog uploadFileDialog = new UploadFileDialog(ofd);

                // Check if the user selected a file and the result was OK.
                if (!string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    FilePath_txt.Text = ofd.FileName;
                }
                else
                {
                    // If no file is selected leave empty.
                    FilePath_txt.Text = string.Empty;
                    MessageBox.Show($"No file was selected.");
                }
            }
        }

        /// <summary>
        /// Handles the click event for selecting a target folder.
        /// Opens a folder browser dialog to choose a folder for saving files.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SelectFolder_btn_Click(object sender, EventArgs e)
        {
            // Manage errors if a folder is not selected.
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
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
                    MessageBox.Show($"No folder selected. Image will be saved in {UploadFileSettings.FilePathTarget}");
                }
            }
        }

        /// <summary>
        /// Handles the click event for uploading the selected file.
        /// Validates the input and calls the API to upload the file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private async void UploadFile_btn_Click(object sender, EventArgs e)
        {
            // Get the file path from the text box.
            string filePath = FilePath_txt.Text;

            // Target Folder.
            string filePathTarget = string.IsNullOrEmpty(FilePathTarget_txt.Text) ? UploadFileSettings.FilePathTarget : FilePathTarget_txt.Text;

            // Custom name for the file, if not specified, use the original name.
            string customFileName = string.IsNullOrWhiteSpace(CustomFileName_txt.Text) ? Path.GetFileName(filePath) : CustomFileName_txt.Text;

            try
            {
                // Validate and upload the file.
                var apiService = new ApiService();
                var (isUploaded, result) = await apiService.UploadFileToApi(filePath);

                if (isUploaded)
                {
                    MessageBox.Show($"File uploaded successfully! Path: {result}");
                }
                else
                {
                    MessageBox.Show($"File upload failed: {result}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error to upload file: {ex.Message}");
            }
        }
    }
}

