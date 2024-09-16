using WinFormUploadFile.Settings;

namespace WinFormUploadFile.Components
{
    internal class UploadFolderDialog
    {
        public UploadFolderDialog(FolderBrowserDialog folderBrowserDialog)
        {
            folderBrowserDialog.Description = UploadFileSettings.FBDDescription;
            folderBrowserDialog.UseDescriptionForTitle = true;
            folderBrowserDialog.ShowDialog();

        }
    }
}
