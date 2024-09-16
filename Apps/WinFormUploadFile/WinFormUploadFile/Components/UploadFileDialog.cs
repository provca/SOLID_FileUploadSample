using WinFormUploadFile.Settings;

namespace WinFormUploadFile.Components
{
    internal class UploadFileDialog
    {
        public UploadFileDialog(OpenFileDialog openFileDialog)
        {
            openFileDialog.Title = UploadFileSettings.FDTitle;
            openFileDialog.InitialDirectory = UploadFileSettings.FDInitialDirectory;
            openFileDialog.Filter = UploadFileSettings.FDFilter;
            openFileDialog.FilterIndex = UploadFileSettings.FDFilterIndex;
            openFileDialog.ShowDialog();
        }
    }
}
