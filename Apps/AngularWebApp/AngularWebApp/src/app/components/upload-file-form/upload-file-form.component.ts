import { Component, OnInit } from "@angular/core";
import { UploadFileFormModel } from "../../models/upload-file-form.model";
import { UploadFileFormService } from "../../services/upload-file-form.service";

@Component({
    selector: "app-upload-file-form",
    templateUrl: "./upload-file-form.component.html",
    styleUrl: "./upload-file-form.component.css",
})
export class UploadFileFormComponent implements OnInit {
    // File selected for upload.
    FormFile: File | undefined;

    // The original name of the file.
    FileName: string | undefined;

    // A custom name specified for the uploaded file.
    CustomFileName: string | undefined;

    // The target folder path for saving the file.
    FilePathTarget: string | undefined;

    // Message displayed when the upload is successful.
    Message: string | undefined;

    // Error message displayed when the upload fails.
    ErrorMessage: string | undefined;

    constructor(private uploadFileFormService: UploadFileFormService) { }

    /**
    Initializes the component's properties with default values.
    */
    ngOnInit(): void {
        this.FormFile = undefined;
        this.FileName = "";
        this.CustomFileName = "customFileName.jpg";
        this.FilePathTarget = "C:\\DefaultUploadImages\\";
    }

    handleFileSelected(event: Event) {
        const input = event.target as HTMLInputElement;

        // Checks if a file is selected and assigns it to the FormFile variable.
        if (input.files && input.files.length > 0) {
            this.FormFile = input.files[0];
            this.FileName = this.FormFile.name;
        }
    }

    /**
    Submits the form data to the server for uploading the selected file.
    */
    onSubmit() {
        // Validates if a file has been selected before proceeding.
        if (!this.FormFile) {
            this.ErrorMessage = "Please select a file.";
            return;
        }

        // Creates an instance of UploadFileFormModel with the selected file and details.
        const uploadFileFormModel = new UploadFileFormModel(
            this.FormFile,
            this.FileName || "",
            this.CustomFileName || "",
            this.FilePathTarget || ""
        );

        // Calls the service method to upload the file and handles the response or error.
        this.uploadFileFormService
            .postUploadFileForm(uploadFileFormModel)
            .subscribe(
                (response) => {
                    // Sets success message on successful upload.
                    this.Message = "File uploaded successfully!";
                    this.ErrorMessage = undefined;
                },
                (error) => {
                    // Sets error message if the upload fails.
                    this.ErrorMessage = "File upload failed. Please try again.";
                    this.Message = undefined;
                }
            );
    }
}
