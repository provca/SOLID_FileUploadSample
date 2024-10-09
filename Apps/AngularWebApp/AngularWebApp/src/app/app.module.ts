import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { UploadFileFormComponent } from "././components/upload-file-form/upload-file-form.component";

@NgModule({
    declarations: [AppComponent, HomeComponent, UploadFileFormComponent],
    imports: [BrowserModule, FormsModule, HttpClientModule, AppRoutingModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
