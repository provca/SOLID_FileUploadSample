import { Component, OnInit } from "@angular/core";
import { UploadFileByteArrayModel } from "../../models/upload-file-byte-array.model";
import { UploadFileByteArrayService } from "../../services/upload-file-byte-array.service";

@Component({
    selector: "app-upload-file-byte-array",
    templateUrl: "./upload-file-byte-array.component.html",
    styleUrl: "./upload-file-byte-array.component.css",
})
export class UploadFileByteArrayComponent implements OnInit {
    // File selected for upload as a number[].
    FileBytes: number[] | undefined;

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

    constructor(
        private uploadFileByteArrayService: UploadFileByteArrayService
    ) {}

    /**
    Initializes the component's properties with default values.
    */
    ngOnInit(): void {
        this.FileBytes = undefined;
        this.FileName = "";
        this.CustomFileName = "customFileName.jpg";
        this.FilePathTarget = "C:\\DefaultUploadImages\\";
    }

    /**
    Handles the event triggered when a file is selected for upload.
    @param event The event containing information about the selected file.
    */
    handleFileSelected(event: Event) {
        // Casts the event target to an HTMLInputElement to access the file input.
        const input = event.target as HTMLInputElement;

        // Checks if any files are selected.
        if (input.files && input.files.length > 0) {
            // Retrieves the first selected file.
            const file = input.files[0];

            // Updates the FileName property with the selected file's name.
            this.FileName = file.name;

            // Creates a FileReader to read the contents of the selected file.
            const reader = new FileReader();

            // Sets up the onload event handler to process the file once it has been read.
            reader.onload = () => {
                // Gets the result of the read operation as an ArrayBuffer.
                const arrayBuffer = reader.result as ArrayBuffer;

                // Converts the ArrayBuffer to a Uint8Array for easier manipulation of byte data.
                const byteArray = new Uint8Array(arrayBuffer);

                // Converts the Uint8Array to a regular array and stores it in FileBytes.
                this.FileBytes = Array.from(byteArray);
            };
            // Starts reading the file as an ArrayBuffer.
            reader.readAsArrayBuffer(file);
        }
    }

    /**
    Submits the form data to the server for uploading the selected file.
    */
    onSubmit() {
        // Validates if a file has been selected before proceeding.
        if (!this.FileBytes || !this.FileName) {
            this.ErrorMessage = "Please select a file.";
            return;
        }

        // Creates an instance of UploadFileByteArrayModel with the selected file and details.
        const uploadFileByteArrayModel = new UploadFileByteArrayModel(
            this.FileBytes,
            this.FileName,
            this.CustomFileName || "",
            this.FilePathTarget || ""
        );

        // Calls the service method to upload the file and handles the response or error.
        this.uploadFileByteArrayService
            .postUploadFileForm(uploadFileByteArrayModel)
            .subscribe(
                (response) => {
                    // Sets success message on successful upload.
                    this.Message = "File uploaded successfully!";
                    this.ErrorMessage = undefined;
                },
                (error) => {
                    console.error("Upload Error:", error);
                    // Sets error message if the upload fails.
                    this.ErrorMessage = "File upload failed. Please try again.";
                    this.Message = undefined;
                }
        );
    }
}
