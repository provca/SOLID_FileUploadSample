using MauiSampleApp.Pages;
namespace MauiSampleApp
{
    /// <summary>
    /// Represents the main application class that configures the initial page of the app.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class, setting the main page to the provided <paramref name="uploadFilePage"/>.
        /// </summary>
        /// <param name="uploadFilePage">The initial page for file uploading within the application.</param>
        public App(UploadFilePage uploadFilePage)
        {
            InitializeComponent();

            // Sets the main page of the application.
            MainPage = uploadFilePage;
        }
    }
}
