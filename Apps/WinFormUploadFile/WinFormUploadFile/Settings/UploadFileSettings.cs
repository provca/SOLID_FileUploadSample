namespace WinFormUploadFile.Settings
{
    internal class UploadFileSettings
    {
        // FileDialog params.
        public static readonly string FDTitle = "Select Image";
        public static readonly string FDInitialDirectory = @"C:\";
        public static readonly string FDFilter = "All files (*.*)|*.*";
        public static readonly int FDFilterIndex = 1;

        // FolderDialog params.
        public static readonly string FBDDescription = "Select de folder to upload the image.";

        // Default values.
        public static string CustomFolderName = @"C:\DefaultUploadedImages\";
        public static string CustomFileName = "customFileName";
    }
}
