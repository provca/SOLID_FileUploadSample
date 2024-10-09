import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UploadFileByteArrayModel } from "../../app/models/upload-file-byte-array.model";

@Injectable({
    providedIn: "root",
})
export class UploadFileByteArrayService {
    // The API endpoint for uploading files.
    private apiUrl =
        "https://localhost:5001/api/UploadFileByteArray/UploadFile";

    /**
    Uploads a file to the server using the provided model data.
    @param uploadFileByteArrayModel The model containing file information, custom name, and target path.
    @returns An Observable with the server response, indicating success or failure.
    */
    constructor(private http: HttpClient) {}

    postUploadFileForm(uploadFileByteArrayModel: UploadFileByteArrayModel
    ): Observable<any> {
        // Sends a POST request to the API with the form data.
        return this.http.post(this.apiUrl, uploadFileByteArrayModel, {
            headers: { "Content-Type": "application/json" },
        });
    }
}
