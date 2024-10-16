﻿using ASPNETCore_MVC.Adapters;
using ASPNETCore_MVC.Models;
using LibServices.Configuration;
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
            // Create a new instance of the model to be used in the view.
            var model = new UploadFileFormModel();

            // Return the view with the model.
            return View(model);
        }

        /// <summary>
        /// Displays the partial view for the file upload form.
        /// </summary>
        /// <returns>
        /// A <see cref="PartialViewResult"/> that renders the upload form view.
        /// </returns>
        [HttpGet]
        public IActionResult UploadFileForm()
        {
            // Return the partial view for the main form.
            return PartialView();
        }

        /// <summary>
        /// Handles the file upload and validation process.
        /// </summary>
        /// <param name="model">The model from <see cref="UploadFileFormModel" /> file.</param>
        /// <returns>An IActionResult to render the appropriate view based on the validation result.</returns>
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileFormModel model)
        {
            // Check if no file was uploaded or if the file is empty.
            if (model.FormFile == null || model.FormFile.Length == 0)
            {
                // Add an error to ModelState when no file is provided.
                ModelState.AddModelError("File", "No file uploaded.");

                // Return the view with the current model to show the error.
                return View("Index", model);
            }

            // Retrieve the default values from the model.
            var valuesToCheck = SetDefaultValuesForModel(model);

            // If the model state contains any validation errors, output them to the console.
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    // Log each validation error to the console.
                    Console.WriteLine($"{state.Key}: {string.Join(",", state.Value.Errors.Select(e => e.ErrorMessage))}");
                }

                // Return the view with the current model to show validation errors.
                return View("Index", model);
            }

            try
            {
                // Create an adapter to convert the form file to IFileService.
                FormFileToIFileServiceAdapter fileAdapter = new(model.FormFile);

                // Validate and upload the file using the service factory.
                var fileUrl = await FilesManagerServiceFactoryForASP.ValidateAndUploadFileAsync(
                    fileAdapter,
                    UploadFileSettings.MaxFileSize,
                    valuesToCheck.FilePathTarget,
                    valuesToCheck.CustomFileName
                );

                // Check if the upload was successful.
                if (fileUrl.isSuccess)
                {
                    // Handle the case where the file path is not provided after upload.
                    if (string.IsNullOrEmpty(fileUrl.uploadedFilePath))
                    {
                        // Return a 500 status code if the upload failed unexpectedly.
                        return StatusCode(500, "Error uploading file.");
                    }

                    // Display a success message to the user.
                    ViewBag.Message = $"File uploaded successfully in {fileUrl.uploadedFilePath}!";
                }
                else
                {
                    // Display a failure message if the upload failed.
                    ViewBag.Message = "File upload failed.";
                }
            }
            catch (Exception ex)
            {
                // Add an error to ModelState with the exception details.
                ModelState.AddModelError(string.Empty, $"An error occurred while uploading the file: {ex.Message}");

                // Return the view with the error message.
                return View("Index", model);
            }

            // Return the Index view to display the final message to the user.
            return View("Index", model);
        }

        /// <summary>
        /// Sets default values for the <see cref="UploadFileFormModel"/> if the user has not provided them.
        /// </summary>
        /// <param name="model">The <see cref="UploadFileFormModel"/> containing the form data for file upload.</param>
        /// <returns>
        /// A tuple containing the folder target path, the file extension, the maximum file size, and the custom file name.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="model.FormFile"/> is null.
        /// </exception>
        private static (string FilePathTarget, string CustomFileName) SetDefaultValuesForModel(UploadFileFormModel model)
        {
            if (model.FormFile == null)
            {
                throw new ArgumentNullException($"A valid FormFile is needed: {nameof(model.FormFile)}");
            }

            // Set custom file name to the original file name without extension if not provided by the user.
            model.CustomFileName = string.IsNullOrEmpty(model.CustomFileName)
                ? Path.GetFileNameWithoutExtension(model.FormFile.FileName)
                : model.CustomFileName;

            // Set folder target to a default path if not provided by the user.
            model.FilePathTarget = string.IsNullOrEmpty(model.FilePathTarget)
                ? Path.GetFullPath(UploadFileSettings.FilePathTarget)
                : model.FilePathTarget;

            // Return the file size, folder target, and custom file name.
            return (model.FilePathTarget, model.CustomFileName);
        }
    }
}
