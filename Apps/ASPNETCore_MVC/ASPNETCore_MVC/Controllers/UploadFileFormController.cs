using LibServices.DataManager.Factories;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_MVC.Controllers
{
    public class UploadFileFormController : Controller
    {
        /// <summary>
        /// Displays the upload file form view.
        /// </summary>
        /// <returns>The Index view for the file upload form.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles the file upload and validation process.
        /// </summary>
        /// <param name="formFile">The file uploaded by the user via the form.</param>
        /// <returns>An IActionResult to render the appropriate view based on the validation result.</returns>
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            // Check if no file was uploaded or if the file is empty.
            if (formFile == null || formFile.Length == 0)
            {
                ModelState.AddModelError("File", "Please select a file to upload.");
                return View("Index");
            }

            // Create a temporary file path to store the uploaded file.
            string filePath = Path.Combine(Path.GetTempPath(), formFile.FileName);

            // Copy the uploaded file's content to the temporary file path.
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            // Validate the uploaded file.
            bool isValidated = FilesManagerServiceFactory.ValidateFile(filePath, "jpg", 1 * 1024 * 1024);

            if (isValidated)
            {
                // If the file is validated successfully, show a success message.
                ViewBag.Message = $"File has been successfully validated.";

                // Delete the temporary file after validation.
                System.IO.File.Delete(filePath);
            }
            else
            {
                // If the file is not valid, show an error message.
                ViewBag.Message = "File is not valid.";
            }
            
            // Return the Index view to display the message to the user.
            return View("Index");
        }
    }
}
