using Microsoft.Office.Tools.Ribbon;

namespace VSTO_ExcelUploadFile
{
    public partial class Ribbon1
    {
        /// <summary>
        /// Handles the click event for the Select File button in the Ribbon.
        /// Opens a dialog for the user to select a file for upload.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SelectFile_btn_Click(object sender, RibbonControlEventArgs e)
        {
            // Creates and displays the upload file form dialog for the user to select a file.
            using (var uploadForm = new UploadFileForm())
            {
                uploadForm.ShowDialog();
            }
        }
    }
}
