using MauiSampleApp.Services.Interfaces;

namespace MauiSampleApp.Pages;

public partial class UploadFilePage : ContentPage
{
    // Dependency on IFileUploadService to handle file uploads.
    private readonly IFileUploadService _fileUploadService;

    // Stores the selected file to be uploaded.
    private FileResult? _file;

    /// <summary>
    /// Initializes a new instance of the <see cref="UploadFilePage"/> class.
    /// </summary>
    /// <param name="fileUploadService">The file upload service to handle the upload operation.</param>
    public UploadFilePage(IFileUploadService fileUploadService)
    {
        InitializeComponent();
        _fileUploadService = fileUploadService;
    }

    /// <summary>
    /// Event handler for the file selection button click. Opens the file picker for the user to select a file.
    /// </summary>
    private async void OnSelectFileClicked(object sender, EventArgs e)
    {
        // Opens the file picker and allows the user to select a file.
        _file = await FilePicker.Default.PickAsync();

        // If a file is selected, update the message label with the selected file's name.
        if (_file != null)
        {
            MessageLabel.Text = $"Selected File: {_file.FileName}";
        }
    }

    /// <summary>
    /// Event handler for the upload button click. Uploads the selected file to the server.
    /// </summary>
    private async void OnUploadFileClicked(object sender, EventArgs e)
    {
        // Checks if a file has been selected.
        if (_file == null)
        {
            MessageLabel.Text = "No file selected.";
            return;
        }

        // Retrieves the custom file name and target file path from the UI inputs.
        string customFileName = CustomFileNameEntry.Text;
        string filePathTarget = FilePathTargetEntry.Text;

        // Calls the file upload service to upload the file asynchronously.
        var result = await _fileUploadService.UploadFileAsync(_file, customFileName, filePathTarget);

        // Updates the message label based on the success of the upload.
        MessageLabel.Text = result.isSuccess ? $"File uploaded to {result.uploadedFilePath}" : "Upload failed.";
    }
}
