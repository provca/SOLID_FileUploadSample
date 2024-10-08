import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { UploadFileByteArrayComponent } from "./components/upload-file-byte-array/upload-file-byte-array.component";

@NgModule({
    declarations: [AppComponent, HomeComponent, UploadFileByteArrayComponent],
    imports: [BrowserModule, AppRoutingModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
