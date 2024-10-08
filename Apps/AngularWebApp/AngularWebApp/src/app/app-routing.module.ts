import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
//import { AppComponent } from "./app.component";
import { HomeComponent } from "./components/home/home.component";
import { UploadFileByteArrayComponent } from "./components/upload-file-byte-array/upload-file-byte-array.component";



const routes: Routes = [
    { path: "", redirectTo: "/home", pathMatch: "full" },
    { path: "home", component: HomeComponent },
    { path: "uploadfile", component: UploadFileByteArrayComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
