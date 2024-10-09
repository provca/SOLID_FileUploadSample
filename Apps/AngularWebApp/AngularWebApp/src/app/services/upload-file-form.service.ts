import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UploadFileFormModel } from "../../app/models/upload-file-form.model";

@Injectable({
    providedIn: "root",
})
export class UploadFileFormService {
    // The API endpoint for uploading files.
    private apiUrl =
        "https://localhost:5001/api/UploadFileFormModel/UploadFile";

    /**
    Uploads a file to the server using the provided model data.
    @param uploadFileFormModel The model containing file information, custom name, and target path.
    @returns An Observable with the server response, indicating success or failure.
    */
    constructor(private http: HttpClient) {}

    postUploadFileForm(uploadFileFormModel: UploadFileFormModel
    ): Observable<any> {
        // Creates a new FormData object to structure the file data for the POST request.
        const formData = new FormData();

        // Appends the file and additional data to the form payload.
        formData.append("FormFile", uploadFileFormModel.FormFile);
        formData.append("FormName", uploadFileFormModel.FileName);
        formData.append("CustomFileName", uploadFileFormModel.CustomFileName);
        formData.append("FilePathTarget", uploadFileFormModel.FilePathTarget);

        // Sends a POST request to the API with the form data.
        return this.http.post(this.apiUrl, formData, { responseType: "text" });
    }
}
